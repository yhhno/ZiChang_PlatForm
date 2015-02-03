/*----------------------------------------------------------------
// Copyright (C) 2009 北京天大天科科技有限公司技术研发部
// 版权所有。 
// 文件名：
// 文件功能描述：系统菜单业务逻辑实现
// 
// 创建标识：2009年7月6日 宋华鑫
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IndustryPlatform.IDAL;
using IndustryPlatform.DALFactory;
using System.Web.UI.WebControls;
using IndustryPlatform.Model;
using Wuqi.Webdiyer;

namespace IndustryPlatform.BLL
{
    public class SYS_Menu
    {
        private readonly ISYS_Menu dal = DataAccess.CreateSYS_Menu();
        public SYS_Menu() { }

        /// <summary>
        /// 是否存在特定的菜单项
        /// </summary>
        /// <param name="sMenuID">菜单编号</param>
        public bool Exists(string menuID)
        {
            return dal.Exists(menuID);
        }

        /// <summary>
        /// 添加一项菜单
        /// </summary>
        /// <param name="menu">菜单实体</param>
        /// <returns>1:添加成功；0：添加失败</returns>
        public int Add(SYS_MenuEntity menu)
        {
            return dal.Add(menu);
        }

        /// <summary>
        /// 更新一项菜单
        /// </summary>
        /// <param name="menu">菜单实体</param>
        /// <returns>1:添加成功；0：添加失败</returns>
        public int Update(SYS_MenuEntity menu)
        {
            return dal.Update(menu);
        }

        /// <summary>
        /// 删除一项菜单
        /// </summary>
        /// <param name="menuID">菜单编号</param>
        /// <returns>:添加成功；0：添加失败</returns>
        public int Delete(string menuID)
        {
            return dal.Delete(menuID);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere">查询条件不带where</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 由菜单项编号获取该菜单项实体
        /// </summary>
        /// <param name="menuID">菜单项编号</param>
        /// <returns>菜单项实体；如果不存在该菜单项返回NULL</returns>
        public SYS_MenuEntity GetModel(string menuID)
        {
            return dal.GetModel(menuID);
        }

        /// <summary>
        /// 获取某个父菜单项下的所有子菜单项
        /// </summary>
        /// <param name="parentID">父菜单项编号</param>
        /// <returns>DataSet</returns>
        public DataSet GetChildrenByParentID(string parentID)
        {
            return dal.GetChildrenByParentID(parentID);
        }

        /// <summary>
        /// 获取菜单的所有根菜单项
        /// </summary>
        /// <param name="PositionCode">职位编号</param>
        /// <returns>DataSet</returns>
        public DataSet GetRootMenuItems(List<int> PositionCode)
        {
            return dal.GetRootMenuItems(PositionCode);
        }

        //子节点前面的空白数 
        public string SpaceLength(int i)
        {
            string space = "";
            for (int j = 0; j < i; j++)
            {
                space += "—";//分层显示字符；   
            }
            return space;
        }

        /// <summary>
        /// 绑定分级菜单项到下拉列表
        /// </summary>
        /// <param name="ddl">下拉列表</param>
        public void BindDdl(DropDownList ddl, List<int> PositionCode)
        {
            ddl.Items.Clear();
            DataSet dst = GetRootMenuItems(PositionCode);
            if (dst != null)
            {
                foreach (DataRow dr in dst.Tables[0].Rows)
                {
                    ddl.Items.Add(new ListItem(dr["menuName"].ToString(), dr["menuID"].ToString()));
                    BindDropChildItem(ddl, dr["menuID"].ToString(), 1);
                }
            }

            ddl.Items.Insert(0, new ListItem("请选择上级菜单项", "0"));
        }

        /// <summary>
        /// 绑定子菜单项通用方法
        /// </summary>
        /// <param name="ddl">下拉列表</param>
        /// <param name="parentID">父菜单项编号</param>
        /// <param name="length">菜单项显示最前面的空白数量</param>
        public void BindDropChildItem(DropDownList ddl, string parentID, int length)
        {
            if (GetChildrenByParentID(parentID) != null)
            {
                foreach (DataRow dr in GetChildrenByParentID(parentID).Tables[0].Select("isLeaf='0'"))
                {
                    ddl.Items.Add(new ListItem(SpaceLength(length) + dr["menuName"].ToString(), dr["menuID"].ToString()));
                    BindDropChildItem(ddl, dr["menuID"].ToString(), length + 1);
                }
            }
        }

        /// <summary>
        /// 生成菜单树
        /// </summary>
        /// <param name="tv"></param>
        public void BuildTree(TreeView tv, List<int> PositionCode)
        {
            DataSet dst = GetRootMenuItems(PositionCode);       //根菜单项
            if (dst != null)
            {
                foreach (DataRow dr in dst.Tables[0].Rows)
                {
                    TreeNode rootNode = new TreeNode(dr["menuName"].ToString(), dr["menuID"].ToString());
                    tv.Nodes.Add(rootNode);

                    //添加子菜单项
                    AddChildNodes(dr["menuID"].ToString(), rootNode);
                }
            }
        }

        /// <summary>
        /// 为父菜单项添加子菜单项
        /// </summary>
        /// <param name="parentID">父菜单项编号</param>
        /// <param name="parentNode">父菜单项节点</param>
        public void AddChildNodes(string parentID, TreeNode parentNode)
        {
            DataSet dst = GetChildrenByParentID(parentID);
            if (dst != null)
            {
                foreach (DataRow dr in dst.Tables[0].Rows)
                {
                    TreeNode childNode = new TreeNode(dr["menuName"].ToString(), dr["menuID"].ToString());
                    parentNode.ChildNodes.Add(childNode);
                    //添加子菜单项
                    AddChildNodes(dr["menuID"].ToString(), childNode);
                }
            }
        }

        /// <summary>
        /// 批量删除菜单项
        /// </summary>
        /// <param name="menuIDs">菜单项ID</param>
        /// <returns>1：为成功；0：为失败</returns>
        public int BatchDelete(List<string> menuIDs)
        {
            return dal.BatchDelete(menuIDs);
        }

        //绑定分页控件
        public void GridViewPagerBind(AspNetPager anpager, string strWhere, string strOrder, GridView grvControl,List<int> PositionCode)
        {
            int iRowCount = 0;
            int row1 = (anpager.CurrentPageIndex - 1) * anpager.PageSize + 1;
            int row2 = anpager.CurrentPageIndex * anpager.PageSize;
            grvControl.DataSource = dal.GridViewData(strWhere, strOrder, row1, row2, ref iRowCount, PositionCode);
            grvControl.DataBind();
            anpager.RecordCount = iRowCount;

            anpager.CustomInfoHTML = "共有<font color=\"blue\"><b>" + anpager.RecordCount.ToString() + "</b></font>条记录";
            anpager.CustomInfoHTML += " 总页数：<font color=\"blue\"><b>" + anpager.PageCount.ToString() + "</b></font>页";
            anpager.CustomInfoHTML += " 当前页：第<font color=\"red\"><b>" + anpager.CurrentPageIndex.ToString() + "</b></font>页";
        }

        /// <summary>
        /// 获取菜单项最大编号并加一
        /// </summary>
        /// <returns>Max(MenuID)+1</returns>
        public string BuildMenuID()
        {
            return dal.BuildMenuID();
        }

        /// <summary>
        /// 获取父菜单项的序列号
        /// </summary>
        /// <param name="parentID">父菜单项编号</param>
        /// <returns>序列号</returns>
        public string GetParentSEQ(string parentID)
        {
            return dal.GetParentSEQ(parentID);
        }

        /// <summary>
        /// 获取菜单项对应的菜单项级别
        /// </summary>
        /// <param name="menuID">菜单项编号</param>
        /// <returns>菜单项级别</returns>
        public int GetMenuLevel(string menuID)
        {
            return dal.GetMenuLevel(menuID);
        }

        /// <summary>
        /// 判断一个菜单项是否为另一个菜单项的子菜单项
        /// </summary>
        /// <param name="menuID">菜单项编号</param>
        /// <param name="selectedMenuID">要比较的菜单项编号</param>
        /// <returns>是否是</returns>
        public bool IsChildren(string menuID, string selectedMenuID)
        {
            return dal.IsChildren(menuID, selectedMenuID);
        }

        /// <summary>
        /// 由菜单项编号获取菜单项名称
        /// </summary>
        /// <param name="menuID">菜单项编号</param>
        /// <returns>菜单项名称</returns>
        public string GetMenuNameByID(string menuID)
        {
            return dal.GetMenuNameByID(menuID);
        }
    }
}
