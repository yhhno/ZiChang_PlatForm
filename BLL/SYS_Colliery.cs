using System;
using System.Data;
using System.Collections.Generic;
using IndustryPlatform.DALFactory;
using IndustryPlatform.Model;
using IndustryPlatform.IDAL;
using System.Web.UI.WebControls;
using IndustryPlatform.DBUtility;
namespace IndustryPlatform.BLL
{
    /// <summary>
    /// 业务逻辑类sys_Colliery 的摘要说明。
    /// </summary>
    public class Sys_Colliery
    {
        private readonly ISys_Colliery dal = DataAccess.CreateSys_Colliery();
        public Sys_Colliery()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strCollCode)
        {
            return dal.Exists(strCollCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(IndustryPlatform.Model.Sys_Colliery model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(IndustryPlatform.Model.Sys_Colliery model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(string strCollCode)
        {
            return dal.Delete(strCollCode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public IndustryPlatform.Model.Sys_Colliery GetModel(string CollCode)
        {
            return dal.GetModel(CollCode);
        }

        public int Forbid(string strCollID, string strValue)
        {
            return dal.Forbid(strCollID, strValue);
        }

        public string Getresult(string strFieldName, string strTableName, string strWhere)
        {
            return dal.Getresult(strFieldName, strTableName, strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return dal.GetList("");
        }

        public DataSet GetList(string strTable, string strWhere)
        {
            return dal.GetList(strTable, strWhere);
        }


        //根据数据，生成下拉列表
        public void GetDropDownListBind(System.Web.UI.WebControls.DropDownList ddl, string strText, string strValue, string strTable, string strWhere)
        {
            ddl.DataSource = GetList(strTable, strWhere);
            ddl.DataTextField = strText;
            ddl.DataValueField = strValue;
            ddl.DataBind();

        }
        public void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strCollCode, string strCollName, string strWhere, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl)
        {
            dal.GridViewPagerBindbyRowNumber(anpager, strCollCode, strCollName, strWhere, strOrderCondition, grvControl);
        }

        public bool Add(IndustryPlatform.Model.Sys_Colliery coll, List<IndustryPlatform.Model.Sys_FileSave> listModel)
        {
            return dal.Add(coll, listModel);
        }


        public bool update(IndustryPlatform.Model.Sys_Colliery coll, List<IndustryPlatform.Model.Sys_FileSave> listModel)
        {
            return dal.update(coll, listModel);
        }



        public int SetColieryLowAccount(string strLowAccount, string strCollieryID)
        {
            return dal.SetColieryLowAccount(strLowAccount, strCollieryID);
        }
        
         
        //设置煤种
        public bool SetCollRunCoalKind(string strCollieryID, List<string> list)
        {
            return dal.SetCollRunCoalKind(strCollieryID, list);
        }


        /// <summary>
        /// 获取所有的煤矿账户信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetColieryAccount(string strWhere)
        {
            return dal.GetColieryAccount(strWhere);
        }


        /// <summary>
        /// 选择父级节点时绑定DropDrowList
        /// </summary>
        /// <param name="ddl"></param>
        public void OrgDllBind(DropDownList ddl)
        {
            ddl.Items.Clear();
            DataTable dt = DbHelperSQL.TQuery("select OrgCode,OrgName,ParentOrgCode from Sys_Organization where IsForbid='0'"); 
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ParentOrgCode"].ToString().Trim() == "0")//绑定根节点   
                    {
                        ddl.Items.Add(new ListItem(dr["OrgName"].ToString(), dr["OrgCode"].ToString()));
                        BindDropChildItem(ddl, dt, dr["OrgCode"].ToString(), 1);
                    }
                }
            }
            ddl.Items.Insert(0, new ListItem("请选择煤管站", "-1"));
        }


        public void BindDropChildItem(DropDownList ddl, DataTable dt, string id, int length)
        {
            DataRow[] rows = dt.Select("ParentOrgCode='" + id + "'", "OrgCode ASC");//取出id子节点进行绑定   
            for (int i = 0; i < rows.Length; i++)
            {
                ddl.Items.Add(new ListItem(SpaceLength(length) + rows[i]["OrgName"].ToString(), rows[i]["OrgCode"].ToString()));
                BindDropChildItem(ddl, dt, rows[i]["OrgCode"].ToString(), length + 1);//空白数目加1   
            }
        }
        //子节点前面的空白数 
        public string SpaceLength(int i)
        {
            string space = "";
            for (int j = 0; j < i; j++)
            {
                space += "--";//分层显示字符；   
            }
            return space;
        }    



        #endregion  成员方法
    }
}

