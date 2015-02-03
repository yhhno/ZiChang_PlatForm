using System;
using System.Collections.Generic;
using System.Text;
using IndustryPlatform.Model;
using System.Data;
using System.Web.UI.WebControls;


namespace IndustryPlatform.IDAL
{
     public interface ISYS_Position
    {
        #region  成员方法
         int Add(SYS_PositionEntity operEntity);
         int Delete(string PositionCode);
         int Update(SYS_PositionEntity operEntity);
         DataSet GetPositions(string OrgCode, string PositionName);
         void BindTreeview(TreeView treeview, string tablename, string fieldText, string fieldValue, string FatherCode, string FatherValue, string condition);
         SYS_PositionEntity GetModel(string PositonID);
         string Getresult(string FieldName, string TableName, string StrWhere);
         int AddMenuPosition(string PositionCode, string menuID);
         int AddMenuPosition(string PositionCode, List<string> menuIDs);
         int DelMenuPosition(string PositionCode);
         DataSet GetMenuPosition(string PositionCode);
         void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strTableName, string strPrimaryKey, string OrgCode, string PositionName, string OrgName, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl);
         DataSet GetList(string strwhere);
         void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strTableName, string strPrimaryKey, string OrgCode,string strOrderCondition, System.Web.UI.WebControls.GridView grvControl);
         DataSet GetPositionList(string strwhere);
         int CheckPosition(int OrgCode,string poname,int posid);
         int CheckPositionCode(string strPositionCode, string strPositonID);
        #endregion  成员方法
    }
}
