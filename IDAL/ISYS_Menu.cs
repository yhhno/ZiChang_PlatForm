/*----------------------------------------------------------------
// Copyright (C) 2009 北京天大天科科技有限公司技术研发部
// 版权所有。 
// 文件名：
// 文件功能描述：系统菜单接口类连接数据库操作和逻辑实现
// 
// 创建标识：2009年7月6日 宋华鑫
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using IndustryPlatform.Model;

namespace IndustryPlatform.IDAL
{
    public interface ISYS_Menu
    {
        /// <summary>
        /// 是否存在特定的菜单项
        /// </summary>
        /// <param name="sMenuID">菜单编号</param>
        bool Exists(string menuID);

        /// <summary>
        /// 添加一项菜单
        /// </summary>
        /// <param name="menu">菜单实体</param>
        /// <returns>1:添加成功；0：添加失败</returns>
        int Add(SYS_MenuEntity menu);

        /// <summary>
        /// 更新一项菜单
        /// </summary>
        /// <param name="menu">菜单实体</param>
        /// <returns>1:添加成功；0：添加失败</returns>
        int Update(SYS_MenuEntity menu);

        /// <summary>
        /// 删除一项菜单
        /// </summary>
        /// <param name="menuID">菜单编号</param>
        /// <returns>:添加成功；0：添加失败</returns>
        int Delete(string menuID);

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere">查询条件不带where</param>
        /// <returns>DataSet</returns>
        DataSet GetList(string strWhere);

        /// <summary>
        /// 由菜单项编号获取该菜单项实体
        /// </summary>
        /// <param name="menuID">菜单项编号</param>
        /// <returns>菜单项实体；如果不存在该菜单项返回NULL</returns>
        SYS_MenuEntity GetModel(string menuID);

        /// <summary>
        /// 获取某个父菜单项下的所有子菜单项
        /// </summary>
        /// <param name="parentID">父菜单项编号</param>
        /// <returns>DataSet</returns>
        DataSet GetChildrenByParentID(string parentID);

        /// <summary>
        /// 由菜单项编号获取菜单项名称
        /// </summary>
        /// <param name="menuID">菜单项编号</param>
        /// <returns>菜单项名称</returns>
        string GetMenuNameByID(string menuID);

        /// <summary>
        /// 批量删除菜单项
        /// </summary>
        /// <param name="menuIDs">菜单项ID</param>
        /// <returns>1：为成功；0：为失败</returns>
        int BatchDelete(List<string> menuIDs);

        DataSet GridViewData(string strWhere, string strOrder, int row1, int row2, ref int iRowCount, List<int> PositionCode);

        /// <summary>
        /// 获取菜单项最大编号并加一
        /// </summary>
        /// <returns>Max(MenuID)+1</returns>
        string BuildMenuID();

        /// <summary>
        /// 获取父菜单项的序列号
        /// </summary>
        /// <param name="parentID">父菜单项编号</param>
        /// <returns>序列号</returns>
        string GetParentSEQ(string parentID);

        /// <summary>
        /// 获取菜单项对应的菜单项级别
        /// </summary>
        /// <param name="menuID">菜单项编号</param>
        /// <returns>菜单项级别</returns>
        int GetMenuLevel(string menuID);

        /// <summary>
        /// 判断一个菜单项是否为另一个菜单项的子菜单项
        /// </summary>
        /// <param name="menuID">菜单项编号</param>
        /// <param name="selectedMenuID">要比较的菜单项编号</param>
        /// <returns>是否是</returns>
        bool IsChildren(string menuID, string selectedMenuID);


        /// <summary>
        /// 获取菜单的所有根菜单项
        /// </summary>
        /// <param name="PositionCode">职位编号</param>
        /// <returns>DataSet</returns>
        DataSet GetRootMenuItems(List<int> PositionCode);
    }
}
