using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThirdLibrary
{
    /// <summary>
    /// author:huangcm
    /// 2009-12-10
    /// </summary>
    public partial class RFCard : Component
    {
        public RFCard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置读写器地址
        /// </summary>
        const byte _RAddr = 0xff;

        //串口号
        string _Port = "";

        //波特率
        byte _BoudRate = 0;

        //功率
        byte _rf;

        //打开句柄
        static int _Hcom = -1;
        //电子标签读卡器状态
        static short iStatus = 1;
        //时间控件是否关闭

        System.Timers.Timer tmTrick = new System.Timers.Timer();

        public EventHandler SetUIValue;      //定义这个是为了在控件外进行事件响应处理

        public RFCard(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        byte TagCount = 0x00;//返回的标签数变量
        /// <summary>
        /// 获取电子标签的数量
        /// </summary>
        public byte CardCount
        {
            get { return TagCount; }
        }

        string _CardCode = "";
        //获取卡号
        public string CardCode
        {
            get
            {
                if (_CardCode != "")
                    return _CardCode.Remove(_CardCode.Length - 1);
                else
                    return "";
            }
            set { _CardCode = value; }
        }

        //转换波特率
        byte ChangeBoudRate(string value)
        {
            byte _byteBoud = 0x00;
            if (value.ToString() == "300")
            {
                _byteBoud = 0x00;
            }
            if (value.ToString() == "600")
            {
                _byteBoud = 0x01;
            }
            if (value.ToString() == "2400")
            {
                _byteBoud = 0x02;
            }
            if (value.ToString() == "4800")
            {
                _byteBoud = 0x03;
            }
            if (value.ToString() == "9600")
            {
                _byteBoud = 0x04;
            }
            if (value.ToString() == "19200")
            {
                _byteBoud = 0x05;
            }
            if (value.ToString() == "38400")
            {
                _byteBoud = 0x06;
            }
            if (value.ToString() == "57600")
            {
                _byteBoud = 0x07;
            }
            if (value.ToString() == "115200")
            {
                _byteBoud = 0x08;
            }
            return _byteBoud;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="strPort"></param>
        /// <param name="boudRate"></param>
        /// <param name="bAddr"></param>
        /// <returns></returns>
        public short Initialize(string strPort, string boudRate)
        {
            _Port = strPort;
            _BoudRate = ChangeBoudRate(boudRate);
            if (iStatus != 0)
            {
                iStatus = RFCardCommon.SeRFIDpub_Open(ref _Hcom, _Port);
                if (iStatus == 0)
                {
                    iStatus = RFCardCommon.SeRFIDpub_SysSetBaudRate(_Hcom, _RAddr, _BoudRate);
                    tmTrick.Interval = 200;
                    tmTrick.Elapsed += new System.Timers.ElapsedEventHandler(RfRead);
                    tmTrick.Enabled = true;
                    tmTrick.Start();
                }
            }
            return iStatus;

        }


        
        //读卡
        void RfRead(object sender, EventArgs e)
        {
            //------------------------------------单标签读方式(start)--------------------------------------------
            //try
            //{
            //    byte[] TagData = new byte[13];
            //    byte QValue = 2;
            //    byte[] TagID = new byte[25];
            //    byte TagCount = 0;
            //    byte Bank = 1, Point = 0, ReadLen = 12;//标签号的块地址，与块内偏移量，以及标签长度
            //    byte MaskLength = 0;//用于匹配的长为0，即不匹配标签，对所有标签都进行操作
            //    byte[] Mask = new byte[16];
            //    iStatus = RFCardCommon.SeRFIDGen2_MultiReadID(_Hcom, _RAddr, QValue, 0, Mask, ref TagCount);
            //    if (iStatus == 0)
            //    {
            //        tmTrick.Stop();
            //        iStatus = RFCardCommon.SeRFIDpub_BufGetTagNum(_Hcom, _RAddr, ref TagCount);
            //        if (TagCount > 0)
            //        {
            //            for (int i = 0; i < TagCount; i++)
            //            {
            //                iStatus = RFCardCommon.SeRFIDpub_BufGetOneAndClear(_Hcom, _RAddr, ref TagID[0]);
            //                string strID = "";
            //                if (iStatus == 0)
            //                {
            //                    for (int j = 1; j < 13; j++)
            //                    {
            //                        //if (TagID[j] < 16)
            //                        //    strID = strID;
            //                        strID = strID + Convert.ToString(TagID[j], 16);
            //                    }
            //                    if (!_CardCode.Contains(strID) && strID != "000000000000")
            //                    {
            //                        _CardCode = _CardCode + strID + ",";
            //                    }
            //                    if (SetUIValue != null)
            //                    {
            //                        SetUIValue(sender, e);
            //                    }
            //                }
            //            }
            //        }
            //        tmTrick.Start();
            //    }
            //    iStatus = RFCardCommon.SeRFIDGen2_End(_Hcom, _RAddr);
            //}
            //catch
            //{ }
            //------------------------------------单标签读方式(e n d)--------------------------------------------



            
            //------------------------------------多标签读方式(start)--------------------------------------------
            try
            {
                byte[] TagData = new byte[13];
                byte QValue = 4;
                byte Bank = 1, Point = 0, ReadLen = 12;//标签号的块地址，与块内偏移量，以及标签长度
                byte MaskLength = 0;//用于匹配的长为0，即不匹配标签，对所有标签都进行操作
                byte[] Mask = new byte[16];

                tmTrick.Stop();

                if (iStatus == 0 && RFCardCommon.SeRFIDGen2_MultiRead(_Hcom, _RAddr, QValue, Bank, Point, ReadLen, MaskLength, Mask) == 0 && RFCardCommon.SeRFIDpub_BufGetTagNum(_Hcom, _RAddr, ref TagCount) == 0)
                {
                    for (int i = 1; i <= TagCount; i++)
                    {
                        if (iStatus == 0 && RFCardCommon.SeRFIDpub_BufGetOneAndClear(_Hcom, _RAddr, ref TagData[0]) == 0)
                        {
                            if (TagData.Length == 13)
                            {
                                string strRemoteCardCode = "";
                                for (int j = 1; j < TagData.Length; j++)
                                {
                                    try
                                    {
                                        short BTagData = TagData[j];
                                        string data = Convert.ToString(TagData[j], 16);
                                        strRemoteCardCode = strRemoteCardCode + data.PadLeft(2, '0');
                                    }
                                    catch
                                    {
                                        break;
                                    }
                                }
                                //暂时用最后10位
                                strRemoteCardCode = strRemoteCardCode.Substring(14);
                                if (!_CardCode.Contains(strRemoteCardCode) && strRemoteCardCode != "000000000000")
                                {
                                    _CardCode = _CardCode + strRemoteCardCode + ",";
                                }
                                if (SetUIValue != null)
                                {
                                    SetUIValue(sender, e);
                                }
                            }
                        }
                    }
                }
                tmTrick.Start();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //------------------------------------多标签读方式(e n d)--------------------------------------------
        }

        private byte[] GetHexBytes(string strhex)
        {
            byte[] byout = new byte[strhex.Length / 2];
            for (int i = 0; i < strhex.Length / 2; i++)
            {
                byout[i] = Convert.ToByte(strhex.Substring(i * 2, 2), 16);
            }
            return byout;
        }


       
        //写卡
        public short RfWrite(string strRemoteCardCode)
        {
            short status = -1;
            if (_Hcom > 0)
            {
                _CardCode = "";
                tmTrick.Stop();
                //定义电子标签读卡器参数
                byte QValue = 2, Bank = 1, Point = 0, DataLen = 12;
                byte[] TagData = new byte[12];
                TagData = GetHexBytes(strRemoteCardCode.PadLeft(24, '0'));
                status = RFCardCommon.SeRFIDGen2_Write(_Hcom, _RAddr, QValue, Bank, Point, DataLen, ref TagData[0]);
                if (status == 0)
                    tmTrick.Start();
            }
            return status;



            //tmTrick.Stop();
            //byte[] m_byPwd = GetHexBytes("88888888");
            //short status = -1;
            //byte[] bydata = new byte[12];
            //status=RFCardCommon.SeRFIDpub_SysTagAuthorizationQuery(_Hcom, 0, ref bydata[0]);
            //if (status== 0)
            //{
            //    if (bydata[0] != 0)
            //    {
            //        bydata = GetHexBytes(strRemoteCardCode.PadLeft(24, '0'));
            //        if (RFCardCommon.SeRFIDGen2_Write(_Hcom, 0, 4, 1, 0, 12, ref bydata[0]) == 0
            //            && RFCardCommon.SeRFIDpub_SysTagAuthorizationSet(_Hcom, 0) == 0)
            //        {
            //            status = RFCardCommon.SeRFIDGen2_Write(_Hcom, 0, 4, 0, 0, 4, ref m_byPwd[0]);
            //            if (status == 0)
            //            {
            //                status = -1;
            //                if (RFCardCommon.SeRFIDGen2_Write(_Hcom, 0, 4, 0, 0, 4, ref m_byPwd[0]) == 0
            //                    && RFCardCommon.SeRFIDGen2_Lock(_Hcom, 0, 4, ref m_byPwd[0], 1, 0, 96, ref bydata[0]) == 0
            //                    && RFCardCommon.SeRFIDGen2_Lock(_Hcom, 0, 4, ref m_byPwd[0], 0, 0, 96, ref bydata[0]) == 0
            //                    && RFCardCommon.SeRFIDGen2_Lock(_Hcom, 0, 4, ref m_byPwd[0], 4, 0, 96, ref bydata[0]) == 0
            //                    && RFCardCommon.SeRFIDGen2_Lock(_Hcom, 0, 4, ref m_byPwd[0], 3, 0, 96, ref bydata[0]) == 0)
            //                {
            //                    status = 0;
            //                }
            //            }
            //        }
            //    }
            //}
            //tmTrick.Start();
            //return status;
        }

        //设置功率
        public short SetRF(byte rf)
        {
            iStatus = RFCardCommon.SeRFIDpub_SysRFSet(_Hcom, _RAddr,rf);
            _rf = rf;
            return iStatus;
        }


        //读取功率
        public string GetRF()
        {

            iStatus = RFCardCommon.SeRFIDpub_SysRFQuery(_Hcom, _RAddr,ref _rf);
            return _rf.ToString();
            //return iStatus;
        }

        //关闭读卡器
        public void Close()
        {
            iStatus = RFCardCommon.SeRFIDpub_Close(_Hcom, _RAddr);
            iStatus = 1;
            _Hcom = -1;
            _CardCode = "";
            tmTrick.Stop();
            tmTrick.Close();
            SetUIValue = null;
        }

        //结束读卡
        public void StopRead()
        {
            tmTrick.Enabled = false;
        }

        //开始循环读卡
        public void StartRead(double tm)
        {
            tmTrick.Interval = tm;
            tmTrick.Enabled = true;
            tmTrick.Elapsed += new System.Timers.ElapsedEventHandler(RfRead);
            tmTrick.Start();
        }
    }
}
