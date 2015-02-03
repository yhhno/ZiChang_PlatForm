/***********************************************
 * 单元名称：短信发送成功接口
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
	/// 接口层ISYS_SucceedSendMessage 的摘要说明。
	/// </summary>
	public interface ISYS_SucceedSendMessage
	{

       DataSet GetOrganizationInfo();
        
        DataSet GetSysType();
        
        void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strWhere, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl, int startyear, int endyear);
       
	}
}
