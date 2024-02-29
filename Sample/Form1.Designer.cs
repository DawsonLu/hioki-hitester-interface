namespace Interface
{
    partial class Form1
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
            this.Label6 = new System.Windows.Forms.Label();
            this.timeoutTextbox = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.portTextbox = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.transmitAndRecieve = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.consoleTextbox = new System.Windows.Forms.TextBox();
            this.commandTextbox = new System.Windows.Forms.TextBox();
            this.ipTextbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.clearRecord = new System.Windows.Forms.Button();
            this.recordLog = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.manualNext = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.secIntervalNumeric = new System.Windows.Forms.NumericUpDown();
            this.timeIntervalRadioButton = new System.Windows.Forms.RadioButton();
            this.autoRadioButton = new System.Windows.Forms.RadioButton();
            this.manualRadioButton = new System.Windows.Forms.RadioButton();
            this.stopRecord = new System.Windows.Forms.Button();
            this.startRecord = new System.Windows.Forms.Button();
            this.stopMeasurement = new System.Windows.Forms.Button();
            this.startMeasurement = new System.Windows.Forms.Button();
            this.voltage_measurement = new System.Windows.Forms.Label();
            this.resistance_measurement = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.resistanceLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.fetchTimer = new System.Windows.Forms.Timer(this.components);
            this.manualRecordTimer = new System.Windows.Forms.Timer(this.components);
            this.autoRecordTimer = new System.Windows.Forms.Timer(this.components);
            this.intervalRecordTimer = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secIntervalNumeric)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(136, 58);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(24, 13);
            this.Label6.TabIndex = 50;
            this.Label6.Text = "sec";
            // 
            // timeoutTextbox
            // 
            this.timeoutTextbox.Location = new System.Drawing.Point(82, 54);
            this.timeoutTextbox.Name = "timeoutTextbox";
            this.timeoutTextbox.Size = new System.Drawing.Size(48, 20);
            this.timeoutTextbox.TabIndex = 49;
            this.timeoutTextbox.Text = "1";
            this.timeoutTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(21, 58);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(45, 13);
            this.Label5.TabIndex = 48;
            this.Label5.Text = "Timeout";
            // 
            // portTextbox
            // 
            this.portTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.portTextbox.Location = new System.Drawing.Point(102, 55);
            this.portTextbox.Name = "portTextbox";
            this.portTextbox.Size = new System.Drawing.Size(62, 23);
            this.portTextbox.TabIndex = 47;
            this.portTextbox.Text = "23";
            this.portTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(21, 31);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(59, 13);
            this.Label4.TabIndex = 51;
            this.Label4.Text = "Commands";
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(404, 229);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(73, 32);
            this.clear.TabIndex = 57;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Label2.Location = new System.Drawing.Point(21, 58);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(34, 17);
            this.Label2.TabIndex = 46;
            this.Label2.Text = "Port";
            // 
            // transmitAndRecieve
            // 
            this.transmitAndRecieve.Location = new System.Drawing.Point(404, 83);
            this.transmitAndRecieve.Name = "transmitAndRecieve";
            this.transmitAndRecieve.Size = new System.Drawing.Size(73, 140);
            this.transmitAndRecieve.TabIndex = 56;
            this.transmitAndRecieve.Text = "Transmit and Receive";
            this.transmitAndRecieve.UseVisualStyleBackColor = true;
            this.transmitAndRecieve.Click += new System.EventHandler(this.TransmitAndRecieve_Click);
            // 
            // disconnect
            // 
            this.disconnect.Location = new System.Drawing.Point(398, 55);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(73, 32);
            this.disconnect.TabIndex = 55;
            this.disconnect.Text = "Disconnect";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(398, 17);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(73, 32);
            this.connect.TabIndex = 54;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Label1.Location = new System.Drawing.Point(21, 27);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(75, 17);
            this.Label1.TabIndex = 44;
            this.Label1.Text = "IP address";
            // 
            // consoleTextbox
            // 
            this.consoleTextbox.Location = new System.Drawing.Point(6, 83);
            this.consoleTextbox.Multiline = true;
            this.consoleTextbox.Name = "consoleTextbox";
            this.consoleTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.consoleTextbox.Size = new System.Drawing.Size(392, 178);
            this.consoleTextbox.TabIndex = 53;
            this.consoleTextbox.WordWrap = false;
            // 
            // commandTextbox
            // 
            this.commandTextbox.Location = new System.Drawing.Point(82, 28);
            this.commandTextbox.Name = "commandTextbox";
            this.commandTextbox.Size = new System.Drawing.Size(234, 20);
            this.commandTextbox.TabIndex = 52;
            this.commandTextbox.Text = "*IDN?";
            // 
            // ipTextbox
            // 
            this.ipTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.ipTextbox.Location = new System.Drawing.Point(102, 24);
            this.ipTextbox.Name = "ipTextbox";
            this.ipTextbox.Size = new System.Drawing.Size(122, 23);
            this.ipTextbox.TabIndex = 45;
            this.ipTextbox.Text = "192.168.1.1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.portTextbox);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Controls.Add(this.disconnect);
            this.groupBox1.Controls.Add(this.connect);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.ipTextbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 99);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Interface";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.stopMeasurement);
            this.groupBox2.Controls.Add(this.startMeasurement);
            this.groupBox2.Controls.Add(this.voltage_measurement);
            this.groupBox2.Controls.Add(this.resistance_measurement);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.resistanceLabel);
            this.groupBox2.Location = new System.Drawing.Point(12, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 323);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Measurements";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.clearRecord);
            this.groupBox4.Controls.Add(this.recordLog);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.manualNext);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.secIntervalNumeric);
            this.groupBox4.Controls.Add(this.timeIntervalRadioButton);
            this.groupBox4.Controls.Add(this.autoRadioButton);
            this.groupBox4.Controls.Add(this.manualRadioButton);
            this.groupBox4.Controls.Add(this.stopRecord);
            this.groupBox4.Controls.Add(this.startRecord);
            this.groupBox4.Location = new System.Drawing.Point(6, 92);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(471, 225);
            this.groupBox4.TabIndex = 61;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Record";
            // 
            // clearRecord
            // 
            this.clearRecord.Location = new System.Drawing.Point(392, 187);
            this.clearRecord.Name = "clearRecord";
            this.clearRecord.Size = new System.Drawing.Size(73, 32);
            this.clearRecord.TabIndex = 58;
            this.clearRecord.Text = "Clear";
            this.clearRecord.UseVisualStyleBackColor = true;
            this.clearRecord.Click += new System.EventHandler(this.ClearRecord_Click);
            // 
            // recordLog
            // 
            this.recordLog.Location = new System.Drawing.Point(151, 13);
            this.recordLog.Multiline = true;
            this.recordLog.Name = "recordLog";
            this.recordLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.recordLog.Size = new System.Drawing.Size(235, 206);
            this.recordLog.TabIndex = 67;
            this.recordLog.WordWrap = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(389, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 66;
            this.label12.Text = "Manual:";
            // 
            // manualNext
            // 
            this.manualNext.Location = new System.Drawing.Point(392, 101);
            this.manualNext.Name = "manualNext";
            this.manualNext.Size = new System.Drawing.Size(73, 32);
            this.manualNext.TabIndex = 65;
            this.manualNext.Text = "Next";
            this.manualNext.UseVisualStyleBackColor = true;
            this.manualNext.Click += new System.EventHandler(this.ManualNext_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(82, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "sec/interval";
            // 
            // secIntervalNumeric
            // 
            this.secIntervalNumeric.Location = new System.Drawing.Point(25, 91);
            this.secIntervalNumeric.Name = "secIntervalNumeric";
            this.secIntervalNumeric.Size = new System.Drawing.Size(49, 20);
            this.secIntervalNumeric.TabIndex = 60;
            this.secIntervalNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // timeIntervalRadioButton
            // 
            this.timeIntervalRadioButton.AutoSize = true;
            this.timeIntervalRadioButton.Location = new System.Drawing.Point(12, 65);
            this.timeIntervalRadioButton.Name = "timeIntervalRadioButton";
            this.timeIntervalRadioButton.Size = new System.Drawing.Size(133, 17);
            this.timeIntervalRadioButton.TabIndex = 59;
            this.timeIntervalRadioButton.TabStop = true;
            this.timeIntervalRadioButton.Text = "Specified time intervals";
            this.timeIntervalRadioButton.UseVisualStyleBackColor = true;
            this.timeIntervalRadioButton.CheckedChanged += new System.EventHandler(this.TimeIntervalRadioButton_CheckedChanged);
            // 
            // autoRadioButton
            // 
            this.autoRadioButton.AutoSize = true;
            this.autoRadioButton.Location = new System.Drawing.Point(12, 42);
            this.autoRadioButton.Name = "autoRadioButton";
            this.autoRadioButton.Size = new System.Drawing.Size(72, 17);
            this.autoRadioButton.TabIndex = 58;
            this.autoRadioButton.TabStop = true;
            this.autoRadioButton.Text = "Automatic";
            this.autoRadioButton.UseVisualStyleBackColor = true;
            this.autoRadioButton.CheckedChanged += new System.EventHandler(this.AutoRadioButton_CheckedChanged);
            // 
            // manualRadioButton
            // 
            this.manualRadioButton.AutoSize = true;
            this.manualRadioButton.Location = new System.Drawing.Point(12, 19);
            this.manualRadioButton.Name = "manualRadioButton";
            this.manualRadioButton.Size = new System.Drawing.Size(60, 17);
            this.manualRadioButton.TabIndex = 57;
            this.manualRadioButton.TabStop = true;
            this.manualRadioButton.Text = "Manual";
            this.manualRadioButton.UseVisualStyleBackColor = true;
            this.manualRadioButton.CheckedChanged += new System.EventHandler(this.ManualRadioButton_CheckedChanged);
            // 
            // stopRecord
            // 
            this.stopRecord.Location = new System.Drawing.Point(392, 51);
            this.stopRecord.Name = "stopRecord";
            this.stopRecord.Size = new System.Drawing.Size(73, 32);
            this.stopRecord.TabIndex = 56;
            this.stopRecord.Text = "Stop";
            this.stopRecord.UseVisualStyleBackColor = true;
            this.stopRecord.Click += new System.EventHandler(this.StopRecord_Click);
            // 
            // startRecord
            // 
            this.startRecord.Location = new System.Drawing.Point(392, 13);
            this.startRecord.Name = "startRecord";
            this.startRecord.Size = new System.Drawing.Size(73, 32);
            this.startRecord.TabIndex = 55;
            this.startRecord.Text = "Start";
            this.startRecord.UseVisualStyleBackColor = true;
            this.startRecord.Click += new System.EventHandler(this.StartRecord_Click);
            // 
            // stopMeasurement
            // 
            this.stopMeasurement.Location = new System.Drawing.Point(398, 54);
            this.stopMeasurement.Name = "stopMeasurement";
            this.stopMeasurement.Size = new System.Drawing.Size(73, 32);
            this.stopMeasurement.TabIndex = 58;
            this.stopMeasurement.Text = "Stop";
            this.stopMeasurement.UseVisualStyleBackColor = true;
            this.stopMeasurement.Click += new System.EventHandler(this.StopMeasurement_Click);
            // 
            // startMeasurement
            // 
            this.startMeasurement.Location = new System.Drawing.Point(398, 16);
            this.startMeasurement.Name = "startMeasurement";
            this.startMeasurement.Size = new System.Drawing.Size(73, 32);
            this.startMeasurement.TabIndex = 57;
            this.startMeasurement.Text = "Start";
            this.startMeasurement.UseVisualStyleBackColor = true;
            this.startMeasurement.Click += new System.EventHandler(this.StartMeasurement_Click);
            // 
            // voltage_measurement
            // 
            this.voltage_measurement.AutoSize = true;
            this.voltage_measurement.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.voltage_measurement.Location = new System.Drawing.Point(145, 60);
            this.voltage_measurement.Name = "voltage_measurement";
            this.voltage_measurement.Size = new System.Drawing.Size(78, 26);
            this.voltage_measurement.TabIndex = 3;
            this.voltage_measurement.Text = "_.____";
            // 
            // resistance_measurement
            // 
            this.resistance_measurement.AutoSize = true;
            this.resistance_measurement.BackColor = System.Drawing.SystemColors.Control;
            this.resistance_measurement.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.resistance_measurement.Location = new System.Drawing.Point(145, 22);
            this.resistance_measurement.Name = "resistance_measurement";
            this.resistance_measurement.Size = new System.Drawing.Size(78, 26);
            this.resistance_measurement.TabIndex = 2;
            this.resistance_measurement.Text = "_.____";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label7.Location = new System.Drawing.Point(19, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 26);
            this.label7.TabIndex = 1;
            this.label7.Text = "Voltage";
            // 
            // resistanceLabel
            // 
            this.resistanceLabel.AutoSize = true;
            this.resistanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.resistanceLabel.Location = new System.Drawing.Point(19, 22);
            this.resistanceLabel.Name = "resistanceLabel";
            this.resistanceLabel.Size = new System.Drawing.Size(120, 26);
            this.resistanceLabel.TabIndex = 0;
            this.resistanceLabel.Text = "Resistance";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Label6);
            this.groupBox3.Controls.Add(this.timeoutTextbox);
            this.groupBox3.Controls.Add(this.Label5);
            this.groupBox3.Controls.Add(this.Label4);
            this.groupBox3.Controls.Add(this.clear);
            this.groupBox3.Controls.Add(this.transmitAndRecieve);
            this.groupBox3.Controls.Add(this.consoleTextbox);
            this.groupBox3.Controls.Add(this.commandTextbox);
            this.groupBox3.Location = new System.Drawing.Point(12, 440);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(483, 267);
            this.groupBox3.TabIndex = 60;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Commands";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // manualRecordTimer
            // 
            this.manualRecordTimer.Tick += new System.EventHandler(this.ManualRecordTimer_Tick);
            // 
            // autoRecordTimer
            // 
            this.autoRecordTimer.Tick += new System.EventHandler(this.AutoRecordTimer_Tick);
            // 
            // intervalRecordTimer
            // 
            this.intervalRecordTimer.Tick += new System.EventHandler(this.IntervalRecordTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 719);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "HIOKI Battery Hi-Tester";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secIntervalNumeric)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox timeoutTextbox;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox portTextbox;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button clear;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button transmitAndRecieve;
        internal System.Windows.Forms.Button disconnect;
        internal System.Windows.Forms.Button connect;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox consoleTextbox;
        internal System.Windows.Forms.TextBox commandTextbox;
        internal System.Windows.Forms.TextBox ipTextbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label resistanceLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label voltage_measurement;
        private System.Windows.Forms.Label resistance_measurement;
        internal System.Windows.Forms.Button stopRecord;
        internal System.Windows.Forms.Button startRecord;
        private System.Windows.Forms.ImageList imageList1;
        internal System.Windows.Forms.Button stopMeasurement;
        internal System.Windows.Forms.Button startMeasurement;
        private System.Windows.Forms.RadioButton timeIntervalRadioButton;
        private System.Windows.Forms.RadioButton autoRadioButton;
        private System.Windows.Forms.RadioButton manualRadioButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown secIntervalNumeric;
        internal System.Windows.Forms.Button manualNext;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer fetchTimer;
        private System.Windows.Forms.Timer manualRecordTimer;
        private System.Windows.Forms.Timer autoRecordTimer;
        private System.Windows.Forms.Timer intervalRecordTimer;
        internal System.Windows.Forms.TextBox recordLog;
        internal System.Windows.Forms.Button clearRecord;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

