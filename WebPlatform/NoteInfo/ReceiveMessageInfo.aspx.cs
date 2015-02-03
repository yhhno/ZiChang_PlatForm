using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using IndustryPlatform.BLL;
using IndustryPlatform.Common;

public partial class NoteInfo_ReceiveMessageInfo : System.Web.UI.Page
{
    SYS_ReceiveMessageBLL RMB = new SYS_ReceiveMessageBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1000;
        if (!Page.IsPostBack)
        {
            this.Bind();
        }
    }

    #region 绑定页面
    protected void Bind()
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
            sbwhere.Append(" where ReceiveDate >='" + txtDateStart.Text.Trim() + " 00:00:00'");
            istartyear = int.Parse(txtDateStart.Text.Trim().Substring(0, 4));
        }
        else
        {
            sbwhere.Append(" where ReceiveDate >='" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00'");
            istartyear = DateTime.Now.Year;
        }

        if (txtDateEnd.Text.Trim() != "")
        {
            sbwhere.Append(" and ReceiveDate <='" + txtDateEnd.Text.Trim() + " 23:59:59'");
            iendyear = int.Parse(txtDateEnd.Text.Trim().Substring(0, 4));
        }
        else
        {
            sbwhere.Append(" and ReceiveDate <='" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59'");
            iendyear = DateTime.Now.Year;
        }

        if (txtPhoneNumber.Text.Trim() != "")
        {
            if (!PageValidate.IsNumber(txtPhoneNumber.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('手机号码应该为数字！');", true);
                return;
            }
            else
            {
                sbwhere.Append(" and PhoneNumber like '%" + txtPhoneNumber.Text.Trim() + "%'");
            }
        }

        RMB.GridViewPagerBindbyRowNumber(anp_ReceiveMessage, sbwhere.ToString(), "ReceiveDate desc", gdv_ReadySendMessage, istartyear, iendyear);

    }
    #endregion

    #region 查询
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        anp_ReceiveMessage.CurrentPageIndex = 1;
        this.Bind();
    }
    #endregion

    #region 分页
    protected void anp_ReceiveMessage_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        anp_ReceiveMessage.CurrentPageIndex = e.NewPageIndex;
        this.Bind();
    }
    #endregion

    #region 当生成数据行是绑定
    protected void gdv_ReadySendMessage_RowDataBound(object sender, GridViewRowEventArgs e)
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
