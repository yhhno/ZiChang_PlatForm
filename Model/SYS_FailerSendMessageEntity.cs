/***********************************************
 * 单元名称：短信发送失败的实体
 * 开 发 者：翁志成
 * 开发时间：2009-8-26
 * 修改时间：
 * 修改原因：
 *********************************************/
using System;
namespace IndustryPlatform.Model
{
	/// <summary>
	/// 实体类SYS_FailerSendMessage 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_FailerSendMessageEntity
	{
		public SYS_FailerSendMessageEntity()
		{}
		#region Model
		private int _fsmid;
		private int _operatorid;
        private string _PhoneNum;
		private string _mcontent;
		private string _systype;
		private DateTime _failerdate;
		/// <summary>
		/// 发送失败的Guid
		/// </summary>
		public int FSMID
		{
			set{ _fsmid=value;}
			get{return _fsmid;}
		}
		/// <summary>
		/// 短信接收人ID
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
		/// 发送短信的内容
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
		/// 发送失败时间
		/// </summary>
		public DateTime FailerDate
		{
			set{ _failerdate=value;}
			get{return _failerdate;}
		}
		#endregion Model

	}
}

