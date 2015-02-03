using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ThirdLibrary
{
    [ToolboxBitmap(typeof(AlarmSound), "Resources.WaterTextBox.bmp")]
    public partial class WaterTextBox : TextBox
    {
        private readonly Label lblwaterText = new Label();
        public WaterTextBox()
        {
            InitializeComponent();
            lblwaterText.BorderStyle = BorderStyle.None;
            lblwaterText.Enabled = false;
            lblwaterText.BackColor = Color.White;
            lblwaterText.AutoSize = false;
            lblwaterText.Top = 1;
            lblwaterText.Left = 0;
            Controls.Add(lblwaterText);
        }
        [Category("扩展属性"), Description("显示的提示信息")]
        public string WaterText
        {
            get { return lblwaterText.Text; }
            set { lblwaterText.Text = value; }
        }
        public override string Text
        {
            set
            {
                if (value != string.Empty)
                    lblwaterText.Visible = false;
                else
                    lblwaterText.Visible = true;
                base.Text = value;
            }
            get 
            {
                return base.Text; 
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (Multiline && (ScrollBars == ScrollBars.Vertical || ScrollBars == ScrollBars.Both))
                lblwaterText.Width = Width - 20;
            else
                lblwaterText.Width = Width;
            lblwaterText.Height = Height - 2;
            base.OnSizeChanged(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            lblwaterText.Visible = false;
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            if (base.Text == string.Empty)
            lblwaterText.Visible = true;
            base.OnLeave(e);
        }
    }
}
