using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IndustryPlatform.DBUtility;
using System.Text;
using IndustryPlatform.BLL;
using System.Data;

public partial class LoginPlatform : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (!IsPostBack)
        {
            try
            {
                CookieManager.RemoveCookie("uid");
                Request.Cookies.Clear();
                getDept();
            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('数据库链接失败，请核查数据库链接是否正确。');</script>");
                return;
            }
        }
    }

    //选择部门
    private void getDept()
    {

        ControlBindHelper.DropDownListBind(this.ddldept, "Sys_Organization", "OrgName", "OrgCode", " IsForbid='0'", "请选择部门", "");
        if (ddldept.Items.Count>2)
        {
            this.ddldept.SelectedIndex = 2;
            getUser(this.ddldept.SelectedValue);
        }
    }

    private void getUser(string orgCode)
    {
        ControlBindHelper.DropDownListBind(this.ddluser, "Sys_Operator", "UserName", "UserCode", " IsForbid='0' and OrgCode='"+orgCode+"'", "请选择用户", "");
    }
    protected void ddldept_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddldept.SelectedValue != "")
        {
            getUser(ddldept.SelectedValue);
        }
    }
    protected void ibnLogin_Click(object sender, ImageClickEventArgs e)
    {
        //判断是否输入为空
        if (this.ddldept.SelectedValue == "")
        {
            MessageBox.Show(Page,"请选择部门！");
        }
        if (this.ddluser.SelectedValue == "")
        {
            MessageBox.Show(Page, "请选择用户！");
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
        DataSet ds = operbll.OperatorLogin(this.ddluser.SelectedItem.Text.ToString(), CommonMethod.MD5Crypt(this.txtPassword.Text.ToString()));
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["IsForbid"].ToString() == "1")
            {
                MessageBox.Show(this.Page, "此用户已被禁用不能登录！");
                return;
            }
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
        Response.Redirect("LoginPlatform.aspx", true);
    }

  
}
