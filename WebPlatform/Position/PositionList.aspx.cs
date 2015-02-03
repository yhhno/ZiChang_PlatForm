using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using IndustryPlatform.DBUtility;
using IndustryPlatform.BLL;
using System.ServiceModel;

using System.Configuration;
using System.Drawing;


public partial class Organization_OrganizationList : System.Web.UI.Page
{
    SYS_Position position = new SYS_Position();
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_position.Focus();
        if (!Page.IsPostBack)
        {
            IndexLoadBind();
        }
    }

    //初始化加载
    private void IndexLoadBind()
    {
        string strWhere = " 1=1 ";
        ControlBindHelper.GridViewPagerBindByRowNum(anp_Org, "SYS_Position", strWhere, "IsForbid asc,PositionCode desc", this.gdv_Org);
    }
 
    protected void anp_Org_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.anp_Org.CurrentPageIndex = e.NewPageIndex;
        IndexLoadBind();
    }

    //循环出选择上的数据
    public string GetSelect(string IsForbid)
    {
        string strtext = "";
        string[] rows = this.hdKey.Value.Split(',');
        for (int i = 0; i < rows.Length; i++)
        {
            int iRow=Convert.ToInt32(rows[i]);
            HiddenField hdIsForbid = (HiddenField)gdv_Org.Rows[iRow].FindControl("hdIsForbid");
            if (gdv_Org.DataKeys[iRow].Value.ToString() != "0" && hdIsForbid.Value != IsForbid)
                strtext += "'" + gdv_Org.DataKeys[iRow].Value.ToString() + "',";
        }
        if ("" != strtext.Trim())
        {
            return strtext.Substring(0, strtext.Length - 1);
        }
        else
        {
            return "";
        }
    }

    //查询
    protected void btn_Select_Click(object sender, ImageClickEventArgs e)
    {
        string strWhere = " PositionName Like '%" + CommonMethod.RepChar(this.txt_position.Text) + "%' ";

        ControlBindHelper.GridViewPagerBindByRowNum(anp_Org, "SYS_Position", strWhere, "PositionCode desc", this.gdv_Org);
    }

    public string GetStatus(string status)
    {
        if (status == null || status == "" || status == "0")
            return "启用";

        else
            return "禁用";
    }
   
    protected void gdv_Org_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "RowClick(this);");
            Label lblIsForbid = (Label)e.Row.FindControl("lblIsForbid");
            if (lblIsForbid.Text == "禁用")
                lblIsForbid.ForeColor = Color.Red;
        }
    }


    protected void lkAdd_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "AddFrom(00);", true);
    }

    protected void lkUpdate_Click(object sender, EventArgs e)
    {
        string strKey = this.gdv_Org.DataKeys[Convert.ToInt32(this.hdKey.Value)].Value.ToString();
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "EditFrom(" + strKey + ");", true);
    }

    protected void lkDelete_Click(object sender, EventArgs e)
    {
        string strselect = GetSelect("1");
        if ("" != strselect)
        {
            string strSQL = "Update Sys_Position set [IsForbid] = 1 " +
                          " Where  [PositionCode] IN(" + strselect + ") ";

            if (DbHelperSQL.ExecuteSql(strSQL) >0)
            {
                #region 数据同步
                if (ConfigurationManager.AppSettings["IsSync"] == "1")
                {
                    try
                    {
                        

                        IndustryPlatform.DBUtility.MsmqManage msm =   MsmqManage.GetMsmq();
                        strSQL = msm.AllStation + msm.Prefix + "Sys_Position" + msm.Prefix + msm.EditFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                        msm.AddMsmq(strSQL);
                       
                    }
                    catch
                    { }
                }
                #endregion

                position.DelMenuPosition(strselect);

                if (ViewState["Node"] == null)
                {
                    ViewState["Node"] = ""; 
                }
                IndexLoadBind();
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "alert('操作成功!'); ", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "alert('操作失败!');", true);
            }
        }
        else
        {
            MessageBox.Show(this.UpdatePanel1, this, "您选择的记录已经是禁用状态！");
        }
    }
    protected void lkSetpower_Click(object sender, EventArgs e)
    {
        string strKey = this.gdv_Org.DataKeys[Convert.ToInt32(this.hdKey.Value)].Value.ToString();
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "Role(" + strKey + ");", true);
    }

    protected void ddl_orgName_SelectedIndexChanged(object sender, EventArgs e)
    { 
    }
    protected void LkEmbargoor_Click(object sender, EventArgs e)
    {
        string strselect = GetSelect("0");
        if ("" != strselect)
        {
            string strSQL = "Update Sys_Position set [IsForbid] = 0 " +
                           " Where  [PositionCode] IN(" + strselect + ") ";


            if (DbHelperSQL.ExecuteSql(strSQL) > 0)
            {
                #region 数据同步
                if (ConfigurationManager.AppSettings["IsSync"] == "1")
                {
                    try
                    {


                        IndustryPlatform.DBUtility.MsmqManage msm =   MsmqManage.GetMsmq();
                        strSQL = msm.AllStation + msm.Prefix + "Sys_Position" + msm.Prefix + msm.EditFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                        msm.AddMsmq(strSQL);

                    }
                    catch
                    { }
                }
                #endregion

                position.DelMenuPosition(strselect);

                if (ViewState["Node"] == null)
                {
                    ViewState["Node"] = "";
                }
                IndexLoadBind();
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "alert('操作成功!'); ", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "alert('操作失败!');", true);
            }
        }
        else
        {
            MessageBox.Show(this.UpdatePanel1, this, "您选择的记录已经是启用状态！");
        }
    }
}
