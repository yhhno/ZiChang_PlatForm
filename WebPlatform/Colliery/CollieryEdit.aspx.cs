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
using System.IO;
using System.Collections.Generic;
using System.ServiceModel;
using IndustryPlatform.DBUtility;



public partial class Colliery_CollieryEdit : System.Web.UI.Page
{
    IndustryPlatform.Model.Sys_Colliery model = new IndustryPlatform.Model.Sys_Colliery();
    IndustryPlatform.Model.Sys_FileSave file = new IndustryPlatform.Model.Sys_FileSave();
    IndustryPlatform.BLL.Sys_Colliery bll = new IndustryPlatform.BLL.Sys_Colliery();

    static string strCustomer = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strCustomer = ConfigurationSettings.AppSettings["ProName"];
            txtCollName.Focus();
            ShowInfo();
        }
    }


    private void bindCollProperty()
    {
        
    }

    private void ShowInfo()
    {
        //生成乡镇列表
        ControlBindHelper.DropDownListBind(this.ddlVillageCode, "Sys_Dictionary", "BusinName", "BusinID", "BusinTypeID='1002' and IsForbid='0'", "请选择所属乡镇", "");
        //生成组织部门列表
        ControlBindHelper.DropDownListBind(this.ddlOrgID, "Sys_Organization", "OrgName", "OrgCode", "OrgType='2' and IsForbid='0'", "请选所属煤管站", "-1");
        //bll.OrgDllBind(this.ddlOrgID);

        //生成煤矿状态
        ControlBindHelper.DropDownListBind(this.ddlCollState, "Sys_Dictionary", "BusinName", "BusinID", "BusinTypeID='1007' and IsForbid='0'", "请选择煤矿状态", "");
        if (strCustomer == "FuYuan")
        {
            this.trParcel.Visible = true;
            //片区
            ControlBindHelper.DropDownListBind(this.ddlParcel, "Sys_Dictionary", "BusinName", "BusinID", "BusinTypeID='1018' and IsForbid='0'", "请选择所属片区", "");
        }
        //生成煤矿属性  用于标识该煤矿为正常煤矿、洗煤厂
        ControlBindHelper.DropDownListBind(this.ddlCollProperty, "Sys_Dictionary", "BusinName", "BusinID", "BusinTypeID='1019' and IsForbid='0'", "请选择煤矿属性", "");
        if (Request.QueryString["CollID"] != null)
        {
            model = bll.GetModel(Request.QueryString["CollID"].ToString());

            //this.txtCollCode.Text = model.CollCode;
            this.txtCollName.Text = model.CollName;

            if (model.VillageCode != "")
            {
                this.ddlOrgID.SelectedValue = model.OrgCode.ToString();
            }
            else
            {
                this.ddlOrgID.SelectedIndex = 0;
            }

            if (model.VillageCode != "")
            {
                this.ddlVillageCode.SelectedValue = model.VillageCode;
            }
            else
            {
                this.ddlVillageCode.SelectedIndex = 0;
            }
            this.txtMineOwner.Text = model.MineOwner;
            this.txtMinePhone.Text = model.MinePhone;
            this.txtYearOutput.Text = model.YearOutput.ToString();
            if (model.CollProperty != "")
            {
                this.ddlCollProperty.SelectedValue = model.CollProperty;
            }
            else
            {
                this.ddlCollProperty.SelectedIndex = 0;
            }
            if (model.CollState != "")
            {
                this.ddlCollState.SelectedValue = model.CollState;
            }
            else
            {
                this.ddlCollState.SelectedIndex = 0;
            }

            if (model.ImageLicence != "" && model.ImageLicence != null)
            {
                imgImageLicence.Src = "show.aspx?ImageID=" + model.ImageLicence + "&d="+DateTime.Now.ToString("yyyyMMddhhmmss");
            }
            if (model.ImageRevenue != "" && model.ImageRevenue != null)
            {
                imgImageRevenue.Src = "show.aspx?ImageID=" + model.ImageRevenue + "&d=" + DateTime.Now.ToString("yyyyMMddhhmmss");
            }
            if (model.ImageCompetency != "" && model.ImageCompetency != null)
            {
                imgImageCompetency.Src = "show.aspx?ImageID=" + model.ImageCompetency + "&d=" + DateTime.Now.ToString("yyyyMMddhhmmss");
            }
            

            hidImageLicence.Value = model.ImageLicence;
           
            hidImageRevenue.Value = model.ImageRevenue;
          
            hidImageCompetency.Value = model.ImageCompetency;
           
            this.txtRemark.Text = model.Remark;
            this.ddlIsForbid.SelectedValue = model.IsForbid;
            if (strCustomer == "FuYuan")
                this.ddlParcel.SelectedValue = model.ParcelCode;

            //判断煤矿是否已经发过标示卡，如果发过，则不允许修改煤矿编号
            //if ("" != bll.Getresult("CollCode", "TT_MarkedCard", "CollCode ='" + Request.QueryString["CollID"].ToString() + "'"))
            //{
            //    this.ViewState["CollCode"] = txtCollCode.Text;
            //    txtCollCode.Enabled = false;
            //}
            hf_action.Value = "edit";

        }
        else
        {
           // this.txtCollCode.Text = "";
            this.txtCollName.Text = "";
            this.ddlOrgID.SelectedIndex = 0;
            this.ddlVillageCode.SelectedIndex = 0;
            this.txtMineOwner.Text = "";
            this.txtMinePhone.Text = "";
            this.txtYearOutput.Text = "0";
            this.ddlCollState.SelectedIndex=0;
            hidImageLicence.Value = "";
            hidImageRevenue.Value = "";
            hidImageCompetency.Value = "";
           
            this.imgImageLicence.Visible = false;
            this.imgImageRevenue.Visible = false;
            this.imgImageCompetency.Visible = false;
            this.txtRemark.Text = "";

            //this.ddlIsForbid.SelectedValue = "-1";
        }
        ScriptManager.RegisterStartupScript(this.upDepartAdd, this.GetType(), "", "initPic();", true);
    }

    protected void btn_Save_Click(object sender, ImageClickEventArgs e)
    {
        if (ddlCollState.SelectedIndex == 0)
        {
            MessageBox.Show(this.upDepartAdd, this, "请选择煤矿状态");
            return;
        }
        if (ddlCollProperty.SelectedIndex == 0)
        {
            MessageBox.Show(this.upDepartAdd,this,"请选择煤矿属性");
            return;
        }
        if (strCustomer == "FuYuan")
        {
            if (this.ddlParcel.SelectedIndex == 0)
            {
                MessageBox.Show(this.upDepartAdd, this, "请选择片区");
                return;
            }
        }
        //判断煤矿编号是否有重复
        if (Request.QueryString["CollID"] == null)
        {
            if (DbHelperSQL.Exists("Select Count(0) from Sys_Colliery where CollName='"+this.txtCollName.Text.Trim().Replace("'","''")+"'"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('煤矿名称已经存在，请重新输入！');", true);
                this.txtCollName.Focus();
                return;
            }
        }
        else
        {
            //判断标示卡中是否存在该煤矿
            //if (txtCollCode.Enabled != false)
            //{
                if ("0" != bll.Getresult("count(*)", "Sys_Colliery", "CollCode !='" + Request.QueryString["CollID"].ToString() + "' and CollName='" + this.txtCollName.Text + "'"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('煤矿名称已经存在，请重新输入！');", true);
                    return;
                }
            //}
        }

        #region   将煤矿信息存放到实体中
       string strExtent = ".gif.png.jpg.bmp.psd.pcx";
       // string CollCode = "";
        
        //if (txtCollCode.Enabled != false)
        //    CollCode = this.txtCollCode.Text;
        //else
        //    CollCode = ViewState["CollCode"].ToString();

        string CollName = this.txtCollName.Text;
        string OrgID = ddlOrgID.SelectedValue;
        string VillageCode = this.ddlVillageCode.SelectedValue;
        string MineOwner = this.txtMineOwner.Text;
        string MinePhone = this.txtMinePhone.Text;
        decimal YearOutput = decimal.Parse(this.txtYearOutput.Text);
        string CollState = this.ddlCollState.SelectedValue;
        string CollProperty = this.ddlCollProperty.SelectedValue;//煤矿属性

        //税务企业工商营业执照
        string ImageLicence = hidImageLicence.Value;
       // string LicenceImageType = this.txtLicenceImageType.Text;
        if (fupImageLicence.PostedFile.FileName != "")
        {
            string Licencepath = fupImageLicence.FileName;

            if (ImageLicence == "")
                ImageLicence = Guid.NewGuid().ToString().Replace("-", "");
           string  LicenceImageType = Licencepath.Substring(Licencepath.LastIndexOf(".") + 1);//后缀名
            if (!strExtent.Contains("." + LicenceImageType.ToLower()))
            {
                MessageBox.Show(this.upDepartAdd, this, "税务企业工商营业执照只能为图片,请重新选择");
                return;
            }
        }

        //税务登记证
        string ImageRevenue = hidImageRevenue.Value;
        //string RevenueImageType = this.txtRevenueImageType.Text;
        if (fupImageRevenue.PostedFile.FileName != "")
        {
            string Revenuepath = fupImageRevenue.FileName;

            if (ImageRevenue == "")
                ImageRevenue = Guid.NewGuid().ToString().Replace("-", "");
           string RevenueImageType = Revenuepath.Substring(Revenuepath.LastIndexOf(".") + 1);//后缀名
            if (!strExtent.Contains("." + RevenueImageType.ToLower()))
            {
                MessageBox.Show(this.upDepartAdd, this, "税务登记证只能为图片,请重新选择");
                return;
            }
        }


        //煤炭经营资格
        string ImageCompetency = hidImageCompetency.Value;
        //string CompetencyImageType = this.txtCompetencyImageType.Text;
        if (fupImageCompetency.PostedFile.FileName != "")
        {
            string Competencypath = fupImageCompetency.FileName;

            if (ImageCompetency == "")
                ImageCompetency = Guid.NewGuid().ToString().Replace("-", "");
           string  CompetencyImageType = Competencypath.Substring(Competencypath.LastIndexOf(".") + 1);//后缀名
            if (!strExtent.Contains("." + CompetencyImageType.ToLower()))
            {
                MessageBox.Show(this.upDepartAdd, this, "煤炭经营资格证只能为图片,请重新选择");
                return;
            }
        }

        string Remark = this.txtRemark.Text;
        string IsForbid = this.ddlIsForbid.SelectedValue;

        //model.CollCode = CollCode;
        model.CollName = CollName;
        model.OrgCode = OrgID;
        model.VillageCode = VillageCode;
        model.MineOwner = MineOwner;
        model.MinePhone = MinePhone;
        model.YearOutput = YearOutput;
        model.CollState = CollState;
        model.CollProperty = CollProperty;//煤矿属性CollProperty
        model.ImageLicence = ImageLicence;
        model.ImageRevenue = ImageRevenue;
        model.ImageCompetency = ImageCompetency;
        model.Remark = Remark;
        model.IsForbid = IsForbid;
        if (strCustomer == "FuYuan")
            model.ParcelCode = this.ddlParcel.SelectedValue;
        else
            model.ParcelCode = "";
        #endregion

        #region   将图片信息存放到实体中
        //存储图片
        List<IndustryPlatform.Model.Sys_FileSave> list = new List<IndustryPlatform.Model.Sys_FileSave>();
        //税务企业工商营业执照
        if (fupImageLicence.PostedFile.FileName != "")
        {
            file = new IndustryPlatform.Model.Sys_FileSave();
            file.FileCode = ImageLicence;
            file.FileName = fupImageLicence.FileName;
            file.FileType = "";
            file.FileContent = fupImageLicence.FileBytes;
            file.FilePath = "";
            file.FileSize = 0;
            list.Add(file);
        }


        //税务登记证
        if (fupImageRevenue.PostedFile.FileName != "")
        {
            file = new IndustryPlatform.Model.Sys_FileSave();
            file.FileCode = ImageRevenue;
            file.FileName = fupImageRevenue.FileName;
            file.FileType = "";
            file.FileContent = fupImageRevenue.FileBytes;
            file.FilePath = "";
            file.FileSize = 0;
            list.Add(file);
        }
        //煤炭经营资格
        if (fupImageCompetency.PostedFile.FileName != "")
        {
            file = new IndustryPlatform.Model.Sys_FileSave();
            file.FileCode = ImageCompetency;
            file.FileName = fupImageCompetency.FileName;
            file.FileType = "";
            file.FileContent = fupImageCompetency.FileBytes;
            file.FilePath = "";
            file.FileSize = 0;
            list.Add(file);
        }
        #endregion



        if (Request.QueryString["CollID"] == null)
        {
            lock(this)
            {
                model.IsForbid = "0";
                model.CollCode = DbHelperSQL.GetBaseMaxID("CollCode", "Sys_Colliery", "1=1");
                if (bll.Add(model, list) == true)
                {
                    #region 数据同步
                    try
                    {
                        //添加成功，数据同步到各个磅房
                        if (ConfigurationManager.AppSettings["IsSync"] == "1")
                        {
                            IndustryPlatform.DBUtility.MsmqManage msm = MsmqManage.GetMsmq();
                            string strSQL = "INSERT INTO Sys_Colliery ( " +
                                "[CollCode] , " +
                                "[CollName] , " +
                                "[OrgCode] , " +
                                "[VillageCode] , " +
                                "[MineOwner] , " +
                                "[MinePhone] , " +
                                "[YearOutput] , " +
                                "[CollState] , " +
                                "[ImageLicence] , " +
                                "[ImageRevenue] , " +
                                "[ImageCompetency] , " +
                                "[Remark] , " +
                                "[CollProperty] , " +
                                "[IsForbid],ParcelCode ) VALUES ('" + model.CollCode + "','" + IndustryPlatform.DBUtility.CommonMethod.RepChar(model.CollName) +
                                "','" + model.OrgCode + "','" + model.VillageCode +
                                "','" + model.MineOwner + "','" + model.MinePhone +
                                "'," + model.YearOutput + ",'" + model.CollState +
                                "','" + model.ImageLicence + "','" + model.ImageRevenue +
                                "','" + model.ImageCompetency +
                                "','" + IndustryPlatform.DBUtility.CommonMethod.RepChar(model.Remark) + "','" + model.CollProperty + "','" + model.IsForbid + "','" + model.ParcelCode + "') ";
                            strSQL += ";insert into TT_ColieryAccount(CollCode) values ('" + model.CollCode + "')";

                            strSQL = msm.AllStation + msm.Prefix + "Sys_Colliery" + msm.Prefix + msm.AddFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                            msm.AddMsmq(strSQL);
                        }
                        //图片信息不用下发
                        //foreach (IndustryPlatform.Model.Sys_FileSave fileSave in list)
                        //{
                        //    strSQL = "INSERT INTO Sys_FileSave ( " +
                        //            "[FileCode] , " +
                        //            "[FileName] , " +
                        //            "[FilePath] , " +
                        //            "[FileSize] , " +
                        //            "[FileType] , " +
                        //            "[FileContent] ) VALUES ('" + fileSave.FileCode + "','" + fileSave.FileName +
                        //            "','" + fileSave.FilePath + "'," + fileSave.FileSize +
                        //            ",'" + fileSave.FileType + "','" + fileSave.FileContent + "')";
                        //    strSQL = msm.AllStation + msm.Prefix + "Sys_FileSave" + msm.Prefix + msm.AddFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                        //    msm.AddMsmq(strSQL);
                        //}
                    }
                    catch
                    { }

                    #endregion

                    ShowInfo();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('添加成功！');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('添加失败！');", true);
                }
            }
        }
        else
        {
            model.CollCode =Request.QueryString["CollID"].ToString();
            if (bll.update(model, list) == true)
            {
                #region 数据同步
                try
                {
                    //添加成功，数据同步到各个磅房
                    if (ConfigurationManager.AppSettings["IsSync"] == "1")
                    {
                        IndustryPlatform.DBUtility.MsmqManage msm = IndustryPlatform.DBUtility.MsmqManage.GetMsmq();
                        string strSQL = "Delete From Sys_Colliery Where CollCode='" + model.CollCode + "';";
                        strSQL += "INSERT INTO Sys_Colliery ( " +
                            "[CollCode] , " +
                            "[CollName] , " +
                            "[OrgCode] , " +
                            "[VillageCode] , " +
                            "[MineOwner] , " +
                            "[MinePhone] , " +
                            "[YearOutput] , " +
                            "[CollState] , " +
                            "[ImageLicence] , " +
                            "[ImageRevenue] , " +
                            "[ImageCompetency] , " +
                            "[Remark] , " +
                            "[CollProperty] , " +
                            "[IsForbid],ParcelCode ) VALUES ('" + model.CollCode + "','" + IndustryPlatform.DBUtility.CommonMethod.RepChar(model.CollName) +
                            "','" + model.OrgCode + "','" + model.VillageCode +
                            "','" + model.MineOwner + "','" + model.MinePhone +
                            "'," + model.YearOutput + ",'" + model.CollState +
                            "','" + model.ImageLicence + "','" + model.ImageRevenue +
                            "','" + model.ImageCompetency +
                            "','" + IndustryPlatform.DBUtility.CommonMethod.RepChar(model.Remark) + "','" + model.CollProperty + "','" + model.IsForbid + "','" + model.ParcelCode + "') ";
                        strSQL = msm.AllStation + msm.Prefix + "Sys_Colliery" + msm.Prefix + msm.AddFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                        msm.AddMsmq(strSQL);
                    }
                    //图片信息不用下发
                    //foreach (IndustryPlatform.Model.Sys_FileSave fileSave in list)
                    //{
                    //    strSQL = "INSERT INTO Sys_FileSave ( " +
                    //            "[FileCode] , " +
                    //            "[FileName] , " +
                    //            "[FilePath] , " +
                    //            "[FileSize] , " +
                    //            "[FileType] , " +
                    //            "[FileContent] ) VALUES ('" + fileSave.FileCode + "','" + fileSave.FileName +
                    //            "','" + fileSave.FilePath + "'," + fileSave.FileSize +
                    //            ",'" + fileSave.FileType + "','" + fileSave.FileContent + "')";
                    //    strSQL = msm.AllStation + msm.Prefix + "Sys_FileSave" + msm.Prefix + msm.AddFlg + msm.Prefix + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + msm.Prefix + strSQL;
                    //    msm.AddMsmq(strSQL);
                    //}
                }
                catch
                { }
                #endregion

                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "top.currForm.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('修改失败！');", true);
            }
        }
    }

    protected void btn_chongzhi_Click(object sender, ImageClickEventArgs e)
    {
        ShowInfo();
    }
}
