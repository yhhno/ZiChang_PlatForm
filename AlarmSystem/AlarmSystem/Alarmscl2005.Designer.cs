namespace AlarmSystem
{
    partial class Alarmscl2005
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alarmscl2005));
            this.label1 = new System.Windows.Forms.Label();
            this.axCL2005Ocx1 = new AxCL2005OCXLib.AxCL2005Ocx();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.axCL2005Ocx1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // axCL2005Ocx1
            // 
            this.axCL2005Ocx1.Enabled = true;
            this.axCL2005Ocx1.Location = new System.Drawing.Point(0, 0);
            this.axCL2005Ocx1.Name = "axCL2005Ocx1";
            this.axCL2005Ocx1.TabIndex = 0;
            this.axCL2005Ocx1.Visible = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "报警系统";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // AlarmThread
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 107);
            this.Controls.Add(this.axCL2005Ocx1);
            this.Controls.Add(this.label1);
            this.Name = "AlarmThread";
            this.Text = "AlarmThread";
            this.Load += new System.EventHandler(this.AlarmThread_Load);
            this.SizeChanged += new System.EventHandler(this.AlarmThread_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmThread_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.axCL2005Ocx1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private AxCL2005OCXLib.AxCL2005Ocx axCL2005Ocx1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}