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

public partial class Colliery_image : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["imgPath"] != null)
        {
            System.IO.FileStream fileStream = new FileStream(Request.QueryString["imgPath"].ToString(), FileMode.Open);
            byte[] myData = new byte[fileStream.Length];
            fileStream.Read(myData, 0, System.Convert.ToInt32(fileStream.Length));//从流中读取字节块，并将数据写入到该缓冲区
            fileStream.Close();
            Response.ContentType = "jpg";
            Response.BinaryWrite(myData);
        }

    }
   
}
