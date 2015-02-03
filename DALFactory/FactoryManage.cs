using System;
using System.Reflection;
using System.Configuration;
using IndustryPlatform.IDAL;

namespace IndustryPlatform.DALFactory
{
    /// <summary>
    /// 抽象工厂模式创建DAL。
    /// web.config 需要加入配置：(利用工厂模式+反射机制+缓存机制,实现动态创建不同的数据层对象接口)  
    /// DataCache类在导出代码的文件夹里
    /// 可以把所有DAL类的创建放在这个DataAccess类里
    /// <appSettings>  
    /// <add key="DAL" value="LiTianPing.SQLServerDAL" /> (这里的命名空间根据实际情况更改为自己项目的命名空间)
    /// </appSettings> 
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string path = System.Configuration.ConfigurationSettings.AppSettings["DAL"];
        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string path, string CacheKey)
        {
            object objType = DataCache.GetCache(CacheKey);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(path).CreateInstance(CacheKey);//反射创建
                    DataCache.SetCache(CacheKey, objType);// 写入缓存
                }
                catch
                { }
            }
            return objType;
        }
        /// <summary>
        /// 创建人员数据层接口
        /// </summary>
        public static IndustryPlatform.IDAL.ISYS_Operator CreateSYS_Operator()
        {
            string CacheKey = path + ".SYS_OperatorDao";
            object objType = CreateObject(path, CacheKey);
            return (IndustryPlatform.IDAL.ISYS_Operator)objType;
        }


        /// <summary>
        /// 创建组织机构数据层接口
        /// </summary>
        /// <returns></returns>
        public static IndustryPlatform.IDAL.ISYS_Organization CreateSYS_Organization()
        {
            string CacheKey = path + ".SYS_Organization";
            object objType = CreateObject(path, CacheKey);
            return (IndustryPlatform.IDAL.ISYS_Organization)objType;
        }

        /// <summary>
        /// 创建菜单数据层接口
        /// </summary>
        public static IndustryPlatform.IDAL.ISYS_Menu CreateSYS_Menu()
        {
            string CacheKey = path + ".SYS_Menu";
            object objType = CreateObject(path,CacheKey);
            return (IndustryPlatform.IDAL.ISYS_Menu)objType;
        }

        /// <summary>
        /// 创建岗位数据层接口
        /// </summary>
        /// <returns></returns>
        public static IndustryPlatform.IDAL.ISYS_Position CreateSYS_Position()
        {
            string CacheKey = path + ".SYS_PositionDao";
            object objType = CreateObject(path, CacheKey);
            return (IndustryPlatform.IDAL.ISYS_Position)objType;
        }

        /// <summary>
        /// 创建留言数据层接口
        /// </summary>
        /// <returns></returns>
        public static IndustryPlatform.IDAL.ISYS_Leaveword CreateSYS_Leaveword()
        {
            string CacheKey = path + ".SYS_LeavewordDao";
            object objType = CreateObject(path, CacheKey);
            return (IndustryPlatform.IDAL.ISYS_Leaveword)objType;
        }

        /// <summary>
        /// 创建Sys_Colliery数据层接口
        /// </summary>
        public static IndustryPlatform.IDAL.ISys_Colliery CreateSys_Colliery()
        {

            string CacheKey = path + ".Sys_Colliery";
            object objType = CreateObject(path, CacheKey);
            return (IndustryPlatform.IDAL.ISys_Colliery)objType;
        }

        /// <summary>
        /// 创建SYS_Dictionary数据层接口
        /// </summary>
        public static IndustryPlatform.IDAL.ISYS_Dictionary CreateSYS_Dictionary()
        {

            string CacheKey = path + ".SYS_DictionaryDao";
            object objType = CreateObject(path, CacheKey);
            return (IndustryPlatform.IDAL.ISYS_Dictionary)objType;
        }


        /// <summary>
        /// 创建SYS_FailerSendMessage数据层接口
        /// </summary>
        public static IndustryPlatform.IDAL.ISYS_FailerSendMessage CreateSYS_FailerSendMessage()
        {

            string CacheKey = path + ".SYS_FailerSendMessageSQLDAL";
            object objType = CreateObject(path, CacheKey);
            return (IndustryPlatform.IDAL.ISYS_FailerSendMessage)objType;
        }

        /// <summary>
        /// 创建SYS_ReadySendMessage数据层接口
        /// </summary>
        public static IndustryPlatform.IDAL.ISYS_ReadySendMessage CreateSYS_ReadySendMessage()
        {

            string CacheKey = path + ".SYS_ReadySendMessageSQLDAL";
            object objType = CreateObject(path, CacheKey);
            return (IndustryPlatform.IDAL.ISYS_ReadySendMessage)objType;
        }


        /// <summary>
        /// 创建SYS_ReceiveMessage数据层接口
        /// </summary>
        public static IndustryPlatform.IDAL.ISYS_ReceiveMessage CreateSYS_ReceiveMessage()
        {

            string CacheKey = path + ".SYS_ReceiveMessageSQLDAL";
            object objType = CreateObject(path, CacheKey);
            return (IndustryPlatform.IDAL.ISYS_ReceiveMessage)objType;
        }


        /// <summary>
        /// 创建SYS_SucceedSendMessage数据层接口
        /// </summary>
        public static IndustryPlatform.IDAL.ISYS_SucceedSendMessage CreateSYS_SucceedSendMessage()
        {

            string CacheKey = path + ".SYS_SucceedSendMessageSQLDAL";
            object objType = CreateObject(path, CacheKey);
            return (IndustryPlatform.IDAL.ISYS_SucceedSendMessage)objType;
        }

    }
}
