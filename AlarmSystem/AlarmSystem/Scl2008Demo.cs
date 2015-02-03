using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using AlarmSystem;

namespace WindowsFormsApplication1
{
    public partial class Scl2008Demo : Form
    {
        public Scl2008Demo()
        {
            InitializeComponent();
        }


        bool bSCL2008 = true;     //'TRUE: 控制器为SCL2008, FALSE: 控制器为SuperComm
        string IPAddr = "10.1.1.100";     //网络通讯: 控制器 IP 地址
        int UDPPort = 1024;           //网络通讯: UDP 端口号

        long LedNum = 0;               //串口通讯: 控制器编号
        long ComPort = 1;               //串口通讯: 计算机串口号
        long Baudrate = 38400;         //串口通讯: 通讯速率

        bool bOnlyShowStatic = false;   //TRUE: 只静止输出,不带移动效果, FALSE:试验发文件的方式
        bool bSendFile = false;         //TRUE: 用 SendFile 发送文件, FALSE:用SendData,SaveFile发送文件
        bool bNet = false;               //TRUE: 使用网络收发, FALSE: 使用串口收发

        int mDevID = 9;               //任意的2字节通讯设备编号
        long TimeOut = 2;              //通讯超时上限
        long RetryTimes = 2;            //通讯重发次数

        int LedWidth = 128;            //区域宽
        int LedHeight = 32;            //区域高
        long CharColor = 255;           //文字颜色

        string FileName = "Test.Txt";    //文本文件名


        private void btnSend_Click(object sender, EventArgs e)
        {
            string S = "";
            bool bOK = false;
            bool xb = false;
            //Dim Buff(1024) As Byte
            //Dim Da As Long, Ti As Long
            Scl2008.TextInfoType TextInfo = new Scl2008.TextInfoType();

            if (bSCL2008)
                TextInfo.Left = 4096 - LedWidth;
            else
                TextInfo.Left = 960 - LedWidth;
            TextInfo.Top = 0;
            TextInfo.Width = LedWidth;
            TextInfo.Height = LedHeight;
            TextInfo.Color = CharColor;
            TextInfo.ASCFont = 1;
            TextInfo.HZFont = 2;
            TextInfo.XPos = 0;
            TextInfo.YPos = 0;

            S = "";
            //Use 6x12,12x12 fonts
            S = S + "   `A1`H2`C0000FF红色12点显示";
            //Use 8x16,16x16 fonts
            S = S + "`A3`H4`C00FF00绿色16点显示AB";
            //Use 12x24,24x24 fonts
            S = S + "`A5`H6`C00FFFF黄色24点显示CD`Y000";
            //Use 16x32,32x32 fonts
            S = S + "`M3`A7`H8`C00FFFF反白32点显示EF";
            //通讯初始化
            if (bNet)
                bOK = Scl2008.SCL_NetInitial(mDevID, "", IPAddr, TimeOut, RetryTimes, UDPPort, bSCL2008);
            else
                bOK = Scl2008.SCL_ComInitial(mDevID, ComPort, Baudrate, LedNum, TimeOut, RetryTimes, bSCL2008);

            if (!bOK)
                MessageBox.Show("初始化失败");

            if (!bOnlyShowStatic)
            {
                //删除移动播出的文本文件
                //仅实现静止显示则可不调用这个函数
                if (bOK)
                    bOK = Scl2008.SCL_RemoveFile(mDevID, 2, FileName);
                if (!bOK)
                    MessageBox.Show("删除文件失败");

                //重启节目表,使屏幕静止(因为节目表中的文本文件不存在了)
                //仅实现静止显示则可不调用这个函数
                if (bOK)
                {
                    if (bSCL2008)
                        bOK = Scl2008.SCL_Replay(mDevID, 0, 0);
                    else
                        bOK = Scl2008.SCL_Replay(mDevID, 1, 0);
                    if (!bOK)
                        MessageBox.Show("重启节目表失败");
                    Thread.Sleep(500);
                }
            }

            //显示文字串,自动排版,超出部分自动截断
            if (bOK)
            {
                bOK = Scl2008.SCL_ShowString(mDevID, TextInfo.Left, S);
                if (!bOK)
                    MessageBox.Show("文字直接输出失败");
            }

            Scl2008.SCL_Close(mDevID);
        }
    }
}
