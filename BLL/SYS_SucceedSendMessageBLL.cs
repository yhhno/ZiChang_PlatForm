/***********************************************
 * 单元名称：短信发送成功
 * 开 发 者：翁志成
 * 开发时间：2009-8-26
 * 修改时间：
 * 修改原因：
 *********************************************/
using System;
using System.Data;
using IndustryPlatform.DALFactory;
using IndustryPlatform.Model;
using IndustryPlatform.IDAL;
namespace IndustryPlatform.BLL
{
    /// <summary>
    /// 业务逻辑类SYS_SucceedSendMessage 的摘要说明。
    /// </summary>
    public class SYS_SucceedSendMessageBLL
    {
        private readonly ISYS_SucceedSendMessage dal = DataAccess.CreateSYS_SucceedSendMessage();
        public SYS_SucceedSendMessageBLL()
        { }

         #region 获取短信发送所属系统表
        public DataSet GetOrganizationInfo()
        {
            return dal.GetOrganizationInfo();
        }
        #endregion

        #region 获取短信发送所属系统表
        public DataSet GetSysType()
        {
            return dal.GetSysType();
        }
        #endregion

        public void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strWhere, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl, int startyear, int endyear)
        {
            dal.GridViewPagerBindbyRowNumber(anpager, strWhere, strOrderCondition, grvControl, startyear, endyear);
        }

    }
}

