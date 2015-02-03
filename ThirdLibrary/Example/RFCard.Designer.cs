namespace WindowsFormsApplication1
{
    partial class RFCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RFCard));
            this.btnWrite = new System.Windows.Forms.Button();
            this.txtWriteCode = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIntial = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cmb_hcom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_braute = new System.Windows.Forms.ComboBox();
            this.gbox_con = new System.Windows.Forms.GroupBox();
            this.gbox_set = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.list_msg = new System.Windows.Forms.ListBox();
            this.gbox_writeCard = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rfCard1 = new ThirdLibrary.RFCard(this.components);
            this.txtRemoteCode = new System.Windows.Forms.TextBox();
            this.gbox_con.SuspendLayout();
            this.gbox_set.SuspendLayout();
            this.gbox_writeCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(202, 47);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 1;
            this.btnWrite.Text = "写卡号";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // txtWriteCode
            // 
            this.txtWriteCode.Location = new System.Drawing.Point(41, 49);
            this.txtWriteCode.MaxLength = 10;
            this.txtWriteCode.Name = "txtWriteCode";
            this.txtWriteCode.Size = new System.Drawing.Size(152, 21);
            this.txtWriteCode.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(49, 119);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIntial
            // 
            this.btnIntial.Location = new System.Drawing.Point(49, 90);
            this.btnIntial.Name = "btnIntial";
            this.btnIntial.Size = new System.Drawing.Size(75, 23);
            this.btnIntial.TabIndex = 5;
            this.btnIntial.Text = "连接";
            this.btnIntial.UseVisualStyleBackColor = true;
            this.btnIntial.Click += new System.EventHandler(this.btnIntial_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "100",
            "105",
            "110",
            "115",
            "120",
            "125",
            "130",
            "135",
            "140",
            "145",
            "150"});
            this.comboBox1.Location = new System.Drawing.Point(26, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(157, 20);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.Text = "105";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(107, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "查询";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmb_hcom
            // 
            this.cmb_hcom.FormattingEnabled = true;
            this.cmb_hcom.Items.AddRange(new object[] {
            "com1",
            "com2",
            "com3",
            "com4",
            "com5",
            "com6",
            "com7"});
            this.cmb_hcom.Location = new System.Drawing.Point(65, 20);
            this.cmb_hcom.Name = "cmb_hcom";
            this.cmb_hcom.Size = new System.Drawing.Size(104, 20);
            this.cmb_hcom.TabIndex = 13;
            this.cmb_hcom.Text = "com3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "串口号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "波特率：";
            // 
            // cmb_braute
            // 
            this.cmb_braute.FormattingEnabled = true;
            this.cmb_braute.Items.AddRange(new object[] {
            "9600",
            "38400",
            "115200"});
            this.cmb_braute.Location = new System.Drawing.Point(65, 57);
            this.cmb_braute.Name = "cmb_braute";
            this.cmb_braute.Size = new System.Drawing.Size(104, 20);
            this.cmb_braute.TabIndex = 13;
            this.cmb_braute.Text = "115200";
            // 
            // gbox_con
            // 
            this.gbox_con.Controls.Add(this.btnIntial);
            this.gbox_con.Controls.Add(this.cmb_braute);
            this.gbox_con.Controls.Add(this.label2);
            this.gbox_con.Controls.Add(this.label1);
            this.gbox_con.Controls.Add(this.cmb_hcom);
            this.gbox_con.Controls.Add(this.btnClose);
            this.gbox_con.Location = new System.Drawing.Point(2, 12);
            this.gbox_con.Name = "gbox_con";
            this.gbox_con.Size = new System.Drawing.Size(175, 168);
            this.gbox_con.TabIndex = 15;
            this.gbox_con.TabStop = false;
            this.gbox_con.Text = "链接";
            // 
            // gbox_set
            // 
            this.gbox_set.Controls.Add(this.label4);
            this.gbox_set.Controls.Add(this.comboBox1);
            this.gbox_set.Controls.Add(this.button2);
            this.gbox_set.Controls.Add(this.button3);
            this.gbox_set.Location = new System.Drawing.Point(8, 186);
            this.gbox_set.Name = "gbox_set";
            this.gbox_set.Size = new System.Drawing.Size(261, 103);
            this.gbox_set.TabIndex = 16;
            this.gbox_set.TabStop = false;
            this.gbox_set.Text = "功率设置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(239, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = " 一般白板设置为150，写卡器设置为105-110\r\n";
            // 
            // list_msg
            // 
            this.list_msg.FormattingEnabled = true;
            this.list_msg.ItemHeight = 12;
            this.list_msg.Location = new System.Drawing.Point(2, 295);
            this.list_msg.Name = "list_msg";
            this.list_msg.Size = new System.Drawing.Size(550, 100);
            this.list_msg.TabIndex = 17;
            // 
            // gbox_writeCard
            // 
            this.gbox_writeCard.Controls.Add(this.txtWriteCode);
            this.gbox_writeCard.Controls.Add(this.btnWrite);
            this.gbox_writeCard.Location = new System.Drawing.Point(275, 186);
            this.gbox_writeCard.Name = "gbox_writeCard";
            this.gbox_writeCard.Size = new System.Drawing.Size(316, 103);
            this.gbox_writeCard.TabIndex = 19;
            this.gbox_writeCard.TabStop = false;
            this.gbox_writeCard.Text = "写卡";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(558, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 100);
            this.button1.TabIndex = 21;
            this.button1.Text = "清空";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // rfCard1
            // 
            this.rfCard1.CardCode = "";
            // 
            // txtRemoteCode
            // 
            this.txtRemoteCode.Location = new System.Drawing.Point(184, 13);
            this.txtRemoteCode.Multiline = true;
            this.txtRemoteCode.Name = "txtRemoteCode";
            this.txtRemoteCode.Size = new System.Drawing.Size(406, 167);
            this.txtRemoteCode.TabIndex = 22;
            // 
            // RFCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 400);
            this.Controls.Add(this.txtRemoteCode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbox_writeCard);
            this.Controls.Add(this.list_msg);
            this.Controls.Add(this.gbox_set);
            this.Controls.Add(this.gbox_con);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RFCard";
            this.Text = "读写卡设置";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.gbox_con.ResumeLayout(false);
            this.gbox_con.PerformLayout();
            this.gbox_set.ResumeLayout(false);
            this.gbox_set.PerformLayout();
            this.gbox_writeCard.ResumeLayout(false);
            this.gbox_writeCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ThirdLibrary.RFCard rfCard1;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.TextBox txtWriteCode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIntial;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cmb_hcom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_braute;
        private System.Windows.Forms.GroupBox gbox_con;
        private System.Windows.Forms.GroupBox gbox_set;
        private System.Windows.Forms.ListBox list_msg;
        private System.Windows.Forms.GroupBox gbox_writeCard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemoteCode;
    }
}