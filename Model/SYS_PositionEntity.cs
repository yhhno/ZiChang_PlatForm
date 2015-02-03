using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace IndustryPlatform.Model
{
    [DataContract]
    public class SYS_PositionEntity
    {
        #region Model
        private string _positioncode;
        private string _positionname;
        private string _remark;
        private string _isforbid;
        /// <summary>
        /// 
        /// </summary>
        public string PositionCode
        {
            set { _positioncode = value; }
            get { return _positioncode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PositionName
        {
            set { _positionname = value; }
            get { return _positionname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
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
