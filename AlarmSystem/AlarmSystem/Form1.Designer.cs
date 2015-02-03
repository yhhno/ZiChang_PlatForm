namespace AlarmSystem
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gbConfig = new System.Windows.Forms.GroupBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.lblDBName = new System.Windows.Forms.Label();
            this.txtPassWd = new System.Windows.Forms.TextBox();
            this.txtDBUserName = new System.Windows.Forms.TextBox();
            this.lblPassWd = new System.Windows.Forms.Label();
            this.lblDBUserName = new System.Windows.Forms.Label();
            this.lblDBServer = new System.Windows.Forms.Label();
            this.txtDBServer = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ledHeght = new System.Windows.Forms.TextBox();
            this.txt_LedWidth = new System.Windows.Forms.TextBox();
            this.txt_ComBaudRate = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gbConfig.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConfig
            // 
            this.gbConfig.BackColor = System.Drawing.Color.Transparent;
            this.gbConfig.Controls.Add(this.txtDBName);
            this.gbConfig.Controls.Add(this.lblDBName);
            this.gbConfig.Controls.Add(this.txtPassWd);
            this.gbConfig.Controls.Add(this.txtDBUserName);
            this.gbConfig.Controls.Add(this.lblPassWd);
            this.gbConfig.Controls.Add(this.lblDBUserName);
            this.gbConfig.Controls.Add(this.lblDBServer);
            this.gbConfig.Controls.Add(this.txtDBServer);
            this.gbConfig.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbConfig.ForeColor = System.Drawing.Color.DarkBlue;
            this.gbConfig.Location = new System.Drawing.Point(36, 21);
            this.gbConfig.Name = "gbConfig";
            this.gbConfig.Size = new System.Drawing.Size(372, 154);
            this.gbConfig.TabIndex = 2;
            this.gbConfig.TabStop = false;
            this.gbConfig.Text = "程序配置";
            this.gbConfig.Enter += new System.EventHandler(this.gbConfig_Enter);
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(152, 54);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(180, 23);
            this.txtDBName.TabIndex = 11;
            this.txtDBName.Text = "CoalTraffic(通用)";
            this.txtDBName.TextChanged += new System.EventHandler(this.txtDBName_TextChanged);
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.ForeColor = System.Drawing.Color.Black;
            this.lblDBName.Location = new System.Drawing.Point(35, 57);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(105, 14);
            this.lblDBName.TabIndex = 10;
            this.lblDBName.Text = "数据库实例名：";
            this.lblDBName.Click += new System.EventHandler(this.lblDBName_Click);
            // 
            // txtPassWd
            // 
            this.txtPassWd.Location = new System.Drawing.Point(152, 116);
            this.txtPassWd.Name = "txtPassWd";
            this.txtPassWd.Size = new System.Drawing.Size(180, 23);
            this.txtPassWd.TabIndex = 7;
            this.txtPassWd.UseSystemPasswordChar = true;
            this.txtPassWd.TextChanged += new System.EventHandler(this.txtPassWd_TextChanged);
            // 
            // txtDBUserName
            // 
            this.txtDBUserName.Location = new System.Drawing.Point(152, 85);
            this.txtDBUserName.Name = "txtDBUserName";
            this.txtDBUserName.Size = new System.Drawing.Size(180, 23);
            this.txtDBUserName.TabIndex = 6;
            this.txtDBUserName.Text = "sa";
            this.txtDBUserName.TextChanged += new System.EventHandler(this.txtDBUserName_TextChanged);
            // 
            // lblPassWd
            // 
            this.lblPassWd.AutoSize = true;
            this.lblPassWd.ForeColor = System.Drawing.Color.Black;
            this.lblPassWd.Location = new System.Drawing.Point(49, 120);
            this.lblPassWd.Name = "lblPassWd";
            this.lblPassWd.Size = new System.Drawing.Size(91, 14);
            this.lblPassWd.TabIndex = 3;
            this.lblPassWd.Text = "数据库密码：";
            this.lblPassWd.Click += new System.EventHandler(this.lblPassWd_Click);
            // 
            // lblDBUserName
            // 
            this.lblDBUserName.AutoSize = true;
            this.lblDBUserName.ForeColor = System.Drawing.Color.Black;
            this.lblDBUserName.Location = new System.Drawing.Point(35, 86);
            this.lblDBUserName.Name = "lblDBUserName";
            this.lblDBUserName.Size = new System.Drawing.Size(105, 14);
            this.lblDBUserName.TabIndex = 2;
            this.lblDBUserName.Text = "数据库用户名：";
            this.lblDBUserName.Click += new System.EventHandler(this.lblDBUserName_Click);
            // 
            // lblDBServer
            // 
            this.lblDBServer.AutoSize = true;
            this.lblDBServer.ForeColor = System.Drawing.Color.Black;
            this.lblDBServer.Location = new System.Drawing.Point(35, 29);
            this.lblDBServer.Name = "lblDBServer";
            this.lblDBServer.Size = new System.Drawing.Size(105, 14);
            this.lblDBServer.TabIndex = 1;
            this.lblDBServer.Text = "数据库服务器：";
            this.lblDBServer.Click += new System.EventHandler(this.lblDBServer_Click);
            // 
            // txtDBServer
            // 
            this.txtDBServer.Location = new System.Drawing.Point(152, 25);
            this.txtDBServer.Name = "txtDBServer";
            this.txtDBServer.Size = new System.Drawing.Size(180, 23);
            this.txtDBServer.TabIndex = 0;
            this.txtDBServer.Text = "127.0.0.1";
            this.txtDBServer.TextChanged += new System.EventHandler(this.txtDBServer_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_ledHeght);
            this.groupBox1.Controls.Add(this.txt_LedWidth);
            this.groupBox1.Controls.Add(this.txt_ComBaudRate);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Location = new System.Drawing.Point(36, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 224);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LED 屏幕设置";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(211, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 6;
            this.label8.Text = "型号";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(153, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 14);
            this.label7.TabIndex = 5;
            this.label7.Text = "Com";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(223, 182);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(53, 18);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "双色";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(152, 182);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 18);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "单色";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "4"});
            this.comboBox2.Location = new System.Drawing.Point(152, 148);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(53, 21);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.comboBox1.Location = new System.Drawing.Point(187, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(53, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(35, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 2;
            this.label6.Text = "屏类型：";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(35, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "控制卡类型：";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(35, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "屏宽：";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(35, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "屏高：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(35, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(35, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "串口号：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_ledHeght
            // 
            this.txt_ledHeght.Location = new System.Drawing.Point(152, 119);
            this.txt_ledHeght.Name = "txt_ledHeght";
            this.txt_ledHeght.Size = new System.Drawing.Size(180, 23);
            this.txt_ledHeght.TabIndex = 0;
            this.txt_ledHeght.Text = "64";
            this.txt_ledHeght.TextChanged += new System.EventHandler(this.txt_ledHeght_TextChanged);
            // 
            // txt_LedWidth
            // 
            this.txt_LedWidth.Location = new System.Drawing.Point(152, 90);
            this.txt_LedWidth.Name = "txt_LedWidth";
            this.txt_LedWidth.Size = new System.Drawing.Size(180, 23);
            this.txt_LedWidth.TabIndex = 0;
            this.txt_LedWidth.Text = "448";
            this.txt_LedWidth.TextChanged += new System.EventHandler(this.txt_LedWidth_TextChanged);
            // 
            // txt_ComBaudRate
            // 
            this.txt_ComBaudRate.Location = new System.Drawing.Point(152, 55);
            this.txt_ComBaudRate.Name = "txt_ComBaudRate";
            this.txt_ComBaudRate.Size = new System.Drawing.Size(180, 23);
            this.txt_ComBaudRate.TabIndex = 0;
            this.txt_ComBaudRate.Text = "38400";
            this.txt_ComBaudRate.TextChanged += new System.EventHandler(this.txt_ComBaudRate_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 422);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "保存设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(448, 457);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbConfig);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.gbConfig.ResumeLayout(false);
            this.gbConfig.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConfig;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.TextBox txtPassWd;
        private System.Windows.Forms.TextBox txtDBUserName;
        private System.Windows.Forms.Label lblPassWd;
        private System.Windows.Forms.Label lblDBUserName;
        private System.Windows.Forms.Label lblDBServer;
        private System.Windows.Forms.TextBox txtDBServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ComBaudRate;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ledHeght;
        private System.Windows.Forms.TextBox txt_LedWidth;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

