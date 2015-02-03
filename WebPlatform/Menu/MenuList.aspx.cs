using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IndustryPlatform.DBUtility;
using System.ServiceModel;

using System.Configuration;

public partial class Menu_MenuList : BasePage
{
    IndustryPlatform.BLL.SYS_Menu menuBll = new IndustryPlatform.BLL.SYS_Menu();
    List<int> PositionCodes = new List<int>();        //职位编号可以为多项

    protected void Page_Load(object sender, EventArgs e)
    {
        txt_MenuName.Focus();
        if (string.IsNullOrEmpty(CookieManager.GetCookieValue("PositionCode").ToString()))
        {
            return; 
        }
        else
        {
            if (CookieManager.GetCookieValue("PositionCode").ToString() == "'0'")
            {
                PositionCodes.Add(0);
            }
            else
            {
                foreach (string PositionCode in CookieManager.GetCookieValue("PositionCode").ToString().Split(','))
                {
                    PositionCodes.Add(Convert.ToInt32(PositionCode));
                }
            }
        }

        if (!IsPostBack)
        {
            //加载树
            menuBll.BuildTree(tv_Menu, PositionCodes);
            //加载列表
            LoadData();
        }
    }

    protected void tv_Menu_SelectedNodeChanged(object sender, EventArgs e)
    {
        //加载列表
        LoadData();
    }

    protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "MenuAdd();", true);
    }

    protected void imgbtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        List<string> ids = GetMenUserCodes();
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "MenuUpdate('" + ids[0] + "');", true);
    }

    protected void imgbtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        List<string> listMenus = GetMenUserCodes();
        int retVal = menuBll.BatchDelete(listMenus);
        if (retVal == 1)
        {
            #region 数据同步
            if (ConfigurationManager.AppSettings["IsSync"] == "1")
            {
                try
                {
                    //添加成功，数据同步到各个磅房
                    IndustryPlatform.DBUtility.MsmqManage msm =  MsmqManage.GetMsmq();
                    foreach (string strMenuID in listMenus)
                    {
                        string strSQL = "Delete From Sys_Menu Where MenuID='" + strMenuID + "'";
                        strSQL = msm.AllStation + msm.Prefix + "Sys_Menu" + msm.Prefix + msm.DelFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                        msm.AddMsmq(strSQL);
                    }
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
                    //        proxy.IndustryPlatform_Menu_BatchDelete(listMenus);
                    //    }
                    //}
                }
                catch
                { }
            }
            #endregion

            tv_Menu.Nodes.Clear();
            menuBll.BuildTree(tv_Menu, PositionCodes);
            tv_Menu.ExpandAll();
            LoadData();
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('删除成功!');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "alert('删除失败!');", true);
        }
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        findData();
        menuBll.BuildTree(tv_Menu, PositionCodes);
    }

    protected void anp_Menu_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        anp_Menu.CurrentPageIndex = e.NewPageIndex;
        LoadData();
    }

    protected List<string> GetMenUserCodes()
    {
        List<string> ListIDs = new List<string>();
        string[] IDs = this.hdKey.Value.Split(',');

        for (int i = 0; i < IDs.Length; i++)
        {
            ListIDs.Add(this.gdv_Menu.DataKeys[Convert.ToInt32(IDs[i])].Value.ToString());
        }

        return ListIDs;
    }

    protected void findData()
    {
        string strWhere = "1=1";
        if (!string.IsNullOrEmpty(this.txt_MenuID.Text))
        {
            strWhere += " and MenuID LIKE '%" + txt_MenuID.Text.Trim() + "%'";
        }
        if (!string.IsNullOrEmpty(txt_MenuName.Text))
        {
            strWhere += " and MenuName LIKE '%" + txt_MenuName.Text.Trim() + "%'";
        }
        ControlBindHelper.GridViewPagerBindByRowNum(this.anp_Menu, "SYS_MENU", strWhere, "menuLevel,displayOrder", this.gdv_Menu);
    }
    protected void LoadData()
    {
        string strWhere = "1=1";
        
        if (tv_Menu.SelectedNode != null)
        {
            strWhere += " and menuSEQ LIKE '%" + tv_Menu.SelectedNode.Value + "%'";
        }
        ControlBindHelper.GridViewPagerBindByRowNum(this.anp_Menu, "SYS_MENU", strWhere, "menuLevel,displayOrder", this.gdv_Menu);
        //menuBll.GridViewPagerBind(anp_Menu, strWhere, "menuLevel,displayOrder", gdv_Menu, PositionCodes);
    }
    protected void lk_Click(object sender, EventArgs e)
    {
        tv_Menu.Nodes.Clear();
        menuBll.BuildTree(tv_Menu, PositionCodes);
        tv_Menu.ExpandAll();
        LoadData();
    }
    protected void gdv_Menu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "RowClick(this);");

            //获取父菜单名称
            Label parentMenuName = (Label)e.Row.FindControl("lblParent");
            parentMenuName.Text = menuBll.GetMenuNameByID(gdv_Menu.DataKeys[e.Row.RowIndex].Values[1].ToString());
        }
    }
}
