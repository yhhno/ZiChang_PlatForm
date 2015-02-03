<%@ WebHandler Language="C#" Class="GetNavHandler" %>

using System;
using System.Web;
using System.Data.SqlClient;

using System.Data;

using System.Text;
using IndustryPlatform.DBUtility;

/// <summary>
/// HttpHandler要继承IReadOnlySessionState接口才能使用Session
/// </summary>
public class GetNavHandler : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
{
    public void ProcessRequest(HttpContext context)
    {
        if (context.Request.Cookies["uid"] != null)
        {
            context.Response.ContentType = "text/plain";
            string strSql = "";
            if (CookieManager.GetCookieValue("uid") != "0")
                strSql = "select menuID,menuName from SYS_MENU where parentsID='s0001' and menuID not in ('s2000','s3000') and menuID in(select distinct menuID from SYS_menuPosition where PositionCode in(" + CookieManager.GetCookieValue("PositionCode") + ")) Order by displayOrder";
            else
                strSql = "select menuID,menuName from SYS_MENU where parentsID='s0001' and menuID not in ('s2000','s3000') Order by displayOrder";
            DataSet DS = DbHelperSQL.DQuery(strSql);

            StringBuilder sbtext = new StringBuilder();
            string html = "";


            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                html = "<li style='width:120px;text-align:left;'><table style='cursor:hand;'  width='120px' border='0' height:8px;  cellpadding='0' cellspacing='0'><tr><td align='center'><a href='index.aspx?sysid=" + DS.Tables[0].Rows[i]["menuID"].ToString() + "' style='height:9px;padding-left:3px;padding-top:2px;color:#000;width:80px;font-weight:bold'>" + DS.Tables[0].Rows[i]["menuName"].ToString() + "</a>&nbsp;&nbsp;&nbsp;&nbsp;</td><td style='width:9px;'><img src='images/topnavdia.jpg' boder='0'/></td></tr></table></li>";
                sbtext.Append(html);

            }
            context.Response.Write(sbtext.ToString());
        }
        else
        {
            string strScript = "<script language='javascript'>top.location.href='LoginPlatform.aspx';" + "</" + "script>";
            context.Response.Write(strScript); 
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}