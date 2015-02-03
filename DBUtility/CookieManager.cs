using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// CookieManager 的摘要说明
/// </summary>
namespace IndustryPlatform.DBUtility
{
    public class CookieManager
    {
        public CookieManager()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 移除cookie,将Request和Response两个集合中的都清理
        ///  Code by KentLi
        /// </summary>
        /// <param name="cookieName">cookie名称</param>
        public static void RemoveCookie(string cookieName)
        {
            HttpCookie Cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (Cookie != null)
            {
                //过期时间设置为立即过期
                Cookie.Expires = System.DateTime.Now.AddDays(-1);
                Cookie.Value = null;
                HttpContext.Current.Request.Cookies.Remove(cookieName);
             
            }
        }
        public static void AppendCookie(string cookieName, string cookiesvalue)
        {
            HttpCookie usercookie = new HttpCookie(cookieName, System.Web.HttpUtility.UrlEncode(cookiesvalue));
            HttpContext.Current.Response.Cookies.Add(usercookie);
        }
        public static void AppendCookie(string cookieName, string cookiesvalue, int days)
        {
            HttpCookie usercookie = new HttpCookie(cookieName, cookiesvalue);
            HttpContext.Current.Response.Cookies.Add(usercookie);
        }
        public static string GetCookieValue(string strCookieName)
        {
            return System.Web.HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[strCookieName].Value);
        }
    }
}
