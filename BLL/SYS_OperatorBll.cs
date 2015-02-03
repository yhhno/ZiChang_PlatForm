using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IndustryPlatform.SQLServerDAL;
using IndustryPlatform.DALFactory;
using IndustryPlatform.IDAL;
using IndustryPlatform.Model;

namespace IndustryPlatform.BLL
{
    public class SYS_OperatorBll
    {
        private readonly ISYS_Operator dal = DataAccess.CreateSYS_Operator();
    

        public DataSet OperatorLogin(string strusername, string strpwd)
        {
            DataSet ds = dal.OperatorLogin(strusername,strpwd);
            return ds;
        }

        public int AddOperator(SYS_OperatorEntity operEntity)
        {
            return dal.AddOperator(operEntity);
        }

        public int UpdateOperator(SYS_OperatorEntity operEntity)
        {
            return dal.UpdateOperator(operEntity);
        }

        public int DelOperator(string stroperid)
        {
            return dal.DelOperator(stroperid);
        }

        public DataSet GetOperatorInfo(string strid)
        {
            return dal.GetOperatorInfo(strid);
        }

        public int UpdatePwd(string perid, string oldpwd, string newpwd)
        {
            return dal.Updatepwd(perid,oldpwd,newpwd);
        }

        public void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strTableName, string strPrimaryKey, string strQuaryCondition, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl)
        {
           dal.GridViewPagerBindbyRowNumber(anpager,strTableName,strPrimaryKey,strQuaryCondition,strOrderCondition,grvControl);

        }

        public IndustryPlatform.Model.SYS_OperatorEntity GetModel(string UserCode)
        {
            return dal.GetModel(UserCode);
        }

        public int GetMaxID(string strFild,string strTable)
        {
            return dal.GetMaxID(strFild,strTable);
        }
        public int AddOperPosition(string stroperid, string PositionCode)
        {
            return dal.AddOperPosition(stroperid, PositionCode);
        }

        public string GetPosi(int operid)
        {
            return dal.GetPosition(operid);
        }

        public string GetOperPosition(int operid)
        {
            return dal.GetOperPosition(operid);
        }
        public int CheckUserID(string struid)
        {
            return dal.CheckUserID(struid);
        }

        public int Ch(string username)
        {
            return dal.CheckUserName(username);
        }

        public int setdefautpwd(string pid,string defautlpwd)
        {
            return dal.SetDefaultPwd(pid, defautlpwd);
        }
    }
}
