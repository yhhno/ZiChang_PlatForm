using System;
using System.Runtime.Serialization;
namespace IndustryPlatform.Model
{
    /// <summary>
    /// 实体类sys_filesave 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [DataContract]
    public class Sys_FileSave
    {
        public Sys_FileSave()
        { }
        #region Model
        private string _filecode;
        private string _filename;
        private string _filepath;
        private decimal _filesize;
        private string _filetype;
        private byte[] _filecontent;
        /// <summary>
        /// 
        /// </summary>
        public string FileCode
        {
            set { _filecode = value; }
            get { return _filecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FileSize
        {
            set { _filesize = value; }
            get { return _filesize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileType
        {
            set { _filetype = value; }
            get { return _filetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] FileContent
        {
            set { _filecontent = value; }
            get { return _filecontent; }
        }
        #endregion Model


    }
}

