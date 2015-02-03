using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;

namespace IndustryPlatform.Common
{
    public class SystemConfig
    {
        /// <summary>
        /// 取出当前WebApplication的根Url
        /// </summary>
        /// <returns>以Http://开头，以/结尾的完全限定名</returns>
        public static string RootUrl
        {
            get
            {
                return GetRoot();
            }
        }


        /// <summary>
        /// 取出系统开始载入程序Url
        /// </summary>
        /// <returns>以Http://开头，以/结尾的完全限定名</returns>
        /// 
        public static string StartUrl
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["StartUrl"].ToString();
            }
        }


   /// <summary>
        /// 取出系统开始载入程序SysID
        /// </summary>
        /// <returns>以Http://开头，以/结尾的完全限定名</returns>
        /// 
        public static string SysID
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["SysID"].ToString();
            }
        }

        public static string ServerPort
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            }
        }

        /// 取得客户端真实IP。如果有代理则取第一个非内网地址 
        /// </summary> 
        public static string IPAddress
        {
            get
            {
                string result = String.Empty;
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (result != null && result != String.Empty)
                {
                    //可能有代理 
                    if (result.IndexOf(".") == -1)     //没有“.”肯定是非IPv4格式 
                        result = null;
                    else
                    {
                        if (result.IndexOf(",") != -1)
                        {
                            //有“,”，估计多个代理。取第一个不是内网的IP。 
                            result = result.Replace(" ", "").Replace("'", "");
                            string[] temparyip = result.Split(",;".ToCharArray());
                            for (int i = 0; i < temparyip.Length; i++)
                            {
                                if (IsIPAddress(temparyip[i])
                                    && temparyip[i].Substring(0, 3) != "10."
                                    && temparyip[i].Substring(0, 7) != "192.168"
                                    && temparyip[i].Substring(0, 7) != "172.16.")
                                {
                                    return temparyip[i];     //找到不是内网的地址 
                                }
                            }
                        }
                        else if (IsIPAddress(result)) //代理即是IP格式 
                            return result;
                        else
                            result = null;     //代理中的内容 非IP，取IP 
                    }

                }
                string IpAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != String.Empty) ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                if (null == result || result == String.Empty)
                    result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                if (result == null || result == String.Empty)
                    result = HttpContext.Current.Request.UserHostAddress;
                return result;
            }
        }
        /// 判断是否是IP地址格式 0.0.0.0
        /// </summary>
        /// <param name="str1">待判断的IP地址</param>
        /// <returns>true or false</returns>
        public static bool IsIPAddress(string str1)
        {
            if (str1 == null || str1 == string.Empty || str1.Length < 7 || str1.Length > 15) return false;

            string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";

            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(str1);
        }

        /// <summary>
        /// 检查用户是否已经失去了会话，即掉线
        /// </summary>
        public static bool VertifyOnline()
        {
            HttpContext _context = HttpContext.Current;
            if (_context.Session["IsOnline"] != null) return true;
            return false;
        }

        /// <summary>
        /// 取出当前WebApplication的根Url
        /// </summary>
        /// <returns>以Http://开头，以/结尾的完全限定名</returns>
        public static string GetRoot()
        {
            string rs;
            string crmAppPath = "";
            crmAppPath = (HttpContext.Current.Request.ApplicationPath == "/") ? HttpContext.Current.Request.ApplicationPath : HttpContext.Current.Request.ApplicationPath + "/";
            string sPort = SystemConfig.ServerPort;
            if (sPort == "80")
                rs = "Http://" + HttpContext.Current.Request.Url.Host + crmAppPath;
            else
                rs = "Http://" + HttpContext.Current.Request.Url.Host + ":" + sPort + crmAppPath;
            return rs;
        }

        /// <summary>
        /// 从获取的请求路经里截取文件名
        /// </summary>
        /// <param name="RequestPath">请求路径</param>
        /// <returns>获取的文件名</returns>
        public static string GetRequestFileName(string RequestPath)
        {
            if (RequestPath == "")
                return string.Empty;
            string rs = "";
            int i = RequestPath.LastIndexOf(@"/");
            if (i != -1)
                rs = RequestPath.Substring(i + 1);
            return rs;
        }

        /// <summary>
        /// 是否为日期
        /// </summary>
        public static bool IsDateTime(object obj)
        {
            if (obj.Equals(string.Empty)) return false;
            bool rs = false;
            try
            {
                DateTime ii = Convert.ToDateTime(obj);
                rs = true;
            }
            catch (InvalidCastException)
            {
                rs = false;
            }
            return rs;
        }
    }
}
