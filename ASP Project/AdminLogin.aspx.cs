using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Project
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                string query = "SELECT PasswordHash, PasswordSalt, FullName FROM Admins WHERE Email=@Email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string storedHash = dr["PasswordHash"].ToString();
                    string storedSalt = dr["PasswordSalt"].ToString();
                    string name = dr["FullName"].ToString();

                    string computedHash = HashPassword(password, storedSalt);

                    if (computedHash == storedHash)
                    {
                        Session["IsAdmin"] = true;
                        Session["AdminEmail"] = email;
                        Session["AdminName"] = name;
                        Response.Redirect("AdminDashboard.aspx");
                        return;
                    }
                }

                lblMsg.Text = "Invalid email or password.";
            }
        }

        private string HashPassword(string password, string saltBase64)
        {
            byte[] salt = Convert.FromBase64String(saltBase64);
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                return Convert.ToBase64String(pbkdf2.GetBytes(32));
            }
        }


    }
}