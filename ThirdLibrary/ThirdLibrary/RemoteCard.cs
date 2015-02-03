using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Drawing;

namespace ThirdLibrary
{
    [ToolboxBitmap(typeof(RemoteCard), "Resources.RemoteCard.bmp")]
    public partial class RemoteCard : System.IO.Ports.SerialPort
    {
        private static string _strRemoteCardCode = "";
        private static string _strRemoteCode ="";

        /// <summary>
        /// get or set远程卡卡号
        /// </summary>
        public string RemoteCode
        {
            get { return _strRemoteCode; }
            set { _strRemoteCardCode = value; }
        }

        public EventHandler SetUIValue;

        /// <summary>
        /// 远程卡初始化及打开
        /// </summary>
        /// <param name="strCom">端口号 如：COM1,COM2...</param>
        /// <param name="iBaud">波特率</param>
        /// <returns>1：初始化成功 0：初始化失败 </returns>
        public int Initialize(string strCom, int iBaud)
        {
            try
            {
                this.PortName = strCom;
                this.BaudRate = iBaud;
                this.DataBits = 8;
                this.Parity = System.IO.Ports.Parity.None;
                this.StopBits = System.IO.Ports.StopBits.One;
                if (!this.IsOpen)
                    this.Open();
                return 1;
            }
            catch (Exception ex)
            {
                Log.WriteLog("远程卡读取控件-打开端口", ex);
                return 0;
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public new void Close()
        {
            try
            {
                if (this.IsOpen)
                    base.Close();
            }
            catch
            { }
        }

        public RemoteCard()
        {
            this.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(RemoteCard_DataReceived);
        }

       
        /// <summary>
        /// 远程读卡器接收数据事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RemoteCard_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                //E002E0040000\n\rA002B7BC4502\n\rC002EFA44502

                string strReadRemoteCode = this.ReadExisting();

                strReadRemoteCode = AnalyzeRemoteCardCode(strReadRemoteCode);

                string[] arReadRemoteCode = strReadRemoteCode.Split(',');

                for (int i = 0; i < arReadRemoteCode.Length; i++)
                {
                    if (_strRemoteCardCode.Contains(arReadRemoteCode[i].ToString()))
                    {

                    }
                    else
                    {
                        _strRemoteCardCode = _strRemoteCardCode + arReadRemoteCode[i].ToString() + ",";
                    }
                }
                //_strRemoteCardCode = strReadRemoteCode;
                if (_strRemoteCardCode != "")
                {
                    _strRemoteCode = _strRemoteCardCode;
                }
                SetUIValue(sender, e);
            }
            catch (Exception ex)
            {
                Log.WriteLog("远程卡读取控件-读数据", ex);
            }
        }

        /// <summary>
        /// 解析远程卡卡号
        /// </summary>
        /// <param name="strLongCard">读取的IC卡卡号</param>
        /// <returns></returns>
        #region 解析远程卡卡号
        public string AnalyzeRemoteCardCode(string strLongCard)
        {
            string strremotecode = "";

            try
            {
                char ca = new char();
                ca = Convert.ToChar("");
                //分析读取到的远程卡
                string[] LongCards = strLongCard.Split(ca);

                for (int i = 1; i <= LongCards.Length - 1; i++)
                {//如果数据不等于空或者数据长度不小于11
                    if (LongCards[i].ToString() != "" && LongCards[i].ToString().Length > 11)
                    {
                        strremotecode = strremotecode + LongCards[i].Substring(LongCards[i].LastIndexOf("\n\r") - 11, 11) + ",";
                    }
                }
            }
            catch
            {
                strremotecode = "";
            }

            return strremotecode;
        }
        #endregion
    }
}
