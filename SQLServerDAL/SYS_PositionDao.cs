using System;
using System.Collections.Generic;
using System.Text;
using IndustryPlatform.Model;
using IndustryPlatform.DBUtility;
using IndustryPlatform.IDAL;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web;

namespace IndustryPlatform.SQLServerDAL
{
    public class SYS_PositionDao:ISYS_Position
    {

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
        public  void BindTreeview(TreeView treeview, string tablename, string fieldText, string fieldValue, string FatherCode, string FatherValue, string condition)
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

        #region 绑定岗位的列表数据

        public DataSet GetPositions(string OrgCode, string PositionName)
        {

            //string str = "select p.*,o.orgName from  SYS_Position as p left join SYS_Organization as o on o.OrgCode=p.OrgCode where p.OrgCode like '%" + OrgCode + "%' and p.PositionName like '%" + PositionName + "%'";
            //DataSet dataset= DbHelperSQL.Query(str);
            //return dataset;

            StringBuilder strSql = new StringBuilder();
            DataSet ds;
            strSql.Append("select p.*,o.orgName,case p.IsForbid when 1 then  '否' else '是'end as Forbid  from  SYS_Position as p left join SYS_Organization as o on o.OrgCode=p.OrgCode ");

            if (OrgCode != "")
            {
                strSql.Append(" where   p.OrgCode=@OrgCode and p.PositionName like @PositionName ");
                PositionName = "%" + PositionName + "%";
                SqlParameter[] parameters = { new SqlParameter("@OrgCode", SqlDbType.Decimal), new SqlParameter("@PositionName", PositionName) };

                parameters[0].Value = Convert.ToDecimal(OrgCode);
                parameters[1].Value = PositionName;

                ds=DbHelperSQL.Query(strSql.ToString(),parameters);
            }
            else
            {
               strSql.Append(" where  p.PositionName like  @PositionName ");
               PositionName = "%" + PositionName + "%";
               SqlParameter[] parameters = { new SqlParameter("@PositionName", PositionName) };
                
                parameters[0].Value = PositionName;

                ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            }

            return ds;
        }
        #endregion

        #region 岗位添加功能
        public int Add(SYS_PositionEntity operEntity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Position(");
            strSql.Append("PositionCode,PositionName,Remark,IsForbid)");
            strSql.Append(" values (");
            strSql.Append("@PositionCode,@PositionName,@Remark,@IsForbid)");
            SqlParameter[] parameters = {
					new SqlParameter("@PositionCode", SqlDbType.VarChar,10),
					new SqlParameter("@PositionName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@IsForbid", SqlDbType.VarChar,1)};
            parameters[0].Value = operEntity.PositionCode;
            parameters[1].Value = operEntity.PositionName;
            parameters[2].Value = operEntity.Remark;
            parameters[3].Value = operEntity.IsForbid;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        #region 删除功能
        public int Delete(string PositionCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete SYS_Position ");
            strSql.Append(" where PositionCode in (" + PositionCode + ") ");
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
        #endregion

        #region 修改功能
        public int Update(SYS_PositionEntity operEntity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Position set ");
            strSql.Append("PositionName=@PositionName,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("IsForbid=@IsForbid");
            strSql.Append(" where PositionCode=@PositionCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@PositionCode", SqlDbType.VarChar,10),
					new SqlParameter("@PositionName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@IsForbid", SqlDbType.VarChar,1)};
            parameters[0].Value = operEntity.PositionCode;
            parameters[1].Value = operEntity.PositionName;
            parameters[2].Value = operEntity.Remark;
            parameters[3].Value = operEntity.IsForbid;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        #region 得到一条数据的实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public IndustryPlatform.Model.SYS_PositionEntity GetModel(string PositionCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PositionCode,PositionName,Remark,IsForbid from Sys_Position ");
            strSql.Append(" where PositionCode=@PositionCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@PositionCode", SqlDbType.VarChar,50)};
            parameters[0].Value = PositionCode;

            IndustryPlatform.Model.SYS_PositionEntity model = new IndustryPlatform.Model.SYS_PositionEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.PositionCode = ds.Tables[0].Rows[0]["PositionCode"].ToString();
                model.PositionName = ds.Tables[0].Rows[0]["PositionName"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                model.IsForbid = ds.Tables[0].Rows[0]["IsForbid"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion


        #region  通过条件，得到数据
        public string Getresult(string FieldName, string TableName, string StrWhere)
        {
            string strsql = "select " + FieldName + "  from " + TableName + " where " + StrWhere + " order by " + FieldName;
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

        #region 岗位权限添加功能
        public int AddMenuPosition(string PositionCode, string menuID)
        {
            
            string strSql = "";
            strSql = "insert into SYS_menuPosition(PositionCode,menuID) values(" + PositionCode + ",'" + menuID + "')";
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

        //added by huangcm
        public int AddMenuPosition(string PositionCode, List<string> menuIDs)
        {
            List<string> listSql = new List<string>();
            listSql.Add("Delete SYS_menuPosition where PositionCode='" + PositionCode + "'");
            foreach (string menuID in menuIDs)
            {
                string strSql = "";
                strSql = "insert into SYS_menuPosition(PositionCode,menuID) values(" + PositionCode + ",'" + menuID + "')";
                listSql.Add(strSql);
            }
            try
            {
                return DbHelperSQL.ExecuteSqlCake(listSql, null) == true ? 1 : 0;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region 删除指定的岗位下的权限
        public int DelMenuPosition(string PositionCode)
        {
            string strSql = "";
            strSql = "delete   SYS_menuPosition where PositionCode=" + PositionCode + "";
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
        #endregion

        #region 获取岗位下的权限
        public DataSet GetMenuPosition(string PositionCode)
        {
            string strSql = "";
            strSql = "select * from SYS_menuPosition where PositionCode=" + PositionCode + "";

            DataSet dataset = DbHelperSQL.Query(strSql);
            return dataset;
        }
        #endregion


        #region 使用分页控件绑定GridView
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
        public void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strTableName, string strPrimaryKey, string OrgCode, string PositionName,string OrgName, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl)
        {
            string strsel = "";
            DataSet dstTemp=new DataSet();
            if (OrgCode != "")
            {
                strsel = "select * from (select row_number() over (order by " + strOrderCondition + ") as rowno,p.*,o.orgName,case p.IsForbid when 1 then  '是' else '否'end as Forbid from " + strTableName + " and   p.OrgCode like @OrgCode and p.PositionName like @PositionName and o.orgName like @orgName) as result Where (rowno Between " + (anpager.CurrentPageIndex - 1) * anpager.PageSize + " and " + anpager.CurrentPageIndex * anpager.PageSize + ")";
                PositionName = "%" + PositionName + "%";
                OrgName = "%" + OrgName + "%";
                OrgCode = "%" + OrgCode + "%";
                SqlParameter[] parameters = { new SqlParameter("@OrgCode", OrgCode), new SqlParameter("@PositionName", PositionName), new SqlParameter("@orgName", OrgName) };
                parameters[0].Value = OrgCode;
                parameters[1].Value = PositionName;
                parameters[2].Value = OrgName;

                anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(*) From " + strTableName + " and  p.OrgCode like @OrgCode and p.PositionName like @PositionName and o.orgName like @orgName ", parameters));
                dstTemp = DbHelperSQL.Query(strsel, parameters);
            }
            else
            {
                strsel = "select * from (select row_number() over (order by " + strOrderCondition + ") as rowno,p.*,o.orgName,case p.IsForbid when 1 then  '否' else '是'end as Forbid from " + strTableName + " and    p.PositionName like @PositionName and  o.orgName like @orgName) as result Where (rowno Between " + (anpager.CurrentPageIndex - 1) * anpager.PageSize + " and " + anpager.CurrentPageIndex * anpager.PageSize + ")";
                PositionName = "%" + PositionName + "%";
                OrgName = "%" + OrgName + "%";
                SqlParameter[] parameters = { new SqlParameter("@PositionName", PositionName),new SqlParameter("@orgName", OrgName)};
                parameters[0].Value = PositionName;
                parameters[1].Value = OrgName;
                anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(*) From " + strTableName + " and   p.PositionName like @PositionName and o.orgName like @orgName", parameters));
                dstTemp = DbHelperSQL.Query(strsel, parameters);
            }


            

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
        #endregion


        #region 使用分页控件绑定GridView(重载方法)
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
        public void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strTableName, string strPrimaryKey, string OrgCode,string strOrderCondition, System.Web.UI.WebControls.GridView grvControl)
        {
            string strsel = "";
            DataSet dstTemp = new DataSet();
            if (OrgCode != "")
            {
                strsel = "select * from (select row_number() over (order by " + strOrderCondition + ") as rowno,p.*,o.orgName,case p.IsForbid when 1 then  '否' else '是'end as Forbid from " + strTableName + " and   p.OrgCode = @OrgCode ) as result Where (rowno Between " + (anpager.CurrentPageIndex - 1) * anpager.PageSize + " and " + anpager.CurrentPageIndex * anpager.PageSize + ")";

                SqlParameter[] parameters = { new SqlParameter("@OrgCode", OrgCode)};
                parameters[0].Value = OrgCode;

                anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(*) From " + strTableName + " and  p.OrgCode like @OrgCode ", parameters));
                dstTemp = DbHelperSQL.Query(strsel, parameters);
            }
            else
            {
                strsel = "select * from (select row_number() over (order by " + strOrderCondition + ") as rowno,p.*,o.orgName,case p.IsForbid when 1 then  '否' else '是'end as Forbid from " + strTableName + " ) as result Where (rowno Between " + (anpager.CurrentPageIndex - 1) * anpager.PageSize + " and " + anpager.CurrentPageIndex * anpager.PageSize + ")";
              
                anpager.RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle("Select Count(*) From " + strTableName + " "));
                dstTemp = DbHelperSQL.Query(strsel);
            }

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

        #region  通过条件，得到组织结构数据
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  FROM  SYS_Organization where  " +strwhere);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion


        #region  通过条件， 得到岗位名称数据
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetPositionList(string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_Position where" + strwhere);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        public int CheckPosition(int OrgCode, string poname,int posid) 
        {
            try
            {
                string strsel = "SELECT COUNT(0) FROM SYS_Position WHERE PositionName=@PositionName and OrgCode=@OrgCode and PositonID<>@PositonID";
                SqlParameter[] parameters = {
                    new SqlParameter("@OrgCode", SqlDbType.Decimal),
                    new SqlParameter("@PositionName",SqlDbType.VarChar),
                    new SqlParameter("@PositonID",SqlDbType.Decimal)
                                            };
                parameters[0].Value = OrgCode;
                parameters[1].Value = poname;
                parameters[2].Value = posid;
                object obj = DbHelperSQL.GetSingle(strsel,parameters);
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

        public int CheckPositionCode(string strPositionCode, string strPositonID)
        {
            try
            {
                string strSql = "";
                if (strPositonID == "")
                    strSql = "select count(0) from SYS_Position where PositionCode='" + strPositionCode + "'";
                else
                    strSql = "select count(0) from SYS_Position where PositionCode='" + strPositionCode + "' and PositonID<>" + strPositonID;
                object obj = DbHelperSQL.GetSingle(strSql);
                if (obj != null)
                    return Convert.ToInt32(obj);
                else
                    return 0;
            }
            catch 
            {
                return 0;
            }
        }

    }
}
