using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace MSP430_BSLprog
{
   
    public partial class MainForm : Form
    {
        BSLWorker worker;
        BSLDevice actualDevice;

        List<BSLDevice> devices = new List<BSLDevice>();


        const string DeviceFilename = "devices.ini";

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            worker = new BSLWorker(serialPort1);
            worker.OnLogRequest += worker_OnLogRequest;
            worker.OnFlashProcExit += worker_OnFlashProcExit;
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="reason"></param>
        private void worker_OnFlashProcExit(object sender, string reason)
        {
            if (reason == "")
            {
                AddLogText("Done");
            }
            else
            {
                AddLogText(reason);
            }

            if (buttonFlashMAIN.InvokeRequired)
            {
                buttonFlashMAIN.Invoke(new Action(() =>
                    {
                        buttonFlashALL.Enabled = true;
                        buttonFlashMAIN.Enabled = true;
                    }
                ));
            }
            else
            {
                buttonFlashALL.Enabled = true;
                buttonFlashMAIN.Enabled = true;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="text"></param>
        private void worker_OnLogRequest(object sender, string text)
        {
            if (textBoxLog.InvokeRequired)
            {
                textBoxLog.Invoke(new Action(() => AddLogText(text)));
            }
            else
            {
                AddLogText(text);
            }
        }


        /// <summary>
        /// Thread safe text append
        /// </summary>
        /// <param name="text"></param>
        private void AddLogText(string text)
        {
            if (textBoxLog.InvokeRequired)
            {
                textBoxLog.Invoke(new Action(() => AddLogText(text)));
            }
            else
            {
                text = DateTime.Now.ToLongTimeString() + " - " + text + System.Environment.NewLine;
                textBoxLog.AppendText(text);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="buff"></param>
        private void AddLogText(byte [] buff)
        {
            string s = DateTime.Now.ToLongTimeString() + " - ";

            for (int i = 0; i < buff.Length; i++)
            {
                s += buff[i].ToString("X2") + " ";
            }

            AddLogText(s);
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        void OpenFirmware(string filename)
        {
            
            worker.Segments.Clear();


            using (StreamReader trd = new StreamReader(filename))
            {
                Segment seg = null;

                string s = trd.ReadToEnd();

                //Remove all but hexadecimal numbers and "@" char
                s =  Regex.Replace(s,"[^0-9A-F@]","",RegexOptions.IgnoreCase);

                //First segment address shoud be on the begining of the file
                if (s[0] != '@') throw new Exception();

                //index inside text file
                int i = 0;
                //index inside segment
                int j = 0;

                while (i < s.Length)
                {
                    //if next bytes are address of new segment
                    if (s[i] == '@')
                    {
                        //If this segment is not first
                        if (seg != null)
                        {
                            worker.Segments.Add(seg);
                        }

                        //Create new segment and init segment indexer
                        seg = new Segment();
                        j = 0;
                        i++;

                        //Extract 4 byte address
                        string addr = s.Substring(i, 4);
                        i += 4;

                        //Length based on next address index or end of file
                        int len = s.IndexOf('@', i) - i;
                        if (len < 0) len = s.Length - i;

                        //Byte size in text is 2 chars
                        len = len / 2;

                        //Init segment with obtained data
                        seg.addr = int.Parse(addr, System.Globalization.NumberStyles.HexNumber);
                        seg.data = new byte[len];
                    }

                    if (seg != null)
                    {
                        seg.data[j++] = byte.Parse(s.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
                        i += 2;
                    }
                }

                //Add last segment into firmware segments
                if (seg != null) worker.Segments.Add(seg);

            }


            
            listBoxSegments.Items.Clear();

            foreach (Segment seg in worker.Segments)
            {
                listBoxSegments.Items.Add(seg.addr.ToString("X4"));
            }
        }



        
        /// <summary>
        /// 
        /// </summary>
        private void OpenFirmwareDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "MSP430 firmware file (*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OpenFirmware(ofd.FileName);

                    textBoxFirmwareFilename.Text = Path.GetFileName(ofd.FileName);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Cannot read file from disk. Original error: " + ex.Message);
                }
            }
        }


        /// <summary>
        /// Loads devices from devices.ini file and filling up the comboBox for choosing device to work with
        /// </summary>
        private void FillDevicesList()
        {

            comboBoxDevices.Items.Clear();

            if (File.Exists(DeviceFilename))
            {
                devices.Clear();

                using (StreamReader sr = new StreamReader(DeviceFilename))
                {
                    string line;
                    int addr;
                    int baudrate;
                    string name;

                    while (sr.EndOfStream == false)
                    {
                        line = sr.ReadLine().Trim();

                        if (line.StartsWith("//")) continue; //ignore comment lines

                        var arr = line.Split(';');
                        if (arr.Length >= 3)
                        {
                            if ((int.TryParse(arr[1], out baudrate)) &&
                                (int.TryParse(arr[2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out addr)))
                            {
                                name = arr[0];
                                devices.Add(new BSLDevice(name, addr, baudrate));
                            }
                        }
                    }
                }

                comboBoxDevices.Items.AddRange(devices.ToArray());
            }

            comboBoxDevices.Items.Add("Custom");
            comboBoxDevices.SelectedIndex = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            var sortedList = ports.OrderBy(port => Convert.ToInt32(port.Replace("COM", string.Empty)));

            comboBoxPort.Items.Clear();

            foreach (string port in sortedList)
            {
                comboBoxPort.Items.Add(port);
            }

            if (comboBoxPort.Items.Count > 0)
            {
                comboBoxPort.SelectedIndex = 0;
            }

            comboBoxBaudrate.SelectedText = "9600";

            comboBoxDebugCommand.SelectedIndex = 0;


            FillDevicesList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFlashMAIN_Click(object sender, EventArgs e)
        {
            buttonFlashALL.Enabled = false;
            buttonFlashMAIN.Enabled = false;

            int mainSegStart = int.Parse(textBoxMainSegStart.Text, NumberStyles.HexNumber);

            worker.BSL_password = StringToByteArray(textBoxBSLPass.Text);
            Task t = new Task(() => worker.FlashMainProc(mainSegStart));
            t.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFlashALL_Click(object sender, EventArgs e)
        {
            buttonFlashALL.Enabled = false;
            buttonFlashMAIN.Enabled = false;

            worker.BSL_password = StringToByteArray(textBoxBSLPass.Text);
            Task t = new Task(() => worker.FlashAllProc());
            t.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFirmwareLoad_Click(object sender, EventArgs e)
        {
            OpenFirmwareDialog();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxSegments_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxFirmwareCode.Text = "";

            string ss = (string)listBoxSegments.SelectedItem;

            Segment selseg = worker.Segments.FirstOrDefault( x => x.addr.ToString("X4") == ss);
           
            if (selseg != null)
            {
                string s = "";

                int newline_cnt = 0;

                s = selseg.addr.ToString("X4") + " ";

                for (int i = 0; i < selseg.data.Count(); i++ )
                {

                    s += selseg.data[i].ToString("X2");

                    if (i + 1 < selseg.data.Count())
                    {
                        newline_cnt++;
                        if (newline_cnt >= 16)
                        {
                            newline_cnt = 0;
                            s += System.Environment.NewLine + (selseg.addr + i + 1).ToString("X4") + " ";
                        }
                    }
                }

                textBoxFirmwareCode.Text = s;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int baud = 0;
            if (int.TryParse((string)comboBoxBaudrate.SelectedItem, out baud))
            {
                serialPort1.BaudRate = baud;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = (string)comboBoxPort.SelectedItem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxInvertRESET_CheckedChanged(object sender, EventArgs e)
        {
            worker.InvertRESET = checkBoxInvertRESET.Checked;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxInvertTEST_CheckedChanged(object sender, EventArgs e)
        {
            worker.InvertTEST = checkBoxInvertTEST.Checked;
        }

   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDebugSend_Click(object sender, EventArgs e)
        {
            string s_cmnd = (string)comboBoxDebugCommand.SelectedItem;
            byte AH, AL, LH, LL;
            byte[] data;

            BSLCommand cmnd = (BSLCommand)Enum.Parse(typeof(BSLCommand), s_cmnd);

            int addr = int.Parse(textBoxDebugAddr.Text, NumberStyles.HexNumber);
            int length = int.Parse(textBoxDebugLen.Text, NumberStyles.HexNumber);

            AL = (byte)(addr & 0xFF);
            AH = (byte)((addr & 0xFF00) / 256);

            LL = (byte)(length & 0xFF);
            LH = (byte)((length & 0xFF00) / 256);

            data = StringToByteArray(textBoxDebugData.Text);
            
            worker.SendBSLCommand(cmnd,0,0,AL,AH,LL,LH,data);
        }


        /// <summary>
        /// Delitious Stackoverflow copypasta, mmmm yummy
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDebugStartBSL_Click(object sender, EventArgs e)
        {
            worker.StartBSL();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDebugReset_Click(object sender, EventArgs e)
        {
            worker.RestartMCU();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWorkerStop_Click(object sender, EventArgs e)
        {
            worker.Stop();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadBSLPass_Click(object sender, EventArgs e)
        {
            string s = "";
           
            byte[] data = new byte[32];

            for (int i = 0; i < 32; i++) data[i] = 0xFF;

            foreach (Segment seg in worker.Segments)
            {
                var segend = seg.addr + seg.data.Count() - 1;

                if (segend > 0xFFE0)
                {
                    
                    int addr = seg.addr;
                    int i = 0;

                    while (addr <= segend)
                    {
                        if (addr >= 0xFFE0)
                        {
                            data[addr - 0xFFE0] = seg.data[i];
                        }

                        i++;
                        addr++;
                    }
                 }
            }



            for (int i = 0; i < 32; i++) s += data[i].ToString("X2");

            textBoxBSLPass.Text = s;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBlankBSLPass_Click(object sender, EventArgs e)
        {
            string s = "";

            byte[] data = new byte[32];

            for (int i = 0; i < 32; i++) data[i] = 0xFF;

            for (int i = 0; i < 32; i++) s += data[i].ToString("X2");

            textBoxBSLPass.Text = s;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxDevices_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ComboBox))
            {
                
                if (comboBoxDevices.SelectedItem.GetType() == typeof(string))
                {
                    textBoxMainSegStart.ReadOnly = false;
                }
                else if (comboBoxDevices.SelectedItem.GetType() == typeof(BSLDevice))
                {
                    textBoxMainSegStart.ReadOnly = true;

                    actualDevice = (BSLDevice)comboBoxDevices.SelectedItem;
                    textBoxMainSegStart.Text = actualDevice.Mainseg_address.ToString("X4");
                }
                else
                {
                    //This should not happend
                }
            }
            else
            {
                //This should not happend too, I guess :)
            }
        }

       
    }
}
