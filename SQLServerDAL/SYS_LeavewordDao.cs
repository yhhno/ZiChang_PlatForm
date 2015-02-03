using System;
using System.Collections.Generic;
using System.Text;
using IndustryPlatform.Model;
using IndustryPlatform.DBUtility;
using IndustryPlatform.IDAL;
using System.Data;
using System.Data.SqlClient;
namespace IndustryPlatform.SQLServerDAL
{
    public class SYS_LeavewordDao : ISYS_Leaveword
    {
        #region 添加
        public int AddLeaveword(List<SYS_LeavewordEntity> entitys)
        {
            List<string> sqls = new List<string>();
            List<SqlParameter[]> pars = new List<SqlParameter[]>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_LeaveWord(");
            strSql.Append("LeaveID,LeaveTitle,LeaveDate,LeaveContent,Operator,ReceiveID,IsRead)");
            strSql.Append(" values (");
            strSql.Append("@LeaveID,@LeaveTitle,@LeaveDate,@LeaveContent,@Operator,@ReceiveID,@IsRead)");
           
            
            for (int i = 0; i < entitys.Count; i++)
            {
                SqlParameter[] parameters = {
					new SqlParameter("@LeaveID", SqlDbType.VarChar,32),
					new SqlParameter("@LeaveTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@LeaveDate", SqlDbType.DateTime),
					new SqlParameter("@LeaveContent", SqlDbType.Text),
					new SqlParameter("@Operator", SqlDbType.NVarChar,20),
					new SqlParameter("@ReceiveID", SqlDbType.VarChar,10),
					new SqlParameter("@IsRead", SqlDbType.VarChar,1)};

                SYS_LeavewordEntity model= entitys[i];
                parameters[0].Value = model.LeaveID;
                parameters[1].Value = model.LeaveTitle;
                parameters[2].Value = model.LeaveDate;
                parameters[3].Value = model.LeaveContent;
                parameters[4].Value = model.Operator;
                parameters[5].Value = model.ReceiveID;
                parameters[6].Value = model.IsRead;


                sqls.Add(strSql.ToString());
                pars.Add(parameters);
            }
            if (DbHelperSQL.ExecuteSqlCake(sqls, pars))
                return 1;
            else
                return 0;
        }
        #endregion

        #region 查询
        public SYS_LeavewordEntity getLeavewordByLid(string LeaveID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LeaveID,LeaveTitle,LeaveDate,LeaveContent,Operator,ReceiveID,IsRead from Sys_LeaveWord ");
            strSql.Append(" where LeaveID=@LeaveID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LeaveID", SqlDbType.VarChar,50)};
            parameters[0].Value = LeaveID;

            IndustryPlatform.Model.SYS_LeavewordEntity model = new IndustryPlatform.Model.SYS_LeavewordEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.LeaveID = ds.Tables[0].Rows[0]["LeaveID"].ToString();
                model.LeaveTitle = ds.Tables[0].Rows[0]["LeaveTitle"].ToString();
                if (ds.Tables[0].Rows[0]["LeaveDate"].ToString() != "")
                {
                    model.LeaveDate = DateTime.Parse(ds.Tables[0].Rows[0]["LeaveDate"].ToString());
                }
                model.LeaveContent = ds.Tables[0].Rows[0]["LeaveContent"].ToString();
                model.Operator = ds.Tables[0].Rows[0]["Operator"].ToString();
                model.ReceiveID = ds.Tables[0].Rows[0]["ReceiveID"].ToString();
                model.IsRead = ds.Tables[0].Rows[0]["IsRead"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
