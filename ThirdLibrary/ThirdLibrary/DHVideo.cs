using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using DHNetSDK;
using System.Runtime.InteropServices;
using DHPlaySDK;
using System.IO;
using System.Drawing.Imaging;

namespace ThirdLibrary
{
    /// <summary>
    /// 大华视频控件
    /// huangcm 2009-11-3
    /// </summary>
    public partial class DHVideo : UserControl
    {
        //视频各通道句柄
        private int iRealPlay;
        private fDisConnect disConnect;
        public NET_DEVICEINFO deviceInfo;
        private const string pMsgTitle = "天大天科大华视频控件";  //断线回调函数
        string _strServerIP="";
        int _iChannel=0;
        //判断抓图是否成功
        bool IsSuccess = true;
        byte[] bytePic = null;
        string _strPath = "";
        public static int iLogin;  //用户登录ID

        bool bolAmplified = false; //是否放大图像
        int _iAmplify = 2;

        int iRelativeT = 0;
        int iRelativeL = 0;
        Control parent = null;

        //判断是否已经登录视频机
        public static bool IsLogin = true;


        /// <summary>
        /// get or set 图像的放大倍数 默认为2倍
        /// </summary>
        [Description("图像的放大倍数 默认为2倍")]
        public int Amplify
        {
            get { return _iAmplify; }
            set { _iAmplify = value; }
        }

        public DHVideo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设备断开连接处理
        /// </summary>
        private void DisConnectEvent(int lLoginID, StringBuilder pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            MessageBox.Show("设备用户断开连接", pMsgTitle);
        }

        public PictureBox Pictrue
        {
            get { return this.Pic; }
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        /// <param name="strServerIP">视频IP</param>
        /// <param name="iChannel">通道号</param>
        /// <param name="strUserName">用户名</param>
        /// <param name="strPsw">密码</param>
        /// <param name="strPath">抓图存储路径 如：\\LoadWeightPic\\FrontImage.jpg</param>
        public void Initialize(string strServerIP, int iChannel, string strUserName, string strPsw, string strPath)
        {
            try
            {
                if (IsLogin)
                {
                    disConnect = new fDisConnect(DisConnectEvent);
                    DHClient.DHInit(disConnect, IntPtr.Zero);
                    DHClient.DHSetEncoding(LANGUAGE_ENCODING.gb2312);

                    deviceInfo = new NET_DEVICEINFO();
                    int iLoginError = 0;
                    iLogin = DHClient.DHLogin(strServerIP, ushort.Parse("37777"), strUserName, strPsw, out deviceInfo, out iLoginError);
                    IsLogin = false;
                }

                _strPath = strPath;
                _strServerIP = strServerIP;
                _iChannel = iChannel;
                iRealPlay = DHClient.DHRealPlay(iLogin, _iChannel, this.Pic.Handle);
            }
            catch(Exception ex)
            {
                Log.WriteLog("大华视频显示控件-初始化：", ex);
            }
        }

        
        /// <summary>
        /// 获取图片的byte[]
        /// </summary>
        /// <returns></returns>
        public byte[] CapturePic()
        {
            try
            {
                GetPic(iRealPlay);
                if (IsSuccess)
                {
                    return bytePic;
                }
                return null;
            }
            catch(Exception ex)
            {
                Log.WriteLog("大华视频显示控件-抓图：", ex);
                return null;
            }
        }
        /// <summary>
        /// 抓图处理
        /// </summary>
        /// <param name="iRealPlay"></param>
        /// <param name="bmpPath"></param>
        private void CapturePicture(int iRealPlay, string bmpPath)
        {
            if (DHClient.DHCapturePicture(iRealPlay, bmpPath))
            {
                if (IsSuccess)
                    IsSuccess = true;
                else
                    IsSuccess = false;
            }
            else
            {
                IsSuccess = false;
            }
        }
        private void GetPic(int iRealPlay)
        {
            string bmpPath = Application.StartupPath + _strPath;
            //抓图处理
            CapturePicture(iRealPlay, bmpPath);
            if (File.Exists(bmpPath))
                bytePic = ChangeImgToByte(bmpPath);
        }
        /// <summary>
        /// 根据图片路径，将图片转化为byte[]格式
        /// </summary>
        /// <param name="strImagePath"></param>
        /// <returns></returns>
        byte[] ChangeImgToByte(string strImagePath)
        {
            Image image = Image.FromFile(strImagePath);
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[ms.Length];
            ms.Read(buffer, 0, (int)ms.Length);//这里已经转成了字节   
            return buffer;
        }


        public void Close()
        {
            try
            {
                DHClient.DHLogout(iLogin);
                IsLogin = true;
            }
            catch(Exception ex)
            {
                Log.WriteLog("大华视频显示控件-关掉视频：", ex);
            }
        }

        ///// <summary>
        ///// 重新让视频显示在PictureBox上 
        ///// </summary>
        public void ShowVidio()
        {
            try
            {
                DHPlay.DHPlayControl(PLAY_COMMAND.ReSume, _iChannel);
            }
            catch (Exception ex)
            {
                Log.WriteLog("大华视频显示控件-重新显示视频：", ex);
            }
        }

        ///// <summary>
        ///// 视频清除，但仍可抓图
        ///// </summary>
        public void ClearVideo()
        {
            try
            {
                DHPlay.DHPlayControl(PLAY_COMMAND.Pause, _iChannel);
            }
            catch (Exception ex)
            {
                Log.WriteLog("大华视频显示控件-清除视频：", ex);
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        /// <summary>
        /// 获取某一控件的Form
        /// </summary>
        /// <param name="ctl"></param>
        /// <returns></returns>
        Control GetParent(Control ctl)
        {
            Control p = ctl.Parent;
            if (p.Parent==null)
                return p;
            else
                return GetParent(p);
        }

        //将视频放大和缩小并在窗体上居中显示
        private void Pic_Click(object sender, EventArgs e)
        {
            Control form = GetParent(this);
            if (!bolAmplified)
            {
                this.Width = this.Width * _iAmplify;
                this.Height = this.Height * _iAmplify;
                iRelativeT = this.Top;
                iRelativeL = this.Left;
                parent = this.Parent;
                parent.Controls.Remove(this);

                form.Controls.Add(this);
                //放大后图片居中
                this.Left = (Parent.ClientSize.Width - this.Width) / 2;
                this.Top = (Parent.ClientSize.Height - this.Height) / 2;
            }
            else
            {
                form.Controls.Remove(this);
                parent.Controls.Add(this);
                this.Width = this.Width / _iAmplify;
                this.Height = this.Height / _iAmplify;
                //再次点击回到原处
                this.Left = iRelativeL;
                this.Top = iRelativeT;
            }
            this.BringToFront();
            bolAmplified = !bolAmplified;
            iRealPlay = DHClient.DHRealPlay(iLogin, _iChannel, this.Pic.Handle);
        }
    }
}
