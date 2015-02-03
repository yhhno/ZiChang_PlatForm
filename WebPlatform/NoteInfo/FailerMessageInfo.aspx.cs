using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using IndustryPlatform.BLL;

public partial class NoteInfo_FailerMessageInfo : System.Web.UI.Page
{
    SYS_SucceedSendMessageBLL SSMB = new SYS_SucceedSendMessageBLL();
    SYS_FailerSendMessageBLL FSMB = new SYS_FailerSendMessageBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1000;
        if (!Page.IsPostBack)
        {
            InitPage();

            this.DBind();
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

        if (txtDateStart.Text.Trim() != "")
        {
            sbwhere.Append(" where FailerDate >='" + txtDateStart.Text.Trim() + " 00:00:00'");
            istartyear = int.Parse(txtDateStart.Text.Trim().Substring(0, 4));
        }
        else
        {
            sbwhere.Append(" where FailerDate >='" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00'");
            istartyear = DateTime.Now.Year;
        }

        if (txtDateEnd.Text.Trim() != "")
        {
            sbwhere.Append(" and FailerDate <='" + txtDateEnd.Text.Trim() + " 23:59:59'");
            iendyear = int.Parse(txtDateEnd.Text.Trim().Substring(0, 4));
        }
        else
        {
            sbwhere.Append(" and FailerDate <='" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59'");
            iendyear = DateTime.Now.Year;
        }

        FSMB.GridViewPagerBindbyRowNumber(anp_MessageInfo, sbwhere.ToString(), "FailerDate desc", gdv_MessageInfo, istartyear, iendyear);
    }
    #endregion



    #region 循环出选择上的数据
    public string GetSelect()
    {
        string strtext = "";
        foreach (GridViewRow grvRow in gdv_MessageInfo.Rows)
        {
            CheckBox chk_BoxSelect = (CheckBox)grvRow.Cells[0].FindControl("cbx");
            if (chk_BoxSelect.Checked == true)
            {
                strtext += "'" + gdv_MessageInfo.DataKeys[grvRow.DataItemIndex][0].ToString() + "',";
            }
        }

        if ("" != strtext.Trim())
        {
            return strtext.Substring(0, strtext.Length - 1);
        }
        else
        {
            return "";
        }
    }
    #endregion

    #region 对数据行绑定时激发
    protected void gdv_MessageInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "RowClick(this);");

            Label LabMContent = (Label)e.Row.Cells[1].FindControl("LabMContent");

            string strMContent = LabMContent.Text.Trim();

            LabMContent.Text = strMContent;
            LabMContent.ToolTip = strMContent;
        }
    }
    #endregion

    #region 分页
    protected void anp_MessageInfo_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        anp_MessageInfo.CurrentPageIndex = e.NewPageIndex;
        this.DBind();
    }
    #endregion

    #region 查询
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        anp_MessageInfo.CurrentPageIndex = 1;
        this.DBind();
    }
    #endregion

    #region 继续发送短信
    protected void lkView_Click(object sender, EventArgs e)
    {
        string strselect = GetSelect();
        int year = int.Parse(txtDateStart.Text.Trim().Substring(0, 4));

        if ("" != strselect)
        {
            int Irow = FSMB.InsertIntoReadySendMessage(strselect, year);

            if (Irow != 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('继续发送短信成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('继续发送短信失败！');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('请选择继续发送短信的数据！');", true);
        }
    }
    #endregion
}
