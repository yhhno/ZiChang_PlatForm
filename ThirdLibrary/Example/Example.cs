using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Collections;
using System.IO.Ports;

namespace WindowsFormsApplication1
{
    public partial class Example : Form
    {
        public delegate void SetUIDelegate();

        delegate void RemoteCardDelegate();

        public Example()
        {
            InitializeComponent();
            //ICCard初始化设置
            //this.icCard1.Initialize(3, 9600, "433834313945", "433834313945");
            //////读取到IC卡后要设置的界面元素，比如 煤种，煤矿，车主。。。。
            //icCard1.SetUIValue += new EventHandler(SetUIICCard);
            //int i = 0;
            //this.icCard1.ReadBlockData(1, ref i);

           // 磅秤初始化   远程卡使用与磅秤一样
            
            InitRemoteCard();
        }

        #region 磅秤读取
        void SetUIAppearance(object sender, EventArgs e)
        {
            SetUIDelegate delgate = null;
            delgate += new SetUIDelegate(SetPoundValue);
            while (!this.IsHandleCreated) { ;}
            this.BeginInvoke(delgate, null);
        }
        void SetPoundValue()
        {
            this.txtPound.Text = this.appearance1.Weight.ToString();
        }
        #endregion



        #region ICCard读取
        public void SetUIICCard(object sender, EventArgs args)
        {
            try
            {
                SetUIDelegate delgate = null;
                delgate += new SetUIDelegate(SetICCValue);
                while (!this.IsHandleCreated) { ;}
                this.BeginInvoke(delgate, null);
            }
            catch(Exception ex)
            {
                Log.WriteLog("IC卡 委托", ex.ToString());
            }
        }
        private void SetICCValue()
        {
            try
            {
                this.txtICCardValue.Text = icCard1.GetFactoryCode();
                //this.txtCardCode.Text = icCard1.GetCardCode();
                this.icCard1.Beep();
            }
            catch(Exception ex)
            {
                Log.WriteLog("IC卡给控件赋值", ex.ToString());
            }
        }
        #endregion


        private void btnWrite_Click(object sender, EventArgs e)
        {
            int i=this.icCard1.WriteBlockData(1,"202020202021".PadRight(32,'0'));
        }

        private void btnReadDate_Click(object sender, EventArgs e)
        {
            int iRead=0;
            string strData = this.icCard1.ReadBlockData(1,ref iRead);
            MessageBox.Show(strData+"状态为："+iRead);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strFactoryCode = this.icCard1.GetFactoryCode();
            MessageBox.Show(strFactoryCode);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //需安装中文语音包
            //this.alarmSound1.Alarm("黄春梅");
            this.dhVideo1.Pictrue.Image = Image.FromFile(Application.StartupPath+"\\aa.png");
        }

        void InitRemoteCard()
        {
            int i = this.remoteCard1.Initialize("COM3", 9600);
            if (i == 0)
                this.alarmSound1.Alarm("远程卡初始化失败");
            else
                this.remoteCard1.SetUIValue += new EventHandler(SetUIRemote);

        }
        void SetUIRemote(object sender, EventArgs args)
        {
            RemoteCardDelegate delgate = null;
            delgate += new RemoteCardDelegate(SetUIRemoteValue);
            this.BeginInvoke(delgate, null);
        }
        void SetUIRemoteValue()
        {
            this.textBox1.Text = this.remoteCard1.RemoteCode;
        }

        private void Example_FormClosing(object sender, FormClosingEventArgs e)
        {
            remoteCard1.Close();
        }

        private void Example_Load(object sender, EventArgs e)
        {

        }

        private void btnSetBang_Click(object sender, EventArgs e)
        {
            int iState = this.appearance1.Initialize(combCom.Text, Convert.ToInt32(combPort.Text), Convert.ToInt32(combStop.Text), "1");
            //读取到磅秤数据后要设置的界面元素
            if (iState == 1)
            {
                this.appearance1.SetUIValue += new EventHandler(SetUIAppearance);
            }
            else
            {
                MessageBox.Show("磅秤打开失败");
            }
        }

        private void btnStopBang_Click(object sender, EventArgs e)
        {
            appearance1.Close(); txtPound.Text = "";
        }

    }
}
