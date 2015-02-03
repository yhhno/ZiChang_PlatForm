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
using System.Drawing;
using IndustryPlatform.DBUtility;
public partial class Log_LogList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            new IndustryPlatform.BLL.SYS_Dictionary().LogTypeBind(this.ddlLOGTYPE);
            DBind();
        }
    }

    /// <summary>
    /// 加载数据列表
    /// </summary>
    public void DBind()
    {
        ControlBindHelper.GridViewPagerBindByRowNum(this.anp_OperateLog, "VSYS_OperateLog", getWhere(), " operatedate desc ", this.gdv_OperateLog);
    }

    #region 查询条件
    protected string getWhere()
    {
        string strwhere = " 1=1";
        if (this.ddlLOGTYPE.SelectedValue != "0")
            strwhere += " and LOGTYPE like '%" + ddlLOGTYPE.SelectedValue + "%'";
        if (this.txtOperatMan.Text.Trim() != "")
            strwhere += " and username like '%" + this.txtOperatMan.Text.Trim().Replace("'", "''") + "%'";
        if(txtBeginDate.Text !="")
            strwhere += " and operatedate >='" + txtBeginDate.Text + "'";
        if (txtEndDate.Text != "")
            strwhere += " and operatedate <='" + txtEndDate.Text + " 23:59:59'";
        return strwhere;
    }
    #endregion

    #region 分页
    protected void anp_OperateLog_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.anp_OperateLog.CurrentPageIndex = e.NewPageIndex;
        DBind();
    }
    #endregion

    #region 查询
    protected void btn_Select_Click(object sender, ImageClickEventArgs e)
    {
        DBind();
    }
    #endregion

}
