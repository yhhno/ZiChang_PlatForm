using System;
using System.Collections.Generic;
using System.Text;
using IndustryPlatform.Model;
namespace IndustryPlatform.IDAL
{
    public interface ISYS_Leaveword
    {
        int AddLeaveword(List<SYS_LeavewordEntity> entitys);
        SYS_LeavewordEntity getLeavewordByLid(string lid);
    }
}
