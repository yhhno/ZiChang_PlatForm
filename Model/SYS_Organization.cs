using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace IndustryPlatform.Model
{
    [DataContract]
    public class SYS_Organization
    {
        public SYS_Organization()
        { }
        #region Model
        private string _orgcode;
        private string _orgname;
        private string _orglevel;
        private string _parentorgcode;
        private string _orgseq;
        private string _orgtype;
        private string _linkman;
        private string _linkmantel;
        private string _email;
        private string _isforbid;
        private string _remark;
        private string _syscode;
        /// <summary>
        /// 
        /// </summary>
        public string OrgCode
        {
            set { _orgcode = value; }
            get { return _orgcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrgName
        {
            set { _orgname = value; }
            get { return _orgname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrgLevel
        {
            set { _orglevel = value; }
            get { return _orglevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParentOrgCode
        {
            set { _parentorgcode = value; }
            get { return _parentorgcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrgSeq
        {
            set { _orgseq = value; }
            get { return _orgseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrgType
        {
            set { _orgtype = value; }
            get { return _orgtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkMan
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkManTel
        {
            set { _linkmantel = value; }
            get { return _linkmantel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IsForbid
        {
            set { _isforbid = value; }
            get { return _isforbid; }
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
        public string SysCode
        {
            set { _syscode = value; }
            get { return _syscode; }
        }
        #endregion Model

    }
}

