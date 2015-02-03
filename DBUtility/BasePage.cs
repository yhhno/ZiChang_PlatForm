using System;
using System.Collections.Generic;
using System.Text;

namespace IndustryPlatform.DBUtility
{
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
        }
       
        protected override void OnLoad(EventArgs e)
        {
            if (Request.Cookies["uid"] == null)
            {
                CookieManager.RemoveCookie("uid");
                CookieManager.RemoveCookie("OrgCode");
                ClientScript.RegisterStartupScript(Page.GetType(), "", "parent.location.href='../';", true);
                return;
            }
            base.OnLoad(e);
        }
    }
}
