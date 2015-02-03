using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.ServiceModel;

using IndustryPlatform.DBUtility;
using System.Configuration;

public partial class Menu_AddMenu : System.Web.UI.Page
{
    IndustryPlatform.BLL.SYS_Menu menuBll = new IndustryPlatform.BLL.SYS_Menu();
    IndustryPlatform.Model.SYS_MenuEntity menuModel = new IndustryPlatform.Model.SYS_MenuEntity();
    List<int> PositionCodes = new List<int>();        //职位编号可以为多项
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(CookieManager.GetCookieValue("PositionCode").ToString()))
        {
            return;
        }
        else
        {
            if (CookieManager.GetCookieValue("PositionCode").ToString() != "'0'")
            {
            foreach (string PositionCode in CookieManager.GetCookieValue("PositionCode").ToString().Split(','))
            {
                PositionCodes.Add(Convert.ToInt32(PositionCode));
            }
            }
            else
            {
                PositionCodes.Add(0);
            }
        }

        if (!IsPostBack)
        {
            this.txtMenuName.Focus();
            menuBll.BindDdl(ddlParents, PositionCodes);
            SetText();
        }
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (this.ddlParents.SelectedIndex == 0)
        {
            MessageBox.Show(this, "请选择父节点!");
            return;
        }
        if (Request.QueryString["menuID"] != null)
        {
            if (this.chkIsLeaf.Checked)
            {
                if (DbHelperSQL.Exists("Select Count(0) from Sys_Menu where ParentsID='" + Request.QueryString["menuID"].ToString() + "'"))
                {
                    MessageBox.Show(this, "您修改的节点下面还有子节点，不能修改成叶子节点!");
                    return;
                }
            }
        }
        BuildModel();

        if (string.IsNullOrEmpty(Request.QueryString["menuID"]))
        {
            string strparentsID = "0";
            if (this.ddlParents.SelectedIndex != 0)
                strparentsID = this.ddlParents.SelectedValue;
            DataTable dtExist = menuBll.GetList(" menuName='" + this.txtMenuName.Text.Trim().Replace("'", "''") + "' and parentsID='"+strparentsID+"'").Tables[0];
            if (dtExist.Rows.Count > 0)
            {
                MessageBox.Show(this, "同父级别下的菜单名称不能重复，请重新输入!");
                return;
            }
            if (menuBll.Add(menuModel) == 1)
            {
                #region 数据同步
                if (ConfigurationManager.AppSettings["IsSync"] == "1")
                {
                    try
                    {
                        //添加成功，数据同步到各个磅房
                        IndustryPlatform.DBUtility.MsmqManage msm = MsmqManage.GetMsmq();
                            string strSQL = "INSERT INTO Sys_Menu ( "+
                            "[MenuID] ,"+
                            "[MenuName] ,"+
                            "[MenuUrl] ,"+
                            "[FunctionID] ,"+
                            "[IsLeaf] ,"+
                            "[MenuLevel] ,"+
                            "[RootID] ,"+
                            "[ParentsID] ,"+
                            "[DisplayOrder] ,"+
                            "[IcValue] ,"+
                            "[IsPop] ,"+
                            "[MenuSeq] ) VALUES ('" + menuModel.MenuID + "','" + CommonMethod.RepChar(menuModel.MenuName) +
                            "','" + CommonMethod.RepChar(menuModel.MenuUrl) + "','" + menuModel.FunctionID +
                            "','" + menuModel.IsLeaf + "','" + menuModel.MenuLevel +
                            "','" + menuModel.RootID + "','" + menuModel.ParentsID +
                            "'," + menuModel.DisplayOrder + ",'" + menuModel.IcValue +
                            "','" + menuModel.IsPop + "','" + menuModel.MenuSeq + "')";
                            strSQL = msm.AllStation + msm.Prefix + "Sys_Menu" + msm.Prefix + msm.AddFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
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
                        //        proxy.IndustryPlatform_Menu_Add(menuModel);
                        //    }
                        //}
                    }
                    catch
                    { }
                }
                #endregion

                MessageBox.Show(this, "添加成功！");
                SetText();
                menuBll.BindDdl(ddlParents, PositionCodes);
            }
            else
            {
                MessageBox.Show(this, "添加失败！");
            }
        }
        else//更新操作
        {
            menuModel.MenuID = Request.QueryString["MenuID"];
            string strparentsID = "0";
            if (this.ddlParents.SelectedIndex != 0)
                strparentsID = this.ddlParents.SelectedValue;
            DataTable dtExist = menuBll.GetList(" menuName='" + this.txtMenuName.Text.Trim().Replace("'", "''") + "' and MenuID<>'" + menuModel.MenuID + "' and ParentsID='" + strparentsID + "'").Tables[0];
            if (dtExist.Rows.Count > 0)
            {
                MessageBox.Show(this, "同父级别下的菜单名称不能重复，请重新输入!");
                return;
            }

            if (menuBll.IsChildren(menuModel.MenuID, ddlParents.SelectedValue))
            {
                MessageBox.Show(this, "不要选择该菜单项下的子菜单项作为父菜单！");
                //菜单项实体
                IndustryPlatform.Model.SYS_MenuEntity menu = menuBll.GetModel(menuModel.MenuID);

                ddlParents.SelectedValue = menu.ParentsID;
            }
            else
            {

                if (menuBll.Update(menuModel) == 1)
                {
                    #region 数据同步
                    if (ConfigurationManager.AppSettings["IsSync"] == "1")
                    {
                        try
                        {
                            //添加成功，数据同步到各个磅房
                            if (menuModel.DisplayOrder == null) menuModel.DisplayOrder = 0;
                            //添加成功，数据同步到各个磅房
                            IndustryPlatform.DBUtility.MsmqManage msm =   MsmqManage.GetMsmq();
                            string strSQL = "Delete From Sys_Menu Where MenuID='" + menuModel.MenuID + "'; ";

                            strSQL+= "INSERT INTO Sys_Menu ( " +
                            "[MenuID] ," +
                            "[MenuName] ," +
                            "[MenuUrl] ," +
                            "[FunctionID] ," +
                            "[IsLeaf] ," +
                            "[MenuLevel] ," +
                            "[RootID] ," +
                            "[ParentsID] ," +
                            "[DisplayOrder] ," +
                            "[IcValue] ," +
                            "[IsPop] ," +
                            "[MenuSeq] ) VALUES ('" + menuModel.MenuID + "','" + CommonMethod.RepChar(menuModel.MenuName) +
                            "','" + CommonMethod.RepChar(menuModel.MenuUrl) + "','" + menuModel.FunctionID +
                            "','" + menuModel.IsLeaf + "','" + menuModel.MenuLevel +
                            "','" + menuModel.RootID + "','" + menuModel.ParentsID +
                            "'," + menuModel.DisplayOrder + ",'" + menuModel.IcValue +
                            "','" + menuModel.IsPop + "','" + menuModel.MenuSeq + "')";
                            strSQL = msm.AllStation + msm.Prefix + "Sys_Menu" + msm.Prefix + msm.AddFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                            msm.AddMsmq(strSQL);
                            
                        }
                        catch
                        { }
                    }
                    #endregion

                    ClientScript.RegisterStartupScript(Page.GetType(), "", "this.top.currForm.close();", true);
                }
                else
                {
                    MessageBox.Show(this, "修改失败！");
                }
            }
        }
    }

    protected void btnReset_Click(object sender, ImageClickEventArgs e)
    {
        SetText();
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "", "this.top.currForm.close();", true);
    }

    protected void SetText()
    {
        if (string.IsNullOrEmpty(Request.QueryString["menuID"]))
        {
            txtDisplayOrder.Text = string.Empty;
            txtFunctionID.Text = string.Empty;
            txtICValue.Text = string.Empty;
            txtMenuAction.Text = string.Empty;

            txtMenuName.Text = string.Empty;

            chkIsLeaf.Checked = false;
            chkIsPop.Checked = false;

        }
        else
        {
            SetModelToControl(Request.QueryString["menuID"]);
        }
    }

    protected void SetModelToControl(string menUserCode)
    {
        //菜单项实体
        IndustryPlatform.Model.SYS_MenuEntity menu = menuBll.GetModel(menUserCode);

        this.txtDisplayOrder.Text = menu.DisplayOrder.ToString();            //排序编号
        this.txtFunctionID.Text = menu.FunctionID.ToString();                //功能编号
        this.txtICValue.Text = menu.IcValue.ToString();                      //图片地址
        this.txtMenuAction.Text = menu.MenuUrl.ToString();                //菜单项活动
        //this.txtMenuLabel.Text = menu.MenuLabel.ToString();                  //菜单项标签

        this.txtMenuName.Text = menu.MenuName.ToString();                    //菜单名称
        this.chkIsLeaf.Checked = menu.IsLeaf.Trim() == "0" ? false : true;   //是否为叶子节点
        this.chkIsPop.Checked = menu.IsPop.Trim() == "0" ? false : true;     //是否填出

        this.ddlParents.SelectedValue = menu.ParentsID;                      //父菜单项编号
    }

    /// <summary>
    /// 为menu实体赋值
    /// </summary>
    protected void BuildModel()
    {
        string menUserCode = string.Empty;
        if (string.IsNullOrEmpty(Request.QueryString["menuID"]))
        {
            menUserCode = menuBll.BuildMenuID();
        }
        else
        {
            menUserCode = Request.QueryString["menuID"].Trim();
        }

        menuModel.DisplayOrder = Convert.ToDecimal(txtDisplayOrder.Text.Trim());        //显示顺序
        menuModel.FunctionID = string.Empty;                                            //功能编号现在还没有用途
        menuModel.IcValue = txtICValue.Text.Trim();                                     //图片地址
        menuModel.IsLeaf = chkIsLeaf.Checked ? "1" : "0";                               //是否为叶菜单项
        menuModel.IsPop = chkIsPop.Checked ? "1" : "0";                                 //是否弹出
        menuModel.MenuUrl = chkIsLeaf.Checked ? txtMenuAction.Text.Trim() : string.Empty;  //菜单活动
        menuModel.MenuID = menUserCode;                                                      //菜单项编号
        //menuModel.MenuLabel = txtMenuLabel.Text.Trim();                                 //菜单项标签
        menuModel.MenuName = txtMenuName.Text.Trim();                                   //菜单项名称

        if (ddlParents.SelectedValue == "0")
        {
            menuModel.RootID = "0";                                                     //菜单项为根时，根编号为0
            menuModel.ParentsID = "0";                                                  //菜单项为根时，父编号为0
            menuModel.MenuSeq = menUserCode;                                                 //菜单项为根时，序号为本身编号
            menuModel.MenuLevel = "0";                                                  //菜单项为根时，菜单项级别为0
        }
        else
        {
            menuModel.ParentsID = ddlParents.SelectedValue;
            menuModel.MenuSeq = menuBll.GetParentSEQ(ddlParents.SelectedValue) + "." + menUserCode;
            menuModel.MenuLevel = (menuBll.GetMenuLevel(ddlParents.SelectedValue) + 1).ToString();
            menuModel.RootID = menuModel.MenuSeq.Substring(0, 5);
        }
    }
}
