/***********************************************
 * 单元名称：短信发送失败
 * 开 发 者：翁志成
 * 开发时间：2009-8-26
 * 修改时间：
 * 修改原因：
 *********************************************/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using IndustryPlatform.IDAL;
using IndustryPlatform.DBUtility;

namespace IndustryPlatform.SQLServerDAL
{
    /// <summary>
    /// 数据访问类SYS_FailerSendMessage。
    /// </summary>
    public class SYS_FailerSendMessageSQLDAL : ISYS_FailerSendMessage
    {
        public SYS_FailerSendMessageSQLDAL()
        { }


        #region 使用分页控件绑定GridView(重载方法)
        //#region Repeater控件分页帮定
        ///// <summary #region GridView控件分页帮定
        /// <summary>
        /// GridView控件分页帮定
        /// </summary>
        /// <param name="anpager">AspNetPager分页控件</param>
        /// <param name="strQuaryCondition">查询Where条件，不含Where</param>
        /// <param name="strOrderCondition">需要排序的字段名</param>
        /// <param name="rptControl">GridView控件</param>
        public void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strWhere, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl, int startyear, int endyear)
        {
            StringBuilder sbSucceedTable = new StringBuilder();

            DataSet dstTemp = new DataSet();

            #region 根据时间获取要查询的短信表
            for (int i = startyear; i <= endyear; i++)
            {
                sbSucceedTable.Append("'Sys_FailerSendMessage" + i + "',");
            }
            sbSucceedTable.Remove(sbSucceedTable.Length - 1, 1);
            string strselectTable = "select name from sysobjects where type='u' and name in(" + sbSucceedTable + ")";

            DataSet dsSucceedTable = DbHelperSQL.DQuery(strselectTable);

            StringBuilder sbsql = new StringBuilder();

            sbsql.Append("select FSMID,PhoneNumber,MContent,FailerDate from (");

            for (int i = 0; i < dsSucceedTable.Tables[0].Rows.Count; i++)
            {
                sbsql.Append("select * from " + dsSucceedTable.Tables[0].Rows[i][0].ToString() + " union");
            }

            sbsql.Remove(sbsql.Length - 6, 6);
            sbsql.Append(") as FSM");
            #endregion

            StringBuilder strSql = new StringBuilder();

            strSql.Append("select * from (select row_number() over (order by " + strOrderCondition + ") as rowno,*  from (" + sbsql.ToString() + ") as VT_FailerMessage");
            strSql.Append(strWhere);
            strSql.Append(" ) as result Where (rowno Between " + ((anpager.CurrentPageIndex - 1) * anpager.PageSize + 1) + " and " + anpager.CurrentPageIndex * anpager.PageSize + ")");

            StringBuilder strb = new StringBuilder();

            strb.Append("Select Count(*) From (" + sbsql.ToString() + ") as VT_FailerMessage");
            strb.Append(strWhere);

            anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle(strb.ToString()));
            dstTemp = DbHelperSQL.Query(strSql.ToString());



            if (dstTemp.Tables[0].Rows.Count == 0)
            {
                grvControl.DataSource = null;
                grvControl.DataBind();
            }
            else
            {
                grvControl.DataSource = dstTemp.Tables[0];
                grvControl.DataBind();
            }


            //动态设置用户自定义文本内容
            anpager.CustomInfoHTML = "共有<font color=\"blue\"><b>" + anpager.RecordCount.ToString() + "</b></font>条记录";
            anpager.CustomInfoHTML += " 总页数：<font color=\"blue\"><b>" + anpager.PageCount.ToString() + "</b></font>页";
            anpager.CustomInfoHTML += " 当前页：第<font color=\"red\"><b>" + anpager.CurrentPageIndex.ToString() + "</b></font>页";

        }
        #endregion

        /// <summary>
        /// 继续发送短信
        /// </summary>
        /// <param name="FailerID"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        #region 继续发送短信
        public int InsertIntoReadySendMessage(string FailerID, int year)
        {
            int Irow = 0;
            List<string> Ltsql = new List<string>();

            string strsql = "select PhoneNumber,MContent,FailerDate from Sys_FailerSendMessage" + year + " where FSMID in(" + FailerID + ")";

            DataSet dsFailerMessage = DbHelperSQL.DQuery(strsql);

            if (null != dsFailerMessage)
            {
                if (dsFailerMessage.Tables[0].Rows.Count != 0)
                {
                    DataRowCollection drc = dsFailerMessage.Tables[0].Rows;

                    for (int i = 0; i < drc.Count; i++)
                    {

                        Ltsql.Add("insert into Sys_ReadySendMessage" + year + " (PhoneNumber,MContent,SendDate) values('" + drc[i]["PhoneNumber"].ToString() + "','" + drc[i]["MContent"].ToString() + "','" + drc[i]["FailerDate"].ToString() + "');");
                    }

                    Ltsql.Add("delete from Sys_ReadySendMessage" + year + " where FSMID in (" + FailerID + ");");

                    Irow = DbHelperSQL.ExecuteSqlTran(Ltsql);
                }
            }
            else
            {
                Irow = 0;
            }

            return Irow;
        }
        #endregion
    }
}

