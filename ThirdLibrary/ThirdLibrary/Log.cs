using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// Log 的摘要说明。
/// 写日志，在应用程序更目录下Log文件夹中按天生成错误日志，记录发生错误的时间和错误信息
/// </summary>
public class Log
{
    public Log()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 写错误日志
    /// </summary>
    /// <param name="body"></param>
    public static void WriteLog(string strControlType,string strText)
    {
        try
        {
            string strTimeMark = DateTime.Now.ToString();
            string strErrorMessage = "*******************" + strTimeMark + "*******************\r\n";
            strErrorMessage += strControlType + "：\r\n";
            strErrorMessage += strText + "\r\n";
            strErrorMessage += "*******************" + strTimeMark + "*******************\r\n\r\n";
            string strPath = Application.StartupPath + "\\Log\\";
            string strFileName = "ThirdLibrary.log";
            //判断日志目录是否存在，不存在就建立目录
            if (!System.IO.Directory.Exists(strPath))
            {
                System.IO.Directory.CreateDirectory(strPath);
            }
            strFileName = strPath + strFileName;
            StreamWriter swriter = new StreamWriter(strFileName, true, Encoding.Default, 128);
            swriter.Write(strErrorMessage);
            swriter.Flush();
            swriter.Close();
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message.ToString());
        }
    }
    /// <summary>
    /// 写错误信息
    /// </summary>
    /// <param name="ex"></param>
    public static void WriteLog(string strControlType,System.Exception ex)
    {
        string strErrorMessage = "错误信息===>>" + ex.Message;
        strErrorMessage += "\r\n堆栈信息===>>" + ex.StackTrace;
        WriteLog(strControlType,strErrorMessage);
    }
    /// <summary>
    /// 获取当前时间
    /// </summary>
    /// <returns></returns>
    private static string getTimeString()
    {
        DateTime dtmNow = DateTime.Now;
        string strNowTime = dtmNow.Year.ToString() + "-" + dtmNow.Month.ToString() + "-" + dtmNow.Day.ToString() + " " 
                         + dtmNow.Hour.ToString() + ":" + dtmNow.Minute.ToString() + ":" + dtmNow.Second.ToString();
        return strNowTime;
    }
}