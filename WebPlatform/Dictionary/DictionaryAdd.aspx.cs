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
using IndustryPlatform.Model;
using IndustryPlatform.DBUtility;
using System.Collections.Generic;
using System.ServiceModel;

public partial class Dictionary_DictionaryAdd : System.Web.UI.Page
{
    SYS_DictionaryEntity entity_dic;
    SYS_Dictionary bll_dic;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            txt_name.Focus();
            initPage();     //初始化页面数据
        }
    }

    #region 初始化页面数据
    protected void initPage()
    {
        //初始化字典类型
        ControlBindHelper.DropDownListBind(ddl_type, "SYS_BusinType", "businTypeName", "businTypeID", " 1=1 ","请选择类型!","0");
        if (Request.QueryString["did"] == null)
        {
            if (Request.QueryString["typeid"] != "0")
                ddl_type.SelectedValue = Request.QueryString["typeid"];
            //this.txt_privilege.Text = "";
            this.txt_name.Text = "";
            this.cb_status.Checked = false;
        }
        else
        {
            //加载修改页面信息
            bll_dic = new SYS_Dictionary();
            entity_dic = bll_dic.GetModel(Request.QueryString["did"], Request.QueryString["tid"]);
            if (entity_dic != null)
            {
                this.txt_name.Text = entity_dic.BusinName;
                //this.txt_privilege.Text = entity_dic.privilege.ToString();
                this.ddl_type.SelectedValue = entity_dic.BusinTypeID;
                this.ddl_type.Enabled = false;
                this.cb_status.Checked = entity_dic.IsForbid == "1"?true :false;
            }
            else
                MessageBox.Show(this.Page, "加载数据失败!");
        }
        //txt_name.Focus();
    }
    #endregion

    #region 保存数据
    protected void btn_Save_Click(object sender, ImageClickEventArgs e)
    {
        entity_dic = new IndustryPlatform.Model.SYS_DictionaryEntity();

        #region 初始化数据
        entity_dic.BusinName = this.txt_name.Text.Trim();
        entity_dic.BusinTypeID = this.ddl_type.SelectedValue;
        entity_dic.IsForbid = this.cb_status.Checked == true ? "1" : "0";
        //entity_dic.privilege = 0;
        //if (this.txt_privilege.Text.Trim()!="")
        //    entity_dic.privilege = Convert.ToDecimal(this.txt_privilege.Text.Trim());
        #endregion

        bll_dic = new SYS_Dictionary();
        bool isOk = false;
        if (Request.QueryString["did"] == null)    //添加
        {
            if (bll_dic.Exists(entity_dic.BusinTypeID, entity_dic.BusinName, ""))
            {
                MessageBox.Show(this.upDepartAdd, this, "您输入的名称在["+this.ddl_type.SelectedItem.Text+"]类型中已经存在,请重新输入!");
                return;
            }
            lock (this)
            {
                entity_dic.BusinID = DbHelperSQL.GetMaxID("businID", "SYS_Dictionary", " businTypeID=" + entity_dic.BusinTypeID).ToString(); // 获得最大ID
                isOk = bll_dic.Add(entity_dic);
            }
        }
        else                                       //修改
        {
            entity_dic.BusinID = Request.QueryString["did"];
            if (bll_dic.Exists(entity_dic.BusinTypeID, entity_dic.BusinName, entity_dic.BusinID))
            {
                MessageBox.Show(this.upDepartAdd, this, "您输入的名称在[" + this.ddl_type.SelectedItem.Text + "]类型中已经存在,请重新输入!");
                return;
            }
            //entity_dic.businTypeID = Request.QueryString["tid"];
            isOk = bll_dic.Update(entity_dic);
        }
        if (isOk)
        {
            #region 数据同步
            if (ConfigurationManager.AppSettings["IsSync"] == "1")
            {
                try
                {
                    ////添加成功，数据同步到各个磅房
                     IndustryPlatform.DBUtility.MsmqManage msm =   MsmqManage.GetMsmq();
                     if (entity_dic.DisplayOrder == null)
                     {
                         entity_dic.DisplayOrder = 0;
                     }
                    if (Request.QueryString["did"] == null || Request.QueryString["did"] == "" )
                    {//添加
                       string strSQL = "INSERT INTO Sys_Dictionary ( "+
                                            "[BusinID] ,"+
                                            "[BusinName] ,"+
                                            "[BusinTypeID] ,"+
                                            "[DisplayOrder] ,"+
                                            "[IsForbid] ,"+
                                            "[OtherInfo] ) VALUES ('" + entity_dic.BusinID + "','" + entity_dic.BusinName +
                                            "','" + entity_dic.BusinTypeID + "'," + entity_dic.DisplayOrder +
                                            ",'" + entity_dic.IsForbid + "','')";
                       strSQL = msm.AllStation + msm.Prefix + "Sys_Dictionary" + msm.Prefix + msm.AddFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                        msm.AddMsmq(strSQL);
                    }
                    else
                    {//修改
                        string strSQL = "Delete From Sys_Dictionary Where BusinID='" + entity_dic.BusinID + "' And BusinTypeID='" + entity_dic.BusinTypeID + "';";
                        strSQL+= "INSERT INTO Sys_Dictionary ( "+
                                            "[BusinID] ,"+
                                            "[BusinName] ,"+
                                            "[BusinTypeID] ,"+
                                            "[DisplayOrder] ,"+
                                            "[IsForbid] ,"+
                                            "[OtherInfo] ) VALUES ('" + entity_dic.BusinID + "','" + entity_dic.BusinName +
                                            "','" + entity_dic.BusinTypeID + "'," + entity_dic.DisplayOrder +
                                            ",'" + entity_dic.IsForbid + "','');";
                        strSQL = msm.AllStation + msm.Prefix + "Sys_Dictionary" + msm.Prefix + msm.DelFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
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
                    //        if (Request.QueryString["did"] == null)
                    //            proxy.IndustryPlatform_Dictionary_Add(entity_dic);
                    //        else
                    //            proxy.IndustryPlatform_Dictionary_Update(entity_dic);
                    //    }
                    //}
                }
                catch
                { }
            }
            #endregion

            if (Request.QueryString["did"] == null)
            {
                MessageBox.Show(this.upDepartAdd, this, "保存成功!");
                initPage();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "top.currForm.close();", true);
            }
        }
        else
        {
            MessageBox.Show(this.upDepartAdd, this, "保存失败!");
        }
        
    }
    #endregion



    protected void btn_chongzhi_Click(object sender, ImageClickEventArgs e)
    {
        initPage();
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnCancel_Click1(object sender, ImageClickEventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.upDepartAdd, Page.GetType(), "", "top.currForm.close();", true);
       // ScriptManager.RegisterStartupScript(Page.GetType(), "", "this.top.OperForm.close();", true);
    }
}
