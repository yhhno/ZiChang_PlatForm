using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// Log 的摘要说明。
/// 写日志，在“C:\Inetpub\wwwroot\log”中按天生成错误日志，记录发生错误的时间和错误信息
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
    public static void WriteLog(string strText)
    {
        try
        {
            string strTimeMark = getTimeString();
            string strErrorMessage = "*******************" + strTimeMark + "*******************\r\n";
            strErrorMessage += strText + "\r\n";
            strErrorMessage += "*******************" + strTimeMark + "*******************\r\n";
            string strPath = Application.StartupPath + "\\log\\";
            string strFileName = getFileName() + ".log";
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
        catch
        { 
        }
    }
    /// <summary>
    /// 写错误信息
    /// </summary>
    /// <param name="ex"></param>
    public static void WriteLog(System.Exception ex)
    {
        string strErrorMessage = "错误信息===>>" + ex.Message;
        strErrorMessage += "\r\n堆栈信息===>>" + ex.StackTrace;
        WriteLog(strErrorMessage);
    }
    /// <summary>
    /// 获取文件名称
    /// </summary>
    /// <returns></returns>
    private static string getFileName()
    {
        DateTime dtmNow = DateTime.Now;
        string strNewFileName = dtmNow.Year.ToString() + "-" + dtmNow.Month.ToString() + "-" + dtmNow.Day.ToString();
        return strNewFileName;
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