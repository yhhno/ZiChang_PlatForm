/***********************************************
 * 单元名称：短信等待发送
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
    /// 数据访问类SYS_ReadySendMessage。
    /// </summary>
    public class SYS_ReadySendMessageSQLDAL : ISYS_ReadySendMessage
    {
        public SYS_ReadySendMessageSQLDAL()
        { }

        /// <summary>
        /// 获取待发短信信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetReadySendMessageInfo()
        {
            DataTable dtReadySendMessageInfo = null;
            int iYear = DateTime.Now.Year;
            int ICount = 0;
            string strsql = "select count(*) from Sys_ReadySendMessage" + (iYear - 1) + "";
            try
            {
                ICount = Convert.ToInt32(DbHelperSQL.GetSingle(strsql));
            }
            catch
            {
                ICount = 0;
            }


            StringBuilder sbsql = new StringBuilder();

            #region 拼接查询
            sbsql.Append("select top 20 RSMID,PhoneNumber,MContent,SendDate");

            if (ICount == 0)
            {
                sbsql.Append(" from Sys_ReadySendMessage" + iYear + " RSM");
                sbsql.Append(" order by SendDate desc");
            }
            else
            {
                sbsql.Append(" from (");
                sbsql.Append("select * from Sys_ReadySendMessage" + iYear + "");
                sbsql.Append(" union");
                sbsql.Append(" select * from Sys_ReadySendMessage" + (iYear - 1) + "");
                sbsql.Append(") as RSM");
                sbsql.Append(" order by SendDate desc");
            }
            #endregion

            DataSet ds = DbHelperSQL.DQuery(sbsql.ToString());

            dtReadySendMessageInfo = ds.Tables[0];

            return dtReadySendMessageInfo;
        }

    }
}

