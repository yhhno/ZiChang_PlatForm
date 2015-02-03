using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThirdLibrary
{



    public partial class LPR : UserControl
    {

        //临时图片存放路径
        string StrImgPath, StrIP;
        
        /// <summary>
        ///车牌识别事件
        /// </summary>
        [Description("用于判断是否是同一张卡的变量")]
        public event OnReceiveEventHandler OnReceive ;
        public LPR()
        {
            //定义车牌信息接收函数指针
            InitializeComponent();
            

        }

        /// <summary>
        ///用于判断是否是同一张卡的变量
        /// </summary>
        [Description("用于判断是否是同一张卡的变量")]
        public string IP
        {
            get { return StrIP; }
            set { StrIP = value; }
        }

        /// <summary>
        /// 获得车牌号相关信息
        /// </summary>
        /// <param name="imgCarNo">车牌号图片</param>
        /// <param name="strCarNo">车牌号字符串</param>
        /// <param name="timeOut">超时时间设定</param>
        /// <returns>状态0成功，1超时，2异常</returns>
        public int GetCarNoInfo(out System.Byte[] byteCarNo, out string strCarNo, int timeOut)
        {
            strCarNo = null;
            byteCarNo = null;
            try
            {

                //链接识别器
                axHVActiveX21.ConnectTo(StrIP);
                DateTime startTime = DateTime.Now;
                while (axHVActiveX21.GetStatus() != 0)
                {
                    System.Threading.Thread.Sleep(10);
                    TimeSpan ts = DateTime.Now - startTime;
                    if (ts.TotalMilliseconds > timeOut)
                    {
                        return 2;
                    }
                }
                axHVActiveX21.ForceSend();
                startTime = DateTime.Now;
                //如果没有得到图片则继续等待
                while (true)
                {
                    
                    TimeSpan ts = DateTime.Now - startTime;
                    strCarNo = axHVActiveX21.GetPlate();                  //取得车牌结果
                   
                    int ism  = axHVActiveX21.SavePlateImage(StrImgPath);           //保存车牌图片
                    if (ism == 0)
                        break;
                    //如过等待超时则返回超时状态
                    if (ts.TotalMilliseconds > timeOut)
                    {

                        return 1;//超时返回1
                    }
                   
                    System.Threading.Thread.Sleep(1000);
                }

                strCarNo = strCarNo.Substring(0, 2) + "-" + strCarNo.Substring(2);
                byteCarNo  = System.IO.File.ReadAllBytes(StrImgPath);
                return 0;

            }
            catch
            {

                return 2;
            }
            finally
            {
                axHVActiveX21.Disconnect();
            }

        }

        /// <summary>
        ///链接车牌识别器
        /// </summary>
        /// <param name="timeOut">超时时间 毫秒</param>
        /// <returns></returns>
        public bool Connect(int timeOut)
        {
            //链接识别器
            axHVActiveX21.ConnectTo(StrIP);
            DateTime startTime = DateTime.Now;
            while (axHVActiveX21.GetStatus() != 0)
            {
                System.Threading.Thread.Sleep(10);
                TimeSpan ts = DateTime.Now - startTime;
                if (ts.TotalMilliseconds > timeOut)
                {
                   return false; 
                }
            }

            return true;
        }

        /// <summary>
        /// 强制触发，车牌识别器。
        /// </summary>
        public void ForceSend()
        {
            axHVActiveX21.ForceSend(); 
        }


        /// <summary>
        ///断开车牌识别器
        /// </summary>
        /// <param name="timeOut">超时时间 毫秒</param>
        /// <returns></returns>
        public void Disconnect()
        {
            //链接识别器
            axHVActiveX21.Disconnect();
            
        }




        private void LPR_Load(object sender, EventArgs e)
        {
            //图片临时存放路径
            StrImgPath = System.IO.Directory.GetCurrentDirectory();
            StrImgPath += @"\";
            StrImgPath += "TDTKCARNO.bmp";
        }

        /// <summary>
        /// 车牌识别触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axHVActiveX21_OnReceivePlate(object sender, EventArgs e)
        {
            int ism = axHVActiveX21.SavePlateImage(StrImgPath);   
            string  strCarNo=axHVActiveX21.GetPlate();
            byte[] imgCarNo=System.IO.File.ReadAllBytes(StrImgPath);
            OnReceiveEventArgs args = new OnReceiveEventArgs(strCarNo, imgCarNo);
            OnReceive(sender, args);
        }


    }

    public delegate void OnReceiveEventHandler(object sender, OnReceiveEventArgs e);

    /// <summary>
    /// 事件类型
    /// </summary>
    public class OnReceiveEventArgs : EventArgs
    {
        private string _strCarNo = null;
        private byte[] _imgCarNo = null;

        public OnReceiveEventArgs(string strno,byte[] img)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            _strCarNo = strno;
            _imgCarNo = img;
        }

        /// <summary>
        /// 获取车牌号码
        /// </summary>
        public string StrCarNo
        {
            get
            {
                return _strCarNo;
            }

        }

        /// <summary>
        /// 获取车牌图片
        /// </summary>
        public byte[] ImgCarNo
        {
            get
            {
                return _imgCarNo;
            }

        }
    }

}
