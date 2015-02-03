using System;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Collections;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace IndustryPlatform.DBUtility
{
    /// <summary>
    /// 控件帮定抽象基础类
    /// </summary>
    public abstract class ControlBindHelper
    {
        public ControlBindHelper()
        {
        }


        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        public static void GridViewPagerBindByRowNum(Wuqi.Webdiyer.AspNetPager anpager, string strTableName, string strWhere, string strOrder, System.Web.UI.WebControls.GridView grvControl)
        {
            int iCount = Convert.ToInt32(DbHelperSQL.GetSingle("select count(0) from " + strTableName + " where " + strWhere));
            anpager.RecordCount = iCount;
            int iRow1 = (anpager.CurrentPageIndex - 1) * anpager.PageSize + 1;
            int iRow2 = anpager.CurrentPageIndex * anpager.PageSize;
            string strSql = "select * from "
                                     + "(select row_number() over(order by " + strOrder + ") RowNo,* from " + strTableName
                                     + " where " + strWhere + ") as result where RowNo>=" + iRow1 + " and RowNo <=" + iRow2;
            DataSet ds = DbHelperSQL.Query(strSql);
            grvControl.DataSource = ds;
            grvControl.DataBind();
            //动态设置用户自定义文本内容
            anpager.CustomInfoHTML = "共有<font color=\"blue\"><b>" + anpager.RecordCount.ToString() + "</b></font>条记录";
            anpager.CustomInfoHTML += " 总页数：<font color=\"blue\"><b>" + anpager.PageCount.ToString() + "</b></font>页";
            anpager.CustomInfoHTML += " 当前页：第<font color=\"red\"><b>" + anpager.CurrentPageIndex.ToString() + "</b></font>页";
        }

        #region DropDownList帮定
        /// <summary>
        /// 帮定DropDownList
        /// </summary>
        /// <param name="ddlControl">DropDownList控件ID</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strText">显示的文本字段</param>
        /// <param name="strValue">值字段</param>
        /// <param name="strInitializeText">初始化文本</param>
        /// <param name="strInitializeValue">初始化值</param>
        public static void DropDownListBind(System.Web.UI.WebControls.DropDownList ddlControl, string strTableName, string strText, string strValue, string strInitializeText,string strInitializeValue)
        {
            string strSql = "SELECT " + strText + "," + strValue + " FROM " + strTableName + "";
            DataSet dstTemp = new DataSet();

            dstTemp = DbHelperSQL.Query(strSql);

            ddlControl.DataSource = dstTemp.Tables[0];
            ddlControl.DataTextField = strText;
            ddlControl.DataValueField = strValue;
            ddlControl.DataBind();

            ddlControl.Items.Insert(0, "" + strInitializeText + "");
            ddlControl.Items[0].Value = strInitializeValue;
        }
        /// <summary>
        /// 帮定DropDownList
        /// </summary>
        /// <param name="ddlControl">DropDownList控件ID</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strText">显示的文本字段</param>
        /// <param name="strValue">值字段</param>
        /// <param name="strWhere">查询条件，不包含Where</param>
        public static void DropDownListBind(System.Web.UI.WebControls.DropDownList ddlControl,string strTableName, string strText, string strValue, string strWhere)
        {

            string strSql = "SELECT " + strText + "," + strValue + " FROM " + strTableName + " Where " + strWhere;
            DataSet dstTemp = new DataSet();

            dstTemp = DbHelperSQL.Query(strSql);
            ddlControl.DataSource = dstTemp.Tables[0];
            ddlControl.DataTextField = strText;
            ddlControl.DataValueField = strValue;
            ddlControl.DataBind();
        }
        /// <summary>
        /// 帮定DropDownList
        /// </summary>
        /// <param name="ddlControl">DropDownList控件ID</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strText">显示的文本字段</param>
        /// <param name="strValue">值字段</param>
        /// <param name="strWhere">查询条件，不包含Where</param>
        /// <param name="strInitializeText">初始化文本</param>
        /// <param name="strInitializeValue">初始化值</param>
        public static void DropDownListBind(System.Web.UI.WebControls.DropDownList ddlControl, string strTableName, string strText, string strValue, string strWhere, string strInitializeText, string strInitializeValue)
        {
            string strSql = "SELECT " + strText + "," + strValue + " FROM " + strTableName + " Where " + strWhere;
            DataSet dstTemp = new DataSet();

            dstTemp = DbHelperSQL.Query(strSql);
            ddlControl.DataSource = dstTemp.Tables[0];
            ddlControl.DataTextField = strText;
            ddlControl.DataValueField = strValue;
            ddlControl.DataBind();
            ddlControl.Items.Insert(0, "" + strInitializeText + "");
            ddlControl.Items[0].Value = strInitializeValue;
        }
        /// <summary>
        /// 帮定DropDownList
        /// </summary>
        /// <param name="ddlControl">DropDownList控件ID</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strText">显示的文本字段</param>
        /// <param name="strValue">值字段</param>
        /// <param name="strWhere">查询条件，不包含Where</param>
        /// <param name="strOrder">排序字段</param>
        /// <param name="strInitializeText">初始化文本</param>
        /// <param name="strInitializeValue">初始化值</param>
        public static void DropDownListBind(System.Web.UI.WebControls.DropDownList ddlControl, string strTableName, string strText, string strValue, string strWhere, string strOrder, string strInitializeText, string strInitializeValue)
        {

            string strSql = "SELECT " + strText + "," + strValue + " FROM " + strTableName + " Where " + strWhere + " Order By " + strOrder;
            DataSet dstTemp = new DataSet();

            dstTemp = DbHelperSQL.Query(strSql);
            ddlControl.DataSource = dstTemp.Tables[0];
            ddlControl.DataTextField = strText;
            ddlControl.DataValueField = strValue;
            ddlControl.DataBind();
            ddlControl.Items.Insert(0, "" + strInitializeText + "");
            ddlControl.Items[0].Value = strInitializeValue;
        }
        #endregion

        //#region Repeater控件分页帮定
        ///// <summary #region GridView控件分页帮定
        /// <summary>
        /// GridView控件分页帮定
        /// </summary>
        /// <param name="anpager">AspNetPager分页控件</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strPrimaryKey">表的唯一主建名</param>
        /// <param name="strQuaryCondition">查询Where条件，不含Where</param>
        /// <param name="strOrderCondition">需要排序的字段名</param>
        /// <param name="rptControl">GridView控件</param>
        public static void GridViewPagerBind(Wuqi.Webdiyer.AspNetPager anpager, string strTableName, string strPrimaryKey, string strQuaryCondition, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl)
        {
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@pageindex",SqlDbType.Int),
                    new SqlParameter("@pagesize",SqlDbType.Int),
                    new SqlParameter("@docount",SqlDbType.Bit),
                    new SqlParameter("@strwhere",SqlDbType.NVarChar,1000),
                    new SqlParameter("@tablenm",SqlDbType.NVarChar,100),
                    new SqlParameter("@tbmainid",SqlDbType.NVarChar,100),
                    new SqlParameter("@strorder",SqlDbType.NVarChar,100),
                };

            parameters[0].Value = anpager.CurrentPageIndex;
            parameters[1].Value = anpager.PageSize;
            parameters[2].Value = false;
            parameters[3].Value = strQuaryCondition;
            parameters[4].Value = strTableName;
            parameters[5].Value = strPrimaryKey;
            parameters[6].Value = strOrderCondition;

            if (strQuaryCondition == "")
            {
                anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(*) From " + strTableName));
            }
            else
            {
                anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(*) From " + strTableName + " Where " + strQuaryCondition));
            }
            DataSet dstTemp = DbHelperSQL.DRunProcedure("P_ControlPager", parameters, "NewTableName");

            if (dstTemp.Tables[0].Rows.Count == 0)
            {
                //DataRow dr = dstTemp.Tables[0].NewRow();
                //dstTemp.Tables[0].Rows.Add(dr);
                grvControl.DataSource = null;
                grvControl.DataBind();
            }
            else
            {
                grvControl.DataSource = dstTemp.Tables["NewTableName"];
                grvControl.DataBind();
            }


            //动态设置用户自定义文本内容
            anpager.CustomInfoHTML = "共有<font color=\"blue\"><b>" + anpager.RecordCount.ToString() + "</b></font>条记录";
            anpager.CustomInfoHTML += " 总页数：<font color=\"blue\"><b>" + anpager.PageCount.ToString() + "</b></font>页";
            anpager.CustomInfoHTML += " 当前页：第<font color=\"red\"><b>" + anpager.CurrentPageIndex.ToString() + "</b></font>页";

        }

        ///// Repeater控件分页帮定
        ///// </summary>
        ///// <param name="anpager">AspNetPager分页控件</param>
        ///// <param name="strTableName">表名</param>
        ///// <param name="strPrimaryKey">表的唯一主建名</param>
        ///// <param name="strQuaryCondition">查询Where条件，不含Where</param>
        ///// <param name="strOrderCondition">需要排序的字段名</param>
        ///// <param name="rptControl">Repeater控件</param>
        //public static void RepeaterPagerBind(Wuqi.Webdiyer.AspNetPager anpager, string strTableName,string strPrimaryKey,string strQuaryCondition,string strOrderCondition, System.Web.UI.WebControls.Repeater rptControl)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //        {
        //            new SqlParameter("@pageindex",SqlDbType.Int),
        //            new SqlParameter("@pagesize",SqlDbType.Int),
        //            new SqlParameter("@docount",SqlDbType.Bit),
        //            new SqlParameter("@strwhere",SqlDbType.NVarChar,1000),
        //            new SqlParameter("@tablenm",SqlDbType.NVarChar,100),
        //            new SqlParameter("@tbmainid",SqlDbType.NVarChar,100),
        //            new SqlParameter("@strorder",SqlDbType.NVarChar,100),
        //        };

        //    parameters[0].Value = anpager.CurrentPageIndex;
        //    parameters[1].Value = anpager.PageSize;
        //    parameters[2].Value = false;
        //    parameters[3].Value = strQuaryCondition;
        //    parameters[4].Value = strTableName;
        //    parameters[5].Value = strPrimaryKey;
        //    parameters[6].Value = strOrderCondition;

        //    if (strQuaryCondition == "")
        //    {
        //        anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(*) From " + strTableName));
        //    }
        //    else
        //    {
        //        anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(*) From " + strTableName + " Where " + strQuaryCondition));
        //    }

        //    DataSet dstTemp = DbHelperSQL.DRunProcedure("P_ControlPager", parameters, "NewTableName");

        //    rptControl.DataSource = dstTemp.Tables["NewTableName"];
        //    rptControl.DataBind();

        //    //动态设置用户自定义文本内容
        //    anpager.CustomInfoHTML = "共有<font color=\"blue\"><b>" + anpager.RecordCount.ToString() + "</b></font>条记录";
        //    anpager.CustomInfoHTML += " 总页数：<font color=\"blue\"><b>" + anpager.PageCount.ToString() + "</b></font>页";
        //    anpager.CustomInfoHTML += " 当前页：第<font color=\"red\"><b>" + anpager.CurrentPageIndex.ToString() + "</b></font>页";
        //}
        //#endregion

        //#region GridView控件分页帮定
        ///// <summary>
        ///// GridView控件分页帮定
        ///// </summary>
        ///// <param name="anpager">AspNetPager分页控件</param>
        ///// <param name="strTableName">表名</param>
        ///// <param name="strPrimaryKey">表的唯一主建名</param>
        ///// <param name="strQuaryCondition">查询Where条件，不含Where</param>
        ///// <param name="strOrderCondition">需要排序的字段名</param>
        ///// <param name="rptControl">GridView控件</param>
        //public static void GridViewPagerBind(Wuqi.Webdiyer.AspNetPager anpager, string strTableName, string strPrimaryKey, string strQuaryCondition, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //        {
        //            new SqlParameter("@pageindex",SqlDbType.Int),
        //            new SqlParameter("@pagesize",SqlDbType.Int),
        //            new SqlParameter("@docount",SqlDbType.Bit),
        //            new SqlParameter("@strwhere",SqlDbType.NVarChar,1000),
        //            new SqlParameter("@tablenm",SqlDbType.NVarChar,100),
        //            new SqlParameter("@tbmainid",SqlDbType.NVarChar,100),
        //            new SqlParameter("@strorder",SqlDbType.NVarChar,100),
        //        };

        //    parameters[0].Value = anpager.CurrentPageIndex;
        //    parameters[1].Value = anpager.PageSize;
        //    parameters[2].Value = false;
        //    parameters[3].Value = strQuaryCondition;
        //    parameters[4].Value = strTableName;
        //    parameters[5].Value = strPrimaryKey;
        //    parameters[6].Value = strOrderCondition;

        //    if (strQuaryCondition == "")
        //    {
        //        anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(*) From " + strTableName));
        //    }
        //    else
        //    {
        //        anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(*) From " + strTableName + " Where " + strQuaryCondition));
        //    }
        //    DataSet dstTemp = DbHelperSQL.DRunProcedure("P_ControlPager", parameters,"NewTableName");

        //    if (dstTemp.Tables[0].Rows.Count == 0)
        //    {
        //        //DataRow dr = dstTemp.Tables[0].NewRow();
        //        //dstTemp.Tables[0].Rows.Add(dr);
        //        grvControl.DataSource = null;
        //        grvControl.DataBind();
        //    }
        //    else
        //    {
        //        grvControl.DataSource = dstTemp.Tables["NewTableName"];
        //        grvControl.DataBind();
        //    }
            

        //    //动态设置用户自定义文本内容
        //    anpager.CustomInfoHTML = "共有<font color=\"blue\"><b>" + anpager.RecordCount.ToString() + "</b></font>条记录";
        //    anpager.CustomInfoHTML += " 总页数：<font color=\"blue\"><b>" + anpager.PageCount.ToString() + "</b></font>页";
        //    anpager.CustomInfoHTML += " 当前页：第<font color=\"red\"><b>" + anpager.CurrentPageIndex.ToString() + "</b></font>页";

        //}

        //#endregion

        //#region GridView控件分页帮定
        ///// <summary>
        ///// GridView控件分页帮定
        ///// </summary>
        ///// <param name="anpager">AspNetPager分页控件</param>
        ///// <param name="strTableName">表名</param>
        ///// <param name="strPrimaryKey">表的唯一主建名</param>
        ///// <param name="strQuaryCondition">查询Where条件，不含Where</param>
        ///// <param name="strOrderCondition">需要排序的字段名</param>
        ///// <param name="rptControl">GridView控件</param>
        //public static void GridViewPagerBind(Wuqi.Webdiyer.AspNetPager anpager, string strTableName, string strPrimaryKey, string strQuaryCondition, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl,string produceName)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //        {
        //            new SqlParameter("@pageindex",SqlDbType.Int),
        //            new SqlParameter("@pagesize",SqlDbType.Int),
        //            new SqlParameter("@docount",SqlDbType.Bit),
        //            new SqlParameter("@strwhere",SqlDbType.NVarChar,1000),
        //            new SqlParameter("@tablenm",SqlDbType.NVarChar,100),
        //            new SqlParameter("@tbmainid",SqlDbType.NVarChar,100),
        //            new SqlParameter("@strorder",SqlDbType.NVarChar,100),
        //        };

        //    parameters[0].Value = anpager.CurrentPageIndex;
        //    parameters[1].Value = anpager.PageSize;
        //    parameters[2].Value = false;
        //    parameters[3].Value = strQuaryCondition;
        //    parameters[4].Value = strTableName;
        //    parameters[5].Value = strPrimaryKey;
        //    parameters[6].Value = strOrderCondition;

        //    if (strQuaryCondition == "")
        //    {
        //        anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(*) From " + strTableName));
        //    }
        //    else
        //    {
        //        anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(*) From " + strTableName + " Where " + strQuaryCondition));
        //    }

        //    DataSet dstTemp = DbHelperSQL.DRunProcedure(produceName, parameters, "NewTableName");

        //    grvControl.DataSource = dstTemp.Tables["NewTableName"];
        //    grvControl.DataBind();

        //    //动态设置用户自定义文本内容
        //    anpager.CustomInfoHTML = "共有<font color=\"blue\"><b>" + anpager.RecordCount.ToString() + "</b></font>条记录";
        //    anpager.CustomInfoHTML += " 总页数：<font color=\"blue\"><b>" + anpager.PageCount.ToString() + "</b></font>页";
        //    anpager.CustomInfoHTML += " 当前页：第<font color=\"red\"><b>" + anpager.CurrentPageIndex.ToString() + "</b></font>页";
        //}

        //#endregion

        //#region DataList控件分页帮定
        ///// <summary>
        ///// DataList控件分页帮定
        ///// </summary>
        ///// <param name="anpager">AspNetPager分页控件</param>
        ///// <param name="strTableName">表名</param>
        ///// <param name="strPrimaryKey">表的唯一主建名</param>
        ///// <param name="strQuaryCondition">查询Where条件，不含Where</param>
        ///// <param name="strOrderCondition">需要排序的字段名</param>
        ///// <param name="rptControl">DataList控件</param>
        //public static void DataListPagerBind(Wuqi.Webdiyer.AspNetPager anpager, string strTableName, string strPrimaryKey, string strQuaryCondition, string strOrderCondition, System.Web.UI.WebControls.DataList dlstControl)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //        {
        //            new SqlParameter("@pageindex",SqlDbType.Int),
        //            new SqlParameter("@pagesize",SqlDbType.Int),
        //            new SqlParameter("@docount",SqlDbType.Bit),
        //            new SqlParameter("@strwhere",SqlDbType.NVarChar,1000),
        //            new SqlParameter("@tablenm",SqlDbType.NVarChar,100),
        //            new SqlParameter("@tbmainid",SqlDbType.NVarChar,100),
        //            new SqlParameter("@strorder",SqlDbType.NVarChar,100),
        //        };

        //    parameters[0].Value = anpager.CurrentPageIndex;
        //    parameters[1].Value = anpager.PageSize;
        //    parameters[2].Value = false;
        //    parameters[3].Value = strQuaryCondition;
        //    parameters[4].Value = strTableName;
        //    parameters[5].Value = strPrimaryKey;
        //    parameters[6].Value = strOrderCondition;

        //    if (strQuaryCondition == "")
        //    {
        //        anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(*) From " + strTableName));
        //    }
        //    else
        //    {
        //        anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(*) From " + strTableName + " Where " + strQuaryCondition));
        //    }

        //    DataSet dstTemp = DbHelperSQL.DRunProcedure("P_ControlPager", parameters, "NewTableName");

        //    dlstControl.DataSource = dstTemp.Tables["NewTableName"];
        //    dlstControl.DataBind();

        //    //动态设置用户自定义文本内容
        //    anpager.CustomInfoHTML = "共有<font color=\"blue\"><b>" + anpager.RecordCount.ToString() + "</b></font>条记录";
        //    anpager.CustomInfoHTML += " 总页数：<font color=\"blue\"><b>" + anpager.PageCount.ToString() + "</b></font>页";
        //    anpager.CustomInfoHTML += " 当前页：第<font color=\"red\"><b>" + anpager.CurrentPageIndex.ToString() + "</b></font>页";

        //}
        //#endregion

        #region CheckBoxListBind邦定
        /// <summary>
        /// CheckBoxListBind邦定
        /// </summary>
        /// <param name="chklControl">CheckBoxList控件</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strText">显示的字段</param>
        /// <param name="strValue">值字段</param>
        public static void CheckBoxListBind(System.Web.UI.WebControls.CheckBoxList chklControl,string strTableName, string strText, string strValue)
        {
            string strSql = "SELECT * FROM " + strTableName + "";
            DataSet dstTemp = new DataSet();

            dstTemp = DbHelperSQL.Query(strSql);

            chklControl.DataSource = dstTemp.Tables[0];
            chklControl.DataTextField = strText;
            chklControl.DataValueField = strValue;
            chklControl.DataBind();
        }
        /// <summary>
        /// CheckBoxListBind邦定
        /// </summary>
        /// <param name="chklControl">CheckBoxList控件</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strText">显示的字段</param>
        /// <param name="strValue">值字段</param>
         /// <param name="strWhere">查询条件</param>
        public static void CheckBoxListBind(System.Web.UI.WebControls.CheckBoxList chklControl, string strTableName, string strText, string strValue, string strWhere)
        {
            string strSql = "SELECT * FROM " + strTableName + " Where " + strWhere;
            DataSet dstTemp = new DataSet();

            dstTemp = DbHelperSQL.Query(strSql);

            chklControl.DataSource = dstTemp.Tables[0];
            chklControl.DataTextField = strText;
            chklControl.DataValueField = strValue;
            chklControl.DataBind();
        }

        #endregion 

        #region 绑定TextBox当前最大主建ID+1
        /// <summary>
        /// 绑定TextBox当前最大主建ID+1
        /// </summary>
        /// <param name="txtControl">TextBox控件ID</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strPrimaryKeyName">主建</param>
        public static void TextBoxAutoIncreaseCodeBind(System.Web.UI.WebControls.TextBox txtControl,string strTableName,string strPrimaryKeyName)
        {
            string strMaxCode = string.Empty;

            try
            {
                string strSql = "Select EnumValue From dbo.T_EnumValue Where EnumValueName='" + strTableName + "'";
                string strDefaultValue = DbHelperSQL.GetSingle(strSql).ToString();

                strSql = "Select Top 1 " + strPrimaryKeyName + " From " + strTableName + " Order By " + strPrimaryKeyName + " desc";

                object objScalar = DbHelperSQL.GetSingle(strSql);

                if (objScalar != null && objScalar.ToString() != "")
                {
                    strMaxCode = objScalar.ToString();

                    if (strMaxCode.Length > 2)
                    {
                        string strMaxCodeBefore = strMaxCode.Substring(0, 1);
                        string strMaxCodeAfter = strMaxCode.Substring(1);
                        int iMaxCodeAfterLength = strMaxCodeAfter.Length;

                        strMaxCodeAfter = (Convert.ToInt32(strMaxCodeAfter) + 1).ToString();

                        if (strMaxCodeAfter.Length != iMaxCodeAfterLength)
                        {
                            strMaxCodeAfter = strMaxCodeAfter.PadLeft(iMaxCodeAfterLength, '0');
                        }

                        strMaxCode = strMaxCodeBefore + strMaxCodeAfter;
                    }
                }
                else
                {
                    strMaxCode = strDefaultValue;
                }
            }
            catch (Exception ex)
            {
                string strErrorMessage = ex.Message.ToString();
            }

            txtControl.Text = strMaxCode;
            txtControl.ReadOnly = true;
            txtControl.BorderColor = Color.DarkGray;
            txtControl.BorderStyle = BorderStyle.None;
        }

        public static void TextBoxAutoIncreaseCodeBindNumber(System.Web.UI.WebControls.TextBox txtControl, string strTableName, string strPrimaryKeyName)
        {
            string strMaxCode = string.Empty;

            try
            {
                string strSql = "Select EnumValue From dbo.T_EnumValue Where EnumValueName='" + strTableName + "'";
                string strDefaultValue = DbHelperSQL.GetSingle(strSql).ToString();

                strSql = "Select Max(Convert(int," + strPrimaryKeyName + ")) From " + strTableName;// +" Order By " + strPrimaryKeyName + " desc";

                object objScalar = DbHelperSQL.GetSingle(strSql);

                if (objScalar != null && objScalar.ToString() != "")
                {
                    strMaxCode = objScalar.ToString();

                    //if (strMaxCode.Length > 0)
                    //{
                        //string strMaxCodeBefore = strMaxCode.Substring(0, 1);
                        string strMaxCodeAfter = strMaxCode;//.Substring(1);
                        int iMaxCodeAfterLength = strMaxCodeAfter.Length;

                        strMaxCodeAfter = (Convert.ToInt32(strMaxCodeAfter) + 1).ToString();

                        //if (strMaxCodeAfter.Length != iMaxCodeAfterLength)
                        //{
                        //    strMaxCodeAfter = strMaxCodeAfter.PadLeft(iMaxCodeAfterLength, '0');
                        //}

                        strMaxCode = strMaxCodeAfter;   //   strMaxCodeBefore +
                    //}
                }
                else
                {
                    strMaxCode = strDefaultValue;
                }
            }
            catch (Exception ex)
            {
                string strErrorMessage = ex.Message.ToString();
            }

            txtControl.Text = strMaxCode;
            txtControl.ReadOnly = true;
            txtControl.BorderColor = Color.DarkGray;
            txtControl.BorderStyle = BorderStyle.None;
        }
        /// <summary>
        /// 绑定TextBox最大
        /// </summary>
        /// <param name="txtControl">TextBox控件ID</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strPrimaryKeyName">主建</param>
        /// <param name="strWhere">查询条件</param>
        public static void TextBoxAutoIncreaseCodeBind(System.Web.UI.WebControls.TextBox txtControl, string strTableName, string strPrimaryKeyName,string strWhere)
        {
            string strMaxCode = string.Empty;
            
            try
            {
                string strSql = "Select EnumValue From dbo.T_EnumValue Where EnumValueName='" + strTableName + "'";
                string strDefaultValue = DbHelperSQL.GetSingle(strSql).ToString();

                strSql = "Select Top 1 " + strPrimaryKeyName + " From " + strTableName + " Where " + strWhere + " Order By " + strPrimaryKeyName + " desc";

                object objScalar = DbHelperSQL.GetSingle(strSql);

                if (objScalar != null && objScalar.ToString() != "")
                {
                    strMaxCode = objScalar.ToString();

                    if (strMaxCode.Length > 2)
                    {
                        string strMaxCodeBefore = strMaxCode.Substring(0, 1);
                        string strMaxCodeAfter = strMaxCode.Substring(1);
                        int iMaxCodeAfterLength = strMaxCodeAfter.Length;

                        strMaxCodeAfter = (Convert.ToInt32(strMaxCodeAfter) + 1).ToString();

                        if (strMaxCodeAfter.Length != iMaxCodeAfterLength)
                        {
                            strMaxCodeAfter = strMaxCodeAfter.PadLeft(iMaxCodeAfterLength, '0');
                        }

                        strMaxCode = strMaxCodeBefore + strMaxCodeAfter;
                    }
                }
                else
                {
                    strMaxCode = strDefaultValue;
                }
            }
            catch (Exception ex)
            {
                string strErrorMessage = ex.Message.ToString();
            }

            txtControl.Text = strMaxCode;
            txtControl.ReadOnly = true;
            txtControl.BorderColor = Color.DarkGray;
            txtControl.BorderStyle = BorderStyle.None;
        }
        /// <summary>
        /// 绑定TextBox最大
        /// </summary>
        /// <param name="txtControl">TextBox控件ID</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strPrimaryKeyName">主建</param>
        /// <param name="strWhere">查询条件</param>
        public static void TextBoxAutoIncreaseCodeBindNumber(System.Web.UI.WebControls.TextBox txtControl, string strTableName, string strPrimaryKeyName, string strWhere)
        {
            string strMaxCode = string.Empty;

            try
            {
                string strSql = "Select EnumValue From dbo.T_EnumValue Where EnumValueName='" + strTableName + "'";
                string strDefaultValue = DbHelperSQL.GetSingle(strSql).ToString();

                strSql = "Select Max(Convert(int," + strPrimaryKeyName + ")) From " + strTableName + " Where " + strWhere;// +" Order By " + strPrimaryKeyName + " desc";

                object objScalar = DbHelperSQL.GetSingle(strSql);

                if (objScalar != null && objScalar.ToString() != "")
                {
                    strMaxCode = objScalar.ToString();

                    if (strMaxCode.Length > 0)
                    {
                        //string strMaxCodeBefore = strMaxCode.Substring(0, 1);
                        string strMaxCodeAfter = strMaxCode;//.Substring(1);
                        int iMaxCodeAfterLength = strMaxCodeAfter.Length;

                        strMaxCodeAfter = (Convert.ToInt32(strMaxCodeAfter) + 1).ToString();

                        if (strMaxCodeAfter.Length != iMaxCodeAfterLength)
                        {
                            strMaxCodeAfter = strMaxCodeAfter.PadLeft(iMaxCodeAfterLength, '0');
                        }

                        strMaxCode = strMaxCodeAfter;   //  strMaxCodeBefore + 
                    }
                }
                else
                {
                    strMaxCode = strDefaultValue;
                }
            }
            catch (Exception ex)
            {
                string strErrorMessage = ex.Message.ToString();
            }

            txtControl.Text = strMaxCode;
            txtControl.ReadOnly = true;
            txtControl.BorderColor = Color.DarkGray;
            txtControl.BorderStyle = BorderStyle.None;
        }
        #endregion

        #region 无控件绑定主键ID最大值
        /// <summary>
        /// 无控件绑定
        /// </summary>
        /// <param name="strTableName">表名</param>
        /// <param name="strPrimaryKeyName">主建</param>
        /// <returns>主键ID最大值</returns>
        public static string UnControlAutoIncreaseCode(string strTableName, string strPrimaryKeyName)
        {
            string strMaxCode = string.Empty;

            try
            {
                string strSql = "Select EnumValue From dbo.T_EnumValue Where EnumValueName='" + strTableName + "'";
                string strDefaultValue = DbHelperSQL.GetSingle(strSql).ToString();

                strSql = "Select Top 1 " + strPrimaryKeyName + " From " + strTableName + " Order By " + strPrimaryKeyName + " desc";

                object objScalar = DbHelperSQL.GetSingle(strSql);

                if (objScalar != null && objScalar.ToString() != "")
                {
                    strMaxCode = objScalar.ToString();

                    if (strMaxCode.Length > 2)
                    {
                        string strMaxCodeBefore = strMaxCode.Substring(0, 1);
                        string strMaxCodeAfter = strMaxCode.Substring(1);
                        int iMaxCodeAfterLength = strMaxCodeAfter.Length;

                        strMaxCodeAfter = (Convert.ToInt32(strMaxCodeAfter) + 1).ToString();

                        if (strMaxCodeAfter.Length != iMaxCodeAfterLength)
                        {
                            strMaxCodeAfter = strMaxCodeAfter.PadLeft(iMaxCodeAfterLength, '0');
                        }

                        strMaxCode = strMaxCodeBefore + strMaxCodeAfter;
                    }
                }
                else
                {
                    strMaxCode = strDefaultValue;
                }
            }
            catch (Exception ex)
            {
                string strErrorMessage = ex.Message.ToString();
            }

            return strMaxCode;
        }

        /// <summary>
        /// 无控件绑定
        /// </summary>
        /// <param name="strTableName">表名</param>
        /// <param name="strPrimaryKeyName">主建</param>
        /// <returns>主键ID最大值</returns>
        public static string UnControlAutoIncreaseCodeNumber(string strTableName, string strPrimaryKeyName)
        {
            string strMaxCode = string.Empty;

            try
            {
                string strSql = "Select EnumValue From dbo.T_EnumValue Where EnumValueName='" + strTableName + "'";
                string strDefaultValue = DbHelperSQL.GetSingle(strSql).ToString();

                strSql = "Select Max(Convert(int," + strPrimaryKeyName + ")) From " + strTableName;// +" Order By " + strPrimaryKeyName + " desc";

                object objScalar = DbHelperSQL.GetSingle(strSql);

                if (objScalar != null && objScalar.ToString() != "")
                {
                    strMaxCode = objScalar.ToString();

                    //if (strMaxCode.Length > 2)
                    //{
                        //string strMaxCodeBefore = strMaxCode.Substring(0, 1);
                        string strMaxCodeAfter = strMaxCode;//.Substring(1);
                        //int iMaxCodeAfterLength = strMaxCodeAfter.Length;

                        strMaxCodeAfter = (Convert.ToInt32(strMaxCodeAfter) + 1).ToString();

                        //if (strMaxCodeAfter.Length != iMaxCodeAfterLength)
                        //{
                        //    strMaxCodeAfter = strMaxCodeAfter.PadLeft(iMaxCodeAfterLength, '0');
                        //}

                        strMaxCode = strMaxCodeAfter;//strMaxCodeBefore + 
                    //}
                }
                else
                {
                    strMaxCode = strDefaultValue;
                    //strMaxCode = "1";
                }
            }
            catch (Exception ex)
            {
                string strErrorMessage = ex.Message.ToString();
            }

            return strMaxCode;
        }
        /// <summary>
        /// 无控件绑定
        /// </summary>
        /// <param name="strTableName">表名</param>
        /// <param name="strPrimaryKeyName">主建</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns>主键ID最大值</returns>
        public static string UnControlAutoIncreaseCode(string strTableName, string strPrimaryKeyName,string strWhere)
        {
            string strMaxCode = string.Empty;
            
            try
            {
                string strSql = "Select EnumValue From dbo.T_EnumValue Where EnumValueName='" + strTableName + "'";
                string strDefaultValue = DbHelperSQL.GetSingle(strSql).ToString();

                strSql = "Select Top 1 " + strPrimaryKeyName + " From " + strTableName + " Where" + strWhere + " Order By " + strPrimaryKeyName + " desc";

                object objScalar = DbHelperSQL.GetSingle(strSql);

                if (objScalar != null && objScalar.ToString() != "")
                {
                    strMaxCode = objScalar.ToString();

                    if (strMaxCode.Length > 2)
                    {
                        string strMaxCodeBefore = strMaxCode.Substring(0, 1);
                        string strMaxCodeAfter = strMaxCode.Substring(1);
                        int iMaxCodeAfterLength = strMaxCodeAfter.Length;

                        strMaxCodeAfter = (Convert.ToInt32(strMaxCodeAfter) + 1).ToString();

                        if (strMaxCodeAfter.Length != iMaxCodeAfterLength)
                        {
                            strMaxCodeAfter = strMaxCodeAfter.PadLeft(iMaxCodeAfterLength, '0');
                        }

                        strMaxCode = strMaxCodeBefore + strMaxCodeAfter;
                    }
                }
                else
                {
                    strMaxCode = strDefaultValue;
                }
            }
            catch (Exception ex)
            {
                string strErrorMessage = ex.Message.ToString();
            }

            return strMaxCode;
        }
        
        #endregion

        #region 绑定树控件数据
        /// <summary>
        /// 
        /// </summary>
        /// <param name="treeview">树控件的ID</param>
        /// <param name="tablename">表名称</param>
        /// <param name="fieldText">数据名称</param>
        /// <param name="fieldValue">数据编号</param>
        /// <param name="FatherCode">父级编号</param>
        /// <param name="FatherValue">父级过滤条件</param>
        /// <param name="condition">条件语句</param>
        public static void BindTreeview(TreeView treeview, string tablename, string fieldText, string fieldValue, string FatherCode, string FatherValue, string condition)
        {
            string str = "select " + fieldText + "," + fieldValue + "," + FatherCode + " from " + tablename + "  where " + condition;
            DataTable dt = DbHelperSQL.Query(str).Tables[0];
            DataRow[] Arr_datarow;
            //根据需求，要求根据人员的权限来设置机构数据
            if (FatherValue != "0")
            {
                Arr_datarow = dt.Select(fieldValue + "='" + FatherValue + "'");
            }
            else
            {
                Arr_datarow = dt.Select(FatherCode + "='" + FatherValue + "'");
            }
            treeview.Nodes.Clear();
            if (Arr_datarow.Length <= 0) return;
            foreach (DataRow dr in Arr_datarow)
            {
                TreeNode rootnode = new TreeNode();
                rootnode.Text = dr[fieldText].ToString().Trim();
                rootnode.Value = dr[fieldValue].ToString().Trim();
                //rootnode.SelectAction = TreeNodeSelectAction.Expand;
                treeview.Nodes.Add(rootnode);
                BindSubNode(dt, rootnode, fieldText, fieldValue, FatherCode);
            }
        }
        private static void BindSubNode(DataTable dtTable, TreeNode fatherNode, string fieldText, string fieldValue, string fathercode)
        {
            DataRow[] arr_datarow = dtTable.Select(fathercode + " = '" + fatherNode.Value.ToString().Trim() + "'");
            if (arr_datarow.Length <= 0) return;
            foreach (DataRow dr in arr_datarow)
            {
                TreeNode node = new TreeNode();
                node.Text = dr[fieldText].ToString().Trim();
                node.Value = dr[fieldValue].ToString().Trim();
                fatherNode.ChildNodes.Add(node);
                BindSubNode(dtTable, node, fieldText, fieldValue, fathercode);
            }

        }
        #endregion


        /// <summary>
        ///获取所有未禁用磅房的IP
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllRoomIP()
        {
            string strSendDataObject = System.Configuration.ConfigurationManager.AppSettings["SendDataObject"].ToString();
            List<string> listIp = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct RoomIp from TT_ROOM  where IsForbid='0'");
            if (strSendDataObject != "")
                strSql.Append(" and RoomType='" + strSendDataObject + "'");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    listIp.Add(ds.Tables[0].Rows[i][0].ToString().Trim());
                }
            }
            return listIp;
        }



        #region 根据表ID得到表中的某一字段
        /// <summary>
        /// 根据表ID得到表中的某一字段
        /// </summary>
        /// <param name="strTable">表名/视图名</param>
        /// <param name="strFieldName">需要得到的字段名</param>
        /// <param name="where">附加条件</param>
        /// <returns>返回查询字段值</returns>
        public static string GetFiledValue(string strTable, string strFieldName,string where)
        {

            string strsel = "SELECT " + strFieldName + " FROM " + strTable + " where 1=1";
            if (where != "")
                strsel += " and " + where + " ";
            try
            {
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(strsel);
                if (sdr.Read())
                {
                    return sdr[0].ToString();
                }
                else
                    return "";
            }
            catch
            {
                return "";
            }

        }
        #endregion
        
      
    }
       
}
