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
using IndustryPlatform.DBUtility;
using System.ServiceModel;
using STOCMessageService;
using System.Collections.Generic;

public partial class Operator_AddOperator : System.Web.UI.Page
{
    SYS_OperatorBll operbll = new SYS_OperatorBll();
    IndustryPlatform.BLL.SYS_Organization bll = new IndustryPlatform.BLL.SYS_Organization();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txt_username.Focus();
            string strSeq = "";
            string pid = "0";
            this.ddl_TypeCode.Visible = false;
            
            //if (CookieManager.GetCookieValue("uid").ToString() != "0")
            //{
            //    IndustryPlatform.Model.SYS_Organization m = bll.GetModel(CookieManager.GetCookieValue("orgID"));
            //    if (m != null)
            //    {
            //        strSeq = m.OrgSeq;
            //        pid = m.ParentOrgCode.ToString();
            //        string strOrgType = m.OrgType;
                    
            //    }
            //}
            bll.OrgDllBind(this.ddl_parentOrgID, strSeq, pid);
        }
    }


    protected void ib_save_Click(object sender, ImageClickEventArgs e)
    {
        lock (this)
        {
            if (CookieManager.GetCookieValue("uid").ToString() == "0" && this.ddl_parentOrgID.SelectedIndex == 0)
            {
               // MessageBox.Show(this, "请选择部门");
                MessageBox.Show(this.UpdatePanel1, this, "请选择部门");
                return;
            }
            if (this.ddl_TypeCode.Visible == true && this.ddl_TypeCode.Items[0].Text == "请选择磅房")
            {
                if (this.ddl_TypeCode.SelectedValue == "")
                {
                    //MessageBox.Show(this, ddl_TypeCode.Items[0].Text);
                    MessageBox.Show(this.UpdatePanel1, this, ddl_TypeCode.Items[0].Text);
                    return;
                }
            }
            int checkid = operbll.Ch(this.txt_username.Text.ToString());

            if (checkid == 1)
            {
                //MessageBox.Show(this, "您输入的用户姓名已经存在，请重新输入!");
                MessageBox.Show(this.UpdatePanel1, this, "您输入的用户姓名已经存在，请重新输入!");
                return;
            }
            SYS_OperatorEntity operEntity = new SYS_OperatorEntity();
            operEntity.Gender = this.rblist_sex.SelectedValue.ToString();
            operEntity.Address = this.txt_address.Text.ToString();
            operEntity.IsForbid = "0";
            operEntity.MobileNo = this.txt_mobile.Text.ToString();
            operEntity.Email = this.txt_email.Text.ToString();
            operEntity.UserCode = DbHelperSQL.GetBaseMaxID("UserCode", "Sys_Operator", "UserCode<>'0'").ToString();
            operEntity.OrgCode = this.ddl_parentOrgID.SelectedValue;
            //operEntity.TypeCode = this.ddl_TypeCode.SelectedValue;
            operEntity.Password = CommonMethod.MD5Crypt("12345");
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
            int isign = operbll.AddOperator(operEntity);
            if (isign == 1)
            {
                #region 数据同步

                if (ConfigurationManager.AppSettings["IsSync"] == "1")
                {
                    try
                    {
                        IndustryPlatform.DBUtility.MsmqManage msm =  MsmqManage.GetMsmq();
                        string strSQL = "INSERT INTO Sys_Operator ( " +
                            "[UserCode] ," +
                            "[UserName] ," +
                            "[Password] ," +
                            "[IsForbid] ," +
                            "[OrgCode] ," +
                            "[Tel] ," +
                            "[Email] ," +
                            "[Address] ," +
                            "[ZipCode] ," +
                            "[PID] ," +
                            "[Gender] ," +
                            "[RegDate] ," +
                            "[MobileNo] ," +
                            "[TypeCode] ) VALUES ('" + operEntity.UserCode + "','" + CommonMethod.RepChar(operEntity.UserName) +
                             "','" + CommonMethod.RepChar(operEntity.Password) + "','" + operEntity.IsForbid +
                             "','" + operEntity.OrgCode + "','" + operEntity.Tel + "','" + operEntity.Email +
                             "','" + CommonMethod.RepChar(operEntity.Address) + "','" + operEntity.ZipCode + "','" + operEntity.PID +
                             "','" + operEntity.Gender + "','" + operEntity.RegDate +
                             "','" + operEntity.MobileNo + "','" + operEntity.TypeCode + "')";
                        strSQL = msm.AllStation + msm.Prefix + "Sys_Operator" + msm.Prefix + msm.AddFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                        msm.AddMsmq(strSQL);

                        //向考勤机发送同步数据
                        if (System.Configuration.ConfigurationManager.AppSettings["ConnKQIP"].ToString() != "")
                        {
                            string kqSql = "INSERT INTO [HMKQ].[dbo].[员工]" +
                                   "([员工编号]" +
                                   ",[姓名]" +
                                //",[虹膜代码]"+
                                //",[虹膜代码2]"+
                                //",[虹膜代码3]"+
                                   ",[密码]" +
                                   ",[部门]" +
                                //",[组别]"+
                                //",[自定义编号]"+
                                   ",[管理权]" +
                                   ",[黑名单])" +
                                //",[照片])"+
                                   " VALUES" +
                                   "('" + operEntity.UserCode + "','" + operEntity.UserName + "','" + CommonMethod.RepChar(operEntity.Password) + "','" + operEntity.OrgCode + "',0,0)";
                            msm.AddMsmq(kqSql, System.Configuration.ConfigurationManager.AppSettings["ConnKQIP"].ToString());//语句，IP
                        }
                    }
                    catch
                    { }
                }
                #endregion

                setnull();
                //MessageBox.Show(this, "添加成功!");
                MessageBox.Show(this.UpdatePanel1, this, "添加成功!");
            }
            else
            {
                 //MessageBox.Show(this, "添加失败!");
               MessageBox.Show(this.UpdatePanel1, this, "添加失败!");
            }
        }
    }

    protected void ib_cav_Click(object sender, ImageClickEventArgs e)
    {
        setnull();
    }

    public void setnull()
    {
        this.txt_address.Text = "";
        this.txt_mobile.Text = "";
        this.txt_email.Text = "";
        this.txt_tel.Text = "";
        this.txt_pid.Text = "";
        this.txt_username.Text = "";
        this.zipcode.Text = "";
        this.ddl_parentOrgID.SelectedIndex = 0;
        this.ddl_TypeCode.Visible = false;
        tdTypeCode.Visible = false;
        this.lblStar.Visible = false;
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        //ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "top.currForm.close();", true);
        ScriptManager.RegisterStartupScript(this.UpdatePanel1,Page.GetType(), "", "top.currForm.close();", true);
    }
    
    protected void ddl_parentOrgID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddl_parentOrgID.SelectedIndex==0)
        {
            this.ddl_TypeCode.Visible = false;
            tdTypeCode.Visible = false;
            this.lblStar.Visible = false;
        }
        else
        {
            string strOrgType = new IndustryPlatform.BLL.SYS_Organization().GetModel(this.ddl_parentOrgID.SelectedValue).OrgType;
            if (strOrgType == "1" || strOrgType == "2")
            {
                this.ddl_TypeCode.Visible = true;
                tdTypeCode.Visible = true;
                this.lblStar.Visible = true;
                this.lblTypeCode.Visible = true;
            }
            else
            {
                this.ddl_TypeCode.Visible = false;
                this.ddl_TypeCode.Visible = false;
                tdTypeCode.Visible = false;
                this.lblStar.Visible = false;
            }
            if (strOrgType == "1")
            {
                ControlBindHelper.DropDownListBind(this.ddl_TypeCode, "TT_Room", "RoomName", "RoomCode", "IsForbid='0'", "请选择磅房", "");
                lblTypeCode.Text = "选择磅房：";
            }
            if (strOrgType == "2")
            {
                ControlBindHelper.DropDownListBind(this.ddl_TypeCode, "Sys_Colliery", "CollName", "CollCode", "IsForbid='0'", "请选择煤矿", "");
                lblTypeCode.Text = "选择煤矿：";
            }
        }
    }
}
