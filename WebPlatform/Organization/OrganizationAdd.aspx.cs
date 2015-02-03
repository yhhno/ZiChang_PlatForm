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
 
public partial class Organization_OrganizationAdd : System.Web.UI.Page
{
    IndustryPlatform.BLL.SYS_Organization bll = new IndustryPlatform.BLL.SYS_Organization();
    IndustryPlatform.Model.SYS_Organization model = new IndustryPlatform.Model.SYS_Organization();
    protected void Page_Load(object sender, EventArgs e) 
    {
        if (!IsPostBack)
        {
            this.txt_OrgName.Focus();
            if (CookieManager.GetCookieValue("uid").ToString() != "0")
            {
                IndustryPlatform.Model.SYS_Organization m = bll.GetModel(CookieManager.GetCookieValue("orgID"));
                ViewState["SEQ"] = m.OrgSeq;
                ViewState["pid"] = m.ParentOrgCode;
            }
            else
            {
                ViewState["SEQ"] = "";
                ViewState["pid"] = "0";
            }
            bll.OrgDllBind(this.ddl_parentOrgID, ViewState["SEQ"].ToString(), ViewState["pid"].ToString());
            ControlBindHelper.DropDownListBind(this.ddlOrgType, "Sys_Dictionary", "BusinName", "BusinID", "BusinTypeID='1014' and IsForbid='0'", "请选择部门类型", "");
            SetText();
        }
    }

    void SetText()
    {
        if (Request.QueryString["orgid"] != null)
        {
            model = bll.GetModel(Request.QueryString["orgid"]);
            if (model != null)
            {
                this.txt_Email.Text = model.Email.Trim();
                this.txt_LinkMan.Text = model.LinkMan.Trim();
                this.txt_LinkManTel.Text = model.LinkManTel.Trim();
                this.txt_memo.Text = model.Remark.Trim();
                //this.txt_OrgIP.Text = model.OrgIP.Trim();
                this.txt_OrgName.Text = model.OrgName.Trim();
                //this.txt_zipCode.Text = model.zipCode.Trim();
                this.ddl_parentOrgID.SelectedValue = model.ParentOrgCode.ToString();
                this.ddlOrgType.SelectedValue = model.OrgType;
            }
        }
        else
        {
            this.txt_Email.Text = "";
            this.txt_LinkMan.Text = "";
            this.txt_LinkManTel.Text = "";
            this.txt_memo.Text ="";
            this.ddlOrgType.SelectedIndex = 0;
            this.txt_OrgName.Text = "";
            if (Request.QueryString["pid"].ToString() == "0")
                this.ddl_parentOrgID.SelectedIndex = 0;
            else
                this.ddl_parentOrgID.SelectedValue = Request.QueryString["pid"].ToString();
        }
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        decimal orgID=0;
        if (Request.QueryString["orgid"] != null)
        {
            orgID = Convert.ToDecimal(Request.QueryString["orgid"]);
            model = bll.GetModel(orgID.ToString());
            if (this.ddl_parentOrgID.SelectedIndex != 0)
            {
                DataTable dt = bll.GetList(" OrgSEQ like '" + model.OrgSeq + "%'").Tables[0];
                DataRow[] drs = dt.Select("OrgCode=" + this.ddl_parentOrgID.SelectedValue);
                if (drs.Length > 0)
                {
                    MessageBox.Show(this, "不能选择自己和自己下级作为父节点，请重新选择!");
                    return;
                }
            }
            string strparentOrgID = "0";
            IndustryPlatform.Model.SYS_Organization m = new IndustryPlatform.Model.SYS_Organization();
            if (this.ddl_parentOrgID.SelectedIndex != 0)
                strparentOrgID = this.ddl_parentOrgID.SelectedValue;

            DataTable dtExistName = bll.GetList(" ParentOrgCode ='" + strparentOrgID + "' and orgName='" + this.txt_OrgName.Text.Trim().Replace("'", "''") + "' and OrgCode<>" + Request.QueryString["orgid"].ToString()).Tables[0];
            if (dtExistName.Rows.Count > 0)
            {
                MessageBox.Show(this, "同父级别下的部门名称不能重复，请重新输入!");
                return;
            }
        }
        else
        {
            model.IsForbid = "0";
            string strparentOrgID = "0";
            IndustryPlatform.Model.SYS_Organization m = new IndustryPlatform.Model.SYS_Organization();
            if (this.ddl_parentOrgID.SelectedIndex != 0)
                strparentOrgID = this.ddl_parentOrgID.SelectedValue;

            DataTable dtExistName = bll.GetList(" ParentOrgCode='" + strparentOrgID + "' and orgName='" + this.txt_OrgName.Text.Trim().Replace("'", "''") + "'").Tables[0];
            if (dtExistName.Rows.Count > 0)
            {
                MessageBox.Show(this, "同父级别下的部门名称不能重复，请重新输入!");
                return;
            }
        }
       
        model.Email=this.txt_Email.Text.Trim();
        model.LinkMan = this.txt_LinkMan.Text.Trim();
        model.LinkManTel = this.txt_LinkManTel.Text.Trim();
        model.Remark = this.txt_memo.Text.Trim();
       
        model.OrgName = this.txt_OrgName.Text.Trim();
        model.OrgType = this.ddlOrgType.SelectedValue;
        
        if (this.ddl_parentOrgID.SelectedValue != "")
            model.ParentOrgCode = this.ddl_parentOrgID.SelectedValue;
        else
            model.ParentOrgCode = bll.GetModel(CookieManager.GetCookieValue("orgID").ToString()).ParentOrgCode;

        model.OrgLevel = "1";
        if (this.ddl_parentOrgID.SelectedValue != "0" && this.ddl_parentOrgID.SelectedValue != "")
        {
            model.OrgLevel = Convert.ToString(Convert.ToInt32(bll.GetModel(model.ParentOrgCode).OrgLevel) + 1);
        }
        else if (this.ddl_parentOrgID.SelectedValue == "")
        {
            if (model.ParentOrgCode == "0")
                model.OrgLevel = "1";
        }
        
        if (Request.QueryString["orgid"] == null)
        {
            model.OrgCode = DbHelperSQL.GetBaseMaxID("OrgCode", "Sys_Organization", "OrgCode<>'0'");
            if (bll.Add(model) > 0)
            {
                #region 数据同步
                if (ConfigurationManager.AppSettings["IsSync"] == "1")
                {
                    try
                    {
                        //添加成功，数据同步到各个磅房
                        IndustryPlatform.DBUtility.MsmqManage msm = MsmqManage.GetMsmq(); 
                        string strSQL = "INSERT INTO Sys_Organization ( "+
                                        "[OrgCode] ,"+
                                        "[OrgName] ,"+
                                        "[OrgLevel] ,"+
                                        "[ParentOrgCode] ,"+
                                        "[OrgSeq] ,"+
                                        "[OrgType] ,"+
                                        "[LinkMan] ,"+
                                        "[LinkManTel] ,"+
                                        "[Email] ,"+
                                        "[IsForbid] ,"+
                                        "[Remark] ," +
                                        "[SysCode] ) VALUES ('" + model.OrgCode + "','" + CommonMethod.RepChar(model.OrgName) +
                                        "','" + model.OrgLevel + "','" + model.ParentOrgCode +
                                        "','" + model.OrgSeq + "','" + model.OrgType + "','" + CommonMethod.RepChar(model.LinkMan) +
                                        "','" + model.LinkManTel + "','" + model.Email + "','" + model.IsForbid +
                                        "','" + CommonMethod.RepChar(model.Remark) + "','" + model.SysCode + "')";
                        strSQL = msm.AllStation + msm.Prefix + "Sys_Organization" + msm.Prefix + msm.AddFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                        msm.AddMsmq(strSQL);

                        //添加考勤信息
                        if (System.Configuration.ConfigurationManager.AppSettings["ConnKQIP"].ToString() != "")
                        {
                            string strKQSQL = "INSERT INTO [HMKQ].[dbo].[t_UNIT]" +
                                           "([unitCode]" +
                                           ",[unitName]" +
                                           ",[upUnitCode]" +
                                //",[unitEnv]"+
                                           ",[unitLev])" +
                                            "VALUES" +
                                           "('" + model.OrgCode + "'" +
                                           ",'" + model.OrgName + "'" +
                                           ",'" + model.ParentOrgCode + "'" +
                                           ",'" + model.OrgLevel + "')";
                            msm.AddMsmq(strKQSQL, System.Configuration.ConfigurationManager.AppSettings["ConnKQIP"].ToString());
                        }
                    }
                    catch
                    { }
                }
                #endregion

                bll.OrgDllBind(this.ddl_parentOrgID, ViewState["SEQ"].ToString(), ViewState["pid"].ToString());
                MessageBox.Show(this, "添加成功!");
                SetText();
            }
            else
                MessageBox.Show(this, "添加失败!");
        }
        else
        {
            if (bll.Update(model) > 0)
            {
                #region 数据同步
                if (ConfigurationManager.AppSettings["IsSync"] == "1")
                {
                    try
                    {
                        //更新成功，数据同步到各个磅房
                        IndustryPlatform.DBUtility.MsmqManage msm =  MsmqManage.GetMsmq();
                        string strSQL="update Sys_Organization set "+
                                "[OrgCode] = '" + model.OrgCode + "'," +
                                "[OrgName] =  '" + CommonMethod.RepChar(model.OrgName) + "'," +
                                "[OrgLevel] =  '" + model.OrgLevel + "'," +
                                "[ParentOrgCode] =  '" + model.ParentOrgCode + "'," +
                                "[OrgSeq] =  '" + model.OrgSeq + "'," +
                                "[OrgType] =  '" + model.OrgType + "'," +
                                "[LinkMan] =  '" + CommonMethod.RepChar(model.LinkMan) + "'," +
                                "[LinkManTel] =  '" + model.LinkManTel + "'," +
                                "[Email] =  '" + model.Email + "'," +
                                "[IsForbid] = '" + model.IsForbid + "'," +
                                "[Remark] =  '" + CommonMethod.RepChar(model.Remark) + "'," +
                                "[SysCode] = '" + model.SysCode + "' where [OrgCode]='" + model.OrgCode + "'";
                        strSQL = msm.AllStation + msm.Prefix + "Sys_Organization" + msm.Prefix + msm.EditFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                        msm.AddMsmq(strSQL);

                        //更新考勤信息
                        if (System.Configuration.ConfigurationManager.AppSettings["ConnKQIP"].ToString() != "")
                        {
                            string strKQSQL = "UPDATE [HMKQ].[dbo].[t_UNIT]" +
                               "SET " +
                                  "[unitName] = '" + model.OrgName + "'" +
                                  ",[upUnitCode] = " + model.ParentOrgCode + "" +
                                                        //" ,[unitEnv] = "++""+
                                  ",[unitLev] = " + model.OrgLevel + "" +
                             " WHERE [unitCode] = '" + model.OrgCode + "'";
                            msm.AddMsmq(strKQSQL, System.Configuration.ConfigurationManager.AppSettings["ConnKQIP"].ToString());
                        }
                    }
                    catch
                    { }
                }
                #endregion

                bll.OrgDllBind(this.ddl_parentOrgID, ViewState["SEQ"].ToString(), ViewState["pid"].ToString());
                ClientScript.RegisterStartupScript(Page.GetType(), "", "this.top.currForm.close();", true);
            }
            else
                MessageBox.Show(this, "修改失败!");
        }
    }

    protected void btnReset_Click(object sender, ImageClickEventArgs e)
    {
        SetText();
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "", "this.top.currForm.close();//this.top.currForm.returnvalue='aa';", true);
    }
   
}
