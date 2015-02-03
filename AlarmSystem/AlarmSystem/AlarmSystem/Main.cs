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
    public partial class LED屏幕报警显示 : Form
    {

        bool bSCL2008 = true;     //TRUE: 控制器为SCL2008, FALSE: 控制器为SuperComm
        int LedNum = 0;           //串口通讯: 控制器编号
        int ComPort = 1;          //串口通讯: 计算机串口号
        int Baudrate = 38400;     //串口通讯: 通讯速率

        bool bNet = false;        //TRUE: 使用网络收发, FALSE: 使用串口收发
        short mDevID = 9;          //任意的2字节通讯设备编号，这个值可以任意设置，只要不是0就行
        int TimeOut = 2;          //通讯超时上限
        int RetryTimes = 4;       //通讯重发次数

        short LedWidth = 384;     //区域宽
        short LedHeight = 96;     //区域高
        int CharColor = 255;      //文字颜色

        
        string strSend = "";//待发送的文字信息
        bool IsClosed = false;
        Thread thread;//声明线程

        //报警ID
        string strRecordID = "";
        //显示报警的时间
        DateTime time;
        //是否显示标题
        bool IsShowTitle = false;

        string strTitle = "";
        short shortX = 0;
        short shortY = 0;
        public LED屏幕报警显示()
        {
            InitializeComponent();
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //保存信息
            if (this.txtOperatePassword.Text.Trim() == "")
            {
                MessageBox.Show("请输入操作密码！", "天大天科",MessageBoxButtons.AbortRetryIgnore);
                return;
            }
            if (txtOperatePassword.Text == "tdtk")
            {
                //config配置
                AppConfig.SaveValue("Config", "IsConfigruation", "1");
                AppConfig.SaveValue("Config", "DBName", txtDBName.Text.Trim());
                AppConfig.SaveValue("Config", "DBServer", txtDBServer.Text.Trim());
                AppConfig.SaveValue("Config", "DBUserName", txtDBUserName.Text.Trim());
                AppConfig.SaveValue("Config", "DBPassWd", CryptDes.EncryptDES(txtPassWd.Text, "EncryDes"));
                //led配置
                AppConfig.SaveValue("LED", "ISConfigruation", "2");
                AppConfig.SaveValue("LED", "ComPort", comboBox1.Text);//串口通讯: 计算机串口号
                AppConfig.SaveValue("LED", "Baudrate", txt_ComBaudRate.Text);//波特率串口通讯: 通讯速率
                AppConfig.SaveValue("LED", "LedWidth", txt_LedWidth.Text);//区域宽
                AppConfig.SaveValue("LED", "LedHeight", txt_ledHeght.Text);//区域高
                AppConfig.SaveValue("LED", "CharColor", txt_CharColor.Text);//文字颜色
                AppConfig.SaveValue("LED", "Title", this.txtTitle.Text.Trim());
                AppConfig.SaveValue("LED", "X", this.txtX.Text.Trim());
                AppConfig.SaveValue("LED", "Y", this.txtY.Text.Trim());
                //AppConfig.SaveValue("LED","mDevID",textBox2.Text);//通讯设备编号
                MessageBox.Show("修改成功,更改后的配置将在系统重启后生效!", "循环报警系统", MessageBoxButtons.OK, MessageBoxIcon.Information); IsClosed = true; this.Close();
            }
            else
            {
                MessageBox.Show("您输入的密码不正确！", "天大天科", MessageBoxButtons.AbortRetryIgnore);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

            //form加载页面时执行
            if (AppConfig.ReadValue("Config", "IsConfigruation") == "1" && AppConfig.ReadValue("LED", "ISConfigruation")=="2")
            {
                //config配置
                txtDBName.Text = AppConfig.ReadValue("Config", "DBName");
                txtDBServer.Text = AppConfig.ReadValue("Config", "DBServer");
                txtDBUserName.Text = AppConfig.ReadValue("Config", "DBUserName");
                txtPassWd.Text = CryptDes.DecryptDES(AppConfig.ReadValue("Config", "DBPassWd"), "EncryDes");
                this.Text = this.Text + AppConfig.ReadValue("Config", "Version");

                //led配置
                ComPort = short.Parse(AppConfig.ReadValue("LED", "ComPort"));//串口通讯: 计算机串口号
                comboBox1.Text = ComPort.ToString();
                Baudrate = int.Parse(AppConfig.ReadValue("LED", "Baudrate"));//波特率串口通讯: 通讯速率
                txt_ComBaudRate.Text = Baudrate.ToString();
                
                LedWidth = short.Parse(AppConfig.ReadValue("LED", "LedWidth"));//区域宽
                txt_LedWidth.Text = LedWidth.ToString();
                LedHeight = short.Parse(AppConfig.ReadValue("LED", "LedHeight"));//区域高
                txt_ledHeght.Text = LedHeight.ToString();
                CharColor = short.Parse(AppConfig.ReadValue("LED", "CharColor"));//文字颜色
                txt_CharColor.Text = CharColor.ToString();

                this.txtTitle.Text = AppConfig.ReadValue("LED", "Title");//没有报警时显示的标题
                this.txtX.Text = AppConfig.ReadValue("LED", "X");  //显示标题的x坐标
                this.txtY.Text = AppConfig.ReadValue("LED", "Y");//显示标题的y坐标
                
                SqlHelp.ConnString = "Data Source=" + txtDBServer.Text + ";Initial Catalog=" + txtDBName.Text + ";User ID=" + txtDBUserName.Text + ";Password=" + txtPassWd.Text;

                //----------------------------------尝试判断数据库连接是否正确------------------------------------
                try
                {
                    this.Hide();
                    thread = new Thread(new ThreadStart(run));
                    thread.IsBackground = true;
                    thread.Start();
                    Control.CheckForIllegalCrossThreadCalls = false;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("数据库配置错误," + exc.Message.ToString(), "循环报警系统", MessageBoxButtons.OK, MessageBoxIcon.Error); Show(); this.Activate();
                }
                //------------------------------------------------------------------------------------------------
            }
            else
            {
                MessageBox.Show("请设置报警系统数据库和LED屏设置", "循环报警系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show(); WindowState = FormWindowState.Normal; txtPassWd.Text = ""; txtPassWd.Text = CryptDes.DecryptDES(AppConfig.ReadValue("Config", "DBPassWd"), "EncryDes");
            }
        }


        /// <summary>
        /// 隐藏窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsClosed)
            {
                WindowState = FormWindowState.Minimized; 
                Hide(); 
                this.notifyIcon1.Visible = true; 
                e.Cancel = true;
            }
        }


        /// <summary>
        /// 报警线程
        /// </summary>
        public void run()
        {
           showBadRecord();
           
        }



        public void clearLed()
        {
            //将整个屏幕信息清空
            string strClear = "                                                                   "
                            + "                                                                   "
                            + "                                                                   "
                            + "                                                                   "
                            + "                                                                   "
                            + "                                                                   "
                            + "                                                                   "
                            + "                                                                   "
                            + "                                                                   ";
            send(strClear, 30, 20,3,2);
        }
        /// <summary>
        /// 输出要报警的信息
        /// </summary>
        public void showBadRecord()
        {
            try
            {
                while (true)
                { 
                    string cmdText = "select top 1 RecordID,RoomName,Decript,BreakDate from VT_BadRecord where AlarmStatus<>1 and BreakDate>='"+DateTime.Today.ToString()+"' order by BreakDate desc";
                    DataTable dtRecord;
                    dtRecord = SqlHelp.ExecuteDataTable(CommandType.Text, cmdText, null);
                    //判断是否还是上个报警
                    if (dtRecord.Rows.Count > 0)
                    {
                        if (dtRecord.Rows[0]["RecordID"].ToString() != strRecordID)
                        {
                            strSend = dtRecord.Rows[0]["RoomName"].ToString()
                                + " 报警：" + dtRecord.Rows[0]["Decript"];
                            //发送之前先清一下屏
                            clearLed();
                            //LED屏显示报警信息
                            send(strSend, 30, 20,3,2);
                            //语音报警
                            Alarm(strSend);
                            strRecordID = dtRecord.Rows[0]["RecordID"].ToString();
                            time = DateTime.Now;
                            IsShowTitle = false;
                        }
                        else
                        {
                            TimeSpan ts = DateTime.Now-time;
                            if (ts.TotalSeconds >= 60)
                            {
                                if (!IsShowTitle)
                                {
                                    string strTitle = AppConfig.ReadValue("LED", "Title");
                                    shortX = Convert.ToInt16(this.txtX.Text.Trim());
                                    shortY = Convert.ToInt16(this.txtY.Text.Trim());
                                    clearLed();
                                    send(strTitle, shortX, shortY,3,8);//
                                    IsShowTitle = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!IsShowTitle)
                        {
                            string strTitle = AppConfig.ReadValue("LED", "Title");
                            shortX = Convert.ToInt16(this.txtX.Text.Trim());
                            shortY = Convert.ToInt16(this.txtY.Text.Trim());
                            clearLed();
                            send(strTitle, shortX, shortY,3,8); 
                            IsShowTitle = true;
                        }
                    }
                    Thread.Sleep(5000);
                }
            }
            catch(Exception ee)
            {
                Log.WriteLog("执行出现异常：" + ee.Message);
                //MessageBox.Show("数据库链接错误，请重新配置数据库信息");
                return;
            }
        }
 
      



        /// <summary>
        /// 发送到led方法
        /// </summary>
        /// <param name="s"></param>
        private void send(string S, short iX, short iY,short engFont,short hzFont)
        {
            try
            {
                bool bOK = false;
                Scl2008.TextInfoType TextInfo = new Scl2008.TextInfoType();

                if (bSCL2008)
                    TextInfo.Left = Convert.ToInt16(4096 - LedWidth);
                else
                    TextInfo.Left = Convert.ToInt16(960 - LedWidth);
                TextInfo.Top = 0;
                TextInfo.Width = LedWidth;
                TextInfo.Height = LedHeight;
                TextInfo.Color = CharColor;
                TextInfo.ASCFont = engFont;//英文字库默认3
                TextInfo.HZFont = hzFont;//汉字字库默认2
                //文本显示的起始位置 XPos 和YPose决定
                TextInfo.XPos = 0;
                TextInfo.YPos = 0;


                //通讯初始化
                if (!bNet)
                    bOK = Scl2008.SCL_ComInitial(mDevID, ComPort, Baudrate, LedNum, TimeOut, RetryTimes, bSCL2008);
                if (!bOK)
                {
                    //MessageBox.Show("发送 " +S + " 时初始化失败");
                    Log.WriteLog("发送  " + S + "  时初始化失败");
                }
                else
                {
                    Log.WriteLog("发送" + S + "初始化成功");
                }
                //显示文字串,自动排版,超出部分自动截断，最多1000个字符
                if (bOK)
                {

                    //文本显示的起始位置 XPos 和YPose决定
                    TextInfo.XPos = iX;
                    TextInfo.YPos = iY;
                    bOK = Scl2008.SCL_ShowString(mDevID, ref TextInfo.Left, S);
                    if (!bOK)
                    {
                        //MessageBox.Show("发送-----" + S + "-----信息失败");
                        Log.WriteLog("发送-----" + S + "-----信息失败");
                    }
                    else
                    {
                        Log.WriteLog("发送-----" + S + "-----信息成功");
                    }
                }
                Scl2008.SCL_Close(mDevID);//再打有打不上
                Log.WriteLog("关闭led屏");
            }
            catch (Exception ee)
            {
                Log.WriteLog("发送led屏时出现异常："+ee.Message);
            }
        }


        /// <summary>
        /// 语音报警
        /// <summary>
        public void Alarm(string strAlarm)
        {
            try
            {
                SpeechSynthesizer Talker = new SpeechSynthesizer();
                Talker.Rate = 2;//控制语速(-10--10)
                Talker.Volume = 100;//控制音量
                Talker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Child, 2, System.Globalization.CultureInfo.CurrentCulture);
                Talker.SpeakAsync(strAlarm);
            }
            catch (Exception ex)
            {
                Log.WriteLog("语音提示控件" + ex.ToString());
            }
        }


        /// <summary>
        /// 鼠标双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = true;
        }


        /// <summary>
        /// 当窗体尺寸改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }
    }
}
