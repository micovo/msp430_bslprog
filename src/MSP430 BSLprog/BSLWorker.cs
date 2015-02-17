using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.IO.Ports;

namespace MSP430_BSLprog
{
    public enum BSLCommand
    {
        RX_data_block,
        RX_password,
        Erase_segment,
        Erase_main_or_info,
        Mass_erase,
        Erase_check,
        Change_baud_rate,
        Set_mem_offset,
        Load_PC,
        TX_data_block,
        TX_BSL_version
    }


    class Segment
    {
        public byte[] data;
        public int addr;
        public bool enabled;

        public Segment()
        {
            enabled = true;
        }
    }


    class BSLWorker
    {
        #region Constants
        const int SyncTickTime = 50;

        #endregion

        #region Public Variables

        public List<Segment> Segments = new List<Segment>();
        public byte[] BSL_password;

        #endregion

        #region Private Variables

        SerialPort serialPort1;

        private bool StopRequested;

        #endregion

        #region Properties
        bool failed;
        public bool Failed
        {
            set { failed = value; }
            get { return failed; }
        }


        int progress;
        public int Progress
        {
            get { return progress; }
        }


        private bool invertRESET;
        public bool InvertRESET
        {
            get { return invertRESET; }
            set { invertRESET = value; }
        }

        private bool invertTEST;
        public bool InvertTEST
        {
            get { return invertTEST; }
            set { invertTEST = value; }
        }


        #endregion


        #region Delegates
        public delegate void EventHandler(object sender, string reason);
        public event EventHandler OnFlashProcExit;
        protected void FlashProcExit(object sender, string reason = "")
        {
            if (OnFlashProcExit != null)
            {
                OnFlashProcExit(sender, reason);
            }
        }


        public delegate void LogHandler(object sender, string text);
        public event LogHandler OnLogRequest;
        protected void LogRequest(object sender, string reason = "")
        {
            if (OnLogRequest != null)
            {
                OnLogRequest(sender, reason);
            }
        }
        #endregion



        /// <summary>
        /// 
        /// </summary>
        /// <param name="serialPort1"></param>
        public BSLWorker(SerialPort serialPort1)
        {
            progress = 0;
            this.serialPort1 = serialPort1;

            invertRESET = false;
            invertTEST = false;

        }



        /// <summary>
        /// 
        /// </summary>
        public void SetRESET()
        {
            serialPort1.DtrEnable = invertRESET;   
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearRESET()
        {
            serialPort1.DtrEnable = !invertRESET;   
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetTEST()
        {
            serialPort1.RtsEnable = invertRESET;   
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearTEST()
        {
            serialPort1.RtsEnable = !invertRESET;   
        }



        /// <summary>
        /// 
        /// Implementation od Figure 1-2. BSL Entry Sequence at Shared JTAG Pins 
        /// http://www.ti.com/lit/ug/slau319i/slau319i.pdf
        /// 
        /// </summary>
        public void StartBSL()
        {
            if (serialPort1.IsOpen == false)
            {
                serialPort1.Open();
            }

            ClearTEST();
            ClearRESET();
            Thread.Sleep(SyncTickTime);

            SetTEST();
            Thread.Sleep(SyncTickTime);

            ClearTEST();
            Thread.Sleep(SyncTickTime);
            Thread.Sleep(SyncTickTime);

            SetTEST();
            Thread.Sleep(SyncTickTime);

            SetRESET();
            Thread.Sleep(SyncTickTime);

            ClearTEST();
        }


        /// <summary>
        /// 
        /// </summary>
        public void RestartMCU()
        {
            if (serialPort1.IsOpen == false)
            {
                serialPort1.Open();
            }

            ClearTEST();
            ClearRESET();
            Thread.Sleep(SyncTickTime);

            SetRESET();
            Thread.Sleep(SyncTickTime);
        }



        private bool SerialPortOpenProc()
        {
            if (serialPort1.IsOpen == false)
            {
                try
                {
                    serialPort1.Open();
                }
                catch (Exception ex)
                {
                    OnLogRequest(this,"Cannot open serial port");
                    OnLogRequest(this, ex.Message);
                }


            }
            return serialPort1.IsOpen;
        }


        /// <summary>
        /// 
        /// </summary>
        public void FlashMainProc(int main_seg_start)
        {
            SerialPortOpenProc();

            int addr;
            byte AH, AL;

            string s = "";
            byte len;
            byte[] data;

            serialPort1.ReadTimeout = 250;
            this.failed = false;
            StopRequested = false;

            progress = 0;



            LogRequest(this, "Starting BSL");
            StartBSL();

            Thread.Sleep(1000);

            serialPort1.ReadExisting();
            
            SendBSLCommand(BSLCommand.RX_password, 0, 0, 0, 0, 0, 0, BSL_password);

            addr = main_seg_start;
            AL = (byte)(addr & 0xFF);
            AH = (byte)((addr & 0xFF00) / 256);

            SendBSLCommand(BSLCommand.Erase_main_or_info, 0, 0, AL, AH, 0x02, 0xA5, null);

            return;


            len = 128;
            data = new byte[len];

            foreach (Segment seg in Segments)
            {
                if (seg.addr <= main_seg_start)
                {
                    int i = 0;
                    addr = seg.addr;
                    len = 128;
                    data = new byte[len];



                    while (i < seg.data.Count())
                    {
                        if (StopRequested)
                        {
                            break;
                        }

                        if ((i + len) > seg.data.Count())
                        {
                            len = (byte)(seg.data.Count() - i);
                            data = new byte[len];
                        }

                        AL = (byte)(addr & 0xFF);
                        AH = (byte)((addr & 0xFF00) / 256);

                        bool skipwrite = true;

                        for (int x = 0; x < len; x++)
                        {
                            data[x] = seg.data[i++];
                            if (data[x] != 0xFF) skipwrite = false;
                        }


                        if (skipwrite == false)
                        {
                            string debug = "Write @ " + addr.ToString("X4") + System.Environment.NewLine;

                            int newline_cnt = 0;

                            for (int x = 0; x < len; x++)
                            {
                                debug += data[x].ToString("X2") + " ";

                                newline_cnt++;
                                if (newline_cnt >= 16)
                                {
                                    newline_cnt = 0;
                                    debug += System.Environment.NewLine;
                                }
                            }

                            debug = debug.Trim();
                            OnLogRequest(this, debug);


                            SendBSLCommand(BSLCommand.RX_data_block, (byte)(len + 4), (byte)(len + 4), (byte)AL, (byte)AH, len, len, data);

                        }

                        addr += len;

                    }
                }

            }


            FlashProcExit(this);

            serialPort1.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        public void FlashAllProc()
        {
            if ( (BSL_password == null) || (BSL_password.Count() != 32))
            {
                FlashProcExit(this, "BSL password is not set");
                return;
            }

            SerialPortOpenProc();



            string s = "";
            byte len;
            byte[] data;

            serialPort1.ReadTimeout = 250;
            this.failed = false;
            StopRequested = false;

            progress = 0;



            LogRequest(this, "Starting BSL");
            StartBSL();

            Thread.Sleep(1000);

            serialPort1.ReadExisting();

            SendBSLCommand(BSLCommand.Mass_erase, 0, 0, 0, 0, 0, 0, null);


            SendBSLCommand(BSLCommand.RX_password, 0, 0, 0, 0, 0, 0, BSL_password);


            len = 128;
            data = new byte[len];

            foreach (Segment seg in Segments)
            {
                //if (seg.enabled)
                {
                    int i = 0;
                    int addr = seg.addr;
                    len = 128;
                    data = new byte[len];


                    
                    while (i < seg.data.Count())
                    {
                        if (StopRequested)
                        {
                            break;
                        }

                        if ((i + len) > seg.data.Count())
                        {
                            len = (byte)(seg.data.Count() - i);
                            data = new byte[len];
                        }

                        var AL = addr & 0xFF;
                        var AH = (addr & 0xFF00) / 256;

                        bool skipwrite = true;

                        for (int x = 0; x < len; x++)
                        {
                            data[x] = seg.data[i++];
                            if (data[x] != 0xFF) skipwrite = false;
                        }


                        if (skipwrite == false)
                        {
                            string debug = "Write @ " + addr.ToString("X4") + System.Environment.NewLine;

                            int newline_cnt = 0;

                            for (int x = 0; x < len; x++)
                            {
                                debug += data[x].ToString("X2") + " ";

                                newline_cnt++;
                                if (newline_cnt >= 16)
                                {
                                    newline_cnt = 0;
                                    debug += System.Environment.NewLine;
                                }
                            }

                            debug = debug.Trim();
                            OnLogRequest(this, debug);


                            SendBSLCommand(BSLCommand.RX_data_block, (byte)(len + 4), (byte)(len + 4), (byte)AL, (byte)AH, len, len, data);

                        }

                        addr += len;

                    }
                }

            }


            FlashProcExit(this);

            serialPort1.Close();
        }



        public void Stop()
        {
            serialPort1.Close();
            StopRequested = true;
            progress = 0;
            FlashProcExit(this, "Stop requested");
        }




        /// <summary>
        /// 
        /// </summary>
        public void SendBSLSync()
        {
            LogRequest(this, "Sync");

            byte[] buff = new byte[1];
            buff[0] = 0x80;

            serialPort1.Write(buff, 0, 1);
            
            Thread.Sleep(50);

            GetBSLResponce();

            Thread.Sleep(50);
        }




        /// <summary>
        /// 
        /// </summary>
        private void GetBSLResponce()
        {
            if (serialPort1.IsOpen == false) return;

            int resp = 0x100;


            if (serialPort1.BytesToRead > 0)
            {
                byte [] buff = new byte[serialPort1.BytesToRead];

                try
                {
                   serialPort1.Read(buff, 0, serialPort1.BytesToRead);
                   resp = buff[0];
                }
                catch (TimeoutException ex)
                {
                    resp = 0x100;
                }
                catch (Exception ex)
                {
                    resp = 0x200;
                }
            }
            

            if (resp == 0x90)
            {
                LogRequest(this, "OK");
            }
            else if (resp == 0x100)
            {
                LogRequest(this, "No responce");
            }
            else if (resp == 0x200)
            {
                LogRequest(this, "Unhandled exception");
            }
            else
            {
                LogRequest(this, "Error (0x" + resp.ToString("X2") + ")");
            }
        }




        /*

        void cmnd_RX_data_block(int addr, byte[] data)
        {

        }

        void cmnd_RX_password(byte[] pass)
        {

        }

        void cmnd_Erase_segment(int address)
        {

        }

        void cmnd_Erase_main_or_info(int address)
        {

        }


        void cmnd_Mass_erase()
        {

        }


        void cmnd_Erase_check(int address, int length)
        {

        }


        void cmnd_Change_baud_rate(int address, int baudrate)
        {

        }

        void cmnd_Set_mem_offser(int address)
        {

        }

        void cmnd_Load_PC(int address)
        {

        }

        */
        





        /// <summary>
        /// 
        /// 
        /// Bootstrap Loader Protocol – 1xx, 2xx, and 4xx Families
        /// http://www.ti.com/lit/ug/slau319i/slau319i.pdf
        /// 
        /// </summary>
        /// <param name="cmnd"></param>
        /// <param name="L1"></param>
        /// <param name="L2"></param>
        /// <param name="AL"></param>
        /// <param name="AH"></param>
        /// <param name="LL"></param>
        /// <param name="LH"></param>
        /// <param name="data"></param>
        public void SendBSLCommand(BSLCommand cmnd, byte L1, byte L2, byte AL, byte AH, byte LL, byte LH, byte[] data)
        {
            if (serialPort1.IsOpen == false)
            {
                serialPort1.Open();
            }

            SendBSLSync();


            int delay = 50;
            int i = 0;

            byte[] buff = new byte[256];


            buff[i++] = 0x80; //HDR

            switch (cmnd)
            {
                case BSLCommand.RX_data_block:
                    delay = 250;
                    LogRequest(this, "Writing");
                    buff[i++] = 0x12;
                    buff[i++] = L1;
                    buff[i++] = L2;
                    buff[i++] = AL;
                    buff[i++] = AH;
                    buff[i++] = LL;
                    buff[i++] = 0;
                    data.CopyTo(buff, i);
                    i += LL;
                    break;
                case BSLCommand.RX_password:
                    delay = 1000;
                    LogRequest(this, "BSL Pass");
                    buff[i++] = 0x10;
                    buff[i++] = 0x24;
                    buff[i++] = 0x24;
                    buff[i++] = 0;
                    buff[i++] = 0;
                    buff[i++] = 0;
                    buff[i++] = 0;
                    data.CopyTo(buff, i);
                    i += data.Length;
                    break;
                case BSLCommand.Erase_segment:
                    delay = 1000;
                    LogRequest(this, "Erase segment " + AH.ToString("X2") + AL.ToString("X2"));
                    buff[i++] = 0x16;
                    buff[i++] = 0x4;
                    buff[i++] = 0x4;
                    buff[i++] = AL;
                    buff[i++] = AH;
                    buff[i++] = 0x02;
                    buff[i++] = 0xA5;
                    break;
                case BSLCommand.Erase_main_or_info:
                    delay = 1000;
                    LogRequest(this, "Erase main or info " + AH.ToString("X2") + AL.ToString("X2"));

                    buff[i++] = 0x16;
                    buff[i++] = 0x4;
                    buff[i++] = 0x4;
                    buff[i++] = AL;
                    buff[i++] = AH;
                    buff[i++] = 0x04;
                    buff[i++] = 0xA5;
                    break;
                case BSLCommand.Mass_erase:
                    delay = 1000;
                    LogRequest(this, "Mass erase");
                    buff[i++] = 0x18;
                    buff[i++] = 0x4;
                    buff[i++] = 0x4;
                    buff[i++] = 0;
                    buff[i++] = 0;
                    buff[i++] = 0x06;
                    buff[i++] = 0xA5;
                    break;
                case BSLCommand.Erase_check:
                    buff[i++] = 0x1C;
                    buff[i++] = 0x4;
                    buff[i++] = 0x4;
                    buff[i++] = AL;
                    buff[i++] = AH;
                    buff[i++] = LL;
                    buff[i++] = LH;
                    break;
                case BSLCommand.Change_baud_rate:
                    buff[i++] = 0x20;
                    buff[i++] = 0x4;
                    buff[i++] = 0x4;
                    buff[i++] = AL;
                    buff[i++] = AH;
                    buff[i++] = LL;
                    buff[i++] = 0;
                    break;
                case BSLCommand.Set_mem_offset:
                    buff[i++] = 0x21;
                    buff[i++] = 0x4;
                    buff[i++] = 0x4;
                    buff[i++] = 0;
                    buff[i++] = 0;
                    buff[i++] = AL;
                    buff[i++] = AH;
                    break;
                case BSLCommand.Load_PC:
                    buff[i++] = 0x1A;
                    buff[i++] = 0x4;
                    buff[i++] = 0x4;
                    buff[i++] = AL;
                    buff[i++] = AH;
                    buff[i++] = 0;
                    buff[i++] = 0;
                    break;
                case BSLCommand.TX_data_block:
                    buff[i++] = 0x14;
                    buff[i++] = 0x4;
                    buff[i++] = 0x4;
                    buff[i++] = AL;
                    buff[i++] = AH;
                    buff[i++] = LL;
                    buff[i++] = 0;
                    break;
                case BSLCommand.TX_BSL_version:
                    buff[i++] = 0x1E;
                    buff[i++] = 0x4;
                    buff[i++] = 0x4;
                    buff[i++] = 0;
                    buff[i++] = 0;
                    buff[i++] = 0;
                    buff[i++] = 0;
                    break;
                default:
                    break;
            }




            byte checksum_low = 0;
            byte checksum_high = 0;

            for (int j = 0; j < i; )
            {
                checksum_low ^= buff[j++];
                checksum_high ^= buff[j++];
            }

            checksum_high = (byte)~checksum_high;
            checksum_low = (byte)~checksum_low;


            buff[i++] = checksum_low;
            buff[i++] = checksum_high;

            serialPort1.Write(buff, 0, i);
            
            Thread.Sleep(delay);

            GetBSLResponce();
            
            

            Thread.Sleep(100);
        }
    }
}
