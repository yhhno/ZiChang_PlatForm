/*----------------------------------------------------------------
// Copyright (C) 2009 北京天大天科科技有限公司技术研发部
// 版权所有。 
// 文件名：
// 文件功能描述：系统菜单数据库交互类
// 
// 创建标识：2009年7月6日 宋华鑫
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;
using IndustryPlatform.Model;
using IndustryPlatform.DBUtility;
using IndustryPlatform.IDAL;
using System.Data.SqlClient;
using System.Data;

namespace IndustryPlatform.SQLServerDAL
{
    public class SYS_Menu : ISYS_Menu
    {
        public SYS_Menu() { }

        /// <summary>
        /// 是否存在特定的菜单项
        /// </summary>
        /// <param name="sMenuID">菜单编号</param>
        public bool Exists(string menuID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(*) from SYS_MENU");
            sb.Append(" where menuID=@menuID");

            SqlParameter[] parameters ={
                                      new SqlParameter("@menuID",menuID)
                                      };

            return DbHelperSQL.Exists(sb.ToString(), parameters);
        }

        /// <summary>
        /// 添加一项菜单
        /// </summary>
        /// <param name="menu">菜单实体</param>
        /// <returns>1:添加成功；0：添加失败</returns>
        public int Add(SYS_MenuEntity model)
        {
     
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Menu(");
            strSql.Append("MenuID,MenuName,MenuUrl,FunctionID,IsLeaf,MenuLevel,RootID,ParentsID,DisplayOrder,IcValue,IsPop,MenuSeq)");
            strSql.Append(" values (");
            strSql.Append("@MenuID,@MenuName,@MenuUrl,@FunctionID,@IsLeaf,@MenuLevel,@RootID,@ParentsID,@DisplayOrder,@IcValue,@IsPop,@MenuSeq)");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.NVarChar,20),
					new SqlParameter("@MenuName", SqlDbType.NVarChar,50),
					new SqlParameter("@MenuUrl", SqlDbType.VarChar,300),
					new SqlParameter("@FunctionID", SqlDbType.NVarChar,100),
					new SqlParameter("@IsLeaf", SqlDbType.VarChar,1),
					new SqlParameter("@MenuLevel", SqlDbType.VarChar,1),
					new SqlParameter("@RootID", SqlDbType.VarChar,32),
					new SqlParameter("@ParentsID", SqlDbType.VarChar,32),
					new SqlParameter("@DisplayOrder", SqlDbType.Decimal,5),
					new SqlParameter("@IcValue", SqlDbType.VarChar,200),
					new SqlParameter("@IsPop", SqlDbType.VarChar,1),
					new SqlParameter("@MenuSeq", SqlDbType.VarChar,300)};
            parameters[0].Value = model.MenuID;
            parameters[1].Value = model.MenuName;
            parameters[2].Value = model.MenuUrl;
            parameters[3].Value = model.FunctionID;
            parameters[4].Value = model.IsLeaf;
            parameters[5].Value = model.MenuLevel;
            parameters[6].Value = model.RootID;
            parameters[7].Value = model.ParentsID;
            parameters[8].Value = model.DisplayOrder;
            parameters[9].Value = model.IcValue;
            parameters[10].Value = model.IsPop;
            parameters[11].Value = model.MenuSeq;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一项菜单
        /// </summary>
        /// <param name="menu">菜单实体</param>
        /// <returns>1:添加成功；0：添加失败</returns>
        public int Update(SYS_MenuEntity menu)
        {
            try
            {
                string originalMenuSEQ = GetParentSEQ(menu.MenuID).TrimEnd(menu.MenuID.ToCharArray());

                #region Update the menuSEQ
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("update SYS_MENU set menuSEQ='{0}'", menu.MenuID.TrimEnd(menu.MenuID.ToCharArray()));
                sb.AppendFormat("+replace(menuSEQ,'{0}','')", originalMenuSEQ);
                sb.AppendFormat(" where menuSEQ like '{0}%'", originalMenuSEQ + menu.MenuID);

                DbHelperSQL.ExecuteSql(sb.ToString());
                #endregion Update the menuSEQ

                StringBuilder sbLevel = new StringBuilder();
                sbLevel.Append("update SYS_MENU set menuLevel = len(menuSEQ)-len(replace(menuSEQ,'.' , ''))");
                sbLevel.AppendFormat(" where menuSEQ like '{0}%'", originalMenuSEQ + menu.MenuID);

                DbHelperSQL.ExecuteSql(sbLevel.ToString());



                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Sys_Menu set ");
                strSql.Append("MenuName=@MenuName,");
                strSql.Append("MenuUrl=@MenuUrl,");
                strSql.Append("FunctionID=@FunctionID,");
                strSql.Append("IsLeaf=@IsLeaf,");
                strSql.Append("MenuLevel=@MenuLevel,");
                strSql.Append("RootID=@RootID,");
                strSql.Append("ParentsID=@ParentsID,");
                strSql.Append("DisplayOrder=@DisplayOrder,");
                strSql.Append("IcValue=@IcValue,");
                strSql.Append("IsPop=@IsPop,");
                strSql.Append("MenuSeq=@MenuSeq");
                strSql.Append(" where MenuID=@MenuID ");
                SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.NVarChar,20),
					new SqlParameter("@MenuName", SqlDbType.NVarChar,50),
					new SqlParameter("@MenuUrl", SqlDbType.VarChar,300),
					new SqlParameter("@FunctionID", SqlDbType.NVarChar,100),
					new SqlParameter("@IsLeaf", SqlDbType.VarChar,1),
					new SqlParameter("@MenuLevel", SqlDbType.VarChar,1),
					new SqlParameter("@RootID", SqlDbType.VarChar,32),
					new SqlParameter("@ParentsID", SqlDbType.VarChar,32),
					new SqlParameter("@DisplayOrder", SqlDbType.Decimal,5),
					new SqlParameter("@IcValue", SqlDbType.VarChar,200),
					new SqlParameter("@IsPop", SqlDbType.VarChar,1),
					new SqlParameter("@MenuSeq", SqlDbType.VarChar,300)};
                parameters[0].Value = menu.MenuID;
                parameters[1].Value = menu.MenuName;
                parameters[2].Value = menu.MenuUrl;
                parameters[3].Value = menu.FunctionID;
                parameters[4].Value = menu.IsLeaf;
                parameters[5].Value = menu.MenuLevel;
                parameters[6].Value = menu.RootID;
                parameters[7].Value = menu.ParentsID;
                parameters[8].Value = menu.DisplayOrder;
                parameters[9].Value = menu.IcValue;
                parameters[10].Value = menu.IsPop;
                parameters[11].Value = menu.MenuSeq;

                DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除一项菜单
        /// </summary>
        /// <param name="menuID">菜单编号</param>
        /// <returns>:添加成功；0：添加失败</returns>
        public int Delete(string menuID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from SYS_MENU where menuID=@menuID");

            SqlParameter[] parameters ={
               new SqlParameter("@menuID",menuID)
                                      };

            return DbHelperSQL.ExecuteSql(sb.ToString(), parameters);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere">查询条件不带where</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * ");
         
            sb.Append(" from SYS_MENU");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sb.AppendFormat(" where {0}", strWhere);
            }

            return DbHelperSQL.DQuery(sb.ToString());
        }

        /// <summary>
        /// 由菜单项编号获取该菜单项实体
        /// </summary>
        /// <param name="menuID">菜单项编号</param>
        /// <returns>菜单项实体；如果不存在该菜单项返回NULL</returns>
        public SYS_MenuEntity GetModel(string MenuID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1* from Sys_Menu ");
            strSql.Append(" where MenuID=@MenuID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.NVarChar,50)};
            parameters[0].Value = MenuID;

            IndustryPlatform.Model.SYS_MenuEntity model = new IndustryPlatform.Model.SYS_MenuEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.MenuID = ds.Tables[0].Rows[0]["MenuID"].ToString();
                model.MenuName = ds.Tables[0].Rows[0]["MenuName"].ToString();
                model.MenuUrl = ds.Tables[0].Rows[0]["MenuUrl"].ToString();
                model.FunctionID = ds.Tables[0].Rows[0]["FunctionID"].ToString();
                model.IsLeaf = ds.Tables[0].Rows[0]["IsLeaf"].ToString();
                model.MenuLevel = ds.Tables[0].Rows[0]["MenuLevel"].ToString();
                model.RootID = ds.Tables[0].Rows[0]["RootID"].ToString();
                model.ParentsID = ds.Tables[0].Rows[0]["ParentsID"].ToString();
                if (ds.Tables[0].Rows[0]["DisplayOrder"].ToString() != "")
                {
                    model.DisplayOrder = decimal.Parse(ds.Tables[0].Rows[0]["DisplayOrder"].ToString());
                }
                model.IcValue = ds.Tables[0].Rows[0]["IcValue"].ToString();
                model.IsPop = ds.Tables[0].Rows[0]["IsPop"].ToString();
                model.MenuSeq = ds.Tables[0].Rows[0]["MenuSeq"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取某个父菜单项下的所有子菜单项
        /// </summary>
        /// <param name="parentID">父菜单项编号</param>
        /// <returns>DataSet</returns>
        public DataSet GetChildrenByParentID(string parentID)
        {
            #region querystring
            StringBuilder sb = new StringBuilder();
            sb.Append("select ");
            sb.Append("menuID,");
            sb.Append("menuName,");
            sb.Append("isLeaf");
            sb.Append(" from SYS_MENU");
            sb.Append(" where ");
            sb.Append("parentsID=@parentsID order by displayOrder");
            #endregion querystring

            SqlParameter[] parameters = { 
               new SqlParameter("@parentsID",parentID)                         
                                        };

            return DbHelperSQL.Query(sb.ToString(), parameters);
        }

        /// <summary>
        /// 获取菜单的所有根菜单项
        /// </summary>
        /// <param name="PositionCode">职位编号</param>
        /// <returns>DataSet</returns>
        public DataSet GetRootMenuItems(List<int> PositionCode)
        {
            //职位编号集合
            string ids = string.Empty;
            foreach (int id in PositionCode)
            {
                ids += id.ToString() + ",";
            }
            ids = ids.TrimEnd(",".ToCharArray());

            #region querystring
            StringBuilder sb = new StringBuilder();
           
            //if (ids != "0")
            //{
            //    sb.Append("select distinct ");
            //    sb.Append("m.menuName,");
            //    sb.Append("m.menuID");
            //    sb.Append(" from SYS_MENU as m");
            //    sb.Append(" inner join ");
            //    sb.Append("SYS_menuPosition as mp");
            //    sb.Append(" on m.menuID=mp.menuID ");
            //    sb.Append("where m.menuLevel='0' and ");
            //    sb.AppendFormat("mp.PositionCode in ({0})", ids);
            //}
            //else
            //{
            //    sb.Append("select menuName,menuID from SYS_MENU where menuLevel='0'");
            //}
            sb.Append("select menuName,menuID from SYS_MENU where menuLevel='0' order by displayOrder");
            #endregion querystring

            return DbHelperSQL.Query(sb.ToString());
        }

        /// <summary>
        /// 批量删除菜单项
        /// </summary>
        /// <param name="menuIDs">菜单项ID</param>
        /// <returns>1：为成功；0：为失败</returns>
        public int BatchDelete(List<string> menuIDs)
        {
            #region querystring
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from SYS_MENU where ");
            sb.AppendFormat("Charindex(@menuID,menuSEQ,0)<>0");
            #endregion

            List<string> queryString = new List<string>();
            List<SqlParameter[]> listParameters = new List<SqlParameter[]>();

            foreach (string menuID in menuIDs)
            {
                SqlParameter[] parameters ={
                    new SqlParameter("@menuID",SqlDbType.VarChar,32)
                                    };
                parameters[0].Value = menuID;
                queryString.Add(sb.ToString());
                listParameters.Add(parameters);
            }
            bool retVal = DbHelperSQL.ExecuteSqlCake(queryString, listParameters);
            return retVal ? 1 : 0;
        }

        public DataSet GridViewData(string strWhere, string strOrder, int row1, int row2, ref int iRowCount,List<int> PositionCode)
        {
            string ids = string.Empty;
            foreach(int id in PositionCode)
            {
                ids=id.ToString()+",";
            }
            ids = ids.TrimEnd(",".ToCharArray());


            StringBuilder sb = new StringBuilder();
            sb.Append("select * from (");
            //指定排序
            sb.AppendFormat(" select row_number() over(order by m.{0}) RowNo,",strOrder);
            sb.Append("m.menuID,");
            sb.Append("m.menuName,");
            sb.Append("m.menuAction,");
            sb.Append("m.menuLabel,");
            sb.Append("m.FunctionID,");
            sb.Append("m.isLeaf,");
            sb.Append("m.menuLevel,");
            sb.Append("m.parentsID,");
            sb.Append("m.displayOrder,");
            sb.Append("m.ICValue,");
            sb.Append("m.ISPOP,");
            if (ids != "0")
            {
                sb.Append("m.menuSEQ from SYS_MENU as m inner join SYS_menuPosition as mp on m.menuID = mp.menuID");

                //多个职位
                sb.AppendFormat(" where mp.PositionCode in ({0})", ids);
                sb.AppendFormat(" and {0}", strWhere);
            }
            else
            {
                sb.Append("m.menuSEQ from SYS_MENU as m");
                sb.AppendFormat(" where {0}", strWhere);
            }

            sb.Append(" ) as rel ");
            sb.AppendFormat("where RowNo>={0} and RowNo<={1}",row1,row2);


            StringBuilder sbCount = new StringBuilder();
            if (ids != "0")
            {
                sbCount.Append("select count(*) from SYS_MENU as m inner join SYS_menuPosition as mp on m.menuID = mp.menuID");
                sbCount.AppendFormat(" where mp.PositionCode in({0})", ids);
                sbCount.AppendFormat(" and {0}", strWhere);
            }
            else
            {
                sbCount.Append("select count(*) from SYS_MENU");
                
                sbCount.AppendFormat(" where {0}", strWhere);
            }

            iRowCount = Convert.ToInt32(DbHelperSQL.GetSingle(sbCount.ToString()));
            return DbHelperSQL.Query(sb.ToString());
        }

        /// <summary>
        /// 获取菜单项最大编号并加一
        /// </summary>
        /// <returns>Max(MenuID)+1</returns>
        public string BuildMenuID()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("select Max(menuID) from SYS_MENU"); //Updated by huangcm
            sb.Append("select 's'+right('000'+cast(isnull(max(cast(substring(menuid,2,31) as int)),0)+1 as varchar),4) from sys_menu");

            string maxMenuID = Convert.ToString(DbHelperSQL.GetSingle(sb.ToString()));
            //maxMenuID = maxMenuID.Substring(1);

            //int menuId = Convert.ToInt32(maxMenuID) + 1;

            //maxMenuID = menuId.ToString();
            //if (maxMenuID.Length == 1)
            //{
            //    maxMenuID = "s00" + maxMenuID;
            //}
            //else if (maxMenuID.Length == 2)
            //{
            //    maxMenuID = "s0" + maxMenuID;
            //}
            //else
            //{
            //    maxMenuID = "s" + maxMenuID;
            //}

            return maxMenuID;
        }

        /// <summary>
        /// 获取父菜单项的序列号
        /// </summary>
        /// <param name="parentID">父菜单项编号</param>
        /// <returns>序列号</returns>
        public string GetParentSEQ(string parentID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select menuSEQ from SYS_MENU where menuID = @menuID");

            SqlParameter[] parameters = { 
                new SqlParameter("@menuID",parentID)                        
                                        };

            return Convert.ToString(DbHelperSQL.GetSingle(sb.ToString(), parameters));
        }

        /// <summary>
        /// 获取菜单项对应的菜单项级别
        /// </summary>
        /// <param name="menuID">菜单项编号</param>
        /// <returns>菜单项级别</returns>
        public int GetMenuLevel(string menuID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select menuLevel from SYS_MENU where menuID = @menuID");

            SqlParameter[] parameters = { 
                new SqlParameter("@menuID",menuID)                            
                                        };

            return Convert.ToInt32(DbHelperSQL.GetSingle(sb.ToString(), parameters));
        }

        /// <summary>
        /// 判断一个菜单项是否为另一个菜单项的子菜单项
        /// </summary>
        /// <param name="menuID">菜单项编号</param>
        /// <param name="selectedMenuID">要比较的菜单项编号</param>
        /// <returns>是否是</returns>
        public bool IsChildren(string menuID, string selectedMenuID)
        {
            #region querystring
            StringBuilder sb = new StringBuilder();
            //updated by huangcm
            sb.Append("select menuSEQ from SYS_MENU where menuID =@menuID");
            sb.Append(" union all ");
            sb.Append("select menuSEQ from SYS_MENU where menuID =@selectedMenuID");
            #endregion querystring

            SqlParameter[] parameters = { 
                new SqlParameter("@menuID",SqlDbType.VarChar,32),
                new SqlParameter("@selectedMenuID",SqlDbType.VarChar,32)
                                        };

            parameters[0].Value = menuID;
            parameters[1].Value = selectedMenuID;

            DataSet dst = DbHelperSQL.Query(sb.ToString(), parameters);

            if (dst.Tables[0].Rows[1][0].ToString().Contains(dst.Tables[0].Rows[0][0].ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 由菜单项编号获取菜单项名称
        /// </summary>
        /// <param name="menuID">菜单项编号</param>
        /// <returns>菜单项名称</returns>
        public string GetMenuNameByID(string menuID)
        {
            #region querystring
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select menuName from SYS_MENU where menuID=@menuID");
            #endregion
            SqlParameter[] parameters ={
                new SqlParameter("@menuID",menuID)                       
                                      };
            return Convert.ToString(DbHelperSQL.GetSingle(sb.ToString(), parameters));
        }
    }
}
