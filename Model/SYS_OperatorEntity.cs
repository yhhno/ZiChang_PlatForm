using System;
using System.Runtime.Serialization;

namespace IndustryPlatform.Model
{
    [DataContract]
    public class SYS_OperatorEntity
    {
        #region Model
        private string _usercode;
        private string _username;
        private string _password;
        private string _isforbid;
        private string _orgcode;
        private string _tel;
        private string _email;
        private string _address;
        private string _zipcode;
        private string _pid;
        private string _gender;
        private DateTime? _regdate;
        private string _mobileno;
        private string _typecode;
        /// <summary>
        /// 
        /// </summary>
        public string UserCode
        {
            set { _usercode = value; }
            get { return _usercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
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
        public string OrgCode
        {
            set { _orgcode = value; }
            get { return _orgcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
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
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZipCode
        {
            set { _zipcode = value; }
            get { return _zipcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PID
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Gender
        {
            set { _gender = value; }
            get { return _gender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RegDate
        {
            set { _regdate = value; }
            get { return _regdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MobileNo
        {
            set { _mobileno = value; }
            get { return _mobileno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeCode
        {
            set { _typecode = value; }
            get { return _typecode; }
        }
        #endregion Model
    }
}
