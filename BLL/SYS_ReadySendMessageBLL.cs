/***********************************************
 * 单元名称：短信等待发送
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
	/// 业务逻辑类SYS_ReadySendMessage 的摘要说明。
	/// </summary>
	public class SYS_ReadySendMessageBLL
	{
		private readonly ISYS_ReadySendMessage dal=DataAccess.CreateSYS_ReadySendMessage();
		public SYS_ReadySendMessageBLL()
		{}

        /// <summary>
        /// 获取待发短信信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetReadySendMessageInfo()
        { 
            return dal.GetReadySendMessageInfo();
        }
		
    }
}

