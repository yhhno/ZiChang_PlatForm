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
    public partial class CarNo : Form
    {
        public CarNo()
        {
            InitializeComponent();
        }

        private void CarNo_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //byte[] bimg;
            //string carno;
            //if (lpr1.GetCarNoInfo(out bimg, out carno, 100000) == 0)
            //{
            //    System.IO.MemoryStream ms = new System.IO.MemoryStream(bimg);
            //    this.pictureBox1.Image = Image.FromStream(ms);
            //    this.label1.Text = carno;
            //}
            //else
            //{
            //    this.label1.Text = "识别失败";
            //}

            //设置车牌识别器的ip地址
            lpr1.IP = "192.168.1.222";
            //链接车品牌识别器
            lpr1.Connect(100000);
            //强制触发车牌识别器
            lpr1.ForceSend();

            //不使用车牌识别器时请关闭识别器；
            //lpr1.Disconnect();
            //
            //
            
        }

        /// <summary>
        /// 车品牌识别事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lpr1_OnReceive(object sender, ThirdLibrary.OnReceiveEventArgs e)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(e.ImgCarNo);
            this.pictureBox1.Image = Image.FromStream(ms);
            this.label1.Text = "车牌号码："+e.StrCarNo;
            textBox1.Text = textBox1.Text + e.StrCarNo + ",";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] b=null;
            this.scanControl1.AutoScanFile(out b);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ms.Write(b,0,b.Length);
            this.pictureBox2.Image = Image.FromStream(ms);
            
        }

        private void CarNo_FormClosing(object sender, FormClosingEventArgs e)
        {
            lpr1.Disconnect();
        }
    }
}
