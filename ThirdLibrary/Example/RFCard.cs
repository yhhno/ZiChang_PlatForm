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
    public partial class RFCard : Form
    {
        public RFCard()
        {
            InitializeComponent();
        }

        public delegate void SetUIDelegate();

       

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
                this.txtRemoteCode.Text = this.rfCard1.CardCode;
            }
            catch (Exception ex)
            {
                Log.WriteLog("IC卡给控件赋值", ex.ToString());
                list_msg.Items.Add(System.DateTime.Now.ToString()+"： IC卡给控件赋值"+ex.ToString());
            }
        }

        private void btnSetCardCode_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.rfCard1.CardCode);
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (rfCard1.RfWrite(this.txtWriteCode.Text.Trim())==0)
            {
                list_msg.Items.Add(System.DateTime.Now.ToString()+"：写卡成功");
                //MessageBox.Show("Write Successfully.");
            }
            else
            {
                list_msg.Items.Add(System.DateTime.Now.ToString()+"：写卡失败，请重试");
                //MessageBox.Show("Write Failed.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.rfCard1.Close();
            this.txtRemoteCode.Text = "";
            list_msg.Items.Add(System.DateTime.Now.ToString()+"：读卡器关闭");
        }

        private void btnIntial_Click(object sender, EventArgs e)
        {
            if (this.rfCard1.Initialize(cmb_hcom.Text, cmb_braute.Text) == 0)
            {
                rfCard1.SetUIValue += new EventHandler(SetUIICCard);
                list_msg.Items.Add(System.DateTime.Now.ToString() + "：初始化成功");
            }
            else
            { list_msg.Items.Add(System.DateTime.Now.ToString() + "：初始化失败，请核查串口链接是否正确，或串口是否被占用"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new RFStart().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new RFStart0().ShowDialog();
        }


        private byte[] GetHexBytes(string strhex)
        {
            byte[] byout = new byte[strhex.Length / 2];
            for (int i = 0; i < strhex.Length / 2; i++)
            {
                byte a = Convert.ToByte(strhex.Substring(i * 2, 2), 16);
                MessageBox.Show(a.ToString());
                byout[i] = Convert.ToByte(strhex.Substring(i * 2, 2), 16);
            }
            return byout;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //设置功率
            if (this.rfCard1.SetRF(Convert.ToByte(comboBox1.Text)) == 0)
            {
                list_msg.Items.Add(System.DateTime.Now.ToString()+"：设置功率成功");
                //MessageBox.Show("设置成功");
            }
            else
            {
                list_msg.Items.Add(System.DateTime.Now.ToString() + "：设置功率失败");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {//查询功率
            string rf = this.rfCard1.GetRF();
            list_msg.Items.Add(System.DateTime.Now.ToString()+"：功率查询成功为 "+rf);
            comboBox1.Text = rf;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //结束读卡
            rfCard1.StopRead();
        }

        private void btnCosole_Click(object sender, EventArgs e)
        {
            //循环读卡
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            list_msg.Items.Clear();
        }

     
    }
}
