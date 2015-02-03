using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

/// <summary>
///AutoComplete 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
[System.Web.Script.Services.ScriptService]
public class AutoComplete : System.Web.Services.WebService
{

    public AutoComplete()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }


    [WebMethod]
    public string[] GetUser(string prefixText, int count)
    {
        string strSQL = "Select Top "+count+" UserName From Sys_Operator Where UserName Like '%" + prefixText + "%'";
        System.Data.DataTable dtPerson =  IndustryPlatform.DBUtility.DbHelperSQL.TQuery(strSQL);

        string[] strArray = new string[dtPerson.Rows.Count];

        for (int i = 0; i < dtPerson.Rows.Count; i++)
        {
            strArray[i] = dtPerson.Rows[i]["UserName"].ToString();
        }

        return strArray;
    }


}

