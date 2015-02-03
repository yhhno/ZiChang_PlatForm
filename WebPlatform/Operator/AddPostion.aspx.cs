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
using System.Text;

using IndustryPlatform.DBUtility;
using IndustryPlatform.BLL;
using System.Collections.Generic;
using System.ServiceModel;

 
public partial class Operator_AddPostion : System.Web.UI.Page
{
    SYS_Position position = new SYS_Position();
    SYS_OperatorBll operbll = new SYS_OperatorBll();
    static string operid = "";
    static string strOperatePostions = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["operid"]))
            {
                operid = Request.QueryString["operid"].ToString();
                if (!operid.Contains(','))
                    strOperatePostions = operbll.GetPosi(Convert.ToInt32(operid));
            }
            if (CookieManager.GetCookieValue("orgID") != null)
            {
                ViewState["SEQ"] = position.Getresult("orgSEQ", "SYS_Organization", "OrgCode=" + CookieManager.GetCookieValue("orgID").ToString());
               // DataTree(CookieManager.GetCookieValue("orgID").ToString());
                DBind(CookieManager.GetCookieValue("orgID").ToString(),"", "");
            }
            else
            {
               // DataTree("0");
            }
            
        }
        //Response.Write(operid.ToString());
    }

    //public void DBind(string OrgID, string strname)
    //{
    //    //position.GridViewPagerBind(this.anp_oper, "SYS_Operator", "operatorID", "", "operatorID", this.gv_oper);

    //    position.GridViewPagerBindbyRowNumber(this.anp_Org, " SYS_Position as p left join SYS_Organization as o on o.orgID=p.orgID ", "PositonID", OrgID, strname, "PositonID desc", this.gdv_Org);


    //}

    public void DBind(string OrgID, string strname, string OrgName)
    {
        if(CookieManager.GetCookieValue("uid").ToString()=="0")
            ControlBindHelper.GridViewPagerBindByRowNum(this.anp_Org, "SYS_Position", "IsForbid='0'", " PositionName ", this.gdv_Org);
        else
            ControlBindHelper.GridViewPagerBindByRowNum(this.anp_Org, "SYS_Position", "IsForbid='0' ", " PositionName ", this.gdv_Org);

    }

    protected void gdv_Org_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!operid.Contains(','))
            {
                string[] strarr = strOperatePostions.Split(',');
                if (strOperatePostions != "")
                {
                    if (strarr.Contains(gdv_Org.DataKeys[e.Row.DataItemIndex].Value.ToString()))
                    {
                        CheckBox chk_BoxSelect = (CheckBox)e.Row.Cells[0].FindControl("chkBoxSelect");
                        chk_BoxSelect.Checked = true;
                    }
                }
            }
            e.Row.Attributes.Add("onclick", "RowClick(this);");
        }
    }

   
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.ViewState["Node"] == null)
        {
            this.DBind("", "","");
        }
        else
        {
            this.DBind(ViewState["Node"].ToString(), "","");
        }
    }

    public string GetSelect()
    {
        StringBuilder strtext = new StringBuilder();
        foreach (GridViewRow grvRow in gdv_Org.Rows)
        {
            CheckBox chk_BoxSelect = (CheckBox)grvRow.Cells[0].FindControl("chkBoxSelect");

            if (chk_BoxSelect.Checked == true)
            {
                strtext.Append(gdv_Org.DataKeys[grvRow.DataItemIndex].Value.ToString() + ",");
            }
        }
        return strtext.ToString();
    }

    protected void ib_save_Click(object sender, ImageClickEventArgs e)
    {
        int iop = 0;
        string str = GetSelect();
        if(operid != "0")
        {
          iop = operbll.AddOperPosition(operid,str);
        }
        if (iop > 0)
        {
            #region 数据同步
            if (ConfigurationManager.AppSettings["IsSync"] == "1")
            {
                try
                {
                    //添加成功，数据同步到各个磅房
                    IndustryPlatform.DBUtility.MsmqManage msm =  MsmqManage.GetMsmq();
                    string strSQL = "Delete From Sys_OperatorPosition Where [UserCode]='" + operid + "';";
                    string[] strArrPID = str.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < strArrPID.Length; i++)
                    {
                        strSQL += "INSERT INTO Sys_OperatorPosition ( " +
                                       "[PositonCode] ," +
                                       "[UserCode] ) VALUES ('" + strArrPID[i] + "','" + operid + "');";
                    }
                    strSQL = msm.AllStation + msm.Prefix + "Sys_OperatorPosition" + msm.Prefix + msm.AddFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                    msm.AddMsmq(strSQL);
                }
                catch
                { }
            }
            #endregion
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "top.currForm.close();", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('设置失败!')", true);
        }
       // ClientScript.RegisterStartupScript(Page.GetType(), "", "this.top.currForm.close();//this.top.currForm.returnvalue='aa';", true);
    }
   
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "top.currForm.close();", true);
    }

    protected void ib_cav_Click(object sender, ImageClickEventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["operid"]))
        {
            operid = Request.QueryString["operid"].ToString();
            if (!operid.Contains(','))
                strOperatePostions = operbll.GetPosi(Convert.ToInt32(operid));
        }
        if (CookieManager.GetCookieValue("orgID") != null)
        {
            ViewState["SEQ"] = position.Getresult("orgSEQ", "SYS_Organization", "OrgCode=" + CookieManager.GetCookieValue("orgID").ToString());
            // DataTree(CookieManager.GetCookieValue("orgID").ToString());
            DBind(CookieManager.GetCookieValue("orgID").ToString(), "", "");
        }
        else
        {
            // DataTree("0");
        }
    }
}
