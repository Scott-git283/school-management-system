using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Project
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear only session
            Session.Clear();
            Session.Abandon();

            // Redirect to login
            Response.Redirect("login.aspx");
        }
    }
}