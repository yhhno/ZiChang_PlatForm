using System;
using System.Data;
using IndustryPlatform.DALFactory;
using IndustryPlatform.Model;
using IndustryPlatform.IDAL;
using IndustryPlatform.DBUtility;
namespace IndustryPlatform.BLL
{
    /// <summary>
    /// 业务逻辑类SYS_Dictionary 的摘要说明。
    /// </summary>
    public class SYS_Dictionary
    {
        private readonly ISYS_Dictionary dal = DataAccess.CreateSYS_Dictionary();
        public SYS_Dictionary()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string businTypeID, string businName, string businID)
        {
            return dal.Exists(businTypeID, businName, businID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(IndustryPlatform.Model.SYS_DictionaryEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(IndustryPlatform.Model.SYS_DictionaryEntity model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string businID, string businTypeID)
        {
            return dal.Delete(businID, businTypeID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public IndustryPlatform.Model.SYS_DictionaryEntity GetModel(string businID, string businTypeID)
        {
            return dal.GetModel(businID, businTypeID);
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
            return GetList("");
        }

        /// <summary>
        /// 返回字典类型
        /// </summary>
        public DataSet GetDictionaryType(string strWhere)
        {
            return dal.GetDictionaryType(strWhere);
        }
      
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        public void LogTypeBind(System.Web.UI.WebControls.DropDownList ddlControl)
        {
            string str = "select Distinct LOGTYPE from SYS_OperateLog";
            ddlControl.DataSource = DbHelperSQL.DQuery(str);
            ddlControl.DataTextField = "LOGTYPE";
            ddlControl.DataValueField = "LOGTYPE";
            ddlControl.DataBind();
            ddlControl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("请选择操作类型", ""));
        }

        #endregion  成员方法
    }
}

