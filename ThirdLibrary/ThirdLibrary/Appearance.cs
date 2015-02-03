using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Drawing;

namespace ThirdLibrary
{
    [ToolboxBitmap(typeof(Appearance), "Resources.Appearance.bmp")]
    public partial class Appearance : System.IO.Ports.SerialPort
    {
        private static string _strWeight = "";
        private static decimal _dWeight = Convert.ToDecimal("0.00");

        /// <summary>
        /// 获取磅秤数据
        /// </summary>
        public decimal Weight
        {
            get { return _dWeight;}
            set { _dWeight = value; }
        }


        /// <summary>
        /// 磅秤初始化及打开
        /// </summary>
        /// <param name="strCom">端口号 如：COM1,COM2...</param>
        /// <param name="iBaud">波特率</param>
        /// <returns>1：初始化成功 0：初始化失败 </returns>
        public int Initialize(string strCom, int iBaud, int iDataBits, string StopBits)
        {
            try
            {
                this.PortName = strCom;
                this.BaudRate = iBaud;
                this.Parity = System.IO.Ports.Parity.None;
                this.DataBits = iDataBits;
                if (StopBits == "1")
                {
                    this.StopBits = System.IO.Ports.StopBits.One;
                }
                else
                {
                    this.StopBits = System.IO.Ports.StopBits.Two;
                }

                if (!this.IsOpen)
                    this.Open();
                return 1;
            }
            catch (Exception ex)
            {
                Log.WriteLog("磅秤显示控件-打开端口", ex);
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

        public Appearance()
        {
            this.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Appearance_DataReceived);
        }

        /// <summary>
        /// 转半角的函数(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            string str = new string(c);
            //转化成大写
            return str.ToUpper();
        }

        public EventHandler SetUIValue; 
        /// <summary>
        /// 磅秤数据接受事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Appearance_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                _strWeight = _strWeight + this.ReadExisting();
                
                //处理类似01632031E+、NAa+00142000000000` 等格式的数据
                if ((_strWeight.IndexOf('+') > -1) && (_strWeight.Substring(_strWeight.IndexOf('+'), _strWeight.Length - _strWeight.IndexOf('+')).IndexOf("") > -1))
                {
                    if (_strWeight.Length >= 11)
                    {
                        _strWeight = _strWeight.Substring(_strWeight.IndexOf('+') + 1, 6).Trim();
                        if (_strWeight.IndexOf('-') > -1)
                        {
                            _dWeight = Convert.ToDecimal("0.00");
                        }
                        else
                        {
                            _dWeight = Convert.ToDecimal(Convert.ToDouble(_strWeight) / 1000);
                        }
                        _strWeight = ""; 
                        this.SetUIValue(sender, e);
                    }
                }
                else if (_strWeight.IndexOf("=.") > -1) //=.046100 转化成1.64
                {
                    if (_strWeight.Length >= 8)
                    {
                        _strWeight = _strWeight.Substring(_strWeight.IndexOf('.') + 1, 6).Trim();
                        if (_strWeight.IndexOf('-') > -1)
                        {
                            _dWeight = Convert.ToDecimal("0.00");
                        }
                        else
                        {
                            char[] arr = _strWeight.ToCharArray(); 
                            Array.Reverse(arr); 
                            _strWeight= new string(arr); 

                            _dWeight = Convert.ToDecimal(Convert.ToDouble(_strWeight) / 1000);
                        }
                        _strWeight = "";
                        this.SetUIValue(sender, e);
                    }
                }
                //处理类似=0411000、0411000=等格式的数据
                else if ((_strWeight.IndexOf('=') > -1) && (_strWeight.Substring(_strWeight.IndexOf('='), _strWeight.Length - _strWeight.IndexOf('=')).IndexOf("=") > -1))
                {
                    if (_strWeight.Length >= 7)
                    {
                        _strWeight = _strWeight.Substring(_strWeight.IndexOf('=') + 1, 6).Trim();

                        if (_strWeight.IndexOf('-') > -1)
                        {
                            _dWeight = Convert.ToDecimal("0.00");
                        }
                        else
                        {
                            string strReverseWeight = "";

                            for (int i = _strWeight.Length; i > 0; i--)
                            {
                                strReverseWeight += _strWeight[i - 1];
                            }
                            _dWeight = Convert.ToDecimal(Convert.ToDouble(strReverseWeight) / 1000);
                        }
                        _strWeight = ""; 
                        this.SetUIValue(sender, e);
                    }
                }
                else if ((_strWeight.IndexOf('+') > -1) && (_strWeight.Substring(_strWeight.IndexOf('+'), _strWeight.Length - _strWeight.IndexOf('+')).IndexOf("kg") > -1))
                {
                    _strWeight = _strWeight.Substring(_strWeight.IndexOf('+') + 2, 6).Trim();

                    _dWeight = Convert.ToDecimal(Convert.ToDouble(_strWeight) / 1000); _strWeight = ""; this.SetUIValue(sender, e);
                }
                else if ((_strWeight.IndexOf('.') > -1) && (_strWeight.Substring(_strWeight.IndexOf('.'), _strWeight.Length - _strWeight.IndexOf('.')).IndexOf("=") > -1))
                {
                    _strWeight = _strWeight.Substring(_strWeight.IndexOf('.') + 1, 6).Trim();

                    if (_strWeight.IndexOf('-') > -1)
                    {
                        _dWeight = Convert.ToDecimal("0.00");
                    }
                    else
                    {
                        string strReverseWeight = "";

                        for (int i = _strWeight.Length; i > 0; i--)
                        {
                            strReverseWeight += _strWeight[i - 1];
                        }

                        _dWeight = Convert.ToDecimal(Convert.ToDouble(strReverseWeight) / 1000);
                    }
                    _strWeight = ""; 
                    this.SetUIValue(sender, e);
                }
            }
            catch (Exception ex)
            {
                _dWeight = Convert.ToDecimal("0.00");
                Log.WriteLog("磅秤仪表显示控件-读数据", ex);
            }

        }
    }
}
