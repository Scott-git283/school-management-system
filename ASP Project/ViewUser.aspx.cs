using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Project.assets.css
{
    public partial class ViewUser : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UserID"] != null)
                    LoadUser(Convert.ToInt32(Request.QueryString["UserID"]));
                else
                    Response.Redirect("ManageUsers.aspx");
            }
        }

        private void LoadUser(int userId)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserID=@UserID", conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblUserID.Text = reader["UserID"].ToString();
                    lblFullName.Text = reader["FullName"].ToString();
                    lblEmail.Text = reader["Email"].ToString();
                    lblPassword.Text = reader["Password"].ToString();
                    lblCreatedAt.Text = Convert.ToDateTime(reader["CreatedAt"]).ToString("yyyy-MM-dd");

                    imgPhoto.ImageUrl = !string.IsNullOrEmpty(reader["Photo"].ToString())
                        ? "~/uploads/" + reader["Photo"].ToString()
                        : "~/assets/img/default-user.png";
                }
            }
        }
    }
}