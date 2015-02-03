/***********************************************
 * 单元名称：接收短信接口
 * 开 发 者：翁志成
 * 开发时间：2009-8-26
 * 修改时间：
 * 修改原因：
 *********************************************/

using System;
using System.Data;
using IndustryPlatform.Model;
namespace IndustryPlatform.IDAL
{
	/// <summary>
	/// 接口层ISYS_ReceiveMessage 的摘要说明。
	/// </summary>
	public interface ISYS_ReceiveMessage
	{
		///// <summary #region GridView控件分页帮定
        /// <summary>
        /// GridView控件分页帮定
        /// </summary>
        /// <param name="anpager">AspNetPager分页控件</param>
        /// <param name="strQuaryCondition">查询Where条件，不含Where</param>
        /// <param name="strOrderCondition">需要排序的字段名</param>
        /// <param name="rptControl">GridView控件</param>
        void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strWhere, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl, int startyear, int endyear);
        
        
	}
}
