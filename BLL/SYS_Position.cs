using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IndustryPlatform.IDAL;
using IndustryPlatform.DALFactory;
using System.Web.UI.WebControls;
using IndustryPlatform.Model;
using IndustryPlatform.DBUtility;

namespace IndustryPlatform.BLL
{
    public class SYS_Position
    {
        private readonly ISYS_Position dal = DataAccess.CreateSYS_Position();


        public int Add(SYS_PositionEntity operEntity)
        {
            return dal.Add(operEntity);
        }

        public int Delete(string PositionCode)
        {
            return dal.Delete(PositionCode);
        }


        public int Update(SYS_PositionEntity operEntity)
        {
            return dal.Update(operEntity);
        }

        public DataSet GetPositions(string OrgCode, string PositionName)
        {
              return dal.GetPositions(OrgCode,PositionName);
        }

        public void BindTreeview(TreeView treeview, string tablename, string fieldText, string fieldValue, string FatherCode, string FatherValue, string condition)
        {
             dal.BindTreeview(treeview, tablename, fieldText, fieldValue, FatherCode, FatherValue, condition);
        }

        public SYS_PositionEntity GetModel(string PositonID)
        {
            return dal.GetModel(PositonID);
        }

        public string Getresult(string FieldName, string TableName, string StrWhere)
        {
            return dal.Getresult(FieldName, TableName, StrWhere);
        }

        public int AddMenuPosition(string PositionCode, string menuID)
        {
            return dal.AddMenuPosition(PositionCode, menuID);
        }

        public int AddMenuPosition(string PositionCode, List<string> menuIDs)
        {
            return dal.AddMenuPosition(PositionCode, menuIDs);
        }
     
        public int DelMenuPosition(string PositionCode)
        {
            return dal.DelMenuPosition(PositionCode);
        }
       public  DataSet GetMenuPosition(string PositionCode)
        {
            return dal.GetMenuPosition(PositionCode);
        }


       public void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strTableName, string strPrimaryKey, string OrgCode, string PositionName, string OrgName, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl)
       {
           dal.GridViewPagerBindbyRowNumber(anpager, strTableName, strPrimaryKey, OrgCode, PositionName, OrgName, strOrderCondition, grvControl);
       }


       public void GridViewPagerBindbyRowNumber(Wuqi.Webdiyer.AspNetPager anpager, string strTableName, string strPrimaryKey, string OrgCode, string strOrderCondition, System.Web.UI.WebControls.GridView grvControl)
       {
           dal.GridViewPagerBindbyRowNumber(anpager, strTableName, strPrimaryKey, OrgCode, strOrderCondition, grvControl);
       }


       public DataSet GetList(string strwhere)
       {
           return  dal.GetList(strwhere);
       }

       public DataSet GetPositionList(string strwhere)
       {
           return dal.GetPositionList(strwhere);
       }

      


       public void BindDropChildItem(DropDownList ddl, DataTable dt, string id, int length)
       {
           DataRow[] rows = dt.Select("parentOrgCode='" + id + "'", "OrgCode ASC");//取出id子节点进行绑定   
           for (int i = 0; i < rows.Length; i++)
           {
               ddl.Items.Add(new ListItem(SpaceLength(length) + rows[i]["orgName"].ToString(), rows[i]["OrgCode"].ToString()));
               BindDropChildItem(ddl, dt, rows[i]["OrgCode"].ToString(), length + 1);//空白数目加1   
           }
       }
       //子节点前面的空白数 
       public string SpaceLength(int i)
       {
           string space = "";
           for (int j = 0; j < i; j++)
           {
               space += "--";//分层显示字符；   
           }
           return space;
       }



       /// <summary>
       /// 选择岗位绑定DropDrowList
       /// </summary>
       /// <param name="ddl"></param>
       public void PositionDllBind(DropDownList ddl, string strwhere)
       {
   
           ddl.DataSource = GetPositionList(strwhere);
           ddl.DataTextField = "PositionName";
           ddl.DataValueField = "PositionCode";
          
           ddl.DataBind();
           ddl.Items.Insert(0, new ListItem("请选择岗位名称", "0"));
       }

       public int CheckPosition(int OrgCode, string strpos, int posid)
       {
           return dal.CheckPosition(OrgCode, strpos,posid);
       }

       public int CheckPositionCode(string strPositionCode, string strPositonID)
       {
           return dal.CheckPositionCode(strPositionCode, strPositonID);
       }

    }
}
