namespace MSP430_BSLprog
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBoxSerial = new System.Windows.Forms.GroupBox();
            this.checkBoxInvertTEST = new System.Windows.Forms.CheckBox();
            this.checkBoxInvertRESET = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFirmwareFilename = new System.Windows.Forms.TextBox();
            this.buttonFirmwareLoad = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFirmwareCode = new System.Windows.Forms.TextBox();
            this.listBoxSegments = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxMainSegStart = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonLoadBSLPass = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxBSLPass = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonWorkerStop = new System.Windows.Forms.Button();
            this.buttonFlashMAIN = new System.Windows.Forms.Button();
            this.buttonFlashALL = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonDebugReset = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxDebugData = new System.Windows.Forms.TextBox();
            this.buttonDebugSend = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxDebugLen = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxDebugAddr = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxDebugCommand = new System.Windows.Forms.ComboBox();
            this.buttonDebugStartBSL = new System.Windows.Forms.Button();
            this.buttonBlankBSLPass = new System.Windows.Forms.Button();
            this.groupBoxSerial.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxLog.Location = new System.Drawing.Point(563, 19);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(10);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(373, 572);
            this.textBoxLog.TabIndex = 3;
            // 
            // serialPort1
            // 
            this.serialPort1.Parity = System.IO.Ports.Parity.Even;
            this.serialPort1.PortName = "COM2";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 609);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(955, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBoxSerial
            // 
            this.groupBoxSerial.Controls.Add(this.checkBoxInvertTEST);
            this.groupBoxSerial.Controls.Add(this.checkBoxInvertRESET);
            this.groupBoxSerial.Controls.Add(this.label2);
            this.groupBoxSerial.Controls.Add(this.comboBoxBaudrate);
            this.groupBoxSerial.Controls.Add(this.label1);
            this.groupBoxSerial.Controls.Add(this.comboBoxPort);
            this.groupBoxSerial.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSerial.Name = "groupBoxSerial";
            this.groupBoxSerial.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxSerial.Size = new System.Drawing.Size(181, 137);
            this.groupBoxSerial.TabIndex = 8;
            this.groupBoxSerial.TabStop = false;
            this.groupBoxSerial.Text = "Serial Port";
            // 
            // checkBoxInvertTEST
            // 
            this.checkBoxInvertTEST.AutoSize = true;
            this.checkBoxInvertTEST.Location = new System.Drawing.Point(31, 103);
            this.checkBoxInvertTEST.Name = "checkBoxInvertTEST";
            this.checkBoxInvertTEST.Size = new System.Drawing.Size(115, 17);
            this.checkBoxInvertTEST.TabIndex = 5;
            this.checkBoxInvertTEST.Text = "Invert TEST (RTS)";
            this.checkBoxInvertTEST.UseVisualStyleBackColor = true;
            this.checkBoxInvertTEST.CheckedChanged += new System.EventHandler(this.checkBoxInvertTEST_CheckedChanged);
            // 
            // checkBoxInvertRESET
            // 
            this.checkBoxInvertRESET.AutoSize = true;
            this.checkBoxInvertRESET.Location = new System.Drawing.Point(31, 80);
            this.checkBoxInvertRESET.Name = "checkBoxInvertRESET";
            this.checkBoxInvertRESET.Size = new System.Drawing.Size(124, 17);
            this.checkBoxInvertRESET.TabIndex = 4;
            this.checkBoxInvertRESET.Text = "Invert RESET (DTR)";
            this.checkBoxInvertRESET.UseVisualStyleBackColor = true;
            this.checkBoxInvertRESET.CheckedChanged += new System.EventHandler(this.checkBoxInvertRESET_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baudrate";
            // 
            // comboBoxBaudrate
            // 
            this.comboBoxBaudrate.FormattingEnabled = true;
            this.comboBoxBaudrate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200",
            ""});
            this.comboBoxBaudrate.Location = new System.Drawing.Point(79, 47);
            this.comboBoxBaudrate.Name = "comboBoxBaudrate";
            this.comboBoxBaudrate.Size = new System.Drawing.Size(89, 21);
            this.comboBoxBaudrate.TabIndex = 2;
            this.comboBoxBaudrate.SelectedIndexChanged += new System.EventHandler(this.comboBoxBaudrate_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port";
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(78, 20);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(90, 21);
            this.comboBoxPort.TabIndex = 0;
            this.comboBoxPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxPort_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxFirmwareFilename);
            this.groupBox1.Controls.Add(this.buttonFirmwareLoad);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxFirmwareCode);
            this.groupBox1.Controls.Add(this.listBoxSegments);
            this.groupBox1.Location = new System.Drawing.Point(12, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(538, 221);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Firmware";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Filename";
            // 
            // textBoxFirmwareFilename
            // 
            this.textBoxFirmwareFilename.Enabled = false;
            this.textBoxFirmwareFilename.Location = new System.Drawing.Point(14, 41);
            this.textBoxFirmwareFilename.Name = "textBoxFirmwareFilename";
            this.textBoxFirmwareFilename.Size = new System.Drawing.Size(120, 20);
            this.textBoxFirmwareFilename.TabIndex = 8;
            // 
            // buttonFirmwareLoad
            // 
            this.buttonFirmwareLoad.Location = new System.Drawing.Point(14, 67);
            this.buttonFirmwareLoad.Name = "buttonFirmwareLoad";
            this.buttonFirmwareLoad.Size = new System.Drawing.Size(120, 23);
            this.buttonFirmwareLoad.TabIndex = 7;
            this.buttonFirmwareLoad.Text = "Load";
            this.buttonFirmwareLoad.UseVisualStyleBackColor = true;
            this.buttonFirmwareLoad.Click += new System.EventHandler(this.buttonFirmwareLoad_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Segments";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Code";
            // 
            // textBoxFirmwareCode
            // 
            this.textBoxFirmwareCode.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxFirmwareCode.Location = new System.Drawing.Point(152, 41);
            this.textBoxFirmwareCode.Multiline = true;
            this.textBoxFirmwareCode.Name = "textBoxFirmwareCode";
            this.textBoxFirmwareCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxFirmwareCode.Size = new System.Drawing.Size(373, 167);
            this.textBoxFirmwareCode.TabIndex = 4;
            // 
            // listBoxSegments
            // 
            this.listBoxSegments.FormattingEnabled = true;
            this.listBoxSegments.Location = new System.Drawing.Point(13, 126);
            this.listBoxSegments.Name = "listBoxSegments";
            this.listBoxSegments.Size = new System.Drawing.Size(120, 82);
            this.listBoxSegments.TabIndex = 0;
            this.listBoxSegments.SelectedIndexChanged += new System.EventHandler(this.listBoxSegments_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBoxMainSegStart);
            this.groupBox2.Location = new System.Drawing.Point(199, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(199, 49);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Main segment start";
            // 
            // textBoxMainSegStart
            // 
            this.textBoxMainSegStart.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxMainSegStart.Location = new System.Drawing.Point(134, 20);
            this.textBoxMainSegStart.MaxLength = 4;
            this.textBoxMainSegStart.Name = "textBoxMainSegStart";
            this.textBoxMainSegStart.Size = new System.Drawing.Size(52, 20);
            this.textBoxMainSegStart.TabIndex = 9;
            this.textBoxMainSegStart.Text = "C000";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.buttonBlankBSLPass);
            this.groupBox3.Controls.Add(this.buttonLoadBSLPass);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBoxBSLPass);
            this.groupBox3.Location = new System.Drawing.Point(12, 507);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(538, 84);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Security";
            // 
            // buttonLoadBSLPass
            // 
            this.buttonLoadBSLPass.Location = new System.Drawing.Point(203, 50);
            this.buttonLoadBSLPass.Name = "buttonLoadBSLPass";
            this.buttonLoadBSLPass.Size = new System.Drawing.Size(120, 23);
            this.buttonLoadBSLPass.TabIndex = 12;
            this.buttonLoadBSLPass.Text = "Load from Firmware";
            this.buttonLoadBSLPass.UseVisualStyleBackColor = true;
            this.buttonLoadBSLPass.Click += new System.EventHandler(this.buttonLoadBSLPass_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "BSL Password";
            // 
            // textBoxBSLPass
            // 
            this.textBoxBSLPass.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxBSLPass.Location = new System.Drawing.Point(126, 24);
            this.textBoxBSLPass.MaxLength = 64;
            this.textBoxBSLPass.Name = "textBoxBSLPass";
            this.textBoxBSLPass.Size = new System.Drawing.Size(399, 20);
            this.textBoxBSLPass.TabIndex = 10;
            this.textBoxBSLPass.Text = "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF";
            this.textBoxBSLPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonWorkerStop);
            this.groupBox4.Controls.Add(this.buttonFlashMAIN);
            this.groupBox4.Controls.Add(this.buttonFlashALL);
            this.groupBox4.Location = new System.Drawing.Point(404, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox4.Size = new System.Drawing.Size(146, 137);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Actions";
            // 
            // buttonWorkerStop
            // 
            this.buttonWorkerStop.Location = new System.Drawing.Point(13, 97);
            this.buttonWorkerStop.Name = "buttonWorkerStop";
            this.buttonWorkerStop.Size = new System.Drawing.Size(120, 23);
            this.buttonWorkerStop.TabIndex = 5;
            this.buttonWorkerStop.Text = "Stop";
            this.buttonWorkerStop.UseVisualStyleBackColor = true;
            this.buttonWorkerStop.Click += new System.EventHandler(this.buttonWorkerStop_Click);
            // 
            // buttonFlashMAIN
            // 
            this.buttonFlashMAIN.Location = new System.Drawing.Point(13, 61);
            this.buttonFlashMAIN.Name = "buttonFlashMAIN";
            this.buttonFlashMAIN.Size = new System.Drawing.Size(120, 23);
            this.buttonFlashMAIN.TabIndex = 4;
            this.buttonFlashMAIN.Text = "Flash MAIN";
            this.buttonFlashMAIN.UseVisualStyleBackColor = true;
            this.buttonFlashMAIN.Click += new System.EventHandler(this.buttonFlashMAIN_Click);
            // 
            // buttonFlashALL
            // 
            this.buttonFlashALL.Location = new System.Drawing.Point(13, 26);
            this.buttonFlashALL.Name = "buttonFlashALL";
            this.buttonFlashALL.Size = new System.Drawing.Size(120, 23);
            this.buttonFlashALL.TabIndex = 3;
            this.buttonFlashALL.Text = "Flash ALL";
            this.buttonFlashALL.UseVisualStyleBackColor = true;
            this.buttonFlashALL.Click += new System.EventHandler(this.buttonFlashALL_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonDebugReset);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.textBoxDebugData);
            this.groupBox5.Controls.Add(this.buttonDebugSend);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.textBoxDebugLen);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.textBoxDebugAddr);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.comboBoxDebugCommand);
            this.groupBox5.Controls.Add(this.buttonDebugStartBSL);
            this.groupBox5.Location = new System.Drawing.Point(12, 155);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox5.Size = new System.Drawing.Size(538, 88);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Debug stuff";
            // 
            // buttonDebugReset
            // 
            this.buttonDebugReset.Location = new System.Drawing.Point(462, 49);
            this.buttonDebugReset.Name = "buttonDebugReset";
            this.buttonDebugReset.Size = new System.Drawing.Size(63, 23);
            this.buttonDebugReset.TabIndex = 13;
            this.buttonDebugReset.Text = "Reset";
            this.buttonDebugReset.UseVisualStyleBackColor = true;
            this.buttonDebugReset.Click += new System.EventHandler(this.buttonDebugReset_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Data";
            // 
            // textBoxDebugData
            // 
            this.textBoxDebugData.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxDebugData.Location = new System.Drawing.Point(73, 52);
            this.textBoxDebugData.MaxLength = 255;
            this.textBoxDebugData.Name = "textBoxDebugData";
            this.textBoxDebugData.Size = new System.Drawing.Size(383, 20);
            this.textBoxDebugData.TabIndex = 11;
            this.textBoxDebugData.Text = "FFFF";
            this.textBoxDebugData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonDebugSend
            // 
            this.buttonDebugSend.Location = new System.Drawing.Point(393, 24);
            this.buttonDebugSend.Name = "buttonDebugSend";
            this.buttonDebugSend.Size = new System.Drawing.Size(63, 23);
            this.buttonDebugSend.TabIndex = 7;
            this.buttonDebugSend.Text = "Send";
            this.buttonDebugSend.UseVisualStyleBackColor = true;
            this.buttonDebugSend.Click += new System.EventHandler(this.buttonDebugSend_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(293, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "LL:LH";
            // 
            // textBoxDebugLen
            // 
            this.textBoxDebugLen.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxDebugLen.Location = new System.Drawing.Point(335, 26);
            this.textBoxDebugLen.MaxLength = 4;
            this.textBoxDebugLen.Name = "textBoxDebugLen";
            this.textBoxDebugLen.Size = new System.Drawing.Size(47, 20);
            this.textBoxDebugLen.TabIndex = 5;
            this.textBoxDebugLen.Text = "0000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(200, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "AL:AH";
            // 
            // textBoxDebugAddr
            // 
            this.textBoxDebugAddr.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxDebugAddr.Location = new System.Drawing.Point(240, 26);
            this.textBoxDebugAddr.MaxLength = 4;
            this.textBoxDebugAddr.Name = "textBoxDebugAddr";
            this.textBoxDebugAddr.Size = new System.Drawing.Size(47, 20);
            this.textBoxDebugAddr.TabIndex = 3;
            this.textBoxDebugAddr.Text = "0000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Command";
            // 
            // comboBoxDebugCommand
            // 
            this.comboBoxDebugCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDebugCommand.FormattingEnabled = true;
            this.comboBoxDebugCommand.Items.AddRange(new object[] {
            "RX_data_block",
            "RX_password",
            "Erase_segment",
            "Erase_main_or_info",
            "Mass_erase",
            "Erase_check",
            "Change_baud_rate",
            "Set_mem_offset",
            "Load_PC",
            "TX_data_block",
            "TX_BSL_version"});
            this.comboBoxDebugCommand.Location = new System.Drawing.Point(73, 26);
            this.comboBoxDebugCommand.Name = "comboBoxDebugCommand";
            this.comboBoxDebugCommand.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDebugCommand.TabIndex = 1;
            // 
            // buttonDebugStartBSL
            // 
            this.buttonDebugStartBSL.Location = new System.Drawing.Point(462, 24);
            this.buttonDebugStartBSL.Name = "buttonDebugStartBSL";
            this.buttonDebugStartBSL.Size = new System.Drawing.Size(63, 23);
            this.buttonDebugStartBSL.TabIndex = 0;
            this.buttonDebugStartBSL.Text = "Start BSL";
            this.buttonDebugStartBSL.UseVisualStyleBackColor = true;
            this.buttonDebugStartBSL.Click += new System.EventHandler(this.buttonDebugStartBSL_Click);
            // 
            // buttonBlankBSLPass
            // 
            this.buttonBlankBSLPass.Location = new System.Drawing.Point(335, 50);
            this.buttonBlankBSLPass.Name = "buttonBlankBSLPass";
            this.buttonBlankBSLPass.Size = new System.Drawing.Size(75, 23);
            this.buttonBlankBSLPass.TabIndex = 13;
            this.buttonBlankBSLPass.Text = "Blank Pass";
            this.buttonBlankBSLPass.UseVisualStyleBackColor = true;
            this.buttonBlankBSLPass.Click += new System.EventHandler(this.buttonBlankBSLPass_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 631);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxSerial);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBoxLog);
            this.MinimumSize = new System.Drawing.Size(971, 616);
            this.Name = "MainForm";
            this.Text = "MSP430 BSPloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxSerial.ResumeLayout(false);
            this.groupBoxSerial.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLog;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBoxSerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBaudrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.CheckBox checkBoxInvertTEST;
        private System.Windows.Forms.CheckBox checkBoxInvertRESET;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFirmwareFilename;
        private System.Windows.Forms.Button buttonFirmwareLoad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFirmwareCode;
        private System.Windows.Forms.ListBox listBoxSegments;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxBSLPass;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonFlashMAIN;
        private System.Windows.Forms.Button buttonFlashALL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxMainSegStart;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxDebugCommand;
        private System.Windows.Forms.Button buttonDebugStartBSL;
        private System.Windows.Forms.Button buttonDebugSend;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxDebugLen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxDebugAddr;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxDebugData;
        private System.Windows.Forms.Button buttonDebugReset;
        private System.Windows.Forms.Button buttonWorkerStop;
        private System.Windows.Forms.Button buttonLoadBSLPass;
        private System.Windows.Forms.Button buttonBlankBSLPass;
    }
}

