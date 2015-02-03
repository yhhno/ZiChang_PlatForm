using System;
using System.Collections.Generic;
using System.Text;
using IndustryPlatform.Model;
using System.Data;

namespace IndustryPlatform.IDAL
{
    public interface ISYS_Operator
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="strusername">登录名</param>
        /// <param name="strpwd">密码</param>
        /// <returns></returns>
        DataSet OperatorLogin(string strusername,string strpwd);
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="operEntity">实体类</param>
        /// <returns></returns>
        int AddOperator(SYS_OperatorEntity operEntity);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="stroperid">选定了的用户ID</param>
        /// <returns></returns>
        int DelOperator(string stroperid);
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="operEntity">实体类</param>
        /// <returns></returns>
        int UpdateOperator(SYS_OperatorEntity operEntity);

        IndustryPlatform.Model.SYS_OperatorEntity GetModel(string UserCode);
        
        DataSet GetOperatorInfo(string perid);
        /// <summary>
        /// 更改密码
        /// </summary>
        /// <param name="perid">用户ID</param>
        /// <param name="oldpwd">旧密码</param>
        /// <param name="newpwd">新密码</param>
        /// <returns></returns>
        int Updatepwd(string perid, string oldpwd, string newpwd);
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="anpager"></param>
        /// <param name="strTableName"></param>
        /// <param name="strPrimaryKey"></param>
        /// <param name="strQuaryCondition"></param>
        /// <param name="strOrderCondition"></param>
        /// <param name="grvControl"></param>
        void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strTableName, string strPrimaryKey, string strQuaryCondition, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl);
        /// <summary>
        /// 得到最大的值
        /// </summary>
        /// <param name="FildName">字段</param>
        /// <param name="TableName">表名</param>
        /// <returns></returns>
        int GetMaxID(string FildName,string TableName);
        /// <summary>
        /// 添加用户的岗位
        /// </summary>
        /// <param name="stroperid">用户ID</param>
        /// <param name="PositionCode">职位ID</param>
        /// <returns></returns>
        int AddOperPosition(string stroperid,string PositionCode);
        /// <summary>
        /// 得到用户的职位ID所组成的字符串
        /// </summary>
        /// <param name="operid">用户ID</param>
        /// <returns></returns>
        string GetPosition(int operid);
        /// <summary>
        /// 得到用户的职位名称所组成的符串
        /// </summary>
        /// <param name="operid">用户ID</param>
        /// <returns></returns>
        string GetOperPosition(int operid);
        /// <summary>
        /// 查询登录名
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        int CheckUserID(string userid);
        int CheckUserName(string username);
        /// <summary>
        /// 初始化密码
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        /// <summary>
        /// 初始化密码
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        int SetDefaultPwd(string pid,string defaultpwd);
       
    }
}
