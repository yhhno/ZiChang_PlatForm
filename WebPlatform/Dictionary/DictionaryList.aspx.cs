using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using IndustryPlatform.DBUtility;
using IndustryPlatform.BLL;
using System.Text;
using System.ServiceModel;

using System.Configuration;

public partial class Dictionary_DictionaryList : System.Web.UI.Page
{
    SYS_Dictionary bll_dic = new SYS_Dictionary();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            IndexLoadBind();   //加载数据
        }
    }


    #region 初始化页面
    private void IndexLoadBind()
    { 
        DataTree();   //绑定树
        DBind();    //绑定列表
    }
    #endregion


    #region 绑定列表数据
    public void DBind()
    {
        ControlBindHelper.GridViewPagerBindByRowNum(this.anp_Dic, "VSYS_Dictionary", getWhere(), "status,businTypeID", this.gdv_Dic);
    }
    #endregion

    #region 设定查询条件
    protected string getWhere()
    {
        StringBuilder sb_where = new StringBuilder();
        string strWhere = " 1=1";
        if (CookieManager.GetCookieValue("uid") != "0")
            strWhere = "IsCanEdit='1'";
        sb_where.Append(strWhere);
        if (tvDictionaryType.SelectedNode != null)
             sb_where.Append(" and businTypeID=" + tvDictionaryType.SelectedNode.Value + " ");
        return sb_where.ToString();
    }
    #endregion

    #region 绑定字典类型
    private void DataTree()
    {
        SYS_Dictionary dic = new SYS_Dictionary();
        string strWhere="1=1";
        if (CookieManager.GetCookieValue("uid") != "0")
            strWhere = "IsCanEdit='1'";
        DataSet ds = dic.GetDictionaryType(strWhere);
        if (ds != null)
        {
            //绑定树
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                TreeNode node = new TreeNode();
                node.Text = row["businTypeName"].ToString();
                node.Value = row["businTypeID"].ToString();
                tvDictionaryType.Nodes.Add(node);
            }
        }
        else
        {
            //加载数据失败
        }
    }
    #endregion


    protected void tvDepart_SelectedNodeChanged(object sender, EventArgs e)
    {
        DBind();  //根据选中的字典类型进行重新绑定
    }

     

    protected void anp_Org_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.anp_Dic.CurrentPageIndex = e.NewPageIndex;
        this.DBind();
        //DBind(tvDepart.SelectedNode.Value,Name.Text);
      
    }
 
 
    //循环出选择上的数据
    public string GetSelect()
    {
        string strtext = "";
        foreach (GridViewRow grvRow in gdv_Dic.Rows)
        {
            CheckBox chk_BoxSelect = (CheckBox)grvRow.Cells[0].FindControl("cbx");
            if (chk_BoxSelect.Checked == true)
            {
                strtext += gdv_Dic.DataKeys[grvRow.DataItemIndex].Values[0].ToString() + "|" + gdv_Dic.DataKeys[grvRow.DataItemIndex].Values[1].ToString() + ",";
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
 
    protected void lk_Click(object sender, EventArgs e)
    {
        //this.tvDepart.Nodes.Clear();
        //bll.OrgTreeBind(0, (TreeNode)null, this.tv_Org);
        //this.tv_Org.ExpandAll();
        //loadData();
    }
    protected void gdv_Org_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "RowClick(this);");
        }
    }

    //关闭弹出页的时候，刷新职位列表和职位下拉框
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.DBind();
    }



    protected void lkAdd_Click(object sender, EventArgs e)
    {

        string strNode = "0";
        if (tvDictionaryType.SelectedNode != null)
        {
            strNode = tvDictionaryType.SelectedNode.Value;
        }

        ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "AddFrom(" + strNode + ");", true);


          
    }
    protected void lkUpdate_Click(object sender, EventArgs e)
    {
        string strselect = GetSelect();
        if ("" != strselect)
        {
            if (GetSelect().LastIndexOf(",") == -1)
            {
                // Response.Redirect("DataEdit.aspx?PositonID=" + strselect);
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "EditFrom(" + strselect.Split('|')[0] + "," + strselect.Split('|')[1] + ");", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "myscript", "alert('修改只能选择一条数据！');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "myscript", "alert('请选择修改数据！');", true);
        }
    }

    #region 删除
    protected void lkDelete_Click(object sender, EventArgs e)
    {
        string strselect = GetSelect();
        if ("" != strselect)
        {
            if (GetSelect().LastIndexOf(",") == -1)
            {
                string strSQL = "Update Sys_Dictionary Set IsForbid= '0'  Where BusinID='" + strselect.Split('|')[0] + "' And BusinTypeID='" + strselect.Split('|')[1] + "'";
                if (DbHelperSQL.ExecuteSql(strSQL) > 0)
                {

                    #region 数据同步
                    if (ConfigurationManager.AppSettings["IsSync"] == "1")
                    {
                        try
                        {
                            //添加成功，数据同步到各个磅房
                            IndustryPlatform.DBUtility.MsmqManage msm =  MsmqManage.GetMsmq();
                            strSQL = msm.AllStation + msm.Prefix + "Sys_Dictionary" + msm.Prefix + msm.EditFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
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
                            //        proxy.IndustryPlatform_Dictionary_Delete(strselect.Split('|')[0], strselect.Split('|')[1]);
                            //    }
                            //}
                        }
                        catch
                        { }
                    }
                    #endregion

                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "alert('启用成功!');", true);
                    this.DBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "alert('启用失败!');", true);
                }
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('启用只能选择一条!');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('请选择启用数据！');", true);
        }
    }
    #endregion


    //禁用
    protected void lnkbtnForbid_Click(object sender, EventArgs e)
    {
        string strselect = GetSelect();
        if ("" != strselect)
        {
            if (GetSelect().LastIndexOf(",") == -1)
            {
                if (this.tvDictionaryType.SelectedValue == "1001")
                {
                    if (DbHelperSQL.Exists("Select Count(0) from TT_TaxItem where ItemType='" + strselect.Split('|')[0] + "'"))
                    {
                        MessageBox.Show(this.UpdatePanel1, this, "您选择的记录已经设置过规费项目不能禁用！");
                        return;
                    }
                }
                string strSQL = "Update Sys_Dictionary Set IsForbid= '1'  Where BusinID='" + strselect.Split('|')[0] + "' And BusinTypeID='" + strselect.Split('|')[1] + "'";
                if (DbHelperSQL.ExecuteSql(strSQL)>0)
                {

                    #region 数据同步
                    if (ConfigurationManager.AppSettings["IsSync"] == "1")
                    {
                        try
                        {
                            //添加成功，数据同步到各个磅房
                            IndustryPlatform.DBUtility.MsmqManage msm =  MsmqManage.GetMsmq();
                            strSQL = msm.AllStation + msm.Prefix + "Sys_Dictionary" + msm.Prefix + msm.EditFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
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
                            //        proxy.IndustryPlatform_Dictionary_Delete(strselect.Split('|')[0], strselect.Split('|')[1]);
                            //    }
                            //}
                        }
                        catch
                        { }
                    }
                    #endregion

                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "alert('禁用成功!');", true);
                    this.DBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "alert('禁用失败!');", true);
                }
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('禁用只能选择一条!');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('请选择禁用数据！');", true);
        }
    }
    
}
