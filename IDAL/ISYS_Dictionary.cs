using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace IndustryPlatform.IDAL
{
    /// <summary>
    /// 接口层ISYS_Dictionary 的摘要说明。
    /// </summary>
    public interface ISYS_Dictionary
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string businTypeID, string businName, string businID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(IndustryPlatform.Model.SYS_DictionaryEntity model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(IndustryPlatform.Model.SYS_DictionaryEntity model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string businID, string businTypeID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        IndustryPlatform.Model.SYS_DictionaryEntity GetModel(string businID, string businTypeID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得字典类型
        /// </summary>
        DataSet GetDictionaryType(string strWhere);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
    }
}

