using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Net;
using System.Collections;
using IndustryPlatform.BLL;
using IndustryPlatform.DBUtility;

public partial class Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (!IsPostBack)
        {
            CookieManager.RemoveCookie("uid");
            Request.Cookies.Clear();
        }
    }
    private void getStr()
    {
        try
        {
            DataSet ds = IndustryPlatform.DBUtility.DbHelperSQL.Query("select UserName from Sys_Operator");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Hidden1.Value += "" + ds.Tables[0].Rows[i]["UserName"].ToString() + ",";
            }
            Hidden1.Value = Hidden1.Value.Substring(0, Hidden1.Value.Length - 1);
        }
        catch (Exception e)
        {
            Response.Write("<script>alert('数据库链接失败，请核查数据库配置是否正确。');</script>");
            Response.Redirect("Login.aspx");
        }
    }

    protected void ibnLogin_Click(object sender, ImageClickEventArgs e)
    {
        //判断是否输入为空
        if (this.txt_name.Text == "")
        {
            MessageBox.Show(Page, "请输入用户名！");
        }
        if (this.txtPassword.Text == "")
        {
            MessageBox.Show(Page, "请输入密码！");
        }
        //存储验证码
        string strCookCode = CookieManager.GetCookieValue("CookCode");
        if (txtCheckCode.Text.Trim() != "" && strCookCode != "")
        {
            if (txtCheckCode.Text.Trim().ToUpper() != strCookCode.ToUpper())
            {
                MessageBox.Show(this.Page, "您输入的验证码不正确！");
                txtCheckCode.Text = "";
                return;
            }

        }
        else
        {
            MessageBox.Show(this.Page, "请输入验证码！");
            txtCheckCode.Text = "";
            return;
        }

        SYS_OperatorBll operbll = new SYS_OperatorBll();
        DataSet ds = operbll.OperatorLogin(this.txt_name.Text.ToString(), CommonMethod.MD5Crypt(this.txtPassword.Text.ToString()));
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["uid"] = ds.Tables[0].Rows[0]["UserCode"].ToString();
            CookieManager.AppendCookie("uid", ds.Tables[0].Rows[0]["UserCode"].ToString());

            Session["UserName"] = ds.Tables[0].Rows[0]["UserName"].ToString();
            CookieManager.AppendCookie("UserName", ds.Tables[0].Rows[0]["UserName"].ToString());

            //所属部门
            Session["orgID"] = ds.Tables[0].Rows[0]["OrgCode"].ToString();
            CookieManager.AppendCookie("orgID", ds.Tables[0].Rows[0]["OrgCode"].ToString());
            //所属于部门下的职位，一个人只属于一个部门，但可有多个职位，Session["PostionID"]保存的数据格式为数字
            //和逗号组成的字符串
            Session["PositionCode"] = operbll.GetPosi(Convert.ToInt32(Session["uid"]));
            CookieManager.AppendCookie("PositionCode", operbll.GetPosi(Convert.ToInt32(Session["uid"])));

            string strIP = System.Net.Dns.Resolve(System.Net.Dns.GetHostName()).AddressList[0].ToString();
            StringBuilder sbSql = new StringBuilder("");
            sbSql.Append("insert into Sys_OperateLog (LogType,OperateTable,Operator,OperateDate,OperateIP,Remark,SysCode,RelationID)");
            sbSql.Append(" values('登录','Sys_Operator','" + ds.Tables[0].Rows[0]["UserName"].ToString() + "',getdate(),'" + strIP + "','登录调运BS系统','s1000','')");
            DbHelperSQL.ExecuteSql(sbSql.ToString());

            Response.Redirect("index.aspx?sysid=" + IndustryPlatform.Common.SystemConfig.SysID, true);
        }
        else
        {
            MessageBox.Show(this, "您输入的用户名和密码有误，请重新输入!");
        }
    }
    protected void ibnCancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Login.aspx", true);
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        return default(string[]);
    }
}
