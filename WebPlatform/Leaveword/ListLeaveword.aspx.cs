using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IndustryPlatform.DBUtility;
using IndustryPlatform.BLL;
public partial class Leaveword_ListLeaveword : System.Web.UI.Page
{
    SYS_OperatorBll operbll = new SYS_OperatorBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        hf_where.Value = " 1=1 ";
        if (!IsPostBack)
        {
            DBind();
        }
    }

    void DBind()
    {
        operbll.GridViewPagerBindbyRowNumber(this.anp_leavel, "SYS_LEAVEWORD", "leaveID", this.hf_where.Value.ToString(), "LEAVEdate desc", this.gv_leavel);
    }

    #region 查询
    protected void search_Click(object sender, ImageClickEventArgs e)
    {
        if (txt_title.Text != "")
            hf_where.Value += " and LEAVEtitle like '%" + txt_title.Text.Trim() + "%'";

        if (TbStarttime.Text == "")
        {
            hf_where.Value += " and LEAVEdate >='1900-01-01 00:00:00'";
        }
        else
        {
            hf_where.Value += " and LEAVEdate >='" + TbStarttime.Text.Trim() + " 00:00:00'";
        }

        if (TBendtime.Text == "")
        {
            hf_where.Value += " and LEAVEdate <='" + DateTime.Now.ToShortDateString() + " 23:59:59'";
        }
        else
        {
            hf_where.Value += " and LEAVEdate <='" + TBendtime.Text.Trim() + " 23:59:59'";
        }
        DBind();
    }
    #endregion
}
