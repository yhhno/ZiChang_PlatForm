/***********************************************
 * 单元名称：短信发送失败接口
 * 开 发 者：翁志成
 * 开发时间：2009-8-26
 * 修改时间：
 * 修改原因：
 *********************************************/

using System;
using System.Data;
namespace IndustryPlatform.IDAL
{
	/// <summary>
	/// 接口层ISYS_FailerSendMessage 的摘要说明。
	/// </summary>
	public interface ISYS_FailerSendMessage
	{

        void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strWhere, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl, int startyear, int endyear);
        

         /// <summary>
        /// 继续发送短信
        /// </summary>
        /// <param name="FailerID"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        int InsertIntoReadySendMessage(string FailerID, int year);
	}
}
