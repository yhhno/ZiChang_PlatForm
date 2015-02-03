using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Speech.Synthesis;

namespace AlarmSystem
{
    public partial class Alarmscl2008 : Form
    {  
        /// <summary>
        /// 不需要设置的默认属性
        /// </summary>
        bool bSCL2008 = true;     //'TRUE: 控制器为SCL2008, FALSE: 控制器为SuperComm        
        bool bOnlyShowStatic = false;   //TRUE: 只静止输出,不带移动效果, FALSE:试验发文件的方式
        bool bSendFile = false;         //TRUE: 用 SendFile 发送文件, FALSE:用SendData,SaveFile发送文件
        bool bNet = false;               //TRUE: 使用网络收发, FALSE: 使用串口收发
        int mDevID = 9;               //任意的2字节通讯设备编号

        /// <summary>
        /// 需要从ini文件中动态读取的
        /// </summary>
        string IPAddr;     //网络通讯: 控制器 IP 地址
        int UDPPort;           //网络通讯: UDP 端口号
        short LedNum;               //串口通讯: 控制器编号
        short ComPort;               //串口通讯: 计算机串口号
        int Baudrate;         //串口通讯: 通讯速率
        short TimeOut;              //通讯超时上限
        short RetryTimes;            //通讯重发次数
        int LedWidth;            //区域宽
        int LedHeight;            //区域高
        short CharColor;           //文字颜色

        string FileName = "Test.Txt";    //文本文件名

        string strSend="";//待发送的文字信息
        Thread t;//声明线程
        public Alarmscl2008(string ip, int udport, short lednum, short comport, int baudrate, short timeout, short retrytime, int width, int height, short color)
        {
            InitializeComponent();
            IPAddr = ip;
            UDPPort = udport;
            LedNum = lednum;
            ComPort = comport;
            Baudrate = baudrate;
            TimeOut = timeout;
            RetryTimes = retrytime;
            LedWidth = width;
            LedHeight = height;
            CharColor = color;
            this.SizeChanged += new System.EventHandler(this.Alarmscl2008_SizeChanged);
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

        private void send(string s)
        {
            string S = "";
            bool bOK = false;
            bool xb = false;

            Scl2008.TextInfoType TextInfo = new Scl2008.TextInfoType();

            if (bSCL2008)
                TextInfo.Left = 4096 - LedWidth;
            else
                TextInfo.Left = 960 - LedWidth;
            TextInfo.Top = 0;
            TextInfo.Width = LedWidth;
            TextInfo.Height = LedHeight;
            TextInfo.Color = CharColor;
            TextInfo.ASCFont = 1;
            TextInfo.HZFont = 2;
            TextInfo.XPos = 0;
            TextInfo.YPos = 0;

            //通讯初始化
            if (bNet)
                bOK = Scl2008.SCL_NetInitial(mDevID, "", IPAddr, TimeOut, RetryTimes, UDPPort, bSCL2008);
            else
                bOK = Scl2008.SCL_ComInitial(mDevID, ComPort, Baudrate, LedNum, TimeOut, RetryTimes, bSCL2008);

            if (!bOK)
                MessageBox.Show("初始化失败");

            if (!bOnlyShowStatic)
            {
                //删除移动播出的文本文件
                //仅实现静止显示则可不调用这个函数
                if (bOK)
                    bOK = Scl2008.SCL_RemoveFile(mDevID, 2, FileName);
                if (!bOK)
                    MessageBox.Show("删除文件失败");

                //重启节目表,使屏幕静止(因为节目表中的文本文件不存在了)
                //仅实现静止显示则可不调用这个函数
                if (bOK)
                {
                    if (bSCL2008)
                        bOK = Scl2008.SCL_Replay(mDevID, 0, 0);
                    else
                        bOK = Scl2008.SCL_Replay(mDevID, 1, 0);
                    if (!bOK)
                        MessageBox.Show("重启节目表失败");
                    Thread.Sleep(500);
                }
            }

            //显示文字串,自动排版,超出部分自动截断
            if (bOK)
            {
                bOK = Scl2008.SCL_ShowString(mDevID, TextInfo.Left, S);
                if (!bOK)
                    MessageBox.Show("文字直接输出失败");
            }

            Scl2008.SCL_Close(mDevID);
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

        private void Alarmscl2008_Load(object sender, EventArgs e)
        {
            //System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
            t = new Thread(new ThreadStart(run));
            t.IsBackground = true;
            t.Start();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = true;
        }

        private void Alarmscl2008_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowState = FormWindowState.Minimized; Hide(); e.Cancel = true;
        }

        private void Alarmscl2008_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }

    }
}
