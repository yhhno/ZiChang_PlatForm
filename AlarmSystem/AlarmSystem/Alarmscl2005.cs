using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;

namespace AlarmSystem
{
    public partial class Alarmscl2005 : Form
    {
        private string strSend = "";
        private bool IsClosed = false;
        Thread t;
        short CardType = 1;          //控制卡类型,2型卡
        short ComPort = 6;          //串口1
        int ComBaudRate = 38400;  //通讯速率
        short ComDelay = 1000;      //延时
        short LedNum = 0;           //屏号
        short LedWidth = 448;       //屏宽
        short LedHeight = 64;      //屏高
        short LedColor = 1;         //双色屏
        public Alarmscl2005(short cardtype, short comport, int combaudrate, short lednum, short comdelay, short ledwidth, short ledheight, short ledcolor)
        {
            InitializeComponent();
            CardType = cardtype;
            ComPort = comport;
            ComBaudRate = combaudrate;
            ComDelay = comdelay;
            LedNum = lednum;
            LedWidth = LedWidth;
            LedHeight = ledheight;
            LedColor = ledcolor;
            this.SizeChanged += new System.EventHandler(this.AlarmThread_SizeChanged);
        }


        private void send(string strSend)
        {
            byte[] val = System.Text.Encoding.Default.GetBytes(strSend);
            axCL2005Ocx1.ComInitial(ComPort, ComBaudRate, ComDelay);
            axCL2005Ocx1.SetLEDProperty(CardType, LedNum, LedWidth, LedHeight, LedColor, 0);
            int iLen = val.Length;
            IntPtr p = Marshal.AllocHGlobal(iLen);
            Marshal.Copy(val, 0, p, iLen);
            axCL2005Ocx1.ShowString(0, 0, 0, 1, (int)p);
            bool OK = axCL2005Ocx1.SwitchToBank(0);
            axCL2005Ocx1.CloseCL2005();
            //if (OK)
            //    MessageBox.Show("发送成功");
            //else
            //    MessageBox.Show("发送失败");

        }
        /// <summary>
        /// 语音提示
        /// <summary>
        public void sayword(string strAlarm)
        {
            try
            {
                SpeechSynthesizer Talker = new SpeechSynthesizer();
                Talker.Rate = 2;//控制语速(-10--10)
                Talker.Volume = 100;//控制音量

                #region 获取本机上所安装的所有的Voice的名称
                //string voicestring = "";

                //foreach (InstalledVoice iv in Talker.GetInstalledVoices())
                //{
                //    voicestring += iv.VoiceInfo.Name + ",";
                //}
                //Microsoft Mary,Microsoft Mike,Microsoft Sam,Microsoft Simplified Chinese,SampleTTSVoice
                //Talker.SelectVoice("Microsoft Mary");
                #endregion

                //Talker.SetOutputToWaveFile("c:\soundfile.wav");//读取文件

                Talker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Child, 2, System.Globalization.CultureInfo.CurrentCulture);
                Talker.SpeakAsync(strAlarm);
            }
            catch (Exception ex)
            {
                Log.WriteLog("语音提示控件" + ex.ToString());
            }
        }   
        
        
        /// <summary>
        /// 报警线程
        /// </summary>
        public void run()
        {
            strSend = "正在初始化...";
            label1.Text = "正在初始化...";
            send(strSend);
            Thread.Sleep(5000);
            showBreakRecord();
            Thread t1 = new Thread(new ThreadStart(showBadRecord));
            t1.IsBackground = true;
            t1.Start();
            while (true)
            {
                //-----设置断网信息输出时间间隔-----
                Thread.Sleep(120000);
                t1.Suspend();
                showBreakRecord();
                t1.Resume();
            }
        }

        /// <summary>
        /// 输出断网信息
        /// </summary>
        public void showBreakRecord()
        {
            string cmdText = "select RoomName,OffLineBegin,OffLineTime from TT_Room where OnOff=0";//0未处理，1处理过的
            DataTable DB_breakLineRecord = SqlHelp.ExecuteDataTable(CommandType.Text, cmdText, null);
            for (int i = 0; i < DB_breakLineRecord.Rows.Count; i++)
            {
                strSend = DB_breakLineRecord.Rows[i][0].ToString() + "在" + DB_breakLineRecord.Rows[i][1].ToString() + "断网，时间为" + DB_breakLineRecord.Rows[i][2].ToString() + "分钟";
                send(strSend);
                label1.Text = strSend;
                sayword(strSend);
                //------设置每条输出信息时间间隔-------
                Thread.Sleep(10000);
            }
        }

        /// <summary>
        /// 输出要报警的信息
        /// </summary>
        public void showBadRecord()
        {
            string cmdText = "select CarNo,Decript,BreakDate from TT_BadRecord where AlarmStatus=0";//不正常的信息
            DataTable DB_badRecord;
            while (true)
            {
                DB_badRecord = SqlHelp.ExecuteDataTable(CommandType.Text, cmdText, null);
                for (int i = 0; i < DB_badRecord.Rows.Count; i++)
                {
                    strSend = "CarNo:" + DB_badRecord.Rows[i][0].ToString() + "Descrip:" + DB_badRecord.Rows[i][1].ToString() + ",BreakDate:" + DB_badRecord.Rows[i][2].ToString();
                    send(strSend);
                    label1.Text = strSend;
                    sayword(strSend);
                    //-------设置每条报警信息时间间隔--------
                    Thread.Sleep(10000);
                }
                Thread.Sleep(10000);
            }
        }

        private void AlarmThread_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
            t = new Thread(new ThreadStart(run));
            t.IsBackground = true;
            t.Start();
        }

        private void AlarmThread_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = true;
        }

        private void AlarmThread_FormClosing(object sender, FormClosingEventArgs e)
        {
           WindowState = FormWindowState.Minimized; Hide(); e.Cancel = true;
        }

    }
}
