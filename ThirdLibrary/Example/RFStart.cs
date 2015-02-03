using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class RFStart : Form
    {
        public delegate void SetUIDelegate();

        public RFStart()
        {
            InitializeComponent();
        }

        public void SetUIICCard(object sender, EventArgs args)
        {
            try
            {
                SetUIDelegate delgate = null;
                delgate += new SetUIDelegate(SetICCValue);
                while (!this.IsHandleCreated) { ;}
                this.BeginInvoke(delgate, null);
            }
            catch (Exception ex)
            {
                Log.WriteLog("IC卡 委托", ex.ToString());
            }
        }
        private void SetICCValue()
        {
            try
            {
                this.txtReadCard.Text = this.rfCard1.CardCode;
            }
            catch (Exception ex)
            {
                Log.WriteLog("IC卡给控件赋值", ex.ToString());
            }
        }

        private void fmStart_Load(object sender, EventArgs e)
        {
            rfCard1.SetUIValue += new EventHandler(SetUIICCard);
            this.rfCard1.Initialize("COM4", "9600");
        }

        private void fmStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.rfCard1.Close();
        }
    }
}
