using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace IndustryPlatform.Model
{
    /// <summary>
    /// 实体类SYS_Dictionary 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [DataContract]
    public class SYS_DictionaryEntity
    {
        public SYS_DictionaryEntity()
        { }
        #region Model
        private string _businid;
        private string _businname;
        private string _busintypeid;
        private decimal? _displayorder;
        private string _isforbid;
        /// <summary>
        /// 
        /// </summary>
        public string BusinID
        {
            set { _businid = value; }
            get { return _businid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BusinName
        {
            set { _businname = value; }
            get { return _businname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BusinTypeID
        {
            set { _busintypeid = value; }
            get { return _busintypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DisplayOrder
        {
            set { _displayorder = value; }
            get { return _displayorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IsForbid
        {
            set { _isforbid = value; }
            get { return _isforbid; }
        }
        #endregion Model

    }
}

