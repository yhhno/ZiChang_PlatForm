/***********************************************
 * 单元名称：待发短信的实体
 * 开 发 者：翁志成
 * 开发时间：2009-8-26
 * 修改时间：
 * 修改原因：
 *********************************************/
using System;
namespace IndustryPlatform.Model
{
	/// <summary>
	/// 实体类SYS_ReadySendMessage 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_ReadySendMessageEntity
	{
		public SYS_ReadySendMessageEntity()
		{}
		#region Model
		private int _rsmid;
		private int _operatorid;
        private string _PhoneNum;
		private string _mcontent;
		private string _systype;
        private DateTime _senddate;
		private string _sendstate;
		private int _failernumber;
		/// <summary>
		/// 发送短信的GUID
		/// </summary>
		public int RSMID
		{
			set{ _rsmid=value;}
			get{return _rsmid;}
		}
		/// <summary>
		/// 短信接收人的ID
		/// </summary>
		public int OperatorID
		{
			set{ _operatorid=value;}
			get{return _operatorid;}
		}
        /// <summary>
        /// 手机号码
        /// </summary>
        public string PhoneNum
        {
            get { return _PhoneNum; }
            set { _PhoneNum = value; }
        }
		/// <summary>
		/// 短信的内容
		/// </summary>
		public string MContent
		{
			set{ _mcontent=value;}
			get{return _mcontent;}
		}
		/// <summary>
		/// 短信所属系统
		/// </summary>
		public string SysType
		{
			set{ _systype=value;}
			get{return _systype;}
		}
        /// <summary>
        /// 待发短信的生成时间
        /// </summary>
        public DateTime SendDate
        {
            get { return _senddate; }
            set { _senddate = value; }
        }
		/// <summary>
		/// 短信的发送状态
		/// </summary>
		public string SendState
		{
			set{ _sendstate=value;}
			get{return _sendstate;}
		}
		/// <summary>
		/// 短信发送失败次数
		/// </summary>
		public int FailerNumber
		{
			set{ _failernumber=value;}
			get{return _failernumber;}
		}
		#endregion Model

	}
}

