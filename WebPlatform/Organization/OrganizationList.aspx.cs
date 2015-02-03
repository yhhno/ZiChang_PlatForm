using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using IndustryPlatform.DBUtility;
using System.ServiceModel;

using System.Configuration;


public partial class Organization_OrganizationList : System.Web.UI.Page
{
    IndustryPlatform.BLL.SYS_Organization bll = new IndustryPlatform.BLL.SYS_Organization();
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_orgCode.Focus();
        if (!IsPostBack)
        {
            if (CookieManager.GetCookieValue("uid").ToString() != "0")
            {
                IndustryPlatform.Model.SYS_Organization m = bll.GetModel(CookieManager.GetCookieValue("orgID"));
                ViewState["SEQ"] = m.OrgSeq;
                ViewState["pid"] = m.ParentOrgCode;
            }
            else
            {
                ViewState["SEQ"] = "";
                ViewState["pid"] = 0;
            }
            lk_Click(sender, e);
        }
    }

    protected void tv_Org_SelectedNodeChanged(object sender, EventArgs e)
    {
        loadData();
        this.ddl_orgName.SelectedValue = this.tv_Org.SelectedValue;
    }
    public string GetStatus(string status)
    {
        if (status == null || status == "" || status == "0")
            return "启用";

        else
            return "禁用";
    }
    private void findData()
    {
        string strWhere = " 1=1";
        if (CookieManager.GetCookieValue("uid").ToString() != "0")
            strWhere += " and orgSEQ like '" + ViewState["SEQ"].ToString() + "%'";
        if (this.txt_orgCode.Text.Trim() != "")
            strWhere += " and orgCode like '%" + this.txt_orgCode.Text.Trim().Replace("'", "''") + "%'";
        if (this.ddl_orgName.SelectedIndex != 0)
        {
            string strSEQ = bll.GetModel(this.ddl_orgName.SelectedValue).OrgSeq;
            strWhere += " and orgSEQ like '" + strSEQ + "%'";
        }
        ControlBindHelper.GridViewPagerBindByRowNum(anp_Org, "VSys_Organization", strWhere, "IsForbid asc,OrgCode desc", this.gdv_Org);
    }
    protected void loadData()
    {

        string strWhere = " 1=1 and orgSEQ like '" + ViewState["SEQ"].ToString() + "%'";
        if (this.tv_Org.SelectedNode != null)
        {
            string strSEQ = bll.GetModel(this.tv_Org.SelectedValue).OrgSeq;
            strWhere += " and orgSEQ like '" + strSEQ + "%'";
        }
        ControlBindHelper.GridViewPagerBindByRowNum(anp_Org, "VSys_Organization", strWhere, "IsForbid asc,OrgCode desc", this.gdv_Org);
        //bll.GridViewPagerBind(anp_Org,strWhere, "orgLevel,orgName", this.gdv_Org);
    }

    protected void anp_Org_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.anp_Org.CurrentPageIndex = e.NewPageIndex;
        loadData();
    }
    protected void lkUpdate_Click(object sender, EventArgs e)
    {
        string strKey = this.gdv_Org.DataKeys[Convert.ToInt32(this.hdKey.Value)].Value.ToString();
        if (strKey == "0")
        {
            MessageBox.Show(this.UpdatePanel1, this, "该机构是默认的顶级机构，不能修改");
            return;
        }
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "OrganizationUpdate(" + strKey + ");", true);
    }
    protected void lkAdd_Click(object sender, EventArgs e)
    {
        string pid = "0";
        if (this.tv_Org.SelectedNode != null)
            pid = this.tv_Org.SelectedNode.Value;
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "OrganizationAdd(" + pid + ");", true);
    }

    /// <summary>
    /// 获取主键的值
    /// </summary>
    /// <returns></returns>
    string GetKeyValue(string IsForbid)
    {
        string strKey = "";
        string[] rows = this.hdKey.Value.Split(',');
        for (int i = 0; i < rows.Length; i++)
        {
            int iRow = Convert.ToInt32(rows[i]);
            HiddenField hdIsForbid = (HiddenField)this.gdv_Org.Rows[iRow].FindControl("hdIsForbid");
            string val = this.gdv_Org.DataKeys[iRow].Value.ToString();
            if (IsForbid != "")
            {
                if (IsForbid != hdIsForbid.Value)
                {
                    strKey += "'" + val + "',";
                }
            }
            else
            {
                strKey += "'" + val + "',";
            }
        }
        if (strKey != "")
            strKey = strKey.Remove(strKey.Length - 1);
        return strKey;
    }

    //启用
    protected void lkStart_Click(object sender, EventArgs e)
    {
        string strKey = GetKeyValue("0");
        if (strKey == "")
        {
            MessageBox.Show(this.UpdatePanel1, this, "您选择的部门已经是启用状态，不能再启用!");
            return;
        }
        //if (bll.GetPositionCountByOrgId(Convert.ToDecimal(strKey)) > 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('您选择的部门下有职务，不能删除!');", true);
        //    return;
        //}

        //if (bll.GetOperatorCountByOrgId(Convert.ToDecimal(strKey)) > 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('您选择的部门下有有人员，不能删除!');", true);
        //    return;
        //}
        //if (strKey == "0")
        //{
        //    MessageBox.Show(this.UpdatePanel1, this, "此部门不能禁用!");
        //    return;
        //}
        string strSQL = "Update Sys_Organization set [IsForbid] = 0 " +
                  " Where  [OrgCode] IN(" + strKey + ") ";

        if (DbHelperSQL.ExecuteSql(strSQL) > 0)
        {
            #region 数据同步
            if (ConfigurationManager.AppSettings["IsSync"] == "1")
            {
                try
                {
                    //添加成功，数据同步到各个磅房
                    IndustryPlatform.DBUtility.MsmqManage msm =  MsmqManage.GetMsmq();

                    strSQL = msm.AllStation + msm.Prefix + "Sys_Organization" + msm.Prefix + msm.EditFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                    msm.AddMsmq(strSQL);
                    //List<string> iplist = ControlBindHelper.GetAllRoomIP();
                    //for (int i = 0; i < iplist.Count; i++)
                    //{
                    //    if (iplist[i] != "")
                    //    {
                    //        EndpointAddress ep = new EndpointAddress("net.msmq://" + iplist[i] + "/private/STOCMessagingQueue");
                    //        NetMsmqBinding et = new NetMsmqBinding();
                    //        et.ExactlyOnce = false;
                    //        et.Security.Mode = System.ServiceModel.NetMsmqSecurityMode.None;
                    //        IDataPublish proxy = ChannelFactory<IDataPublish>.CreateChannel(et, ep);
                    //        proxy.IndustryPlatform_Organization_Delete(strKey);
                    //    }
                    //}
                }
                catch
                { }
            }
            #endregion

            lk_Click(sender, e);
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('启用成功!');", true);
        }
        else
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('启用失败!');", true);
    }
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.anp_Org.CurrentPageIndex = 1;
        this.findData();
    }
    protected void lk_Click(object sender, EventArgs e)
    {
        bll.OrgDllBind(this.ddl_orgName, ViewState["SEQ"].ToString(), ViewState["pid"].ToString());
        bll.OrgTreeBind(tv_Org);
        loadData();
    }
    protected void gdv_Org_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "RowClick(this);");
            Label lblIsForbid = (Label)e.Row.FindControl("lblIsForbid");
            if (lblIsForbid.Text == "禁用")
                lblIsForbid.ForeColor = System.Drawing.Color.Red;
        }
    }

    //禁用
    protected void lkForbid_Click(object sender, EventArgs e)
    {
        string strKey = GetKeyValue("1");
        if (strKey == "")
        {
            MessageBox.Show(this.UpdatePanel1, this, "您选择的部门已经是禁用状态，不能再禁用!");
            return;
        }
        if (strKey.Contains("'" + CookieManager.GetCookieValue("orgID").ToString() + "'"))
        {
            MessageBox.Show(this.UpdatePanel1, this, "您选择的部门中有当前登录用户的所属部门，不能再禁用!");
            return;
        }

        //if (bll.GetPositionCountByOrgId(Convert.ToDecimal(strKey)) > 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('您选择的部门下有职务，不能删除!');", true);
        //    return;
        //}

        //if (bll.GetOperatorCountByOrgId(Convert.ToDecimal(strKey)) > 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('您选择的部门下有有人员，不能删除!');", true);
        //    return;
        //}
        if (strKey == "0")
        {
            MessageBox.Show(this.UpdatePanel1, this, "此部门不能禁用!");
            return;
        }
        string strSQL = "Update Sys_Organization set [IsForbid] = 1 " +
                         " Where  [OrgCode] IN(" + strKey + ") ";

        if (DbHelperSQL.ExecuteSql(strSQL) > 0)
        {
            #region 数据同步
            if (ConfigurationManager.AppSettings["IsSync"] == "1")
            {
                try
                {
                    //添加成功，数据同步到各个磅房
                    IndustryPlatform.DBUtility.MsmqManage msm =   MsmqManage.GetMsmq();
                    strSQL = msm.AllStation + msm.Prefix + "Sys_Organization" + msm.Prefix + msm.EditFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                    msm.AddMsmq(strSQL);
                }
                catch
                { }
            }
            #endregion

            lk_Click(sender, e);
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('禁用成功!');", true);
        }
        else
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('禁用失败!');", true);
    }
}
