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
    public partial class AdminSetup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string name = txtName.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblInfo.Text = "Email and password are required.";
                return;
            }

            string salt = CreateSalt();
            string hash = HashPassword(password, salt);

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "INSERT INTO Admins (Email, PasswordHash, PasswordSalt, FullName) VALUES (@Email,@Hash,@Salt,@Name)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Hash", hash);
                cmd.Parameters.AddWithValue("@Salt", salt);
                cmd.Parameters.AddWithValue("@Name", name);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Admin created. Delete this page for security.";
                }
                catch (SqlException ex)
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Error: " + ex.Message;
                }
            }
        }

        private string CreateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        private string HashPassword(string password, string saltBase64)
        {
            byte[] salt = Convert.FromBase64String(saltBase64);
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(32);
                return Convert.ToBase64String(hash);
            }
        }
    }
}