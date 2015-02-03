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
using IndustryPlatform.BLL;
using System.Text;
using System.Collections.Generic;
using System.ServiceModel;
using STOCMessageService;

public partial class Operator_OperatorList :  BasePage
{
    SYS_OperatorBll operbll = new SYS_OperatorBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_username.Focus();
        if (!Page.IsPostBack)
        {
            if (CookieManager.GetCookieValue("uid").ToString() != "0")
            {
                string strSeq = "";
                IndustryPlatform.Model.SYS_Organization mOrg = new IndustryPlatform.BLL.SYS_Organization().GetModel(CookieManager.GetCookieValue("orgID").ToString());
                if (mOrg != null)
                    strSeq = mOrg.OrgSeq;
                else
                    strSeq = "-";
                ControlBindHelper.DropDownListBind(this.ddl_position, "SYS_Position", "PositionName", "PositionCode", "IsForbid='0' ", "请选择职位", "0");
            }
            else
            {
                ControlBindHelper.DropDownListBind(this.ddl_position, "SYS_Position", "PositionName", "PositionCode", "IsForbid='0'", "请选择职位", "0");
            }
            this.hf_where.Value = " 1=1 ";
            DBind();
        }

    }

    public string GetPositonByUc(string strUc)
    {
        string strSQL = "SELECT PositionName FROM  SYS_Position  a join Sys_OperatorPosition b on a.PositionCode=b.PositonCode where b.UserCode='" + strUc + "'";
        DataTable dt = DbHelperSQL.TQuery(strSQL);
        string strP = "";
        foreach (DataRow dr in dt.Rows)
        {
            strP += "、" + dr[0].ToString();
        }
        if (strP == "")
            return "未分配职位";
        strP = strP.Substring(1);
        return strP;
    }


    public string GetStatus(string status)
    {
        if (status == null || status == "" || status == "0")
            return "启用";

        else
            return "禁用";
    }


    public void DBind()
    {
        if (CookieManager.GetCookieValue("uid").ToString() != "0")
        {
            string strSeq = "";
            IndustryPlatform.Model.SYS_Organization mOrg = new IndustryPlatform.BLL.SYS_Organization().GetModel(CookieManager.GetCookieValue("orgID").ToString());
            if (mOrg != null)
                strSeq = mOrg.OrgSeq;
            else
                strSeq = "-";
            ControlBindHelper.GridViewPagerBindByRowNum(this.anp_oper, "VSYS_Operator", this.hf_where.Value.ToString(), "IsForbid asc,UserCode desc", this.gv_oper);
        }
        else
        {
            ControlBindHelper.GridViewPagerBindByRowNum(this.anp_oper, "VSYS_Operator", this.hf_where.Value.ToString(), "IsForbid asc,UserCode desc", this.gv_oper);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="b">是否取消选择0 id</param>
    /// <returns></returns>
    public string GetSelect(string strIsForbid)
    {
        string strValue = "";
        string[] rows = this.hdKey.Value.Split(',');
        for (int i = 0; i < rows.Length; i++)
        {
            int iRow = Convert.ToInt32(rows[i]);
            HiddenField hdIsForbid = (HiddenField)this.gv_oper.Rows[iRow].FindControl("hdIsForbid");
            if (strIsForbid != "")
            {
                if (hdIsForbid.Value != strIsForbid)
                {
                    strValue += "'" + this.gv_oper.DataKeys[iRow].Value.ToString() + "',";
                }
            }
            else
            {
                strValue += "'" + this.gv_oper.DataKeys[iRow].Value.ToString() + "',";
            }
        }
        if (strValue != "")
            strValue = strValue.Remove(strValue.Length - 1);
        return strValue;
    }

    public void search_Click(object sender, ImageClickEventArgs e)
    {
        string strwhere = " 1=1 ";
        if (!string.IsNullOrEmpty(this.txt_username.Text))
        {
            strwhere = strwhere + " and userName like '%" + this.txt_username.Text.ToString() + "%'";
        }
        if (this.ddl_position.SelectedValue != "0")
        {
            strwhere = strwhere + " and UserCode in (SELECT distinct UserCode FROM SYS_OperatorPosition where PositonCode='" + this.ddl_position.SelectedValue + "')";
            //strwhere = strwhere + " and UserCode in (SELECT SYS_OperatorPosition.UserCode FROM SYS_OperatorPosition where PositonID in (SELECT SYS_Position.positonID FROM SYS_Position where OrgCode=" + CookieManager.GetCookieValue("OrgCode") + "))";
        }
        this.hf_where.Value = strwhere;
        DBind();
    }

    protected void gv_oper_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "RowClick(this);");
            Label lblIsForbid = (Label)e.Row.FindControl("lblIsForbid");
            if (lblIsForbid.Text == "禁用")
                lblIsForbid.ForeColor = System.Drawing.Color.Red;
        }
    }


    protected void lk_Click(object sender, EventArgs e)
    {
        DBind();
    }

    //重置密码
    protected void lbsetpwd_Click(object sender, EventArgs e)
    {
        string str = GetSelect("");

        int iop = 0;

        iop = operbll.setdefautpwd(str, CommonMethod.MD5Crypt("12345"));
        if (iop > 0)
        {
            #region 数据同步
            if (ConfigurationManager.AppSettings["IsSync"] == "1")
            {
                #region 数据同步
                if (ConfigurationManager.AppSettings["IsSync"] == "1")
                {
                    string strSQL = "Update SYS_Operator Set Password='" + CommonMethod.MD5Crypt("12345") + "' where UserCode in (" + str + ")";
                    IndustryPlatform.DBUtility.MsmqManage msm =   MsmqManage.GetMsmq();
                    strSQL = msm.AllStation + msm.Prefix + "Sys_Operator" + msm.Prefix + msm.EditFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                    msm.AddMsmq(strSQL);
                }
                #endregion
            }
            #endregion

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('密码重置成功!')", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('密码重置失败!')", true);
        }


    }

    #region 进行分页操作
    protected void anp_oper_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.anp_oper.CurrentPageIndex = e.NewPageIndex;
        DBind();
    }
    #endregion

    //修改
    protected void lkUpdate_Click(object sender, EventArgs e)
    {
        string strKey = gv_oper.DataKeys[Convert.ToInt32(this.hdKey.Value)].Value.ToString();
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "", "EditForm('" + strKey + "')", true);
    }

    //设置职位
    protected void lnbtnSetPosition_Click(object sender, EventArgs e)
    {
        string str = GetSelect("");
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "SetPosition(" + str + ")", true);
    }

    //禁用
    protected void lkForbid_Click(object sender, EventArgs e)
    {
        string str = GetSelect("1");
        if (str == "")
        {
            MessageBox.Show(this.UpdatePanel1, this, "您选择的用户已经是禁用状态，不能再禁用!");
            return;
        }
        else
        {
            str = str.Replace("'" + CookieManager.GetCookieValue("uid") + "'", "").Replace(",,", ",").TrimEnd(',');
            if (str == "" || str == "0")
            {
                MessageBox.Show(this.UpdatePanel1, this, "您选择的用户是当前登录用户，不能再禁用!");
                return;
            }
        }
        //int iop = operbll.DelOperator(str);

        string strSQL = "Update Sys_Operator Set IsForbid = 1   Where UserCode IN (" + str + ")";
        int iop = DbHelperSQL.ExecuteSql(strSQL);
        if (iop > 0)
        {
            #region 数据同步
            if (ConfigurationManager.AppSettings["IsSync"] == "1")
            {
                try
                {
                    IndustryPlatform.DBUtility.MsmqManage msm =   MsmqManage.GetMsmq();
                    strSQL = msm.AllStation + msm.Prefix + "Sys_Operator" + msm.Prefix + msm.EditFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                    msm.AddMsmq(strSQL);

                    string strKQSQL = "update 员工 set 黑名单=1 where 员工编号 in (" + str + ")";
                    msm.AddMsmq(strKQSQL, System.Configuration.ConfigurationManager.AppSettings["ConnKQIP"].ToString());

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('操作成功!但是数据下发失败" + ex.Message + "')", true);
                }
            }
            #endregion

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('操作成功!')", true);
        }
        else
        {

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('操作失败!')", true);
        }
        DBind();
    }

    //启用
    protected void lkStart_Click(object sender, EventArgs e)
    {
        string str = GetSelect("0");
        if (str == "")
        {
            MessageBox.Show(this.UpdatePanel1, this, "您选择的用户已经是启用状态，不能再启用!");
            return;
        }
        else
        {
            str = str.Replace("'" + CookieManager.GetCookieValue("uid") + "'", "").Replace(",,", ",").TrimEnd(',');
            if (str == "" || str == "0")
            {
                MessageBox.Show(this.UpdatePanel1, this, "您选择的用户是当前登录用户，不能再启用!");
                return;
            }
        }
        //int iop = operbll.DelOperator(str);

        string strSQL = "Update Sys_Operator Set IsForbid = 0   Where UserCode IN (" + str + ")";
        int iop = DbHelperSQL.ExecuteSql(strSQL);
        if (iop > 0)
        {
            #region 数据同步
            if (ConfigurationManager.AppSettings["IsSync"] == "1")
            {
                try
                {
                    IndustryPlatform.DBUtility.MsmqManage msm =   MsmqManage.GetMsmq();
                    strSQL = msm.AllStation + msm.Prefix + "Sys_Operator" + msm.Prefix + msm.EditFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                    msm.AddMsmq(strSQL);

                    string strKQSQL = "update 员工 set 黑名单=0 where 员工编号 in (" + str + ")";
                    msm.AddMsmq(strKQSQL, System.Configuration.ConfigurationManager.AppSettings["ConnKQIP"].ToString());
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('操作成功!但是数据下发失败" + ex.Message + "')", true);
                }
            }
            #endregion

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('操作成功!')", true);
        }
        else
        {

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('操作失败!')", true);
        }
        DBind();
    }

    protected void lkAdd_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "getForm();", true);
    }
}
