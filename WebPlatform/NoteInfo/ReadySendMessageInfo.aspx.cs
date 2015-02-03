using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using IndustryPlatform.BLL;

public partial class NoteInfo_ReadySendMessageInfo : System.Web.UI.Page
{
    SYS_ReadySendMessageBLL RSMB = new SYS_ReadySendMessageBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1000;

        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {
        DataTable dt = RSMB.GetReadySendMessageInfo();

        gdv_ReadySendMessage.DataSource = dt;
        gdv_ReadySendMessage.DataBind();
    }


}
