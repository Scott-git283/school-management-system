using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Project
{
    public partial class login : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "SELECT COUNT(*) FROM Users WHERE Email=@Email AND Password=@Password";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

                con.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count == 1)
                {
                    Session["UserEmail"] = txtEmail.Text.Trim();
                    Response.Redirect("index.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid email or password!";
                }
            }

        }
    }
}