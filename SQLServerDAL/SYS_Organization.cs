using System;
using System.Collections.Generic;
using System.Text;
using IndustryPlatform.DBUtility;
using System.Data.SqlClient;
using System.Data;
using IndustryPlatform.IDAL;

namespace IndustryPlatform.SQLServerDAL
{
    public class SYS_Organization : ISYS_Organization
    {
        public SYS_Organization()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string OrgCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Organization");
            strSql.Append(" where OrgCode=@OrgCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrgCode", SqlDbType.VarChar,50)};
            parameters[0].Value = OrgCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(IndustryPlatform.Model.SYS_Organization model)
        {
            try
            {
                lock (this)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into Sys_Organization(");
                    strSql.Append("OrgCode,OrgName,OrgLevel,ParentOrgCode,OrgSeq,OrgType,LinkMan,LinkManTel,Email,IsForbid,Remark,SysCode)");
                    strSql.Append(" values (");
                    strSql.Append("@OrgCode,@OrgName,@OrgLevel,@ParentOrgCode,@OrgSeq,@OrgType,@LinkMan,@LinkManTel,@Email,@IsForbid,@Remark,@SysCode)");
                    SqlParameter[] parameters = {
					new SqlParameter("@OrgCode", SqlDbType.VarChar,10),
					new SqlParameter("@OrgName", SqlDbType.NVarChar,50),
					new SqlParameter("@OrgLevel", SqlDbType.VarChar,1),
					new SqlParameter("@ParentOrgCode", SqlDbType.VarChar,10),
					new SqlParameter("@OrgSeq", SqlDbType.NVarChar,300),
					new SqlParameter("@OrgType", SqlDbType.VarChar,1),
					new SqlParameter("@LinkMan", SqlDbType.NVarChar,20),
					new SqlParameter("@LinkManTel", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@IsForbid", SqlDbType.VarChar,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@SysCode", SqlDbType.VarChar,4)};
                    int iKey = DbHelperSQL.GetMaxID("OrgCode", "SYS_Organization");
                    string strSEQ = "";
                    if (model.ParentOrgCode == "0")
                        strSEQ = iKey + ".";
                    else
                        strSEQ = GetModel(model.ParentOrgCode).OrgSeq + iKey + ".";

                    model.OrgSeq = strSEQ;
                    parameters[0].Value = model.OrgCode;
                    parameters[1].Value = model.OrgName;
                    parameters[2].Value = model.OrgLevel;
                    parameters[3].Value = model.ParentOrgCode;
                    parameters[4].Value = model.OrgSeq;
                    parameters[5].Value = model.OrgType;
                    parameters[6].Value = model.LinkMan;
                    parameters[7].Value = model.LinkManTel;
                    parameters[8].Value = model.Email;
                    parameters[9].Value = model.IsForbid;
                    parameters[10].Value = model.Remark;
                    parameters[11].Value = model.SysCode;

                    DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                    return 1;
                }
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(IndustryPlatform.Model.SYS_Organization model)
        {
            try
            {
                List<string> listSql = new List<string>();
                List<SqlParameter[]> listParm = new List<SqlParameter[]>();
                string strOldSEQ = GetModel(model.OrgCode).OrgSeq;
                string strNewSEQ = model.OrgCode + ".";
                if (model.ParentOrgCode != "0")
                {
                    IndustryPlatform.Model.SYS_Organization p=GetModel(model.ParentOrgCode);
                    strNewSEQ = p.OrgSeq + model.OrgCode+".";
                }
                
                //更新序列
                string strSqlSeq = "update SYS_Organization set OrgSeq='" + strNewSEQ + "'+ replace(OrgSeq,'" + strOldSEQ + "','') where OrgSeq like '" + strOldSEQ + "%'";
                //DbHelperSQL.ExecuteSql(strSqlSeq);
                listSql.Add(strSqlSeq);
                listParm.Add(null);

                //更新Level
                string strSqlLevel = "Update SYS_Organization set orgLevel=len(orgSEQ)-len(replace(orgSEQ,'.' , ''))  where orgSEQ like '" + strNewSEQ + "%'";
                listSql.Add(strSqlLevel);
                listParm.Add(null);
                //DbHelperSQL.ExecuteSql(strSqlLevel);
                
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Sys_Organization set ");
                strSql.Append("OrgName=@OrgName,");
                strSql.Append("OrgLevel=@OrgLevel,");
                strSql.Append("ParentOrgCode=@ParentOrgCode,");
                strSql.Append("OrgSeq=@OrgSeq,");
                strSql.Append("OrgType=@OrgType,");
                strSql.Append("LinkMan=@LinkMan,");
                strSql.Append("LinkManTel=@LinkManTel,");
                strSql.Append("Email=@Email,");
                strSql.Append("IsForbid=@IsForbid,");
                strSql.Append("Remark=@Remark,");
                strSql.Append("SysCode=@SysCode");
                strSql.Append(" where OrgCode=@OrgCode ");
                SqlParameter[] parameters = {
					new SqlParameter("@OrgCode", SqlDbType.VarChar,10),
					new SqlParameter("@OrgName", SqlDbType.NVarChar,50),
					new SqlParameter("@OrgLevel", SqlDbType.VarChar,1),
					new SqlParameter("@ParentOrgCode", SqlDbType.VarChar,10),
					new SqlParameter("@OrgSeq", SqlDbType.NVarChar,300),
					new SqlParameter("@OrgType", SqlDbType.VarChar,1),
					new SqlParameter("@LinkMan", SqlDbType.NVarChar,20),
					new SqlParameter("@LinkManTel", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@IsForbid", SqlDbType.VarChar,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@SysCode", SqlDbType.VarChar,4)};
                parameters[0].Value = model.OrgCode;
                parameters[1].Value = model.OrgName;
                parameters[2].Value = model.OrgLevel;
                parameters[3].Value = model.ParentOrgCode;
                parameters[4].Value = strNewSEQ;
                parameters[5].Value = model.OrgType;
                parameters[6].Value = model.LinkMan;
                parameters[7].Value = model.LinkManTel;
                parameters[8].Value = model.Email;
                parameters[9].Value = model.IsForbid;
                parameters[10].Value = model.Remark;
                parameters[11].Value = model.SysCode;
                listSql.Add(strSql.ToString());
                listParm.Add(parameters);
                //DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                DbHelperSQL.ExecuteSqlCake(listSql, listParm);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(string OrgCode)
        {
            try
            {
                List<string> listSql = new List<string>();
                string[] Orgs = OrgCode.Split(',');
                for (int i = 0; i < Orgs.Length; i++)
                {
                    string strSEQ = GetModel(Orgs[i].ToString()).OrgSeq;
                    //删除本身及所有下级的岗位
                    //listSql.Add("Delete SYS_Position where OrgCode in(select OrgCode from SYS_Organization where orgSEQ like '" + strSEQ + "%')");
                    ////使该机构下人员的组织为空
                    //listSql.Add("update SYS_Operator set OrgCode=null where OrgCode in(select OrgCode from SYS_Organization where orgSEQ like '" + strSEQ + "%')");
                    //删除本身及所有的下级
                    listSql.Add("Delete SYS_Organization where orgSEQ like '" + strSEQ + "%'");
                }
                DbHelperSQL.ExecuteSqlCake(listSql, null);
                return 1;
            }
            catch
            {
                return 0;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public IndustryPlatform.Model.SYS_Organization GetModel(string OrgCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrgCode,OrgName,OrgLevel,ParentOrgCode,OrgSeq,OrgType,LinkMan,LinkManTel,Email,IsForbid,Remark,SysCode from Sys_Organization ");
            strSql.Append(" where OrgCode=@OrgCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrgCode", SqlDbType.VarChar,50)};
            parameters[0].Value = OrgCode;

            IndustryPlatform.Model.SYS_Organization model = new IndustryPlatform.Model.SYS_Organization();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.OrgCode = ds.Tables[0].Rows[0]["OrgCode"].ToString();
                model.OrgName = ds.Tables[0].Rows[0]["OrgName"].ToString();
                model.OrgLevel = ds.Tables[0].Rows[0]["OrgLevel"].ToString();
                model.ParentOrgCode = ds.Tables[0].Rows[0]["ParentOrgCode"].ToString();
                model.OrgSeq = ds.Tables[0].Rows[0]["OrgSeq"].ToString();
                model.OrgType = ds.Tables[0].Rows[0]["OrgType"].ToString();
                model.LinkMan = ds.Tables[0].Rows[0]["LinkMan"].ToString();
                model.LinkManTel = ds.Tables[0].Rows[0]["LinkManTel"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.IsForbid = ds.Tables[0].Rows[0]["IsForbid"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                model.SysCode = ds.Tables[0].Rows[0]["SysCode"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SYS_Organization ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "SYS_Organization";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        /// <summary>
        /// 判断某一机构下是否有岗位
        /// </summary>
        /// <param name="OrgCode"></param>
        /// <returns></returns>
        public int GetPositionCountByOrgCode(string OrgCode)
        {
            string strSEQ = GetModel(OrgCode).OrgSeq;
            string strSql = "select count(0) from SYS_Position "
            + "where OrgCode in(select OrgCode from SYS_Organization where orgSEQ like '" + strSEQ + "%' ) and IsForbid='0'";
            return DbHelperSQL.ExecuteSql(strSql);
        }

        /// <summary>
        /// 判断某以组织下是否存在人员
        /// </summary>
        /// <param name="OrgCode"></param>
        /// <returns></returns>
        public int GetOperatorCountByOrgCode(string OrgCode)
        {
            string strSEQ = GetModel(OrgCode).OrgSeq;
            string strSql = "select count(0) from SYS_Operator "
            + "where OrgCode in(select OrgCode from SYS_Organization where orgSEQ like '" + strSEQ + "%' )";
            return DbHelperSQL.ExecuteSql(strSql);
        }


        public DataSet GridViewData(string strWhere, string strOrder,int row1,int row2,ref int iRowCount)
        {
            string strSql = "select * from "
                            + "("
                            + " select row_number() over(order by "+strOrder+") RowNo,* from SYS_Organization"
                            + " where "+strWhere
                            + " ) as rel where RowNo >="+row1+" and RowNo<="+row2;
            iRowCount = Convert.ToInt32(DbHelperSQL.GetSingle("select count(0) from SYS_Organization where " + strWhere));
            return DbHelperSQL.Query(strSql);
        }

        /// <summary>
        /// 判断组织代码是否存在
        /// </summary>
        /// <param name="orgCode"></param>
        /// <param name="OrgCode"></param>
        /// <returns></returns>
        public int ExistOrgCode(string orgCode)
        {
            
                return Convert.ToInt32(DbHelperSQL.GetSingle("select count(0) from SYS_Organization where orgCode='" + orgCode.Replace("'", "''") + "'"));
            
        }
       
        #endregion  成员方法
    }
}

