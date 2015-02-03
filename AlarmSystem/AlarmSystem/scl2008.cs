using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

public class Scl2008
{
    [DllImport("SCL_API_Stdcall", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool SCL_NetInitial(short DevID, string Password, string IP, int TimeOut, int Retry, short UDPPort, bool SCL2008);
    [DllImport("SCL_API_Stdcall", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool SCL_ComInitial(short DevID, int ComPort, int Baudrate, int LedNum, int TimeOut, int Retry, bool SCL2008);
    [DllImport("SCL_API_Stdcall", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool SCL_ShowString(short DevID, ref short TextInfo, string Str_Renamed);
    [DllImport("SCL_API_Stdcall", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool SCL_SendFile(short DevID, int DrvNo, string Path, string FileName);
    [DllImport("SCL_API_Stdcall", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool SCL_SendData(short DevID, int Offset, int SendBytes, ref byte Buff);
    [DllImport("SCL_API_Stdcall", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool SCL_SaveFile(short DevID, int DrvNo, string FileName, int Length, int Da, int Ti);
    [DllImport("SCL_API_Stdcall", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool SCL_GetFileDosDateTime(string FileName, ref int Da, ref int Ti);
    [DllImport("SCL_API_Stdcall", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool SCL_RemoveFile(short DevID, int DrvNo, string FileName);
    [DllImport("SCL_API_Stdcall", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool SCL_Replay(short DevID, int Drv, int Index);
    [DllImport("SCL_API_Stdcall", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool SCL_Close(short DevID);


    // ---------------------------------------------------------------------------------------------
    // 文本输出信息结构,
    public struct TextInfoType
    {
        public short Left;
        public short Top;
        public short Width;
        public short Height;
        public int Color;
        public short ASCFont;
        public short HZFont;
        public short XPos;
        public short YPos;
    }

}