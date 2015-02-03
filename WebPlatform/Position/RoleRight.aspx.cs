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
using System.Text; 
using System.Collections.Generic;
using System.ServiceModel;
using IndustryPlatform.DBUtility;


public partial class Position_RoleRight : System.Web.UI.Page
{
    SYS_Position position = new SYS_Position();
    protected void Page_Load(object sender, EventArgs e)
    {
        tvmeun.Attributes.Add("onclick", " OnTreeNodeChecked('" + this.tvmeun.ClientID + "')");
        if (!Page.IsPostBack)
        {
            Databing();
            GetTree();
          
        }
    }

    //绑定数据
    private void Databing()
    {
        position.BindTreeview(tvmeun, "SYS_MENU", "menuName", "menuID", "parentsID", "0", "1=1");
        try
        {
            lblName.Text = position.Getresult("orgName", "SYS_Organization", " orgID=(select orgID from SYS_Position where PositonID=" + Request.QueryString["PositonID"] + ")");
            lblName.Text += "-->" + position.Getresult("PositionName", "SYS_Position", " PositonID=" + Request.QueryString["PositonID"] + "") + "-->";
        }
        catch
        {
            lblName.Text = "";
        }

    }


    #region  如果这个人已经有了权限，将其拥有的权限显示在菜单上

    //获取职位下的权限
    private void GetTree()
    {
        this.ViewState["dt"] = position.GetMenuPosition(Request.QueryString["PositonID"]).Tables[0];
        DataTable dt = (DataTable)ViewState["dt"];
        if (dt != null && dt.Rows.Count != 0)
        {
            for (int i = 0; i < tvmeun.Nodes.Count; i++)
            {
                if (tvmeun.Nodes[i].ChildNodes.Count > 0)  //判断是否还有子节点
                {
                    GetTreeNod(tvmeun.Nodes[i]);
                }
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (tvmeun.Nodes[i].Value == dt.Rows[j]["menuID"].ToString())
                    {
                        tvmeun.Nodes[i].Checked = true;
                    }

                }

            }
        }

    }
    //当编辑用户时，把已经选中的节点菜单，赋值给菜单树
    public void GetTreeNod(TreeNode node)
    {

        DataTable dt = (DataTable)ViewState["dt"]; 
        for (int i = 0; i < node.ChildNodes.Count; i++)
        {
            if (node.ChildNodes[i].ChildNodes.Count > 0)   
            {
                GetTreeNod(node.ChildNodes[i]);                
            }

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                if (node.ChildNodes[i].Value == dt.Rows[j]["menuID"].ToString())
                {
                    node.ChildNodes[i].Checked = true;
                }
              
            }
                
        }
    }
    #endregion

    #region  选定菜单后，循环保存到数据库里

    protected void btn_Edit_Click(object sender, ImageClickEventArgs e)
    {
        position.DelMenuPosition(Request.QueryString["PositonID"]);

        List<string> listMenus = new List<string>();
        for (int i = 0; i < tvmeun.Nodes.Count; i++)
        {
            if (tvmeun.Nodes[i].ChildNodes.Count > 0)  //判断是否还有子节点
            {
                GetNode(tvmeun.Nodes[i],ref listMenus);
            }
            if (tvmeun.Nodes[i].Checked == true)       //判断是否被选中
            {
                listMenus.Add(tvmeun.Nodes[i].Value);
                //string s = tvmeun.Nodes[i].Value.ToString();
                //h_Count.Value=position.AddMenuPosition(Request.QueryString["PositonID"], s).ToString();
            }
        }

        if (position.AddMenuPosition(Request.QueryString["PositonID"],listMenus)==1)
        {
            #region 数据同步
            if (ConfigurationManager.AppSettings["IsSync"] == "1")
            {
                try
                {
                    string strPositonID = Request.QueryString["PositonID"];
                    IndustryPlatform.DBUtility.MsmqManage msm =   MsmqManage.GetMsmq();
                    string strSQL = "Delete From Sys_MenuPosition Where PositionCode='" + strPositonID + "';";
                    foreach (string strCode in listMenus)
                    {
                        strSQL += " INSERT INTO Sys_MenuPosition ( "+
                                "[PositionCode] ,"+
                                "[MenuID] ) VALUES ('" + strPositonID + "','" + strCode + "');";
                    
                    }
                    strSQL = msm.AllStation + msm.Prefix + "Sys_MenuPosition" + msm.Prefix + msm.AddFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('权限设置失败！');", true);
        }


    }

    public void GetNode(TreeNode node,ref List<string> listMenus)
    {
        for (int i = 0; i < node.ChildNodes.Count; i++)
        {
            if (node.ChildNodes[i].ChildNodes.Count > 0)  //判断是否还有子节点
            {
                GetNode(node.ChildNodes[i],ref listMenus);               //递归查找
            }
            if (node.ChildNodes[i].Checked == true)     //判断是否被选中
            {
                listMenus.Add(node.ChildNodes[i].Value); //Updated by huangcm
                //string s = node.ChildNodes[i].Value.ToString();
                //h_Count.Value = position.AddMenuPosition(Request.QueryString["PositonID"], s).ToString();
            }
        }
    }
    #endregion

    protected void btn_chongzhi_Click(object sender, ImageClickEventArgs e)
    {
        Databing();
        tvmeun.ExpandAll();
        GetTree();
      
    }
}
