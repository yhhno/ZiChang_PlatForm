namespace ThirdLibrary
{
    partial class LPR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LPR));
            this.axHVActiveX21 = new AxHVActiveX2Lib.AxHVActiveX2();
            ((System.ComponentModel.ISupportInitialize)(this.axHVActiveX21)).BeginInit();
            this.SuspendLayout();
            // 
            // axHVActiveX21
            // 
            this.axHVActiveX21.Enabled = true;
            this.axHVActiveX21.Location = new System.Drawing.Point(0, 0);
            this.axHVActiveX21.Name = "axHVActiveX21";
            this.axHVActiveX21.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axHVActiveX21.OcxState")));
            this.axHVActiveX21.Size = new System.Drawing.Size(32, 32);
            this.axHVActiveX21.TabIndex = 0;
            this.axHVActiveX21.OnReceivePlate += new System.EventHandler(this.axHVActiveX21_OnReceivePlate);
            // 
            // LPR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axHVActiveX21);
            this.Name = "LPR";
            this.Size = new System.Drawing.Size(36, 33);
            this.Load += new System.EventHandler(this.LPR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axHVActiveX21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxHVActiveX2Lib.AxHVActiveX2 axHVActiveX21;
    }
}
