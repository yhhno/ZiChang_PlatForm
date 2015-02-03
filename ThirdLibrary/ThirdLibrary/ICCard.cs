using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;

//added by huangcm
//2009-10-25
namespace ThirdLibrary
{
    [ToolboxBitmap(typeof(ICCard), "Resources.ICCard.bmp")]
    public partial class ICCard : Component
    {
        private int _iCom; //端口号
        private int _iBaudRate;//波特率
        private string _strPassWordA;//A区密码
        private string _strPassWordB;//B区密码

        private int _iBlock; //块号
        string _strReadBlockData;//读取到的某块的数据
        string _strWriteBlockData;//要写的某块数据
        private IntPtr _iPonter;//IC卡指针
        int _iValid = 0;//数据验证

        public EventHandler SetUIValue;      //定义这个是为了在控件外进行事件响应处理
        string _FactoryCode = ""; //IC卡内部编号

        int _iLen = 10;

        System.Timers.Timer tmTrick = new System.Timers.Timer();

        public ICCard()
        {
            InitializeComponent();
        }

        public ICCard(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        /// <summary>
        /// 蜂鸣
        /// </summary>
        public void Beep()
        {
            RWCard.rf_beep(_iPonter, 20);
        }

        /// <summary>
        /// 关闭读卡器串口
        /// </summary>
        public void Close()
        {
            try
            {
                RWCard.rf_exit(_iPonter);
                tmTrick.Stop();
                tmTrick.Close();
                tmTrick.Dispose();
                SetUIValue = null;
            }
            catch (Exception ex)
            {
                Log.WriteLog("IC卡读写控件-关闭串口", ex);
            }
        }

        /// <summary>
        ///用于判断是否是同一张卡的变量
        /// </summary>
        [Description("用于判断是否是同一张卡的变量")]
        public string FactoryCodeInitValue
        {
            get { return _FactoryCode; }
            set {_FactoryCode=value;}
        }
       
        /// <summary>
        /// IC卡初始化
        /// </summary>
        /// <param name="iCom"></param>
        /// <param name="iBaudRate"></param>
        /// <param name="strPassWordA"></param>
        /// <param name="strPassWordB"></param>
        /// <returns>1：初始化成功 0：初始化失败</returns>
        public int Initialize(int iCom, int iBaudRate, string strPassWordA, string strPassWordB)
        {
            try
            {
                _iCom = iCom;
                _iBaudRate = iBaudRate;
                _strPassWordA = strPassWordA;
                _strPassWordB = strPassWordB;
                _iPonter = RWCard.rf_init(iCom, iBaudRate);
                if (_iPonter.ToInt32() != -130)  //初始化成功
                {
                    tmTrick.Interval = 500;
                    return 1;
                }
                else //初始化失败
                    return 0;
            }
            catch(Exception ex)
            {
                Log.WriteLog("IC卡读写控件-初始化", ex);
                return 0;
            }
        }

        public int Initialize(int iCom, int iBaudRate, string strPassWordA, string strPassWordB,int iLen)
        {
            try
            {
                _iCom = iCom;
                _iBaudRate = iBaudRate;
                _strPassWordA = strPassWordA;
                _strPassWordB = strPassWordB;
                _iPonter = RWCard.rf_init(iCom, iBaudRate);
                _iLen = iLen;
                if (_iPonter.ToInt32() != -130)  //初始化成功
                {
                    tmTrick.Interval = 500;
                    return 1;
                }
                else //初始化失败
                    return 0;
            }
            catch (Exception ex)
            {
                Log.WriteLog("IC卡读写控件-初始化", ex);
                return 0;
            }
        }
        /// <summary>
        /// 获取IC卡自带编号
        /// </summary>
        /// <returns></returns>
        public string GetFactoryCode()
        {
            return _FactoryCode;
        }

        /// <summary>
        /// 读取IC卡某一块的数据 1：读取成功 0：读取失败 -1：密码验证失败 -2：未寻到卡
        /// </summary>
        /// <param name="iBlock">块号</param>
        /// <param name="iValid">读取结果 1：读取成功 0：读取失败 -1：密码验证失败 -2：未寻到卡</param>
        /// <returns></returns>
        public string ReadBlockData(int iBlock, ref int iValid)
        {
            _iBlock = iBlock;
            //读卡器初始化成功再读
            if (_iPonter.ToInt32() != -130)
            {
                tmTrick.Elapsed += new System.Timers.ElapsedEventHandler(ReadBlockDataEvent);
                tmTrick.Enabled = true;
            }
            Thread.Sleep(20);
            iValid = _iValid;
            return _strReadBlockData;
        }
        void  ReadBlockDataEvent(object sender, EventArgs e)
        {
            try
            {
                ulong uFactoryCode = 0;
                _strReadBlockData="";
                RWCard.rf_card(_iPonter, 0, ref uFactoryCode);
                if (uFactoryCode != 0)
                {
                    if ((_FactoryCode == string.Empty) || (uFactoryCode.ToString() != _FactoryCode))
                    {
                        tmTrick.Stop();
                        int iSec = _iBlock / 4;
                        RWCard.rf_load_key_hex(_iPonter, 0, Convert.ToInt16(iSec), _strPassWordA); //加载A密码
                        RWCard.rf_load_key_hex(_iPonter, 4, Convert.ToInt16(iSec), _strPassWordB); //加载B密码
                        int i = RWCard.rf_authentication(_iPonter, 0, Convert.ToInt16(iSec)); //验证密码
                        if (i == 0)
                        {
                            byte[] bytData = new byte[32];
                            i = RWCard.rf_read_hex(_iPonter, Convert.ToInt16(_iBlock), bytData);//读取_iBlock块区中的数据
                            
                            if (i == 0)
                            {
                                _strReadBlockData = DecConverString(bytData);
                                _FactoryCode = uFactoryCode.ToString();
                                _iValid = 1;  //读取成功
                                SetUIValue(sender, e);
                            }
                            else
                            {
                                _iValid = 0;  //读取失败
                            }
                        }
                        else
                        {
                            _iValid = -1; //密码验证失败
                        }
                    }
                }
                else
                {
                    _iValid = -2; //未寻到卡
                }
                tmTrick.Start();
            }
            catch(Exception ex)
            {
                Log.WriteLog("IC卡读写控件-读卡", ex);
            }
        }
        /// <summary>
        /// AscII码转换为数值
        /// </summary>
        /// <param name="bytSource"></param>
        /// <returns></returns>
        string DecConverString(byte[] bytSource)
        {
            string strConvertResult = string.Empty;

            for (int i = 0; i < 32; i++)
            {
                int iValue = Convert.ToInt32(bytSource[i]) - 48;
                strConvertResult += iValue.ToString();
            }
            return strConvertResult;
        }


        /// <summary>
        /// 请先执行ReadBlockData()这个方法，获取IC类型 1：标识卡  2：准运卡 3：临时卡
        /// </summary>
        /// <returns></returns>
        public string GetCardType()
        {
            if (_strReadBlockData != "")
                return _strReadBlockData.Substring(_iLen, 1);
            else
                return "";
        }

        /// <summary>
        /// 请先执行ReadBlockData()这个方法，获取IC自定义编号(卡面号)
        /// </summary>
        /// <returns></returns>
        public string GetCardCode()
        {
            if (_strReadBlockData != "")
                return _strReadBlockData.Substring(0, _iLen);
            else
                return "";
        }

        public string GetCoalKind()
        {
            if (_strReadBlockData != "")
                return _strReadBlockData.Substring(_iLen+2, 4);
            else
                return "";
        }


        /// <summary>
        /// 写数据 1：写入成功 0：写入失败 -1：密码验证失败 -2：未寻到卡
        /// </summary>
        /// <param name="iBlock">要写的块号</param>
        /// <param name="strBlockData">要写的数据</param>
        /// <returns></returns>
        public int WriteBlockData(int iBlock, string strBlockData)
        {
            try
            {
                _iBlock = iBlock;
                _strWriteBlockData = strBlockData;
                ulong uFactoryCode = 0;
                RWCard.rf_card(_iPonter, 0, ref uFactoryCode);
                if (uFactoryCode != 0)
                {
                    tmTrick.Stop();
                    int iSec = _iBlock / 4;
                    RWCard.rf_load_key_hex(_iPonter, 0, Convert.ToInt16(iSec), _strPassWordA);
                    RWCard.rf_load_key_hex(_iPonter, 4, Convert.ToInt16(iSec), _strPassWordB);
                    int i = RWCard.rf_authentication(_iPonter, 0, Convert.ToInt16(iSec));
                    if (i == 0)
                    {
                        i = RWCard.rf_write_hex(_iPonter, Convert.ToInt16(_iBlock), _strWriteBlockData);//往_iBlock块区中写入数据
                        Thread.Sleep(10);
                        if (i == 0)
                        {
                            RWCard.rf_beep(_iPonter, 20);
                            _iValid = 1; //写成功
                        }
                        else //写失败
                        {
                            _iValid = 0;
                        }
                    }
                    else
                    {
                        _iValid = -1;//密码验证失败
                    }
                }
                else
                {
                    _iValid = -2;
                }
                //转到读卡状态
                tmTrick.Start();
                return _iValid;
            }
            catch(Exception ex)
            {
                Log.WriteLog("IC卡读写控件-写卡", ex);
                return 0;
            }
        }
    }
}
