using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IndustryPlatform.IDAL
{
    public interface ISYS_Organization
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string OrgCode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(IndustryPlatform.Model.SYS_Organization model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(IndustryPlatform.Model.SYS_Organization model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(string OrgCode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        IndustryPlatform.Model.SYS_Organization GetModel(string OrgCode);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);

        /// <summary>
        /// 判断某一机构下是否有岗位
        /// </summary>
        /// <param name="OrgCode"></param>
        /// <returns></returns>
        int GetPositionCountByOrgCode(string OrgCode);

        /// <summary>
        /// 判断某一机构下是否有人员
        /// </summary>
        /// <param name="OrgCode"></param>
        /// <returns></returns>
        int GetOperatorCountByOrgCode(string OrgCode);

        DataSet GridViewData(string strWhere, string strOrder, int row1, int row2, ref int iRowCount);

        /// <summary>
        /// 判断组织代码是否存在
        /// </summary>
        /// <param name="orgCode"></param>
        /// <param name="OrgCode"></param>
        /// <returns></returns>
        int ExistOrgCode(string orgCode);
        #endregion  成员方法
    }
}
