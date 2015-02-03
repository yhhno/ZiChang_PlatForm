using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using IndustryPlatform.IDAL;
using IndustryPlatform.DBUtility;
using System.Web;//请先添加引用
namespace IndustryPlatform.SQLServerDAL
{
    /// <summary>
    /// 数据访问类Sys_Colliery。
    /// </summary>
    public class Sys_Colliery : ISys_Colliery
    {
        public Sys_Colliery()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string  strCollCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Colliery");
            strSql.Append(" where CollCode=@CollCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@CollCode", SqlDbType.VarChar)};
            parameters[0].Value = strCollCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        public bool Add(IndustryPlatform.Model.Sys_Colliery coll, List<IndustryPlatform.Model.Sys_FileSave> listModel)
        {
            try
            {
                lock (this)
                {
                    StringBuilder strSql = new StringBuilder();
                    List<string> listSql = new List<string>();
                    List<SqlParameter[]> listParm = new List<SqlParameter[]>();
                   
                    strSql.Append("insert into Sys_Colliery(");
                    strSql.Append("CollCode,CollName,OrgCode,VillageCode,MineOwner,MinePhone,YearOutput,CollState,ImageLicence,ImageRevenue,ImageCompetency,Remark,IsForbid,CollProperty,ParcelCode)");
                    strSql.Append(" values (");
                    strSql.Append("@CollCode,@CollName,@OrgCode,@VillageCode,@MineOwner,@MinePhone,@YearOutput,@CollState,@ImageLicence,@ImageRevenue,@ImageCompetency,@Remark,@IsForbid,@CollProperty,@ParcelCode)");
                    SqlParameter[] parameters = {
					
					new SqlParameter("@CollCode", SqlDbType.VarChar,20),
					new SqlParameter("@CollName", SqlDbType.VarChar,50),
					new SqlParameter("@OrgCode", SqlDbType.VarChar,10),
					new SqlParameter("@VillageCode", SqlDbType.VarChar,4),
					new SqlParameter("@MineOwner", SqlDbType.VarChar,20),
					new SqlParameter("@MinePhone", SqlDbType.VarChar,30),
					new SqlParameter("@YearOutput", SqlDbType.Decimal,9),
					new SqlParameter("@CollState", SqlDbType.VarChar,10),
					new SqlParameter("@ImageLicence", SqlDbType.VarChar,32),
					new SqlParameter("@ImageRevenue", SqlDbType.VarChar,32),
					new SqlParameter("@ImageCompetency", SqlDbType.VarChar,32),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@IsForbid", SqlDbType.VarChar,1),
                    new SqlParameter("@CollProperty",SqlDbType.VarChar,1),
                    new SqlParameter("@ParcelCode",SqlDbType.VarChar,10)};
                   
                    parameters[0].Value = coll.CollCode;
                    parameters[1].Value = coll.CollName;
                    parameters[2].Value = coll.OrgCode;
                    parameters[3].Value = coll.VillageCode;
                    parameters[4].Value = coll.MineOwner;
                    parameters[5].Value = coll.MinePhone;
                    parameters[6].Value = coll.YearOutput;
                    parameters[7].Value = coll.CollState;
                    parameters[8].Value = coll.ImageLicence;
                    parameters[9].Value = coll.ImageRevenue;
                    parameters[10].Value = coll.ImageCompetency;
                    parameters[11].Value = coll.Remark;
                    parameters[12].Value = coll.IsForbid;
                    parameters[13].Value = coll.CollProperty;//煤矿属性
                    parameters[14].Value = coll.ParcelCode;
                    listSql.Add(strSql.ToString());
                    listParm.Add(parameters);

                    //保存煤矿最低余额
                    strSql = new StringBuilder();
                    strSql.Append("insert into TT_ColieryAccount(CollCode) values (@CollCode)");
                    SqlParameter[] parameters3 = {
					new SqlParameter("@CollCode", SqlDbType.VarChar,10)};
                    parameters3[0].Value = coll.CollCode;
                    listSql.Add(strSql.ToString());
                    listParm.Add(parameters3);

                    foreach (IndustryPlatform.Model.Sys_FileSave model in listModel)
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into Sys_FileSave(");
                        strSql.Append("FileCode,FileName,FilePath,FileSize,FileType,FileContent)");
                        strSql.Append(" values (");
                        strSql.Append("@FileCode,@FileName,@FilePath,@FileSize,@FileType,@FileContent)");
                        SqlParameter[] parameters2 = {
					    new SqlParameter("@FileCode", SqlDbType.VarChar,32),
					    new SqlParameter("@FileName", SqlDbType.VarChar,50),
					    new SqlParameter("@FilePath", SqlDbType.VarChar,200),
					    new SqlParameter("@FileSize", SqlDbType.Decimal,9),
					    new SqlParameter("@FileType", SqlDbType.VarChar,50),
					    new SqlParameter("@FileContent", SqlDbType.VarBinary)
					   };
                        parameters2[0].Value = model.FileCode;
                        parameters2[1].Value = model.FileName;
                        parameters2[2].Value = model.FilePath;
                        parameters2[3].Value = model.FileSize;
                        parameters2[4].Value = model.FileType;
                        parameters2[5].Value = model.FileContent;

                        listSql.Add(strSql.ToString());
                        listParm.Add(parameters2);

                    }
                    return DbHelperSQL.ExecuteSqlCake(listSql, listParm);
                }
            }
            catch
            {
                return false;
            }
        }



        public bool update(IndustryPlatform.Model.Sys_Colliery coll, List<IndustryPlatform.Model.Sys_FileSave> listModel)
        {
            try
            {
                lock (this)
                {
                    StringBuilder strSql = new StringBuilder();
                    List<string> listSql = new List<string>();
                    List<SqlParameter[]> listParm = new List<SqlParameter[]>();
                    strSql = new StringBuilder();
                    strSql.Append("update Sys_Colliery set ");
                    strSql.Append("CollName=@CollName,");
                    strSql.Append("OrgCode=@OrgCode,");
                    strSql.Append("VillageCode=@VillageCode,");
                    strSql.Append("MineOwner=@MineOwner,");
                    strSql.Append("MinePhone=@MinePhone,");
                    strSql.Append("YearOutput=@YearOutput,");
                    strSql.Append("CollState=@CollState,");
                    strSql.Append("ImageLicence=@ImageLicence,");
                    strSql.Append("ImageRevenue=@ImageRevenue,");
                    strSql.Append("ImageCompetency=@ImageCompetency,");
                    strSql.Append("Remark=@Remark,");
                    strSql.Append("IsForbid=@IsForbid,");
                    strSql.Append("CollProperty=@CollProperty,");
                    strSql.Append("ParcelCode=@ParcelCode");
                    strSql.Append(" where CollCode=@CollCode ");
                    SqlParameter[] parameters = {
					new SqlParameter("@CollCode", SqlDbType.VarChar,20),
					new SqlParameter("@CollName", SqlDbType.VarChar,50),
					new SqlParameter("@OrgCode", SqlDbType.VarChar,10),
					new SqlParameter("@VillageCode", SqlDbType.VarChar,4),
					new SqlParameter("@MineOwner", SqlDbType.VarChar,20),
					new SqlParameter("@MinePhone", SqlDbType.VarChar,30),
					new SqlParameter("@YearOutput", SqlDbType.Decimal,9),
					new SqlParameter("@CollState", SqlDbType.VarChar,10),
					new SqlParameter("@ImageLicence", SqlDbType.VarChar,32),
					new SqlParameter("@ImageRevenue", SqlDbType.VarChar,32),
					new SqlParameter("@ImageCompetency", SqlDbType.VarChar,32),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@IsForbid", SqlDbType.VarChar,1),
                    new SqlParameter("@CollProperty",SqlDbType.VarChar,1),
                    new SqlParameter("@ParcelCode",SqlDbType.VarChar,10)};
                   
                    parameters[0].Value = coll.CollCode;
                    parameters[1].Value = coll.CollName;
                    parameters[2].Value = coll.OrgCode;
                    parameters[3].Value = coll.VillageCode;
                    parameters[4].Value = coll.MineOwner;
                    parameters[5].Value = coll.MinePhone;
                    parameters[6].Value = coll.YearOutput;
                    parameters[7].Value = coll.CollState;
                    parameters[8].Value = coll.ImageLicence;
                    parameters[9].Value = coll.ImageRevenue;
                    parameters[10].Value = coll.ImageCompetency;
                    parameters[11].Value = coll.Remark;
                    parameters[12].Value = coll.IsForbid;
                    parameters[13].Value = coll.CollProperty;//煤矿属性
                    parameters[14].Value = coll.ParcelCode;

                    listSql.Add(strSql.ToString());
                    listParm.Add(parameters);

                    foreach (IndustryPlatform.Model.Sys_FileSave model in listModel)
                    {
                        strSql = new StringBuilder();

                        if ("0" != Getresult("count(*)", "Sys_FileSave", "FileCode='" + model.FileCode + "'"))
                        {
                            strSql.Append("update Sys_FileSave set ");
                            strSql.Append("FileName=@FileName,");
                            strSql.Append("FilePath=@FilePath,");
                            strSql.Append("FileSize=@FileSize,");
                            strSql.Append("FileType=@FileType,");
                            strSql.Append("FileContent=@FileContent");
                            strSql.Append(" where FileCode=@FileCode ");
                            SqlParameter[] parameters2 = {
					            new SqlParameter("@FileCode", SqlDbType.VarChar,32),
					            new SqlParameter("@FileName", SqlDbType.VarChar,50),
					            new SqlParameter("@FilePath", SqlDbType.VarChar,200),
					            new SqlParameter("@FileSize", SqlDbType.Decimal,9),
					            new SqlParameter("@FileType", SqlDbType.VarChar,32),
					            new SqlParameter("@FileContent", SqlDbType.VarBinary)
					            };
                            parameters2[0].Value = model.FileCode;
                            parameters2[1].Value = model.FileName;
                            parameters2[2].Value = model.FilePath;
                            parameters2[3].Value = model.FileSize;
                            parameters2[4].Value = model.FileType;
                            parameters2[5].Value = model.FileContent;
                            listSql.Add(strSql.ToString());
                            listParm.Add(parameters2);

                        }
                        else
                        {
                            strSql.Append("insert into Sys_FileSave(");
                            strSql.Append("FileCode,FileName,FilePath,FileSize,FileType,FileContent)");
                            strSql.Append(" values (");
                            strSql.Append("@FileCode,@FileName,@FilePath,@FileSize,@FileType,@FileContent)");
                            SqlParameter[] parameters2 = {
					        new SqlParameter("@FileCode", SqlDbType.VarChar,32),
					        new SqlParameter("@FileName", SqlDbType.VarChar,50),
					        new SqlParameter("@FilePath", SqlDbType.VarChar,200),
					        new SqlParameter("@FileSize", SqlDbType.Decimal,9),
					        new SqlParameter("@FileType", SqlDbType.VarChar,32),
					        new SqlParameter("@FileContent", SqlDbType.VarBinary)
                                                         };

                            parameters2[0].Value = model.FileCode;
                            parameters2[1].Value = model.FileName;
                            parameters2[2].Value = model.FilePath;
                            parameters2[3].Value = model.FileSize;
                            parameters2[4].Value = model.FileType;
                            parameters2[5].Value = model.FileContent;
                            listSql.Add(strSql.ToString());
                            listParm.Add(parameters2);

                        }
                    }

                    return DbHelperSQL.ExecuteSqlCake(listSql, listParm);
                }
            }
            catch
            {
                return false;
            }
        }






        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(IndustryPlatform.Model.Sys_Colliery model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Colliery(");
            strSql.Append("CollieryID,CollCode,CollName,OrgCode,VillageCode,MineOwner,MinePhone,YearOutput,CollState,ImageLicence,LicenceImageType,ImageRevenue,RevenueImageType,ImageCompetency,CompetencyImageType,Remark,IsForbid,CollProperty)");
            strSql.Append(" values (");
            strSql.Append("@CollCode,@CollName,@OrgCode,@VillageCode,@MineOwner,@MinePhone,@YearOutput,@CollState,@ImageLicence,@ImageRevenue,@ImageCompetency,@Remark,@IsForbid,@CollProperty)");
            SqlParameter[] parameters = {
					
					new SqlParameter("@CollCode", SqlDbType.VarChar,20),
					new SqlParameter("@CollName", SqlDbType.VarChar,50),
					new SqlParameter("@OrgCode", SqlDbType.Decimal,9),
					new SqlParameter("@VillageCode", SqlDbType.VarChar,4),
					new SqlParameter("@MineOwner", SqlDbType.VarChar,20),
					new SqlParameter("@MinePhone", SqlDbType.VarChar,30),
					new SqlParameter("@YearOutput", SqlDbType.Decimal,9),
					new SqlParameter("@CollState", SqlDbType.VarChar,10),
					new SqlParameter("@ImageLicence", SqlDbType.VarChar,32),
					new SqlParameter("@ImageRevenue", SqlDbType.VarChar,32),
					new SqlParameter("@ImageCompetency", SqlDbType.VarChar,32),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@IsForbid", SqlDbType.VarChar,1),
                    new SqlParameter("@CollProperty",SqlDbType.VarChar,1)};
           
            parameters[0].Value = model.CollCode;
            parameters[1].Value = model.CollName;
            parameters[2].Value = model.OrgCode;
            parameters[3].Value = model.VillageCode;
            parameters[4].Value = model.MineOwner;
            parameters[5].Value = model.MinePhone;
            parameters[6].Value = model.YearOutput;
            parameters[7].Value = model.CollState;
            parameters[8].Value = model.ImageLicence;
           
            parameters[9].Value = model.ImageRevenue;
            
            parameters[10].Value = model.ImageCompetency;
            
            parameters[11].Value = model.Remark;
            parameters[12].Value = model.IsForbid;
            parameters[13].Value = model.CollProperty;//煤矿属性
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(IndustryPlatform.Model.Sys_Colliery model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Colliery set ");
          
            strSql.Append("CollName=@CollName,");
            strSql.Append("OrgCode=@OrgCode,");
            strSql.Append("VillageCode=@VillageCode,");
            strSql.Append("MineOwner=@MineOwner,");
            strSql.Append("MinePhone=@MinePhone,");
            strSql.Append("YearOutput=@YearOutput,");
            strSql.Append("CollState=@CollState,");
            strSql.Append("ImageLicence=@ImageLicence,");
            strSql.Append("ImageRevenue=@ImageRevenue,");
            strSql.Append("ImageCompetency=@ImageCompetency,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("IsForbid=@IsForbid,");
            strSql.Append("CollProperty=@CollProperty");//煤矿属性
            strSql.Append(" where CollCode=@CollCode ");
            SqlParameter[] parameters = {
                  
                    new SqlParameter("@CollCode", SqlDbType.VarChar,20),
                    new SqlParameter("@CollName", SqlDbType.VarChar,50),
                    new SqlParameter("@OrgCode", SqlDbType.Decimal,9),
                    new SqlParameter("@VillageCode", SqlDbType.VarChar,4),
                    new SqlParameter("@MineOwner", SqlDbType.VarChar,20),
                    new SqlParameter("@MinePhone", SqlDbType.VarChar,30),
                    new SqlParameter("@YearOutput", SqlDbType.Decimal,9),
                    new SqlParameter("@CollState", SqlDbType.VarChar,10),
                    new SqlParameter("@ImageLicence", SqlDbType.VarChar,32),
                    new SqlParameter("@LicenceImageType", SqlDbType.VarChar,10),
                    new SqlParameter("@ImageRevenue", SqlDbType.VarChar,32),
                    new SqlParameter("@RevenueImageType", SqlDbType.VarChar,10),
                    new SqlParameter("@ImageCompetency", SqlDbType.VarChar,32),
                    new SqlParameter("@CompetencyImageType", SqlDbType.VarChar,10),
                    new SqlParameter("@Remark", SqlDbType.VarChar,200),
                    new SqlParameter("@IsForbid", SqlDbType.VarChar,1),
                    new SqlParameter("@CollProperty",SqlDbType.VarChar,1)};
           
            parameters[0].Value = model.CollCode;
            parameters[1].Value = model.CollName;
            parameters[2].Value = model.OrgCode;
            parameters[3].Value = model.VillageCode;
            parameters[4].Value = model.MineOwner;
            parameters[5].Value = model.MinePhone;
            parameters[6].Value = model.YearOutput;
            parameters[7].Value = model.CollState;
            parameters[8].Value = model.ImageLicence;
            parameters[9].Value = model.ImageRevenue;
            parameters[10].Value = model.ImageCompetency;
            parameters[11].Value = model.Remark;
            parameters[12].Value = model.IsForbid;
            parameters[13].Value = model.CollProperty;//煤矿属性

          

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(string strCollCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Sys_Colliery ");
            strSql.Append(" where CollCode  in (" + strCollCode + ") ");
          
            try
            {
                DbHelperSQL.ExecuteSql(strSql.ToString());
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 禁用或者解禁一条或多条记录
        /// </summary>
        /// <param name="CoalKindCode">煤种编码</param>
        /// <param name="strValue">是否禁用值</param>
        /// <returns></returns>
        public int Forbid(string strCollID, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Colliery  set IsForbid=" + strValue + "");
            strSql.Append(" where CollCode in (" + strCollID + ") ");
            try
            {
                DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public IndustryPlatform.Model.Sys_Colliery GetModel(string CollCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CollCode,CollName,OrgCode,VillageCode,MineOwner,MinePhone,YearOutput,CollState,ImageLicence,ImageRevenue,ImageCompetency,Remark,IsForbid,CollProperty,ParcelCode from Sys_Colliery ");
            strSql.Append(" where CollCode=@CollCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@CollCode", SqlDbType.NVarChar)};
            parameters[0].Value = CollCode;

            IndustryPlatform.Model.Sys_Colliery model = new IndustryPlatform.Model.Sys_Colliery();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
               
                model.CollCode = ds.Tables[0].Rows[0]["CollCode"].ToString();
                model.CollName = ds.Tables[0].Rows[0]["CollName"].ToString();
                if (ds.Tables[0].Rows[0]["OrgCode"].ToString() != "")
                {
                    model.OrgCode = ds.Tables[0].Rows[0]["OrgCode"].ToString();
                }
                model.VillageCode = ds.Tables[0].Rows[0]["VillageCode"].ToString();
                model.MineOwner = ds.Tables[0].Rows[0]["MineOwner"].ToString();
                model.MinePhone = ds.Tables[0].Rows[0]["MinePhone"].ToString();
                if (ds.Tables[0].Rows[0]["YearOutput"].ToString() != "")
                {
                    model.YearOutput = decimal.Parse(ds.Tables[0].Rows[0]["YearOutput"].ToString());
                }
                model.CollState = ds.Tables[0].Rows[0]["CollState"].ToString();
                if (ds.Tables[0].Rows[0]["ImageLicence"].ToString() != "")
                {
                    model.ImageLicence = ds.Tables[0].Rows[0]["ImageLicence"].ToString();
                }
               
                if (ds.Tables[0].Rows[0]["ImageRevenue"].ToString() != "")
                {
                    model.ImageRevenue = ds.Tables[0].Rows[0]["ImageRevenue"].ToString();
                }
               
                if (ds.Tables[0].Rows[0]["ImageCompetency"].ToString() != "")
                {
                    model.ImageCompetency =ds.Tables[0].Rows[0]["ImageCompetency"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CollProperty"].ToString() != "")
                {
                    model.CollProperty = ds.Tables[0].Rows[0]["CollProperty"].ToString();
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                model.IsForbid = ds.Tables[0].Rows[0]["IsForbid"].ToString();
                model.ParcelCode = ds.Tables[0].Rows[0]["ParcelCode"].ToString();
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
            strSql.Append("select CollCode,CollName,OrgCode,VillageCode,MineOwner,MinePhone,YearOutput,CollState,ImageLicence,ImageRevenue,ImageCompetency,Remark,IsForbid,CollProperty,ParcelCode ");
            strSql.Append(" FROM Sys_Colliery ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strTable, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *   ");
            strSql.Append(" FROM  " + strTable + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



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
        public void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager,string strCollCode,string strCollName, string strWhere, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl)
        {
            StringBuilder strSql = new StringBuilder();
            DataSet dstTemp = new DataSet();

            strSql.Append("select * from (select row_number() over (order by " + strOrderCondition + ") as rowno,*  from VSYS_Colliery where CollCode like @CollCode and CollName like @CollName ");
            strSql.Append(strWhere);
            strSql.Append(" ) as result Where (rowno Between " + ((anpager.CurrentPageIndex - 1) * anpager.PageSize+1) + " and " + anpager.CurrentPageIndex * anpager.PageSize + ")");

            strCollCode = "%" + strCollCode + "%";
            strCollName = "%" + strCollName + "%";

            SqlParameter[] parameters = { new SqlParameter("@CollCode", strCollCode), new SqlParameter("@CollName", strCollName) };
            parameters[0].Value = strCollCode;
            parameters[1].Value = strCollName;



            StringBuilder strb = new StringBuilder();

            strb.Append("Select Count(*) From  VSYS_Colliery where CollCode like @CollCode and CollName like @CollName  ");
            strb.Append(strWhere);

            anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle(strb.ToString(), parameters));
            dstTemp = DbHelperSQL.Query(strSql.ToString(), parameters);



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


        #region  通过条件，得到数据
        public string Getresult(string strFieldName, string strTableName, string strWhere)
        {
            string strsql = "select " + strFieldName + "  from " + strTableName + " where " + strWhere;
            object obj = DbHelperSQL.GetSingle(strsql);
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }
        #endregion


        public int SetColieryLowAccount(string strLowAccount, string strCollieryID)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(0) from TT_ColieryAccount");
                strSql.Append(" where CollCode=@CollCode ");
                SqlParameter[] parameters = {
					new SqlParameter("@CollCode", SqlDbType.Char,20)};
                parameters[0].Value = strCollieryID;

                bool exi = DbHelperSQL.Exists(strSql.ToString(), parameters);
                string str = "";
                if (exi)
                    str = "update TT_ColieryAccount set lowACCOUNT=" + strLowAccount + " where CollCode=" + strCollieryID + " ";
                else
                    str = "insert into TT_ColieryAccount (CollCode,lowACCOUNT) values (" + strCollieryID + "," + strLowAccount + ")";

                DbHelperSQL.ExecuteSql(str);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        #region 设置煤矿最低金额
        public int AddColieryAccount(string strCollieryID, string strlowACCOUNT)
        {
            List<string> listSql = new List<string>();
            List<SqlParameter[]> listParm = new List<SqlParameter[]>();

            string strsql = "insert into TT_ColieryAccount (CollCode,lowACCOUNT) values (" + strCollieryID + "," + strlowACCOUNT + ")";
            listSql.Add(strsql);
            listParm.Add(null);

            if (System.Configuration.ConfigurationManager.AppSettings["IsAddLog"] == "1")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sys_OperateLog(");
                strSql.Append("LogID,LogType,OperateTable,Operator,OperateDate,OperateIP,RelationID,Remark)");
                strSql.Append(" values (");
                strSql.Append("@LogID,@LogType,@OperateTable,@Operator,CONVERT(varchar,getdate(),120),@OperateIP,@RelationID,@Remark)");
                SqlParameter[] parameters1 = {
					new SqlParameter("@LogID", SqlDbType.VarChar,32),
					new SqlParameter("@LogType", SqlDbType.NVarChar,18),
					new SqlParameter("@OperateTable", SqlDbType.VarChar,32),
					new SqlParameter("@Operator", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateIP", SqlDbType.Char,18),
                    new SqlParameter("@RelationID", SqlDbType.Char,32),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
                parameters1[0].Value = Guid.NewGuid().ToString().Replace("-", "");
                parameters1[1].Value = "煤矿最低余额设置";
                parameters1[2].Value = "TT_ColieryAccount";
                parameters1[3].Value = CookieManager.GetCookieValue("UserName");
                parameters1[4].Value = HttpContext.Current.Request.UserHostAddress; ;
                parameters1[5].Value = strCollieryID.ToString();
                parameters1[6].Value = "将煤矿最低余额设置为：" + strlowACCOUNT;
                listSql.Add(strSql.ToString());
                listParm.Add(parameters1);
            }

            return DbHelperSQL.ExecuteSqlCake(listSql, listParm) == true ? 1 : 0;
        }

        public int UpdateColieryAccount(string strCollieryID, string strlowACCOUNT)
        {
            List<string> listSql = new List<string>();
            List<SqlParameter[]> listParm = new List<SqlParameter[]>();
            string strsql = "update TT_ColieryAccount set  lowACCOUNT=" + strlowACCOUNT + " where    CollCode=" + strCollieryID + " ";
            listSql.Add(strsql);
            listParm.Add(null);

            if (System.Configuration.ConfigurationManager.AppSettings["IsAddLog"] == "1")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Sys_OperateLog(");
                strSql.Append("LogID,LogType,OperateTable,Operator,OperateDate,OperateIP,RelationID,Remark)");
                strSql.Append(" values (");
                strSql.Append("@LogID,@LogType,@OperateTable,@Operator,CONVERT(varchar,getdate(),120),@OperateIP,@RelationID,@Remark)");
                SqlParameter[] parameters1 = {
					new SqlParameter("@LogID", SqlDbType.VarChar,32),
					new SqlParameter("@LogType", SqlDbType.NVarChar,18),
					new SqlParameter("@OperateTable", SqlDbType.VarChar,32),
					new SqlParameter("@Operator", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateIP", SqlDbType.Char,18),
                    new SqlParameter("@RelationID", SqlDbType.Char,32),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
                parameters1[0].Value = Guid.NewGuid().ToString().Replace("-", "");
                parameters1[1].Value = "设置账户最低余额";
                parameters1[2].Value = "TT_ColieryAccount";
                parameters1[3].Value = CookieManager.GetCookieValue("UserName");
                parameters1[4].Value = HttpContext.Current.Request.UserHostAddress; ;
                parameters1[5].Value = strCollieryID.ToString();
                parameters1[6].Value = "将煤矿最低余额设置为：" + strlowACCOUNT;
                listSql.Add(strSql.ToString());
                listParm.Add(parameters1);
            }
            return DbHelperSQL.ExecuteSqlCake(listSql, listParm) == true ? 1 : 0;
        }

        #endregion



        

        #region 设置煤矿煤种
        public bool SetCollRunCoalKind(string strCollieryID, List<string> list)
        {
            try
            {
                List<string> listSql = new List<string>();
                List<SqlParameter[]> listParm = new List<SqlParameter[]>();
                listSql.Add("delete TT_CollRunCoalKind where CollCode=" + strCollieryID);
                listParm.Add(null);
                foreach (string strKindCode in list)
                {
                    listSql.Add("insert into TT_CollRunCoalKind(CollCode,CoalKindCode) values(" + strCollieryID + "," + strKindCode + ")");
                    listParm.Add(null);
                }

                if (System.Configuration.ConfigurationManager.AppSettings["IsAddLog"] == "1")
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into Sys_OperateLog(");
                    strSql.Append("LogID,LogType,OperateTable,Operator,OperateDate,OperateIP,RelationID,Remark)");
                    strSql.Append(" values (");
                    strSql.Append("@LogID,@LogType,@OperateTable,@Operator,CONVERT(varchar,getdate(),120),@OperateIP,@RelationID,@Remark)");
                    SqlParameter[] parameters1 = {
					new SqlParameter("@LogID", SqlDbType.VarChar,32),
					new SqlParameter("@LogType", SqlDbType.NVarChar,18),
					new SqlParameter("@OperateTable", SqlDbType.VarChar,32),
					new SqlParameter("@Operator", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateIP", SqlDbType.Char,18),
                    new SqlParameter("@RelationID", SqlDbType.Char,32),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
                    parameters1[0].Value = Guid.NewGuid().ToString().Replace("-", "");
                    parameters1[1].Value = "设置煤矿经营煤种";
                    parameters1[2].Value = "TT_CollRunCoalKind";
                    parameters1[3].Value = Convert.ToDecimal(CookieManager.GetCookieValue("uid"));
                    parameters1[4].Value = HttpContext.Current.Request.UserHostAddress; ;
                    parameters1[5].Value = strCollieryID.ToString();
                    parameters1[6].Value = "";
                    listSql.Add(strSql.ToString());
                    listParm.Add(parameters1);
                }

                return DbHelperSQL.ExecuteSqlCake(listSql, listParm);
            }
            catch
            {
                return false;
            }
        
        }

        #endregion


        /// <summary>
        /// 获取所有的煤矿账户信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetColieryAccount(string strWhere)
        {
            string strSql = "select * from TT_ColieryAccount where " + strWhere;
            return DbHelperSQL.TQuery(strSql);
        }


        #endregion  成员方法
    }
} 

