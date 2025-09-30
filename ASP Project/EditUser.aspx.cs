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
    public partial class EditUser : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UserID"] != null)
                {
                    int userId = Convert.ToInt32(Request.QueryString["UserID"]);
                    LoadUser(userId);
                }
                else
                {
                    Response.Redirect("ManageUsers.aspx");
                }
            }
        }
        private void LoadUser(int userId)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "SELECT * FROM Users WHERE UserID=@UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    hfUserID.Value = reader["UserID"].ToString();
                    txtFullName.Text = reader["FullName"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtPassword.Text = reader["Password"].ToString();

                    if (reader["Photo"] != DBNull.Value && !string.IsNullOrEmpty(reader["Photo"].ToString()))
                    {
                        imgPhoto.ImageUrl = "~/uploads/" + reader["Photo"].ToString();
                    }
                    else
                    {
                        imgPhoto.ImageUrl = "~/assets/img/default-user.png";
                    }
                }
                conn.Close();
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            int userId = Convert.ToInt32(hfUserID.Value);
            string photoFileName = null;

           
            if (fuPhoto.HasFile)
            {
                string folderPath = Server.MapPath("~/uploads/");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                photoFileName = Guid.NewGuid().ToString() + Path.GetExtension(fuPhoto.FileName);
                fuPhoto.SaveAs(Path.Combine(folderPath, photoFileName));
            }

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrEmpty(photoFileName))
                {
                    query = "UPDATE Users SET FullName=@FullName, Email=@Email, Password=@Password, Photo=@Photo WHERE UserID=@UserID";
                    cmd.Parameters.AddWithValue("@Photo", photoFileName);
                }
                else
                {
                    query = "UPDATE Users SET FullName=@FullName, Email=@Email, Password=@Password WHERE UserID=@UserID";
                }

                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            Response.Redirect("ManageUsers.aspx");
           
        }
    }
}