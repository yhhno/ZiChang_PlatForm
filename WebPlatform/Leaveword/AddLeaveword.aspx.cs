using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IndustryPlatform.Model;
using IndustryPlatform.BLL;
public partial class Leaveword_AddLeaveword : System.Web.UI.Page
{
    SYS_Leaveword leaveword;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["operid"] != null)
                loadData(Request.QueryString["operid"]);
        }
    }

    #region 加载数据
    protected void loadData(string lid)
    {
        leaveword = new SYS_Leaveword();
        SYS_LeavewordEntity entity = leaveword.getLeavewordByLid(lid);
        if (entity != null)
        {
            hf_lid.Value = entity.LeaveID;
            this.txt_LEAVEtitle.Text = entity.LeaveTitle;
            this.txt_LEAVEcontent.Text = entity.LeaveContent;
            this.hf_ReceiveID.Value = entity.ReceiveID.ToString();
            this.txt_ReceiveID.Text = entity.ReceiveID.ToString();
            this.ib_save.Visible = false;
            this.ib_cav.Visible = false;
        }
        else
            MessageBox.Show(this.Page, "加载数据失败!");
    }
    #endregion

    #region 保存数据
    protected void ib_save_Click(object sender, ImageClickEventArgs e)
    {
        List<SYS_LeavewordEntity> entitys = new List<SYS_LeavewordEntity>();
        if (hf_ReceiveID.Value == "")
        {
            MessageBox.Show(this.Page, "请选择接收人!");
            return;
        }
        string[] receiveIDs = hf_ReceiveID.Value.Split(',');
        for (int i = 0; i < receiveIDs.Length; i++)
        {
            SYS_LeavewordEntity entity = new SYS_LeavewordEntity();
            entity.LeaveTitle = this.txt_LEAVEtitle.Text.Trim();
            entity.LeaveDate = System.DateTime.Now;
            entity.LeaveContent = this.txt_LEAVEcontent.Text.Trim();
            entity.Operator = "1";
            entity.IsRead = "0";
            entity.ReceiveID = receiveIDs[i];
            entitys.Add(entity);
        }
        leaveword = new SYS_Leaveword();
        int result = leaveword.AddLeaveword(entitys);
        if (result == 1)
            MessageBox.Show(this.Page,"保存成功!");
        else
            MessageBox.Show(this.Page, "保存失败!");
    }
    #endregion
}
