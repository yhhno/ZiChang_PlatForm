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
using IndustryPlatform.Model;
using IndustryPlatform.BLL;
using IndustryPlatform.DBUtility;
using System.Collections.Generic;
using System.ServiceModel;


public partial class Updatepwd : System.Web.UI.Page
{
    SYS_OperatorBll operbll = new SYS_OperatorBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        int operid = 0;
        if (int.TryParse(Request.QueryString["operid"], out operid))
        {

        }
    }

    protected void ib_save_Click(object sender, ImageClickEventArgs e)
    {
        int iop = operbll.UpdatePwd(CookieManager.GetCookieValue("uid"), CommonMethod.MD5Crypt(this.txt_oldpwd.Text.ToString()), CommonMethod.MD5Crypt(this.txt_newpwd.Text.ToString()));
        if (iop == -1)
        {
            MessageBox.Show(this,"原密码输入不正确!");
        }
        if(iop == 1)
        {
            #region 数据同步
            if (ConfigurationManager.AppSettings["IsSync"] == "1")
            {
                IndustryPlatform.DBUtility.MsmqManage msm =   MsmqManage.GetMsmq();
                string strSQL = "UPDATE Sys_Operator SET Password='" + CommonMethod.MD5Crypt(this.txt_newpwd.Text.ToString()) + "' WHERE UserCode='" + CookieManager.GetCookieValue("uid") + "'";
                strSQL = msm.AllStation + msm.Prefix + "Sys_Operator" + msm.Prefix + msm.EditFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                msm.AddMsmq(strSQL);
            }
            #endregion
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('密码修改成功!');top.currForm.close();", true);
        }
        if (iop == 0)
        {
            MessageBox.Show(this, "修改失败!");
        }
    }
}
