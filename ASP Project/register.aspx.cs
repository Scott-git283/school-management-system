using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Project
{
    public partial class register : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e) 
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblMessage.Text = "Passwords do not match!";
                return;
            }

            string photoFileName = "";
            if (fuPhoto.HasFile)
            {
                string folderPath = Server.MapPath("~/uploads/");
                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                photoFileName = Path.GetFileName(fuPhoto.FileName);
                fuPhoto.SaveAs(Path.Combine(folderPath, photoFileName));
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "INSERT INTO Users (FullName, Email, Password, Photo, CreatedAt) " +
                           "VALUES (@FullName, @Email, @Password, @Photo, @CreatedAt)";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@FullName", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim()); 
                cmd.Parameters.AddWithValue("@Photo", photoFileName);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            ClearForm();
            lblMessage.Text = "✅ Registration successful!";
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }
    }
}