using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using IndustryPlatform.DBUtility;


public partial class Default : System.Web.UI.Page
{
    public string strHtml = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            setHtml();
        }
    }

    void setHtml()
    {
        string strSql = "";
        if (CookieManager.GetCookieValue("uid") == "0")
            strSql = "select top 5 menuID,menuName,IcValue,MenuUrl from SYS_MENU where IcValue<>'' and RootID='" +CookieManager.GetCookieValue("Sys")+ "'";
        else
            strSql = "select top 5 menuID,menuName,IcValue,MenuUrl  from SYS_MENU where IcValue<>''"
                    + "and menuID in (select distinct menuID from SYS_menuPosition where PositionCode in(" + CookieManager.GetCookieValue("PositionCode") + ")) and RootID='" + CookieManager.GetCookieValue("Sys") + "'";
        DataTable dt = DbHelperSQL.TQuery(strSql);
        
        if (dt.Rows.Count > 0)
        {
            string strImg="<tr>";
            string strText="<tr>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strJs = "javascript:setTitleAndUrl('&nbsp;&nbsp;" + dt.Rows[i]["MenuName"].ToString() + "','" + dt.Rows[i]["MenuUrl"].ToString() + "');";
                strImg += "<td style=\"width:150px\" align=\"center\">"
                        + "<a href=\"" + strJs + "\"><img src=\"Images/Default/" + dt.Rows[i]["IcValue"].ToString() + "\" /> </a>"
                        + "</td>";
                strText+="<td  style=\"width:150px\" align=\"center\">"
                                + "<a href=\"" + strJs + "\">" + dt.Rows[i]["MenuName"].ToString() + "</a>"
                            +"</td>";
            }
            strImg+="</tr>";
            strText+="</tr>";
            strHtml = strImg + strText;
        }
    }

    protected void lkRoom_Click(object sender, EventArgs e)
    {
        try
        {
            CommonMethod.FileDownLoad(Server.MapPath("Resources/Room.doc"));
        }
        catch
        {
            MessageBox.Show(this, "您要下载的文件不存在");
        }
    }
    protected void lkCheck_Click(object sender, EventArgs e)
    {
        try
        {
            CommonMethod.FileDownLoad(Server.MapPath("Resources/CheckRoom.doc"));
        }
        catch
        {
            MessageBox.Show(this, "您要下载的文件不存在");
        }
    }
    protected void lkCenter_Click(object sender, EventArgs e)
    {
        try
        {
            CommonMethod.FileDownLoad(Server.MapPath("Resources/Center.doc"));
        }
        catch
        {
            MessageBox.Show(this, "您要下载的文件不存在");
        }
    }
}
