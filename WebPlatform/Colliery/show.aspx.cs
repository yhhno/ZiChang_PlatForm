using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Colliery_show : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ImageID"] != null)
        {
            IndustryPlatform.BLL.Sys_Colliery bll = new IndustryPlatform.BLL.Sys_Colliery();
            DataRow myRow;
            byte[] myData = new byte[0];
            DataTable db = bll.GetList("Sys_FileSave", "   FileCode='" + Request.QueryString["ImageID"].ToString() + "'").Tables[0];
            if (db != null && db.Rows.Count != 0)
            {
                myRow = db.Rows[0];
                if (myRow["FileContent"].ToString() != "")
                    myData = (byte[])myRow["FileContent"];
                if (myRow["FileType"].ToString() != "")
                    Response.ContentType = myRow["FileType"].ToString();
                else
                    Response.ContentType = "jpg";
                Response.BinaryWrite(myData);
            }
        }

    }
}
