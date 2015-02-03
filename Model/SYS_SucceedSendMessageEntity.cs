/***********************************************
 * 单元名称：短信发送成功的实体
 * 开 发 者：翁志成
 * 开发时间：2009-8-26
 * 修改时间：
 * 修改原因：
 *********************************************/
using System;
namespace IndustryPlatform.Model
{
	/// <summary>
	/// 实体类SYS_SucceedSendMessage 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SYS_SucceedSendMessageEntity
	{
		public SYS_SucceedSendMessageEntity()
		{}
		#region Model
		private int _ssmid;
		private int _operatorid;
        private string _PhoneNum;
		private string _mcontent;
		private string _systype;
		private DateTime _succeeddate;
		/// <summary>
		/// 短信编号
		/// </summary>
		public int SSMID
		{
			set{ _ssmid=value;}
			get{return _ssmid;}
		}
		/// <summary>
		/// 收短信人ID
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
		/// 短信内容
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
		/// 发送成功的时间
		/// </summary>
		public DateTime SucceedDate
		{
			set{ _succeeddate=value;}
			get{return _succeeddate;}
		}
		#endregion Model

	}
}

