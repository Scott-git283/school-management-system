using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Project
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUsersGrid();
            }
        }

        // Bind GridView with Users table
        private void BindUsersGrid()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT * FROM Users";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridViewUsers.DataSource = dt;
                GridViewUsers.DataBind();
            }
        }

        // Handle Row Commands (View, Edit, Delete)
        protected void GridViewUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int userId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "View")
            {
                Response.Redirect("ViewUser.aspx?UserID=" + userId);
            }
            else if (e.CommandName == "Edit")
            {
                Response.Redirect("EditUser.aspx?UserID=" + userId);
            }
            else if (e.CommandName == "CustomDelete")  // changed
            {
                DeleteUser(userId);
                LoadUsers();
            }
        }

        private void DeleteUser(int userId)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string photoPath = null;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                // Get photo filename (if exists)
                string selectQuery = "SELECT Photo FROM Users WHERE UserID=@UserID";
                SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
                selectCmd.Parameters.AddWithValue("@UserID", userId);
                object result = selectCmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    photoPath = result.ToString();
                }

                // Delete user
                string deleteQuery = "DELETE FROM Users WHERE UserID=@UserID";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                deleteCmd.Parameters.AddWithValue("@UserID", userId);
                deleteCmd.ExecuteNonQuery();

                conn.Close();
            }

            // Delete photo file from uploads
            if (!string.IsNullOrEmpty(photoPath))
            {
                string fullPath = Server.MapPath("~/uploads/" + photoPath);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }
        }

        private void LoadUsers()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users", conn);
                conn.Open();
                GridViewUsers.DataSource = cmd.ExecuteReader();
                GridViewUsers.DataBind();
                conn.Close();
            }
        }

        // Optional: Handle row selection
        protected void GridViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(GridViewUsers.SelectedDataKey.Value);
            Response.Redirect("ViewUser.aspx?UserID=" + userId);
        }
    }
}