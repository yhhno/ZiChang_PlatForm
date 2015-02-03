namespace AlarmSystem
{
    partial class LED屏幕报警显示
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LED屏幕报警显示));
            this.gbConfig = new System.Windows.Forms.GroupBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.lblDBName = new System.Windows.Forms.Label();
            this.txtPassWd = new System.Windows.Forms.TextBox();
            this.txtDBUserName = new System.Windows.Forms.TextBox();
            this.lblPassWd = new System.Windows.Forms.Label();
            this.lblDBUserName = new System.Windows.Forms.Label();
            this.lblDBServer = new System.Windows.Forms.Label();
            this.txtDBServer = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ComBaudRate = new System.Windows.Forms.TextBox();
            this.txt_ledHeght = new System.Windows.Forms.TextBox();
            this.txt_LedWidth = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_CharColor = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOperatePassword = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.gbConfig.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.gbConfig.Location = new System.Drawing.Point(59, 4);
            this.gbConfig.Name = "gbConfig";
            this.gbConfig.Size = new System.Drawing.Size(394, 133);
            this.gbConfig.TabIndex = 5;
            this.gbConfig.TabStop = false;
            this.gbConfig.Text = "程序配置";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(157, 46);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(180, 23);
            this.txtDBName.TabIndex = 11;
            this.txtDBName.Text = "CoalTraffic";
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDBName.Location = new System.Drawing.Point(40, 49);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(105, 14);
            this.lblDBName.TabIndex = 10;
            this.lblDBName.Text = "数据库实例名：";
            // 
            // txtPassWd
            // 
            this.txtPassWd.Location = new System.Drawing.Point(157, 100);
            this.txtPassWd.Name = "txtPassWd";
            this.txtPassWd.Size = new System.Drawing.Size(180, 23);
            this.txtPassWd.TabIndex = 7;
            this.txtPassWd.UseSystemPasswordChar = true;
            // 
            // txtDBUserName
            // 
            this.txtDBUserName.Location = new System.Drawing.Point(157, 73);
            this.txtDBUserName.Name = "txtDBUserName";
            this.txtDBUserName.Size = new System.Drawing.Size(180, 23);
            this.txtDBUserName.TabIndex = 6;
            this.txtDBUserName.Text = "sa";
            // 
            // lblPassWd
            // 
            this.lblPassWd.AutoSize = true;
            this.lblPassWd.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblPassWd.Location = new System.Drawing.Point(47, 104);
            this.lblPassWd.Name = "lblPassWd";
            this.lblPassWd.Size = new System.Drawing.Size(98, 14);
            this.lblPassWd.TabIndex = 3;
            this.lblPassWd.Text = "数据库 密码：";
            // 
            // lblDBUserName
            // 
            this.lblDBUserName.AutoSize = true;
            this.lblDBUserName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDBUserName.Location = new System.Drawing.Point(40, 78);
            this.lblDBUserName.Name = "lblDBUserName";
            this.lblDBUserName.Size = new System.Drawing.Size(105, 14);
            this.lblDBUserName.TabIndex = 2;
            this.lblDBUserName.Text = "数据库用户名：";
            // 
            // lblDBServer
            // 
            this.lblDBServer.AutoSize = true;
            this.lblDBServer.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDBServer.Location = new System.Drawing.Point(40, 22);
            this.lblDBServer.Name = "lblDBServer";
            this.lblDBServer.Size = new System.Drawing.Size(105, 14);
            this.lblDBServer.TabIndex = 1;
            this.lblDBServer.Text = "数据库服务器：";
            // 
            // txtDBServer
            // 
            this.txtDBServer.Location = new System.Drawing.Point(157, 18);
            this.txtDBServer.Name = "txtDBServer";
            this.txtDBServer.Size = new System.Drawing.Size(180, 23);
            this.txtDBServer.TabIndex = 0;
            this.txtDBServer.Text = "172.10.14.1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.comboBox1.Location = new System.Drawing.Point(157, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(92, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "屏宽：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(92, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "屏高：";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSave.Location = new System.Drawing.Point(216, 425);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存设置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(79, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率：";
            // 
            // txt_ComBaudRate
            // 
            this.txt_ComBaudRate.Location = new System.Drawing.Point(157, 44);
            this.txt_ComBaudRate.Name = "txt_ComBaudRate";
            this.txt_ComBaudRate.Size = new System.Drawing.Size(180, 23);
            this.txt_ComBaudRate.TabIndex = 0;
            this.txt_ComBaudRate.Text = "38400";
            // 
            // txt_ledHeght
            // 
            this.txt_ledHeght.Location = new System.Drawing.Point(157, 100);
            this.txt_ledHeght.Name = "txt_ledHeght";
            this.txt_ledHeght.Size = new System.Drawing.Size(180, 23);
            this.txt_ledHeght.TabIndex = 0;
            this.txt_ledHeght.Text = "96";
            // 
            // txt_LedWidth
            // 
            this.txt_LedWidth.Location = new System.Drawing.Point(157, 71);
            this.txt_LedWidth.Name = "txt_LedWidth";
            this.txt_LedWidth.Size = new System.Drawing.Size(180, 23);
            this.txt_LedWidth.TabIndex = 0;
            this.txt_LedWidth.Text = "384";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtX);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtY);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_CharColor);
            this.groupBox1.Controls.Add(this.txt_ledHeght);
            this.groupBox1.Controls.Add(this.txt_LedWidth);
            this.groupBox1.Controls.Add(this.txt_ComBaudRate);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Location = new System.Drawing.Point(59, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 221);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LED 屏幕设置";
            // 
            // txtX
            // 
            this.txtX.Font = new System.Drawing.Font("宋体", 9F);
            this.txtX.Location = new System.Drawing.Point(284, 186);
            this.txtX.MaxLength = 3;
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(53, 21);
            this.txtX.TabIndex = 13;
            this.txtX.Text = "30";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(213, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "标题距左：";
            // 
            // txtY
            // 
            this.txtY.Font = new System.Drawing.Font("宋体", 9F);
            this.txtY.Location = new System.Drawing.Point(157, 186);
            this.txtY.MaxLength = 3;
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(53, 21);
            this.txtY.TabIndex = 11;
            this.txtY.Text = "20";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(64, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "标题距顶：";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("宋体", 9F);
            this.txtTitle.Location = new System.Drawing.Point(157, 158);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(180, 21);
            this.txtTitle.TabIndex = 9;
            this.txtTitle.Text = "热烈欢迎领导莅临指导工作!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(72, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "LED标题：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(73, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 7;
            this.label9.Text = "COM口号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(64, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "文字颜色：";
            // 
            // txt_CharColor
            // 
            this.txt_CharColor.Location = new System.Drawing.Point(157, 128);
            this.txt_CharColor.Name = "txt_CharColor";
            this.txt_CharColor.Size = new System.Drawing.Size(180, 23);
            this.txt_CharColor.TabIndex = 0;
            this.txt_CharColor.Text = "255";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtOperatePassword);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox2.Location = new System.Drawing.Point(59, 370);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 49);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "关闭窗体";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(52, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "请输入操作密码：";
            // 
            // txtOperatePassword
            // 
            this.txtOperatePassword.Font = new System.Drawing.Font("宋体", 10F);
            this.txtOperatePassword.Location = new System.Drawing.Point(163, 21);
            this.txtOperatePassword.Name = "txtOperatePassword";
            this.txtOperatePassword.Size = new System.Drawing.Size(180, 23);
            this.txtOperatePassword.TabIndex = 0;
            this.txtOperatePassword.UseSystemPasswordChar = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "报警系统";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // LED屏幕报警显示
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(520, 465);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbConfig);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LED屏幕报警显示";
            this.Text = "LED屏幕报警显示";
            this.Load += new System.EventHandler(this.Main_Load);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.gbConfig.ResumeLayout(false);
            this.gbConfig.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ComBaudRate;
        private System.Windows.Forms.TextBox txt_ledHeght;
        private System.Windows.Forms.TextBox txt_LedWidth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtOperatePassword;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_CharColor;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label7;
    }
}