/***********************************************
 * 单元名称：短信等待发送接口
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
	/// 接口层ISYS_ReadySendMessage 的摘要说明。
	/// </summary>
	public interface ISYS_ReadySendMessage
	{
        /// <summary>
        /// 获取待发短信信息
        /// </summary>
        /// <returns></returns>
        DataTable GetReadySendMessageInfo();
        
	}
}
