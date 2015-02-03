namespace WindowsFormsApplication1
{
    partial class RFStart0
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
            this.txtReadCard = new System.Windows.Forms.TextBox();
            this.rfCard1 = new ThirdLibrary.RFCard(this.components);
            this.SuspendLayout();
            // 
            // txtReadCard
            // 
            this.txtReadCard.Location = new System.Drawing.Point(21, 67);
            this.txtReadCard.MaxLength = 12;
            this.txtReadCard.Name = "txtReadCard";
            this.txtReadCard.Size = new System.Drawing.Size(235, 21);
            this.txtReadCard.TabIndex = 5;
            // 
            // rfCard1
            // 
            this.rfCard1.CardCode = "";
            // 
            // fmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.txtReadCard);
            this.Name = "fmStart";
            this.Text = "fmStart";
            this.Load += new System.EventHandler(this.fmStart_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmStart_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReadCard;
        private ThirdLibrary.RFCard rfCard1;
    }
}