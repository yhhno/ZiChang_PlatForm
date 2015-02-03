/*----------------------------------------------------------------
// Copyright (C) 2009 北京天大天科科技有限公司技术研发部
// 版权所有。 
// 文件名：
// 文件功能描述：ini文件操作基本类
// 创建标识：2009年2月18日 张鹏寿
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

/// <summary>
/// 读写Ini文件
/// </summary>
public abstract class AppConfig
{
    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string strSection, string strKey, string strValue, string strFilePath);
    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string strSection, string strKey, string strDefault, StringBuilder retrunValue, int iSize, string strFilePath);

    /// <summary>
    /// 读出Setting.ini文件
    /// </summary>
    /// <param name="Section">项目名称(如 [TypeName] )</param>
    /// <param name="Key">键</param>
    public static string ReadValue(string strSection, string strKey)
    {
        StringBuilder temp = new StringBuilder(500);
        int i = GetPrivateProfileString(strSection, strKey, "", temp, 500, System.Windows.Forms.Application.StartupPath + "\\Settings.ini");
        return temp.ToString();
    }
    /// <summary>
    /// 保存Setting.ini文件
    /// </summary>
    /// <param name="Section">项目名称(如 [TypeName] )</param>
    /// <param name="Key">键</param>
    /// <param name="Value">值</param>
    public static void SaveValue(string strSection, string strKey, string strValue)
    {
        WritePrivateProfileString(strSection, strKey, strValue, System.Windows.Forms.Application.StartupPath + "\\Settings.ini");
    }
}