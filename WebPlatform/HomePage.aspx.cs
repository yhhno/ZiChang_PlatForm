using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using IndustryPlatform.DBUtility;

public partial class HomePage : System.Web.UI.Page
{
    string sysCode = string.Empty;          //系统编号由cookie中获取，如果为空，赋值为“S11”
    string positionCode = string.Empty;     //职位编号由cookie中获取
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Request.Cookies["sysCode"]==null)
            {
                sysCode = "S12";
            }
            else
            {
                sysCode = Request.Cookies["sysCode"].Value.ToString();
            }

            if (Request.Cookies["positionCode"] == null)
            {
                return;
            }
            else
            {
                positionCode = Request.Cookies["positionCode"].Value.ToString();
            }


            // <---------------
            BindFunctionGroup();
        }
    }

    protected void grvContainer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string funCode = grvContainer.DataKeys[e.Row.RowIndex]["FunCode"].ToString();
            DataList dtlContainer = (DataList)e.Row.FindControl("dtlContainer");
            // <-------------------------------------------------------------------
            dtlContainer.DataSource = GetFunctions(sysCode, positionCode, funCode);
            dtlContainer.DataBind();
        }
    }

    /// <summary>
    /// 由“系统编号”和“职位编号”获取功能组
    /// </summary>
    /// <param name="sysCode">系统编号</param>
    /// <param name="positionCode">职位编号</param>
    protected DataSet GetFunctionGroup(string sysCode, string positionCode)
    {
        StringBuilder queryStringBulider = new StringBuilder();
        queryStringBulider.Append("SELECT FunctionID,FunName,FunCode FROM V_PositionsOnFunctions WHERE ");
        queryStringBulider.AppendFormat("PositionCode = '{0}' AND ",positionCode);
        queryStringBulider.AppendFormat("SysCode = '{0}' AND ",sysCode);
        queryStringBulider.Append("FunType = '1'");

        return DbHelperSQL.DQuery(queryStringBulider.ToString());
    }

    /// <summary>
    /// 获取某个功能组下的所有权限
    /// </summary>
    /// <param name="sysCode">系统编号</param>
    /// <param name="positionCode">职位编号</param>
    /// <param name="funCode">功能组编号</param>
    protected DataSet GetFunctions(string sysCode, string positionCode, string funCode)
    {//PicturePath
        StringBuilder queryStringBulier = new StringBuilder();
        queryStringBulier.Append("SELECT FunName,FunFile,ModulePicture,(FunName+','+FunFile) as DataKey FROM V_PositionsOnFunctions WHERE ");
        queryStringBulier.AppendFormat("PositionCode = '{0}' AND ",positionCode);
        queryStringBulier.AppendFormat("SysCode = '{0}' AND ",sysCode);
        queryStringBulier.AppendFormat("ParentCode = '{0}' AND ",funCode);
        queryStringBulier.Append("FunType = '2'");

        return DbHelperSQL.DQuery(queryStringBulier.ToString());
    }

    protected void BindFunctionGroup()
   {
        // <------------------------------------------------------------
        DataSet dstFunctionGroup = GetFunctionGroup(sysCode,positionCode);

        if (dstFunctionGroup != null)
        {
            grvContainer.DataSource = dstFunctionGroup;
            grvContainer.DataBind();
        }
    }

    protected void dtlContainer_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataList dtlContianer = (DataList)e.Item.Parent.Parent.Parent.FindControl("dtlContainer");
            string[] dataKeys = dtlContianer.DataKeys[e.Item.ItemIndex].ToString().Split(',');
        }
    }
}
 