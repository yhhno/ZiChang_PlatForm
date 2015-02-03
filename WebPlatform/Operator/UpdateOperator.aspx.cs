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
using System.Collections.Generic;
using System.ServiceModel;

using IndustryPlatform.DBUtility;
 
public partial class Operator_UpdateOperator : System.Web.UI.Page
{
    SYS_OperatorBll operbll = new SYS_OperatorBll();
    IndustryPlatform.BLL.SYS_Organization bll = new IndustryPlatform.BLL.SYS_Organization();
    static decimal operid = 0;
    string strSeq = "";
    string pid = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (decimal.TryParse(Request.QueryString["operid"], out operid))
        {}
        if (!Page.IsPostBack)
        {
            // Response.Write(Request.QueryString["operid"].ToString());
            //bll.OrgDllBind(this.ddl_parentOrgID);
            txt_username.Focus();
            OperInfoBind(operid.ToString());
        }
    }

    public void OperInfoBind(string strid)
    {
        if (CookieManager.GetCookieValue("uid").ToString() != "0")
        {
            IndustryPlatform.Model.SYS_Organization m = bll.GetModel(CookieManager.GetCookieValue("orgID"));
            strSeq = m.OrgSeq;
            pid = m.ParentOrgCode.ToString();
            string strOrgType = m.OrgType;
            if(strOrgType=="1")
            {
                lblTypeCode.Text = "选择磅房：";
                ControlBindHelper.DropDownListBind(this.ddl_TypeCode, "TT_Room", "RoomName", "RoomCode", "IsForbid='0'", "请选择磅房", "");
            }
            else if (strOrgType == "2")
            {
                lblTypeCode.Text = "选择煤矿：";
                ControlBindHelper.DropDownListBind(this.ddl_TypeCode, "Sys_Colliery", "CollName", "CollCode", "IsForbid='0'", "请选择煤矿", "");
            }
            if (strOrgType == "1" || strOrgType=="2")
            {
                this.ddl_TypeCode.Visible = true;
                tdTypeCode.Visible = true;
            }
            else
            {
                this.ddl_TypeCode.Visible = false;
                this.ddl_TypeCode.Items.Clear();
                this.ddl_TypeCode.Items.Add(new ListItem("1", ""));
            }
        }
        bll.OrgDllBind(this.ddl_parentOrgID, strSeq, pid);
        DataSet ds = new DataSet();
        ds = operbll.GetOperatorInfo(strid);

        this.rblist_sex.Items.FindByValue(ds.Tables[0].Rows[0]["Gender"].ToString()).Selected = true;
        this.txt_address.Text = ds.Tables[0].Rows[0]["Address"].ToString();
 
        //this.rblist_local.Items.FindByValue(ds.Tables[0].Rows[0]["isLocal"].ToString()).Selected = true;

        this.txt_mobile.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
        this.txt_email.Text = ds.Tables[0].Rows[0]["Email"].ToString();
        this.ddl_parentOrgID.SelectedValue = ds.Tables[0].Rows[0]["OrgCode"].ToString();
        ddl_parentOrgID_SelectedIndexChanged(null, null);
        if (ddl_TypeCode.Visible)
        {
            ddl_TypeCode.SelectedValue = ds.Tables[0].Rows[0]["TypeCode"].ToString();
        }
        
        this.txt_tel.Text = ds.Tables[0].Rows[0]["Tel"].ToString();

        this.txt_pid.Text = ds.Tables[0].Rows[0]["PID"].ToString();
        this.txt_username.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
        this.zipcode.Text = ds.Tables[0].Rows[0]["ZipCode"].ToString();

    }
    
    protected void ib_cav_Click(object sender, ImageClickEventArgs e)
    {
        OperInfoBind(Request.QueryString["operid"].ToString());
    }
    protected void ib_save_Click(object sender, ImageClickEventArgs e)
    {
        if (CookieManager.GetCookieValue("uid").ToString()=="0" && this.ddl_parentOrgID.SelectedIndex == 0)
        {
            MessageBox.Show(this.UpdatePanel1,this, "请选择部门");
            return;
        }
        if (this.ddl_TypeCode.Visible == true)
        {
            if (this.ddl_TypeCode.SelectedValue == "")
            {
                MessageBox.Show(this.UpdatePanel1, this, this.ddl_TypeCode.Items[0].Text);
                return;
            }
        }


        if (DbHelperSQL.Exists("Select Count(0) from Sys_Operator where UserName='" + this.txt_username.Text.Trim().Replace("'", "''") + "' and UserCode<>'" + Request.QueryString["operid"].ToString() + "'"))
        {
            MessageBox.Show(this.UpdatePanel1, this, "您输入的用户名已经存在!");
            return;
        }
        SYS_OperatorEntity operEntity = new SYS_OperatorEntity();
        operEntity = operbll.GetModel(Request.QueryString["operid"].ToString());

        operEntity.Gender = this.rblist_sex.SelectedValue.ToString();
        operEntity.Address = this.txt_address.Text.ToString();
        operEntity.MobileNo = this.txt_mobile.Text.ToString();
        operEntity.Email = this.txt_email.Text.ToString();
        //operEntity. = Convert.ToDecimal(operbll.GetMaxID("operatorID", "SYS_Operator"));
        operEntity.OrgCode = this.ddl_parentOrgID.SelectedValue;
        operEntity.TypeCode = this.ddl_TypeCode.SelectedValue;
        operEntity.PID = this.txt_pid.Text.ToString();
        operEntity.RegDate = Convert.ToDateTime(System.DateTime.Now);
        operEntity.UserName = this.txt_username.Text.ToString();
        operEntity.Tel = this.txt_tel.Text;

        if (ddl_TypeCode.Visible)
        {
            operEntity.TypeCode = this.ddl_TypeCode.SelectedValue;
        }
        else
        {
            operEntity.TypeCode = "0";
        }
        operEntity.ZipCode = this.zipcode.Text.ToString();
        int isign = operbll.UpdateOperator(operEntity);
        if (isign == 1)
        {
            //MessageBox.Show(this, "修改成功!");
            #region 数据同步

            if (ConfigurationManager.AppSettings["IsSync"] == "1")
            {
                try
                {
                    IndustryPlatform.DBUtility.MsmqManage msm =  MsmqManage.GetMsmq();
                    string strSQL = "Update Sys_Operator set "+
                        "[UserCode] = '" + operEntity.UserCode + "', " +
                        "[UserName] =  '" + CommonMethod.RepChar(operEntity.UserName) + "', " +
                        "[Password] = '" + CommonMethod.RepChar(operEntity.Password) + "', " +
                        "[IsForbid] = '" + operEntity.IsForbid + "', " +
                        "[OrgCode] = '" + operEntity.OrgCode + "', " +
                        "[Tel] = '" + operEntity.Tel + "', " +
                        "[Email] = '" + operEntity.Email + "' ," +
                        "[Address] = '" + CommonMethod.RepChar(operEntity.Address) + "', " +
                        "[ZipCode] = '" + operEntity.ZipCode + "', " +
                        "[PID] = '" + operEntity.PID + "', " +
                        "[Gender] = '" + operEntity.Gender + "', " +
                        "[RegDate] = '" + operEntity.RegDate + "', " +
                        "[MobileNo] = '" + operEntity.MobileNo + "', " +
                        "[TypeCode] = '" + operEntity.TypeCode +"' "+
                        " where [UserCode]='" + CommonMethod.RepChar(operEntity.UserCode) + "'";
                    strSQL = msm.AllStation + msm.Prefix + "Sys_Operator" + msm.Prefix + msm.EditFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                    msm.AddMsmq(strSQL);

                    //向考勤机发送更新语句
                    if (System.Configuration.ConfigurationManager.AppSettings["ConnKQIP"].ToString() != null)
                    {
                        string strKQSQL = "UPDATE [HMKQ].[dbo].[员工]" +
                        "SET [姓名] = '" + operEntity.UserName + "'" +
                           " ,[密码] = '" + CommonMethod.RepChar(operEntity.Password) + "'" +
                            ",[部门] = '" + operEntity.OrgCode + "'" +
                       "WHERE [员工编号]='" + operEntity.UserCode + "'";
                        msm.AddMsmq(strKQSQL, System.Configuration.ConfigurationManager.AppSettings["ConnKQIP"].ToString());
                    }
                }
                catch
                { }
            }
            #endregion

            ScriptManager.RegisterStartupScript(this.UpdatePanel1,Page.GetType(), "", "top.currForm.close();", true);
        }
        else
        {
            MessageBox.Show(this.UpdatePanel1, this, "修改失败!");
        }
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, Page.GetType(), "", "top.currForm.close();", true);
    }
   
    protected void ddl_parentOrgID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddl_parentOrgID.SelectedValue == "")
        {
            this.ddl_TypeCode.Visible = false;
            tdTypeCode.Visible = false;
            spanStar.Visible = false;
        }
        else
        {
            string strOrgType = new IndustryPlatform.BLL.SYS_Organization().GetModel(this.ddl_parentOrgID.SelectedValue).OrgType;
            if (strOrgType == "1")
            {
                lblTypeCode.Text = "选择磅房：";
                ControlBindHelper.DropDownListBind(this.ddl_TypeCode, "TT_Room", "RoomName", "RoomCode", "IsForbid='0'", "请选择磅房", "");
            }
            else if (strOrgType == "2")
            {
                lblTypeCode.Text = "选择煤矿：";
                ControlBindHelper.DropDownListBind(this.ddl_TypeCode, "Sys_Colliery", "CollName", "CollCode", "IsForbid='0'", "请选择煤矿", "");
            }
            if (strOrgType == "1" || strOrgType == "2")
            {
                this.ddl_TypeCode.Visible = true;
                tdTypeCode.Visible = true;
                spanStar.Visible = true;
            }
            else
            {
                this.tdTypeCode.Visible = false;
                this.ddl_TypeCode.Visible = false;
                spanStar.Visible = false;
                this.ddl_TypeCode.Items.Clear();
                this.ddl_TypeCode.Items.Add(new ListItem("1", ""));
            }
        }
    }
}
