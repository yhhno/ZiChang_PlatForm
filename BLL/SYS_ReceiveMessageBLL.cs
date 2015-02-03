/***********************************************
 * 单元名称：接收短信
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
	/// 业务逻辑类SYS_ReceiveMessage 的摘要说明。
	/// </summary>
	public class SYS_ReceiveMessageBLL
	{
		private readonly ISYS_ReceiveMessage dal=DataAccess.CreateSYS_ReceiveMessage();
		public SYS_ReceiveMessageBLL()
		{}
		
        /// <summary>
        /// GridView控件分页帮定
        /// </summary>
        /// <param name="anpager">AspNetPager分页控件</param>
        /// <param name="strQuaryCondition">查询Where条件，不含Where</param>
        /// <param name="strOrderCondition">需要排序的字段名</param>
        /// <param name="rptControl">GridView控件</param>
        public void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strWhere, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl, int startyear, int endyear)
        {
            dal.GridViewPagerBindbyRowNumber(anpager, strWhere, strOrderCondition, grvControl, startyear, endyear);
        }
    }
}

