using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.UI;
using IndustryPlatform.IDAL;
using IndustryPlatform.DALFactory;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using IndustryPlatform.DBUtility;
using System.Web;

namespace IndustryPlatform.BLL
{
    /// <summary>
    /// 业务逻辑类SYS_Organization 的摘要说明。
    /// </summary>
    public class SYS_Organization
    {
        private readonly ISYS_Organization dal = DataAccess.CreateSYS_Organization();
        public SYS_Organization()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string OrgCode)
        {
            return dal.Exists(OrgCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(IndustryPlatform.Model.SYS_Organization model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int  Update(IndustryPlatform.Model.SYS_Organization model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(string OrgCode)
        {
            return dal.Delete(OrgCode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public IndustryPlatform.Model.SYS_Organization GetModel(string OrgCode)
        {

            return dal.GetModel(OrgCode);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 组织机构树绑定
        /// </summary>
        /// <param name="pOrgCode"></param>
        /// <param name="node"></param>
        /// <param name="tv"></param>
        public void OrgTreeBind(string pOrgCode, TreeNode node, TreeView tv)
        {
            DataSet dsOrg = GetList("parentOrgCode=" + pOrgCode );
            if (dsOrg != null)
            {
                if (dsOrg.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsOrg.Tables[0].Rows)
                    {
                        TreeNode n = new TreeNode(dr["orgName"].ToString(), dr["OrgCode"].ToString());
                        n.Selected = false;
                        if (pOrgCode == "-1")
                        {
                            tv.Nodes.Add(n);
                            OrgTreeBind(dr["OrgCode"].ToString(), n, tv);
                        }
                        else
                        {
                            node.ChildNodes.Add(n);
                            OrgTreeBind(dr["OrgCode"].ToString(), n, tv);
                        }
                    }
                }
            }
        }

        public void OrgTreeBind(TreeView tv)
        {
            tv.Nodes.Clear();
            if (CookieManager.GetCookieValue("uid") != "0")
            {
                IndustryPlatform.Model.SYS_Organization m = GetModel(CookieManager.GetCookieValue("orgID"));
                TreeNode n = new TreeNode(m.OrgName, m.OrgCode);
                tv.Nodes.Add(n);
                OrgTreeBind(m.OrgCode, n, tv);
            }
            else
                OrgTreeBind("-1", (TreeNode)null, tv);
            tv.ExpandAll();
        }



        /// <summary>
        /// 选择父级节点时绑定DropDrowList
        /// </summary>
        /// <param name="ddl"></param>
        public void OrgDllBind(DropDownList ddl)
        {
            ddl.Items.Clear();
            string strWhere = "ORGstatus='0' ";
            DataTable dt = GetList(strWhere).Tables[0];

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["parentOrgCode"].ToString().Trim() == "0")//绑定根节点   
                    {
                        ddl.Items.Add(new ListItem(dr["orgName"].ToString(), dr["OrgCode"].ToString()));
                        BindDropChildItem(ddl, dt, dr["OrgCode"].ToString(), 1);
                    }
                }
            }
            ddl.Items.Insert(0, new ListItem("请选择机构", "0"));
        }

        public void OrgDllBind(DropDownList ddl, string SEQ,string pid)
        {
            ddl.Items.Clear();
            string strWhere = "1=1 ";
            if (SEQ != "")
                strWhere += " and orgSEQ like '" + SEQ + "%'";
            DataTable dt = GetList(strWhere).Tables[0];

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["parentOrgCode"].ToString().Trim() == pid)//绑定根节点   
                    {
                        ddl.Items.Add(new ListItem(dr["OrgName"].ToString(), dr["OrgCode"].ToString()));
                        BindDropChildItem(ddl, dt, dr["OrgCode"].ToString(), 1);
                    }
                }
            }
            if (SEQ == "")  //如果是超级管理员，默认添加根节点
                ddl.Items.Insert(0, new ListItem("请选择机构", "0"));
            else   //如果不是超级管理员，默认添加的是第一级子节点
            {
                //string strDefault = CookieManager.GetCookieValue("OrgCode");
                //ddl.Items.Insert(0, new ListItem("请选择机构", strDefault));
            }
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
        /// 判断某一机构下是否有岗位
        /// </summary>
        /// <param name="OrgCode"></param>
        /// <returns></returns>
        public int GetPositionCountByOrgCode(string OrgCode)
        {
            return dal.GetPositionCountByOrgCode(OrgCode);
        }

        /// <summary>
        /// 判断某一机构下是否有人员
        /// </summary>
        /// <param name="OrgCode"></param>
        /// <returns></returns>
        public int GetOperatorCountByOrgCode(string OrgCode)
        {
            return dal.GetOperatorCountByOrgCode(OrgCode);
        }

        /// <summary>
        /// 判断组织代码是否存在
        /// </summary>
        /// <param name="orgCode"></param>
        /// <param name="OrgCode"></param>
        /// <returns></returns>
        public int ExistOrgCode(string orgCode)
        {
            return dal.ExistOrgCode(orgCode);
        }


        /// <summary>
        /// 组织的GridView绑定
        /// </summary>
        /// <param name="anpager"></param>
        /// <param name="strWhere"></param>
        /// <param name="strOrder"></param>
        /// <param name="grvControl"></param>
        public void GridViewPagerBind(AspNetPager anpager, string strWhere, string strOrder, GridView grvControl)
        {
            int iRowCount = 0;
            int row1 = (anpager.CurrentPageIndex - 1) * anpager.PageSize + 1;
            int row2 = anpager.CurrentPageIndex * anpager.PageSize;
            grvControl.DataSource = dal.GridViewData(strWhere, strOrder, row1, row2, ref iRowCount);
            grvControl.DataBind();
            anpager.RecordCount = iRowCount;

            anpager.CustomInfoHTML = "共<font color=\"blue\"><b>" + anpager.RecordCount.ToString() + "</b></font>条记录";
            anpager.CustomInfoHTML += " 共<font color=\"blue\"><b>" + anpager.PageCount.ToString() + "</b></font>页";
            anpager.CustomInfoHTML += " 当前第<font color=\"red\"><b>" + anpager.CurrentPageIndex.ToString() + "</b></font>页";
        }

        #endregion  成员方法
    }
}

