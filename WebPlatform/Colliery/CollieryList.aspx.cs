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
using IndustryPlatform.BLL;
using System.Drawing;
using System.ServiceModel;
using System.Collections.Generic;

using IndustryPlatform.DBUtility;

public partial class Colliery_CollieryList : System.Web.UI.Page
{
    Sys_Colliery coll = new Sys_Colliery();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCollCode.Focus();
        if (!Page.IsPostBack)
        {
            string strCustomer = ConfigurationSettings.AppSettings["ProName"];
            if (strCustomer != "FuYuan")
                this.gdv_Colliery.Columns[7].Visible = false;
            IndexLoadBind();
        }
    }


    //初始化加载
    private void IndexLoadBind()
    {
        //生成乡镇列表
        ControlBindHelper.DropDownListBind(this.ddlVillageCode, "Sys_Dictionary", "BusinName", "BusinID", "BusinTypeID='1002' and IsForbid='0'", "请选择所属乡镇", "-1");
        DBind();
    }
    /// <summary>
    /// 加载数据列表
    /// </summary>
    public void DBind()
    {
        string strWhere = " 1=1";
        if (this.ddlVillageCode.SelectedValue != "-1")
            strWhere += " and VillageCode='" + this.ddlVillageCode.SelectedValue + "'";
        if (this.ddlIsForbid.SelectedValue != "-1")
            strWhere += " and  IsForbid ='" + ddlIsForbid.SelectedValue + "'";
        if (this.txtCollCode.Text.Trim() != "")
            strWhere += " and CollCode like '%" + this.txtCollCode.Text.Trim().Replace("'", "''") + "%'";
        if (this.txtCollName.Text.Trim() != "")
            strWhere += " and CollName like '%"+this.txtCollName.Text.Trim().Replace("'","''")+"%'";
        ControlBindHelper.GridViewPagerBindByRowNum(this.anp_Colliery, "VSYS_CollieryNet", strWhere, " IsForbid asc,CollCode desc", this.gdv_Colliery);
    }

    protected void lkAdd_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "AddFrom();", true);
    }

    protected void lkUpdate_Click(object sender, EventArgs e)
    {
        string strselect = GetSelect("");
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "EditFrom(" + strselect + ");", true);
    }

    protected void lkDelete_Click(object sender, EventArgs e)
    {
        string strselect = GetSelect("");
        //判断煤种是否在标示卡中，如果存在，则不能禁用
        if ("" != coll.Getresult("CollCode", "TT_MarkedCard", "CollCode in (" + strselect + ")"))
        {
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "alert('此煤矿已经存在标示卡中，请查证后在删除！');", true);
            return;
        }

        if (coll.Delete(strselect) == 1)
        {
            DBind();

            //增加煤矿删除日志
            string[] split = strselect.Split(new Char[] { ',' });
            foreach (string s in split)
            {
                //IndustryPlatform.BLL.TT_OperateLog.Add("煤矿信息删除", "9999", "sys_Colliery", "", s.Substring(1, s.LastIndexOf("'") - 1));
            }
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "alert('删除成功！');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "alert('删除失败！');", true);
        }
    }


    //禁用煤矿
    protected void lkForbid_Click(object sender, EventArgs e)
    {
        string strselect = GetSelect("1");
        if ("" != strselect)
        {
            if (coll.Forbid(strselect, "1") == 1)
            {
                #region 同步数据
                if (ConfigurationManager.AppSettings["IsSync"] == "1")
                {
                    try
                    {
                        //添加成功，数据同步到各个磅房
                        MsmqManage msm = MsmqManage.GetMsmq();
                        string strSQL = "update Sys_Colliery set IsForbid = 1 " +
                            "Where CollCode In(" + strselect + ")";
                        strSQL = msm.AllStation + msm.Prefix + "Sys_Colliery" + msm.Prefix + msm.EditFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                        msm.AddMsmq(strSQL);

                    }
                    catch
                    { }
                }
                #endregion

                DBind();
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "alert('禁用成功！');", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "alert('禁用失败！');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('您选中的煤矿已经是禁用状态！');", true);
        }
    }

    //解禁煤矿
    protected void LkEmbargoor_Click(object sender, EventArgs e)
    {
        string strselect = GetSelect("0");
        if ("" != strselect)
        {
            if (coll.Forbid(strselect, "0") == 1)
            {
                #region 同步数据
                if (ConfigurationManager.AppSettings["IsSync"] == "1")
                {
                    try
                    {
                        //添加成功，数据同步到各个磅房
                        IndustryPlatform.DBUtility.MsmqManage msm = IndustryPlatform.DBUtility.MsmqManage.GetMsmq();
                        string strSQL = "update Sys_Colliery set IsForbid = 0 " +
                            "Where CollCode In(" + strselect + ")";

                        strSQL = msm.AllStation + msm.Prefix + "Sys_Colliery" + msm.Prefix + msm.EditFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                        msm.AddMsmq(strSQL);
                        //List<string> iplist = new TDTK.IndustryPlatform.CoalTraffic.BLL.TT_Room().GetAllRoomIP();
                        //for (int i = 0; i < iplist.Count; i++)
                        //{
                        //    if (iplist[i] != "")
                        //    {
                        //        EndpointAddress ep = new EndpointAddress("net.msmq://" + iplist[i] + "/private/STOCMessagingQueue");
                        //        NetMsmqBinding et = new NetMsmqBinding();
                        //        et.ExactlyOnce = false;
                        //        et.Security.Mode = System.ServiceModel.NetMsmqSecurityMode.None;
                        //        IDataPublish proxy = ChannelFactory<IDataPublish>.CreateChannel(et, ep);
                        //        proxy.ForbidCollieryIndustryPlatform(strselect, "0");
                        //    }
                        //}
                    }
                    catch
                    { }
                }
                #endregion

                DBind();
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "alert('启用成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "alert('启用失败！');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('您选中的煤矿已经是启用状态！');", true);
        }
    }

    //循环出选择上的数据
    public string GetSelect(string strIsForbid)
    {
        string strtext = "";
        foreach (GridViewRow grvRow in gdv_Colliery.Rows)
        {
            HiddenField hdIsForbid = (HiddenField)grvRow.Cells[0].FindControl("hdIsForbid");
            if (strIsForbid != "")
            {
                if (hdIsForbid.Value != strIsForbid)
                {
                    CheckBox chk_BoxSelect = (CheckBox)grvRow.Cells[0].FindControl("cbx");
                    if (chk_BoxSelect.Checked == true)
                    {
                        strtext += "'" + gdv_Colliery.DataKeys[grvRow.DataItemIndex].Value.ToString() + "',";
                    }
                }
            }
            else
            {
                CheckBox chk_BoxSelect = (CheckBox)grvRow.Cells[0].FindControl("cbx");
                if (chk_BoxSelect.Checked == true)
                {
                    strtext += "'" + gdv_Colliery.DataKeys[grvRow.DataItemIndex].Value.ToString() + "',";
                }
            }
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

    protected void anp_Colliery_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.anp_Colliery.CurrentPageIndex = e.NewPageIndex;
        DBind();
    }
    protected void gdv_Colliery_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "RowClick(this);");
            if (e.Row.Cells[8].Text == "是")
                e.Row.Cells[8].ForeColor = Color.Red;

         
        }
    }
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.anp_Colliery.CurrentPageIndex = 1;
        DBind();
    }

    protected void lk_Click(object sender, EventArgs e)
    {
        DBind();
    }
}
