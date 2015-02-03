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
using System.Collections.Generic;
using IndustryPlatform.DBUtility;
using System.ServiceModel;


public partial class Position_DataEdit : System.Web.UI.Page
{
    SYS_Position position = new SYS_Position();
    SYS_PositionEntity Emtity = new SYS_PositionEntity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            txt_PositionName.Focus();
            IndexLoadBind();
        }
    }

    //初始化加载
    private void IndexLoadBind()
    {
        SetText();
    }

    /// <summary>
    /// 初始化数据
    /// </summary>
    void SetText()
    {
        if (Request.QueryString["PositonID"] != null)
        {
            Emtity = position.GetModel(Request.QueryString["PositonID"].ToString());
            if (Emtity != null)
            {
                this.txt_PositionName.Text = Emtity.PositionName;
                this.txt_Remark.Text = Emtity.Remark;
                //this.h_orgID.Value = Emtity.orgID.ToString();
                //this.ddl_IsForbid.SelectedValue = Emtity.IsForbid;
                // this.txt_orgName.Text = position.Getresult("orgName", "SYS_Organization", " orgID=" + Emtity.orgID + "");
            }
        }
        else
        {
            this.txt_PositionName.Text = "";
            this.txt_Remark.Text = "";
        }
    }

    protected void btn_Save_Click(object sender, ImageClickEventArgs e)
    {
        SYS_PositionEntity Entity = new SYS_PositionEntity();
        if (Request.QueryString["PositonID"] != null)
        {
            Entity = position.GetModel(Request.QueryString["PositonID"].ToString());
        }
        Entity.PositionName = this.txt_PositionName.Text;
        Entity.Remark = this.txt_Remark.Text;
        Entity.IsForbid = "0";

        if (Request.QueryString["PositonID"] != null)//修改保存
        {
            DataSet pDs = position.GetPositionList(" PositionName='" + CommonMethod.RepChar(Entity.PositionName) + "' and PositionCode<>'" + Request.QueryString["PositonID"] .ToString()+ "'");
            if (pDs.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(this.upDepartAdd, this, "您输入的职位名称已经存在!");
                return;
            }
            if (position.Update(Entity) == 1)
            {
                #region 数据同步
                if (ConfigurationManager.AppSettings["IsSync"] == "1")
                {
                    try
                    {
                        //添加成功，数据同步到各个磅房
                        IndustryPlatform.DBUtility.MsmqManage msm =   MsmqManage.GetMsmq();
                        string strSQL = "update Sys_Position set " +
                                      "[PositionCode] = '" + Entity.PositionCode + "'," +
                                      "[PositionName] = '" + CommonMethod.RepChar(Entity.PositionName) + "'," +
                                      "[Remark] = '" + CommonMethod.RepChar(Entity.Remark) + "'," +
                                      "[IsForbid] = '" + Entity.IsForbid + "' where [PositionCode]='" + Entity.PositionCode + "'";

                        strSQL = msm.AllStation + msm.Prefix + "Sys_Position" + msm.Prefix + msm.EditFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                        msm.AddMsmq(strSQL);
                    }
                    catch
                    { }
                }
                #endregion

                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('修改成功！'); top.currForm.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('修改失败！');", true);
            }
        }
        else//新增保存
        {
            DataSet pDs = position.GetPositionList(" PositionName='" + CommonMethod.RepChar(Entity.PositionName) + "'");
            if (pDs.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(this.upDepartAdd, this, "您输入的职位名称已经存在!");
                return;
            }
            lock (this)
            {
                Entity.PositionCode = DbHelperSQL.GetBaseMaxID("PositionCode", "SYS_Position", " PositionCode<>'0'");
                Entity.IsForbid = "0";
                if (position.Add(Entity) == 1)
                {
                    #region 数据同步
                    if (ConfigurationManager.AppSettings["IsSync"] == "1")
                    {
                        try
                        {
                            //添加成功，数据同步到各个磅房
                            IndustryPlatform.DBUtility.MsmqManage msm =  MsmqManage.GetMsmq();
                            string strSQL = "INSERT INTO Sys_Position ( " +
                                          "[PositionCode] ," +
                                          "[PositionName] ," +
                                          "[Remark] ," +
                                          "[IsForbid] ) VALUES ('" + Entity.PositionCode + "','" + CommonMethod.RepChar(Entity.PositionName) + "','" + CommonMethod.RepChar(Entity.Remark) + "','" + Entity.IsForbid + "')";
                            strSQL = msm.AllStation + msm.Prefix + "Sys_Position" + msm.Prefix + msm.AddFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                            msm.AddMsmq(strSQL);
                        }
                        catch
                        { }
                    }
                    #endregion

                    SetText();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('添加成功！');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('添加失败！');", true);
                }
            }
        }
    }


    protected void btn_chongzhi_Click(object sender, ImageClickEventArgs e)
    {
        SetText();
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager.RegisterStartupScript(this,Page.GetType(), "", "this.top.currForm.close();", true);
    }
}
