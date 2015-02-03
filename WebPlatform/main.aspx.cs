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

using IndustryPlatform.DBUtility;
using IndustryPlatform.BLL;
using System.Text;


public partial class main : System.Web.UI.Page
{
    SYS_OperatorBll operbll = new SYS_OperatorBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
        DBind();
        }
    }

    public void DBind()
    {
        //ControlBindHelper.GridViewPagerBind(this.anp_oper, "SYS_Operator", "operatorID", "", "operatorID", this.gv_oper);
        operbll.GridViewPagerBindbyRowNumber(this.AspNetPager1, "SYS_Operator", "operatorID", "1=1", "operatorID desc", this.GridView1);
    }
}
