using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using IndustryPlatform.BLL;
using IndustryPlatform.Common;

public partial class NoteInfo_SucceedSendMessageInfo : System.Web.UI.Page
{
    SYS_SucceedSendMessageBLL SSMB = new SYS_SucceedSendMessageBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1000;
        if (!Page.IsPostBack)
        {
            InitPage();
        }
    }

    #region 初始化页面
    protected void InitPage()
    {
        this.DBind();
    }
    #endregion

    #region  获取查询结果
    protected void DBind()
    {
        StringBuilder sbwhere = new StringBuilder();

        int istartyear = 0;
        int iendyear = 0;

        if (txtPhoneNumber.Text.Trim() != "")
        {
            if (PageValidate.IsNumber(txtPhoneNumber.Text.Trim()))
            {
                sbwhere.Append("where PhoneNuber like '%" + txtPhoneNumber.Text.Trim() + "%'");
            }
            else
            {
                txtPhoneNumber.Text = "";
                sbwhere.Append("where PhoneNuber like '%%'");
            }
        }
        if (txtDateStart.Text.Trim() != "")
        {
            sbwhere.Append(" and SucceedDate >='" + txtDateStart.Text.Trim() + " 00:00:00'");
            istartyear = int.Parse(txtDateStart.Text.Trim().Substring(0, 4));
        }
        else
        {
            sbwhere.Append(" where SucceedDate >='" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00'");
            istartyear = DateTime.Now.Year;
        }

        if (txtDateEnd.Text.Trim() != "")
        {
            sbwhere.Append(" and SucceedDate <='" + txtDateEnd.Text.Trim() + " 23:59:59'");
            iendyear = int.Parse(txtDateEnd.Text.Trim().Substring(0, 4));
        }
        else
        {
            sbwhere.Append(" and SucceedDate <='" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59'");
            iendyear = DateTime.Now.Year;
        }


        SSMB.GridViewPagerBindbyRowNumber(anp_LoadWeight, sbwhere.ToString(), "SucceedDate desc", gdv_LoadWeight, istartyear, iendyear);
    }
    #endregion

    #region 查询
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        anp_LoadWeight.CurrentPageIndex = 1;
        DBind();
    }
    #endregion

    #region 分页
    protected void anp_LoadWeight_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        anp_LoadWeight.CurrentPageIndex = e.NewPageIndex;
        this.DBind();
    }
    #endregion

    #region 当生成数据行是绑定
    protected void gdv_LoadWeight_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label LabMContent = (Label)e.Row.Cells[1].FindControl("LabMContent");

            string strMContent = LabMContent.Text.Trim();

            LabMContent.Text = strMContent;
            LabMContent.ToolTip = strMContent;
        }
    }
    #endregion
}
