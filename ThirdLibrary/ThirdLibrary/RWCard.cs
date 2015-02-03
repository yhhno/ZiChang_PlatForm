using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ThirdLibrary
{
    /// <summary>
    /// IC卡操作
    /// author:huangcm
    /// date:2008-8-7
    /// </summary>
    public class RWCard
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="port">端口号</param>
        /// <param name="baud">波特率</param>
        /// <returns></returns>
        [DllImport("iccrf")]
        public static extern IntPtr rf_init(int port, long baud);

        /// <summary>
        /// 鸣叫
        /// </summary>
        /// <param name="hCom">打开的串口的句柄</param>
        /// <param name="time">鸣叫时间</param>
        /// <returns></returns>
        [DllImport("iccrf")]
        public static extern int rf_beep(IntPtr hCom, int time);

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <param name="hCom">打开的串口的句柄</param>
        /// <returns></returns>
        [DllImport("iccrf")]
        public static extern int rf_exit(IntPtr hCom);

        /// <summary>
        /// 寻卡，能返回在工作区域内某张卡的序列号
        /// </summary>
        /// <param name="hCom">打开的串口的句柄</param>
        /// <param name="Mode">寻卡模式(0 -- 一次只对一张卡操作，1 -- 一次可对多张卡操作)</param>
        /// <param name="Snr">卡的序列号</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("iccrf")]
        public static extern int rf_card(IntPtr hCom, int Mode, ref ulong Snr);

        /// <summary>
        /// 将十六进制密码装入读写模块RAM中
        /// </summary>
        /// <param name="icdev">被打开串口的句柄</param>
        /// <param name="Mode">装入密码模式，同密码验证模式对于M1卡的每个扇区，密码包括A密码（KEYA）和B密码（KEYB）用0，4来表示0： KEYA	4：KEYB	</param>
        /// <param name="SecNr">扇区号（0～15）</param>
        /// <param name="NKey">写入读写器中的卡密码</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("iccrf")]
        public static extern int rf_load_key_hex(IntPtr icdev, Int16 Mode, Int16 SecNr, string NKey);
        
        /// <summary>
        /// 验证某一扇区密码
        /// </summary>
        /// <param name="icdev">被打开串口的句柄</param>
        /// <param name="Mode">密码验证模式 0</param>
        /// <param name="SecNr">要验证密码的扇区号（0～15）</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("iccrf")]
        public static extern int rf_authentication(IntPtr icdev, Int16 Mode, Int16 SecNr);
        
        /// <summary>
        /// 初始化块值
        /// </summary>
        /// <param name="icdev">被打开串口的句柄</param>
        /// <param name="Adr">块地址（0～63）</param>
        /// <param name="Value">初始值</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("iccrf")]
        public static extern int rf_initval(IntPtr icdev,Int16 Adr,long Value);
        
        /// <summary>
        /// 读取卡中数据
        /// </summary>
        /// <param name="icdev">被打开串口的句柄</param>
        /// <param name="Adr">M1卡块地址（0～63）；ML卡页地址（0～11）</param>
        /// <param name="Data">返回读取的数据</param>
        /// <returns>成功则返回 0</returns>
        [DllImport("iccrf")]
        public static extern int rf_read_hex(IntPtr icdev, Int16 Adr, byte[] Data);
        
        /// <summary>
        /// 向卡中写入数据
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="Adr">M1卡块地址（0～63）；  ML卡页地址（2～11）</param>
        /// <param name="Data">要写入的数据</param>
        /// <returns>成功则返回0</returns>
        [DllImport("iccrf")]
        public static extern int rf_write_hex(IntPtr icdev,Int16 Adr,string Data);

        [DllImport("iccrf")]
        public static extern int rf_HL_authentication(IntPtr icdev,int reqmode, int snr,int authmode,int secnr);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="icdev">被打开串口的句柄</param>
        /// <param name="SecNr">扇区号</param>
        /// <param name="KeyA">A密码</param>
        /// <param name="B0"></param>
        /// <param name="B1"></param>
        /// <param name="B2"></param>
        /// <param name="B3"></param>
        /// <param name="BK"></param>
        /// <param name="KeyB">B密码</param>
        /// <returns></returns>
        [DllImport("iccrf")]
        public static extern int rf_changeb3(IntPtr icdev, Int16 SecNr, string KeyA, Int16 B0, Int16 B1, Int16 B2, Int16 B3, Int16 BK, string KeyB);
        [DllImport("iccrf")]
        public static extern int rf_changeb3(IntPtr icdev, Int16 SecNr, object[] KeyA, Int16 B0, Int16 B1, Int16 B2, Int16 B3, Int16 BK, object[] KeyB);

        /// <summary>
        /// 读取IC卡数据
        /// </summary>
        /// <param name="icdev">被打开串口的句柄</param>
        /// <param name="Adr">读取第几位</param>
        /// <param name="begin">读取的起始位置</param>
        /// <param name="len">读取的长度</param>
        /// <returns></returns>
        public static string ReadICCard(IntPtr icdev, short Adr, int begin, int len)
        {
            byte[] data = new byte[32];
            rf_read_hex(icdev, Adr, data);
            string strNO = "";
            for (int i = begin; i < (begin + len); i++)
            {
                strNO += Convert.ToString(data[i] - 48);
            }
            return strNO;
        }

    }
}
