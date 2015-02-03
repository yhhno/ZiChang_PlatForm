using System;
namespace IndustryPlatform.Model
{
    /// <summary>
    /// 实体类Sys_Colliery 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Sys_Colliery
    {
        public Sys_Colliery()
        { }
        #region Model
        private string _collcode;
        private string _collname;
        private string _orgcode;
        private string _villagecode;
        private string _mineowner;
        private string _minephone;
        private decimal _yearoutput;
        private string _collstate;
        private string _imagelicence;
        private string _imagerevenue;
        private string _imagecompetency;
        private string _remark;
        private string _isforbid;
        private string _collproperty;
        /// <summary>
        /// 
        /// </summary>
        public string CollCode
        {
            set { _collcode = value; }
            get { return _collcode; }
        }

        /// <summary>
        /// 煤矿属性
        /// </summary>
        public string CollProperty
        {
            set { _collproperty = value; }
            get { return _collproperty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CollName
        {
            set { _collname = value; }
            get { return _collname; }
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
        public string VillageCode
        {
            set { _villagecode = value; }
            get { return _villagecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MineOwner
        {
            set { _mineowner = value; }
            get { return _mineowner; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MinePhone
        {
            set { _minephone = value; }
            get { return _minephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal YearOutput
        {
            set { _yearoutput = value; }
            get { return _yearoutput; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CollState
        {
            set { _collstate = value; }
            get { return _collstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImageLicence
        {
            set { _imagelicence = value; }
            get { return _imagelicence; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImageRevenue
        {
            set { _imagerevenue = value; }
            get { return _imagerevenue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImageCompetency
        {
            set { _imagecompetency = value; }
            get { return _imagecompetency; }
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

        /// <summary>
        /// 片区
        /// </summary>
        public string ParcelCode
        { get; set; }
        #endregion Model

    }
}

