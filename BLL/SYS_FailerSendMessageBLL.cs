/***********************************************
 * 单元名称：短信发送失败
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
	/// 业务逻辑类SYS_FailerSendMessage 的摘要说明。
	/// </summary>
	public class SYS_FailerSendMessageBLL
	{
		private readonly ISYS_FailerSendMessage dal=DataAccess.CreateSYS_FailerSendMessage();
		public SYS_FailerSendMessageBLL()
		{}


        public void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strWhere, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl, int startyear, int endyear)
        {
            dal.GridViewPagerBindbyRowNumber(anpager,strWhere,strOrderCondition,grvControl,startyear,endyear);
        }

         /// <summary>
        /// 继续发送短信
        /// </summary>
        /// <param name="FailerID"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        #region 继续发送短信
        public int InsertIntoReadySendMessage(string FailerID, int year)
        {
            return dal.InsertIntoReadySendMessage(FailerID,year);
        }
        #endregion
    }
}

