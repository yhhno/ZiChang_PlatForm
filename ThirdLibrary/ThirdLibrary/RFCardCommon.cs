using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ThirdLibrary
{
    /// <summary>
    /// 电子标签API
    /// </summary>
    public class RFCardCommon
    {

        /// <summary>
        /// 打开远程读卡器
        /// </summary>
        /// <param name="hCom">输出的串号句柄</param>
        /// <param name="com_port">需要打开的串号名 如 Com1</param>
        /// <returns>返回0，表示程序执行成功、其他是失败</returns>
        [DllImport("SeRFIDAPI02.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern short SeRFIDpub_Open(ref int _hCom, string com_port);


        /// <summary>
        /// 关闭远程读卡器
        /// </summary>
        /// <param name="hCom">传入的串号句柄</param>
        /// <param name="RAddr">传入读写器地址 地址：一般为255</param>
        /// <returns>状态 0 标示成功，其他失败</returns>
        [DllImport("SeRFIDAPI02.dll")]
        public static extern short SeRFIDpub_Close(int hCom, byte RAddr);

        /// <summary>
        /// 单标签读取标签数据
        /// </summary>
        /// <param name="hCom">传入的串号句柄</param>
        /// <param name="rAddr">传入读写器地址 地址：一般为255</param>
        /// <param name="QValue">传入的询问会话参数(1Byte:0-15),值越大一次读取的标签数越多，但读取的速度越慢。建议取值为4</param>
        /// <param name="Bank">标签中数据块的地址</param>
        /// <param name="Point">标签中数据块内的便宜地址</param>
        /// <param name="ReadLength">需要读出的数据长度，以Byte为单位</param>
        /// <param name="MaskLength">匹配条件Byte数</param>
        /// <param name="Mask">用于匹配条件的数组值</param>
        /// <param name="TagCount">返回读出的标签数指针，值为0或1，表示未读到标签，1表示读取到一张标签</param>
        /// <param name="DataLength">返回读取的数据长度，以Byte为单位</param>
        /// <param name="Data">返回读取的标签数据数组</param>
        /// <returns>状态 0 标示成功，其他失败</returns>
        [DllImport("SeRFIDAPI02.dll")]
        public static extern short SeRFIDGen2_SingleRead(int hCom, byte rAddr, byte QValue, byte Bank, byte Point, byte ReadLength, byte MaskLength, ref byte Mask, ref byte TagCount, ref byte DataLength, ref byte Data);


        /// <summary>
        /// 将当前频率范围的卡号到缓存中
        /// </summary>
        /// <param name="hCom">传入的串号句柄</param>
        /// <param name="rAddr">传入读写器地址 地址：一般为255</param>
        /// <param name="QValue">传入的询问会话参数(1Byte:0-15),值越大一次读取的标签数越多，但读取的速度越慢。建议取值为4</param>
        /// <param name="Bank">标签中数据块的地址</param>
        /// <param name="Point">标签中数据块内的便宜地址</param>
        /// <param name="ReadLength">需要读出的数据长度，以Byte为单位</param>
        /// <param name="MaskLength">匹配条件Byte数</param>
        /// <param name="Mask">用于匹配条件的数组值</param>
        /// <returns>状态 0 标示成功，其他失败</returns>
        [DllImport("SeRFIDAPI02.dll")]
        public static extern short SeRFIDGen2_MultiRead(int hCom, byte rAddr, byte QValue, byte Bank, byte Point, byte ReadLength, byte MaskLength, byte[] Mask);


        /// <summary>
        /// 读取缓存中的一条卡号，不删除
        /// </summary>
        /// <param name="hCom">传入的串号句柄</param>
        /// <param name="rAddr">传入读写器地址 地址：一般为255</param>
        /// <param name="tag_data">返回读取到的标签数据指针。标签数据的第一个字节表示该组数据的长度（不包含长度本身）</param>
        /// <returns>状态 0 标示成功，其他失败</returns>
        [DllImport("SeRFIDAPI02.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern short SeRFIDpub_BufGetOneNoClear(int hCom, byte rAddr, ref byte tag_data);


        /// <summary>
        /// 读取缓存中的一条卡号，不删除
        /// </summary>
        /// <param name="hCom">传入的串号句柄</param>
        /// <param name="rAddr">传入读写器地址 地址：一般为255</param>
        /// <param name="tag_data">返回读取到的标签数据指针。标签数据的第一个字节表示该组数据的长度（不包含长度本身）</param>
        /// <returns>状态 0 标示成功，其他失败</returns>
        [DllImport("SeRFIDAPI02.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern short SeRFIDpub_BufGetOneAndClear(int hCom, byte rAddr, ref byte tag_data);


        /// <summary>
        /// 写单标签
        /// </summary>
        /// <param name="hCom">传入的串号句柄</param>
        /// <param name="rAddr">传入读写器地址</param>
        /// <param name="QValue">传入的询问会话参数(1Byte:0-15),值越大一次读取的标签数越多，但读取的速度越慢。建议取值为4</param>
        /// <param name="Bank">标签中数据块的地址</param>
        /// <param name="Point">标签中数据块内的便宜地址</param>
        /// <param name="DataLen">将要写入数据的长度，以Byte为单位</param>
        /// <param name="Data">将要写入标签数据数组</param>
        /// <returns></returns>
        [DllImport("SeRFIDAPI02.dll")]
        public static extern short SeRFIDGen2_Write(int hCom, byte rAddr, byte QValue, byte Bank, byte Point, byte DataLen, byte[] Data);

        [DllImport("SeRFIDAPI02.dll")]
        public static extern short SeRFIDGen2_Write(int hcom, byte raddr, byte qvalue, byte bank, byte point, byte length, ref byte data);

        /// <summary>
        /// 设置缓存类型
        /// </summary>
        /// <param name="hCom">传入的串号句柄</param>
        /// <param name="rAddr">传入读写器地址</param>
        /// <param name="bufType">缓存类型 0：内部存储器 1：外部存储器 默认使用内部存储器</param>
        /// <returns></returns>
        [DllImport("SeRFIDAPI02.dll")]
        public static extern short SeRFIDpub_SysBufTypeSelSet(int hCom, byte rAddr, byte bufType);

        /// <summary>
        /// 查询读写器当前的缓存类型
        /// </summary>
        /// <param name="hCom">传入的串号句柄</param>
        /// <param name="rAddr">传入读写器地址</param>
        /// <param name="bufType">缓存类型 0：内部存储器 1：外部存储器</param>
        /// <returns></returns>
        [DllImport("SeRFIDAPI02.dll")]
        public static extern short SeRFIDpub_SysBufTypeSelQuery(int hCom, byte rAddr, ref byte bufType);

        /// <summary>
        /// 清空缓冲区 复位所有缓冲区指针
        /// </summary>
        /// <param name="hCom">传入的串号句柄</param>
        /// <param name="rAddr">传入读写器地址</param>
        /// <returns></returns>
        [DllImport("SeRFIDAPI02.dll")]
        public static extern short SeRFIDpub_BufCLRAll(int hCom, byte rAddr);

        /// <summary>
        /// 设置波特率
        /// </summary>
        /// <param name="hCom">传入的串号句柄</param>
        /// <param name="rAddr">传入读写器地址</param>
        /// <param name="bandRate">波特率值 0x04:9600 0x05:19200 0x06:38400 0x07:57400</param>
        /// <returns></returns>
        [DllImport("SeRFIDAPI02.dll")]
        public static extern short SeRFIDpub_SysSetBaudRate(int hCom, byte rAddr, byte bandRate);

        /// <summary>
        /// 结束读标签操作
        /// </summary>
        /// <param name="hCom">传入的串号句柄</param>
        /// <param name="rAddr">传入读写器地址</param>
        /// <returns></returns>
        [DllImport("SeRFIDAPI02.dll")]
        public static extern short SeRFIDGen2_End(int hCom, byte rAddr);

        /// <summary>
        /// 查询缓冲区中标签个数
        /// </summary>
        /// <param name="hCom">传入的串号句柄</param>
        /// <param name="rAddr">传入读写器地址</param>
        /// <param name="TagCount">返回标签数量</param>
        /// <returns></returns>
        [DllImport("SeRFIDAPI02.dll")]
        public static extern short SeRFIDpub_BufGetTagNum(int hCom, byte rAddr, ref byte TagCount);
        //public static extern byte SeRFIDpub_BufGetTagNum(int g_hCom, int g_Addr, ref int TagCount);

        //读标签
        [DllImport("SeRFIDAPI02.dll")]
        public static extern byte SeRFIDGen2_MultiReadID(int g_hCom, byte g_Addr, byte QValue, int MaskLength, byte[] Mask, ref byte TagCount);

        //获取版本号
        [DllImport("SeRFIDAPI02.dll")]
        public static extern byte SeRFIDpub_SysGetFirmwareRevision(int g_hCom, byte RAdrr, ref int MainVersion, ref int MinorVersion);

        [DllImport("SeRFIDAPI02.dll")]
        public static extern short SeRFIDGen2_Lock(int hcom, byte raddr, byte qvalue, ref byte pwd, byte select, byte action, byte bitcount, ref byte tagid);


        [DllImport("SeRFIDAPI02.dll")]
        public static extern short SeRFIDpub_SysTagAuthorizationQuery(int hcom, byte raddr, ref byte uac);

        [DllImport("SeRFIDAPI02.dll")]
        public static extern short SeRFIDpub_SysTagAuthorizationSet(int hcom, byte raddr);

        //设置功率
        [DllImport("SeRFIDAPI02.dll")]
        public static extern short SeRFIDpub_SysRFSet(int hcom,byte raddr,byte rf);//HANDLE hCom, unsigned char RAddr, unsigned char RF

        [DllImport("SeRFIDAPI02.dll")]
        public static extern short SeRFIDpub_SysRFQuery(int hcom, byte raddr, ref byte rf);//,ref byte rf  HANDLE hCom, unsigned char RAddr, unsigned char* RF
    }
}
