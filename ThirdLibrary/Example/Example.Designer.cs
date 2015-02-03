namespace WindowsFormsApplication1
{
    partial class Example
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
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnReadDate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtICCardValue = new System.Windows.Forms.TextBox();
            this.txtPound = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dhVideo1 = new ThirdLibrary.DHVideo();
            this.dhVideo2 = new ThirdLibrary.DHVideo();
            this.icCard1 = new ThirdLibrary.ICCard(this.components);
            this.alarmSound1 = new ThirdLibrary.AlarmSound(this.components);
            this.appearance1 = new ThirdLibrary.Appearance();
            this.remoteCard1 = new ThirdLibrary.RemoteCard();
            this.txtCardCode = new System.Windows.Forms.TextBox();
            this.combCom = new System.Windows.Forms.ComboBox();
            this.combPort = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.combStop = new System.Windows.Forms.ComboBox();
            this.btnSetBang = new System.Windows.Forms.Button();
            this.btnStopBang = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(49, 133);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 0;
            this.btnWrite.Text = "IC卡写数据";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnReadDate
            // 
            this.btnReadDate.Location = new System.Drawing.Point(49, 90);
            this.btnReadDate.Name = "btnReadDate";
            this.btnReadDate.Size = new System.Drawing.Size(75, 23);
            this.btnReadDate.TabIndex = 1;
            this.btnReadDate.Text = "IC卡读数据";
            this.btnReadDate.UseVisualStyleBackColor = true;
            this.btnReadDate.Click += new System.EventHandler(this.btnReadDate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(151, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "读内部卡号";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(151, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "播放中文声音";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtICCardValue
            // 
            this.txtICCardValue.Location = new System.Drawing.Point(126, 17);
            this.txtICCardValue.Name = "txtICCardValue";
            this.txtICCardValue.Size = new System.Drawing.Size(114, 21);
            this.txtICCardValue.TabIndex = 5;
            // 
            // txtPound
            // 
            this.txtPound.Location = new System.Drawing.Point(102, 215);
            this.txtPound.Name = "txtPound";
            this.txtPound.Size = new System.Drawing.Size(59, 21);
            this.txtPound.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "磅秤数据：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "IC卡数据显示：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 242);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 72);
            this.textBox1.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dhVideo1);
            this.groupBox1.Location = new System.Drawing.Point(324, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 130);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dhVideo1
            // 
            this.dhVideo1.Amplify = 3;
            this.dhVideo1.AutoSize = true;
            this.dhVideo1.BackColor = System.Drawing.SystemColors.Control;
            this.dhVideo1.Location = new System.Drawing.Point(31, 20);
            this.dhVideo1.Name = "dhVideo1";
            this.dhVideo1.Size = new System.Drawing.Size(90, 76);
            this.dhVideo1.TabIndex = 9;
            // 
            // dhVideo2
            // 
            this.dhVideo2.Amplify = 2;
            this.dhVideo2.AutoSize = true;
            this.dhVideo2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dhVideo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dhVideo2.Location = new System.Drawing.Point(333, 169);
            this.dhVideo2.Name = "dhVideo2";
            this.dhVideo2.Size = new System.Drawing.Size(163, 145);
            this.dhVideo2.TabIndex = 10;
            // 
            // icCard1
            // 
            this.icCard1.FactoryCodeInitValue = "";
            // 
            // appearance1
            // 
            this.appearance1.Weight = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // remoteCard1
            // 
            this.remoteCard1.RemoteCode = "";
            // 
            // txtCardCode
            // 
            this.txtCardCode.Location = new System.Drawing.Point(126, 44);
            this.txtCardCode.Name = "txtCardCode";
            this.txtCardCode.Size = new System.Drawing.Size(114, 21);
            this.txtCardCode.TabIndex = 13;
            // 
            // combCom
            // 
            this.combCom.DropDownWidth = 121;
            this.combCom.FormattingEnabled = true;
            this.combCom.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.combCom.Location = new System.Drawing.Point(102, 183);
            this.combCom.Name = "combCom";
            this.combCom.Size = new System.Drawing.Size(59, 20);
            this.combCom.TabIndex = 14;
            // 
            // combPort
            // 
            this.combPort.DropDownWidth = 121;
            this.combPort.FormattingEnabled = true;
            this.combPort.Items.AddRange(new object[] {
            "1200",
            "2400",
            "9600",
            "115200"});
            this.combPort.Location = new System.Drawing.Point(168, 183);
            this.combPort.Name = "combPort";
            this.combPort.Size = new System.Drawing.Size(60, 20);
            this.combPort.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "磅秤设置：";
            // 
            // combStop
            // 
            this.combStop.DropDownWidth = 121;
            this.combStop.FormattingEnabled = true;
            this.combStop.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1"});
            this.combStop.Location = new System.Drawing.Point(234, 183);
            this.combStop.Name = "combStop";
            this.combStop.Size = new System.Drawing.Size(39, 20);
            this.combStop.TabIndex = 17;
            // 
            // btnSetBang
            // 
            this.btnSetBang.Location = new System.Drawing.Point(168, 213);
            this.btnSetBang.Name = "btnSetBang";
            this.btnSetBang.Size = new System.Drawing.Size(53, 23);
            this.btnSetBang.TabIndex = 18;
            this.btnSetBang.Text = "打开";
            this.btnSetBang.UseVisualStyleBackColor = true;
            this.btnSetBang.Click += new System.EventHandler(this.btnSetBang_Click);
            // 
            // btnStopBang
            // 
            this.btnStopBang.Location = new System.Drawing.Point(222, 213);
            this.btnStopBang.Name = "btnStopBang";
            this.btnStopBang.Size = new System.Drawing.Size(53, 23);
            this.btnStopBang.TabIndex = 19;
            this.btnStopBang.Text = "关闭";
            this.btnStopBang.UseVisualStyleBackColor = true;
            this.btnStopBang.Click += new System.EventHandler(this.btnStopBang_Click);
            // 
            // Example
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 320);
            this.Controls.Add(this.btnStopBang);
            this.Controls.Add(this.btnSetBang);
            this.Controls.Add(this.combStop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combPort);
            this.Controls.Add(this.combCom);
            this.Controls.Add(this.txtCardCode);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dhVideo2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPound);
            this.Controls.Add(this.txtICCardValue);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnReadDate);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.groupBox1);
            this.Name = "Example";
            this.Text = "ICCard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Example_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWrite;
        private ThirdLibrary.ICCard icCard1;
        private System.Windows.Forms.Button btnReadDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtICCardValue;
        private ThirdLibrary.AlarmSound alarmSound1;
        private System.Windows.Forms.TextBox txtPound;
        private ThirdLibrary.Appearance appearance1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ThirdLibrary.DHVideo dhVideo1;
        private ThirdLibrary.DHVideo dhVideo2;
        private ThirdLibrary.RemoteCard remoteCard1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCardCode;
        private System.Windows.Forms.ComboBox combCom;
        private System.Windows.Forms.ComboBox combPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combStop;
        private System.Windows.Forms.Button btnSetBang;
        private System.Windows.Forms.Button btnStopBang;
    }
}