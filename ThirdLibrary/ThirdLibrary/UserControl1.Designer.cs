namespace ThirdLibrary
{
    partial class UserControl1
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.axDeviceManager1 = new AxWIA.AxDeviceManager();
            ((System.ComponentModel.ISupportInitialize)(this.axDeviceManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // axDeviceManager1
            // 
            this.axDeviceManager1.Enabled = true;
            this.axDeviceManager1.Location = new System.Drawing.Point(101, 194);
            this.axDeviceManager1.Name = "axDeviceManager1";
            this.axDeviceManager1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axDeviceManager1.OcxState")));
            this.axDeviceManager1.Size = new System.Drawing.Size(32, 32);
            this.axDeviceManager1.TabIndex = 0;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axDeviceManager1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(335, 272);
            ((System.ComponentModel.ISupportInitialize)(this.axDeviceManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWIA.AxDeviceManager axDeviceManager1;
    }
}
