using System;
namespace IndustryPlatform.Model
{
    /// <summary>
    /// 实体类SYS_OperateLogEntity 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class SYS_OperateLogEntity
    {
        public SYS_OperateLogEntity()
        { }
        #region Model
        private string _logid;
        private string _logtype;
        private string _operattable;
        private decimal _operatorid;
        private string _operatedate;
        private string _operateip;
        private string _relationid;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public string logID
        {
            set { _logid = value; }
            get { return _logid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LOGTYPE
        {
            set { _logtype = value; }
            get { return _logtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string operatTable
        {
            set { _operattable = value; }
            get { return _operattable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal operatorID
        {
            set { _operatorid = value; }
            get { return _operatorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string operatedate
        {
            set { _operatedate = value; }
            get { return _operatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string operateIP
        {
            set { _operateip = value; }
            get { return _operateip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RELATIONID
        {
            set { _relationid = value; }
            get { return _relationid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

