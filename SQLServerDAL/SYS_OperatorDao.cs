using System;
using System.Collections.Generic;
using System.Text;
using IndustryPlatform.Model;
using IndustryPlatform.DBUtility;
using System.Data.SqlClient;
using System.Data;


namespace IndustryPlatform.SQLServerDAL
{
    public class SYS_OperatorDao : IndustryPlatform.IDAL.ISYS_Operator
    {

        public DataSet OperatorLogin(string strusername, string strpwd)
        {
            try
            {
                string strsql = "SELECT * FROM Sys_Operator WHERE UserName=@UserCode and Password=@Password";
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@UserCode",strusername),
                    new SqlParameter("@Password",strpwd)
                };
                DataSet ds = DbHelperSQL.Query(strsql, parm);
                return ds;
            }
            catch
            {
                return null;
            }
        }

        public void SetParameterValue(SYS_OperatorEntity model, out SqlParameter[] sqlParm)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UserCode", SqlDbType.VarChar,10),
					new SqlParameter("@UserName", SqlDbType.NVarChar,20),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@IsForbid", SqlDbType.VarChar,1),
					new SqlParameter("@OrgCode", SqlDbType.VarChar,10),
					new SqlParameter("@Tel", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@ZipCode", SqlDbType.VarChar,10),
					new SqlParameter("@PID", SqlDbType.VarChar,18),
					new SqlParameter("@Gender", SqlDbType.NVarChar,2),
					new SqlParameter("@RegDate", SqlDbType.DateTime),
					new SqlParameter("@MobileNo", SqlDbType.NVarChar,20),
					new SqlParameter("@TypeCode", SqlDbType.VarChar,10)};

            parameters[0].Value = model.UserCode;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.IsForbid;
            parameters[4].Value = model.OrgCode;
            parameters[5].Value = model.Tel;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.ZipCode;
            parameters[9].Value = model.PID;
            parameters[10].Value = model.Gender;
            parameters[11].Value = model.RegDate;
            parameters[12].Value = model.MobileNo;
            parameters[13].Value = model.TypeCode;

            sqlParm= parameters;
         
           
        }
        public int AddOperator(SYS_OperatorEntity operEntity)
        {
            try
            {
                
                SqlParameter[] parm = new SqlParameter[]{};
                SetParameterValue(operEntity, out parm);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sys_Operator(");
                strSql.Append("UserCode,UserName,Password,IsForbid,OrgCode,Tel,Email,Address,ZipCode,PID,Gender,RegDate,MobileNo,TypeCode)");
                strSql.Append(" values (");
                strSql.Append("@UserCode,@UserName,@Password,@IsForbid,@OrgCode,@Tel,@Email,@Address,@ZipCode,@PID,@Gender,@RegDate,@MobileNo,@TypeCode)");

                int op = DbHelperSQL.ExecuteSql(strSql.ToString(), parm);
                return op;
            }
            catch
            {
                return 0;
            }
        }
        public int DelOperator(string stroperid)
        {
            try
            {
                string strdel = "Delete SYS_Operator where UserCode in ("+stroperid+")";
                int op = DbHelperSQL.ExecuteSql(strdel);
                return op;
            }
            catch
            {
                return 0;
            }
        }
        public int UpdateOperator(SYS_OperatorEntity operEntity)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Sys_Operator set ");
                strSql.Append("UserName=@UserName,");
                strSql.Append("Password=@Password,");
                strSql.Append("IsForbid=@IsForbid,");
                strSql.Append("OrgCode=@OrgCode,");
                strSql.Append("Tel=@Tel,");
                strSql.Append("Email=@Email,");
                strSql.Append("Address=@Address,");
                strSql.Append("ZipCode=@ZipCode,");
                strSql.Append("PID=@PID,");
                strSql.Append("Gender=@Gender,");
                strSql.Append("RegDate=@RegDate,");
                strSql.Append("MobileNo=@MobileNo,");
                strSql.Append("TypeCode=@TypeCode");
                strSql.Append(" where UserCode=@UserCode ");
                SqlParameter[] parm = new SqlParameter[] { };
                SetParameterValue(operEntity,out parm);
                int op = DbHelperSQL.ExecuteSql(strSql.ToString(), parm);
                return op;
            }
            catch
            {
                return 0;
            }
        }

        public DataSet GetOperatorInfo(string perid)
        {
            try
            {
                DataSet ds = new DataSet();
                string strsel = "Select * from SYS_Operator Where UserCode=@UserCode";

                SqlParameter[] parm = new SqlParameter[] 
                {
                    new SqlParameter("@UserCode",perid)
                };
                ds = DbHelperSQL.Query(strsel, parm);
                return ds;
            }
            catch
            {
                return null;
            }
        }

        public int Updatepwd(string perid, string oldpwd, string newpwd)
        {
            try
            {
                string sel = "select count(0) from SYS_Operator Where UserCode=@UserCode and password=@password";
                SqlParameter[] parm = new SqlParameter[] 
                {
                    new SqlParameter("@UserCode",perid),
                    new SqlParameter("@password",oldpwd)
                };
                bool exi = DbHelperSQL.Exists(sel,parm);
                if (exi)
                {
                    string sqlupdate = "Update SYS_Operator set password=@password where UserCode=@UserCode";
                    SqlParameter[] uparm = new SqlParameter[] 
                   {
                    new SqlParameter("@UserCode",perid),
                    new SqlParameter("@password",newpwd)
                   };
                   int iop = DbHelperSQL.ExecuteSql(sqlupdate, uparm);
                   return iop;
                }
                else
                {
                    return -1;
                }

            }
            catch
            {
                return 0;
 
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public IndustryPlatform.Model.SYS_OperatorEntity GetModel(string UserCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserCode,UserName,Password,IsForbid,OrgCode,Tel,Email,Address,ZipCode,PID,Gender,RegDate,MobileNo,TypeCode from Sys_Operator ");
            strSql.Append(" where UserCode=@UserCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserCode", SqlDbType.VarChar,50)};
            parameters[0].Value = UserCode;

            IndustryPlatform.Model.SYS_OperatorEntity model = new IndustryPlatform.Model.SYS_OperatorEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.UserCode = ds.Tables[0].Rows[0]["UserCode"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.IsForbid = ds.Tables[0].Rows[0]["IsForbid"].ToString();
                model.OrgCode = ds.Tables[0].Rows[0]["OrgCode"].ToString();
                model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.ZipCode = ds.Tables[0].Rows[0]["ZipCode"].ToString();
                model.PID = ds.Tables[0].Rows[0]["PID"].ToString();
                model.Gender = ds.Tables[0].Rows[0]["Gender"].ToString();
                if (ds.Tables[0].Rows[0]["RegDate"].ToString() != "")
                {
                    model.RegDate = DateTime.Parse(ds.Tables[0].Rows[0]["RegDate"].ToString());
                }
                model.MobileNo = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                model.TypeCode = ds.Tables[0].Rows[0]["TypeCode"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        public int SetDefaultPwd(string pid,string defaultpwd)
        {
            try
            {
                string sqlupdate = "Update SYS_Operator set password='" + defaultpwd + "' where UserCode in ("+pid+")";
                int op = DbHelperSQL.ExecuteSql(sqlupdate);
                return op;
            }
            catch
            {
                return 0;
            }
        }

        public int GetMaxID(string FildName, string TableName)
        {
            return DbHelperSQL.GetMaxID(FildName, TableName);
        }

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
        public void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strTableName, string strPrimaryKey, string strQuaryCondition, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl)
        {
            string strsel = "";
            if (strQuaryCondition == "")
            {
                strsel = "select * from (select row_number() over (order by " + strOrderCondition + ") as rowno,SYS_Operator.* from " + strTableName + ") as result Where (rowno Between " + ((anpager.CurrentPageIndex - 1) * anpager.PageSize+1) + " and " + anpager.CurrentPageIndex * anpager.PageSize + ")";
               
                anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(*) From " + strTableName));
            }
            else
            {
                strsel = "select * from (select row_number() over (order by " + strOrderCondition + ") as rowno,SYS_Operator.* from " + strTableName + " where " + strQuaryCondition + ") as result Where (rowno Between " + ((anpager.CurrentPageIndex - 1) * anpager.PageSize+1) + " and " + anpager.CurrentPageIndex * anpager.PageSize + ")";
                anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(*) From " + strTableName + " Where " + strQuaryCondition));
            }
            DataSet dstTemp = DbHelperSQL.Query(strsel);

            if (dstTemp.Tables[0].Rows.Count == 0)
            {
                //DataRow dr = dstTemp.Tables[0].NewRow();
                //dstTemp.Tables[0].Rows.Add(dr);
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

        public int AddOperPosition(string stroperid,string PositionCode)
        {
            
           
            try
            {
                List<string> sqlinsert = new List<string>();
                string[] arroperid = stroperid.TrimEnd(',').Split(',');
                sqlinsert.Add("DELETE FROM SYS_OperatorPosition WHERE UserCode in (" + stroperid.TrimEnd(',') + ")");
                for (int i = 0; i < arroperid.Length; i++)
                {
                    string[] arrposi = PositionCode.TrimEnd(',').Split(',');
                    for (int j = 0; j < arrposi.Length; j++)
                    {
                        sqlinsert.Add("INSERT INTO SYS_OperatorPosition (UserCode,PositonCode) VALUES (" + arroperid[i] + "," + arrposi[j] + ")");
                        // DbHelperSQL.ExecuteSql("INSERT INTO SYS_OperatorPosition VALUES ("+arroperid[i]+","+arrposi[j]+",'0')");

                    }
                }

                if (DbHelperSQL.ExecuteSqlCake(sqlinsert, null))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch
            {
                return 0;
            }
        }

        public string GetPosition(int operid)
        {
            try
            {
                string strsql = "SELECT * FROM SYS_OperatorPosition WHERE UserCode=" + operid + "";
               DataTable dt = DbHelperSQL.TQuery(strsql);
               StringBuilder strb = new StringBuilder();
               if (dt.Rows.Count > 0)
               {
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       strb.Append(dt.Rows[i]["PositonCode"].ToString() + ",");
                   }
                   return strb.ToString().TrimEnd(',');
               }
               else
               {
                   return "'0'";
               }
            }
            catch
            {
                return "'0'";
            }
        }

        public string GetOperPosition(int operid)
        {
            try
            {
                string strsql = "SELECT SYS_Position.PositionName FROM SYS_OperatorPosition left outer join  SYS_Position on SYS_OperatorPosition.PositonID = SYS_Position.PositonID WHERE UserCode=" + operid + "";
                DataTable dt = DbHelperSQL.TQuery(strsql);
                StringBuilder strb = new StringBuilder();
                if (dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strb.Append(dt.Rows[i]["PositionName"].ToString() + "|");
                    }
                    return strb.ToString().TrimEnd('|');
                }
                else
                {
                    return "未分配岗位";
                }
            }
            catch
            {
                return "未分配岗位";
            }
        }

        public int CheckUserID(string userid)
        {
            try
            {
                string strcheck = "SELECT COUNT(0) FROM SYS_Operator WHERE userID=@userID";
                SqlParameter[] parm = new SqlParameter[] 
                {
                    new SqlParameter("@userID",userid)
                    
                };
                object obj = DbHelperSQL.GetSingle(strcheck,parm);
                if (obj != null)
                {
                    return Convert.ToInt32(obj);
                }
                else
                {
                    return 0;
                }

            }
            catch
            {
                return -1;
            }
        }

        public int CheckUserName(string userName)
        {
            try
            {
                string strcheck = "SELECT COUNT(0) FROM SYS_Operator WHERE userName=@userName";
                SqlParameter[] parm = new SqlParameter[] 
                {
                    new SqlParameter("@userName",userName)
                    
                };
                object obj = DbHelperSQL.GetSingle(strcheck, parm);
                if (obj != null)
                {
                    return Convert.ToInt32(obj);
                }
                else
                {
                    return 0;
                }

            }
            catch
            {
                return -1;
            }
        }

        

    }
}
