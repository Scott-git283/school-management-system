using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Project
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Protect admin pages - if not logged in, redirect to AdminLogin
            if (Session["IsAdmin"] == null || (bool)Session["IsAdmin"] != true)
            {
                Response.Redirect("~/AdminLogin.aspx");
            }
        }
    }
}