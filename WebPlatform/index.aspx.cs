using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IndustryPlatform.DBUtility;
using System.Text;
using System.Drawing;
using System.Data;
using IndustryPlatform.BLL;
public partial class index : BasePage
{
    public string sysid;
    public string strUrl;
    protected void Page_Load(object sender, EventArgs e)
    {

        //注册ajax  
        strUrl = IndustryPlatform.Common.SystemConfig.StartUrl;
        OutScriptUrl();//输出js
        sysid = Request.QueryString["sysid"];
        if (sysid == null || sysid == "")
        {
            sysid = "s0002";
        }
        CookieManager.AppendCookie("Sys", sysid);
        
        if (!Page.IsPostBack)
        {
            IndustryPlatform.Model.SYS_MenuEntity menu = new IndustryPlatform.BLL.SYS_Menu().GetModel(sysid);
            if (menu != null)
                this.lbSys.Text = menu.MenuName;
            DataSet ds = new DataSet();
            SYS_OperatorBll operbll = new SYS_OperatorBll();
            ds = operbll.GetOperatorInfo(CookieManager.GetCookieValue("uid"));
            this.lbUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();

            BindTree(sysid);
          
        }
    }

    public void OutScriptUrl()
    {
        string strScript = " <script type='text/javascript'> function initMainFrame() " +
       "{ " +
       "     document.getElementById('mainIframe').src='" + IndustryPlatform.Common.SystemConfig.StartUrl + "'; " +
       "} </script> ";

        this.Literal1.Text = strScript;
       
    }
    private void BindTree(string SysCode)
    {
        string strSql = "";
        if (CookieManager.GetCookieValue("uid") != "0") //非超级管理员用户
            strSql = "select * from SYS_MENU where menuID in(select distinct menuID from SYS_menuPosition where PositionCode in(" + CookieManager.GetCookieValue("PositionCode") + ")) Order by displayOrder";
        else
            strSql = "select * from SYS_MENU Order by displayOrder";
        DataSet DS = DbHelperSQL.DQuery(strSql);

        DataTable dt = DS.Tables[0];
        DataView dv = new DataView(dt);
        dv.RowFilter = " parentsID ='" + sysid + "' ";
        foreach (DataRowView drv in dv)
        {
            TreeNode node = new TreeNode();
            node.Text = drv["menuName"].ToString();
            node.Value = drv["menuID"].ToString();
            node.ImageUrl = "Images/icons/openroomiconinfo.gif";
            node.SelectAction = TreeNodeSelectAction.Expand;

            //根据测试需求加的
            //node.NavigateUrl = drv["menuAction"].ToString();
            //if ("0" == drv["IsPop"].ToString())
            //{
            //    node.NavigateUrl = "javascript:setTitleAndUrl('" + node.Text + "','" + drv["menuAction"].ToString() + "');";
            //}
            //else
            //{
            //    node.NavigateUrl = "javascript:window.open('" + drv["menuAction"].ToString() + "');";
            //}

            node.Expanded = false;
            this.TreeView1.Nodes.Add(node);
            AddReplies(dt, node);
        }
    }

    //递归函数 
    private void AddReplies(DataTable dt, TreeNode node)
    {
        DataView dv = new DataView(dt);
        dv.RowFilter = "parentsID=  '" + node.Value + "'  ";
        foreach (DataRowView row in dv)
        {
            TreeNode replyNode = new TreeNode();
            replyNode.Text = row["menuName"].ToString();
            replyNode.Value = row["menuID"].ToString();
            replyNode.ImageUrl = "Images/icons/setuseridicon.png";

            if ("0" == row["IsPop"].ToString())
            {
                replyNode.NavigateUrl = "javascript:setTitleAndUrl('&nbsp;&nbsp;" + replyNode.Text + "','" + row["MenuUrl"].ToString() + "');";
            }
            else
            {
                replyNode.NavigateUrl = "javascript:void(window.open('" + row["MenuUrl"].ToString() + "'));";
            }
            //replyNode.NavigateUrl = row["menuAction"].ToString();
            //if ("0" == row["IsPop"].ToString())
            //{
            //    replyNode.Target = "mainIframe";
            //}
            //else
            //{
            //    replyNode.Target = "_blank";
            //}
            // replyNode.Expanded = false;



            node.ChildNodes.Add(replyNode);
            AddReplies(dt, replyNode);
        }
    }


    protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
    {
        TreeNodeCollection ts = null;
        if (e.Node.Parent == null)
        {
            ts = ((TreeView)sender).Nodes;
        }
        else
            ts = e.Node.Parent.ChildNodes;
        foreach (TreeNode node in ts)
        {
            if (node != e.Node)
            {
                node.Collapse();
            }
        }
    }

}
