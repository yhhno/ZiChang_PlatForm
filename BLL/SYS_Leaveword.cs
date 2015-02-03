using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndustryPlatform.IDAL;
using IndustryPlatform.DALFactory;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using IndustryPlatform.DBUtility;
using IndustryPlatform.Model;
namespace IndustryPlatform.BLL
{
    public class SYS_Leaveword
    {
        private readonly ISYS_Leaveword dal = DataAccess.CreateSYS_Leaveword();
        public int AddLeaveword(List<SYS_LeavewordEntity> entitys)
        {
            int result = dal.AddLeaveword(entitys);
            return result;
        }

        public SYS_LeavewordEntity getLeavewordByLid(string lid)
        {
            SYS_LeavewordEntity entity = dal.getLeavewordByLid(lid);
            return entity;
        }
    }
}
