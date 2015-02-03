/***********************************************
 * 单元名称：接收短信的实体
 * 开 发 者：翁志成
 * 开发时间：2009-8-26
 * 修改时间：
 * 修改原因：
 *********************************************/
using System;
namespace IndustryPlatform.Model
{
	/// <summary>
	/// 实体类SYS_ReceiveMessage 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_ReceiveMessageEntity
	{
		public SYS_ReceiveMessageEntity()
		{}
		#region Model
		private int _rmid;
		private string _phonenumber;
		private string _mcontent;
		private DateTime _receivedate;
		/// <summary>
		/// 短信接收的GUID
		/// </summary>
		public int RMID
		{
			set{ _rmid=value;}
			get{return _rmid;}
		}
		/// <summary>
		/// 短信的PhoneNumber
		/// </summary>
		public string PhoneNumber
		{
			set{ _phonenumber=value;}
			get{return _phonenumber;}
		}
		/// <summary>
		/// 接收短信的内容
		/// </summary>
		public string MContent
		{
			set{ _mcontent=value;}
			get{return _mcontent;}
		}
		/// <summary>
		/// 接收时间
		/// </summary>
		public DateTime ReceiveDate
		{
			set{ _receivedate=value;}
			get{return _receivedate;}
		}
		#endregion Model

	}
}

