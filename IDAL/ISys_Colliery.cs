using System;
using System.Data;
using System.Collections.Generic;
namespace IndustryPlatform.IDAL
{
    /// <summary>
    /// 接口层Isys_Colliery 的摘要说明。
    /// </summary>
    public interface ISys_Colliery
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string strCollCode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(IndustryPlatform.Model.Sys_Colliery model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(IndustryPlatform.Model.Sys_Colliery model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(string strCollCode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        IndustryPlatform.Model.Sys_Colliery GetModel(string CollCode);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);

        DataSet GetList(string strTable, string strWhere);
        int Forbid(string strCollID, string strValue);
        string Getresult(string strFieldName, string strTableName, string strWhere);
        void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strCollCode, string strCollName, string strWhere, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl);
        bool Add(IndustryPlatform.Model.Sys_Colliery coll, List<IndustryPlatform.Model.Sys_FileSave> listModel);
        bool update(IndustryPlatform.Model.Sys_Colliery coll, List<IndustryPlatform.Model.Sys_FileSave> listModel);

        int SetColieryLowAccount(string strLowAccount, string strCollieryID);
        int AddColieryAccount(string strCollieryID, string strlowACCOUNT);
        int UpdateColieryAccount(string strCollieryID, string strlowACCOUNT);
        bool SetCollRunCoalKind(string strCollieryID, List<string> list);

        /// <summary>
        /// 获取所有的煤矿账户信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataTable GetColieryAccount(string strWhere);
       
        #endregion  成员方法
    }
}
