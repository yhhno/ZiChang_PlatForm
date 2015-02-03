using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using IndustryPlatform.IDAL;
using IndustryPlatform.DBUtility;
namespace IndustryPlatform.SQLServerDAL
{
    /// <summary>
    /// 数据访问类SYS_Dictionary。
    /// </summary>
    public class SYS_DictionaryDao : ISYS_Dictionary
    {
        public SYS_DictionaryDao()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string businTypeID, string businName, string businID)
        {
            if (businID == "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(0) from SYS_Dictionary");
                strSql.Append(" where businName=@businName and businTypeID=@businTypeID ");
                SqlParameter[] parameters = {
					new SqlParameter("@businName", SqlDbType.VarChar),
					new SqlParameter("@businTypeID", SqlDbType.VarChar)};
                parameters[0].Value = businName;
                parameters[1].Value = businTypeID;
                return DbHelperSQL.Exists(strSql.ToString(), parameters);
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(0) from SYS_Dictionary");
                strSql.Append(" where businName=@businName and businTypeID=@businTypeID and businID<>@businID");
                SqlParameter[] parameters = {
					new SqlParameter("@businName", SqlDbType.VarChar),
					new SqlParameter("@businTypeID", SqlDbType.VarChar),
                    new SqlParameter("@businID", SqlDbType.VarChar) };
                parameters[0].Value = businName;
                parameters[1].Value = businTypeID;
                parameters[2].Value = businID;
                return DbHelperSQL.Exists(strSql.ToString(), parameters);
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(IndustryPlatform.Model.SYS_DictionaryEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Dictionary(");
            strSql.Append("BusinID,BusinName,BusinTypeID,DisplayOrder,IsForbid)");
            strSql.Append(" values (");
            strSql.Append("@BusinID,@BusinName,@BusinTypeID,@DisplayOrder,@IsForbid)");
            SqlParameter[] parameters = {
					new SqlParameter("@BusinID", SqlDbType.VarChar,10),
					new SqlParameter("@BusinName", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinTypeID", SqlDbType.VarChar,10),
					new SqlParameter("@DisplayOrder", SqlDbType.Decimal,5),
					new SqlParameter("@IsForbid", SqlDbType.VarChar,1)};

            try
            {
                parameters[0].Value = model.BusinID;
                parameters[1].Value = model.BusinName;
                parameters[2].Value = model.BusinTypeID;
                parameters[3].Value = model.DisplayOrder;
                parameters[4].Value = model.IsForbid;

                if (DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(IndustryPlatform.Model.SYS_DictionaryEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Dictionary set ");
            strSql.Append("BusinName=@BusinName,");
            strSql.Append("DisplayOrder=@DisplayOrder,");
            strSql.Append("IsForbid=@IsForbid");
            strSql.Append(" where BusinID=@BusinID and BusinTypeID=@BusinTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BusinID", SqlDbType.VarChar,10),
					new SqlParameter("@BusinName", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinTypeID", SqlDbType.VarChar,10),
					new SqlParameter("@DisplayOrder", SqlDbType.Decimal,5),
					new SqlParameter("@IsForbid", SqlDbType.VarChar,1)};
            parameters[0].Value = model.BusinID;
            parameters[1].Value = model.BusinName;
            parameters[2].Value = model.BusinTypeID;
            parameters[3].Value = model.DisplayOrder;
            parameters[4].Value = model.IsForbid;

           

            try
            {
                DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                return true;
            }
            catch(Exception ex)
            { return false; }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string businID, string businTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_Dictionary ");
            strSql.Append(" where businID=@businID and businTypeID=@businTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@businID", SqlDbType.VarChar,50),
					new SqlParameter("@businTypeID", SqlDbType.VarChar,50)};
            parameters[0].Value = businID;
            parameters[1].Value = businTypeID;
            try
            {
                DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                return true;
            }
            catch
            { return false; }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public IndustryPlatform.Model.SYS_DictionaryEntity GetModel(string BusinID, string BusinTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BusinID,BusinName,BusinTypeID,DisplayOrder,IsForbid from Sys_Dictionary ");
            strSql.Append(" where BusinID=@BusinID and BusinTypeID=@BusinTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BusinID", SqlDbType.VarChar,50),
					new SqlParameter("@BusinTypeID", SqlDbType.VarChar,50)};
            parameters[0].Value = BusinID;
            parameters[1].Value = BusinTypeID;

            IndustryPlatform.Model.SYS_DictionaryEntity model = new IndustryPlatform.Model.SYS_DictionaryEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.BusinID = ds.Tables[0].Rows[0]["BusinID"].ToString();
                model.BusinName = ds.Tables[0].Rows[0]["BusinName"].ToString();
                model.BusinTypeID = ds.Tables[0].Rows[0]["BusinTypeID"].ToString();
                if (ds.Tables[0].Rows[0]["DisplayOrder"].ToString() != "")
                {
                    model.DisplayOrder = decimal.Parse(ds.Tables[0].Rows[0]["DisplayOrder"].ToString());
                }
                model.IsForbid = ds.Tables[0].Rows[0]["IsForbid"].ToString();
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
            strSql.Append("select BusinID,BusinName,BusinTypeID,DisplayOrder,IsForbid ");
            strSql.Append(" FROM Sys_Dictionary ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        
        /// <summary>
        /// 获得字典类型
        /// </summary>
        public DataSet GetDictionaryType(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select businTypeID,businTypeName from SYS_BusinType where "+strWhere+" order by businTypeID");
            try
            {
                return DbHelperSQL.Query(strSql.ToString());
            }
            catch
            { return null; }
        }
        #endregion  成员方法
    }
}

