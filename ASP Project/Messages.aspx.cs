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
    public partial class Messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMessages();
            }
        }

        private void BindMessages()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT Id, Name, Email, Subject, Message, CreatedAt FROM ContactMessages ORDER BY CreatedAt DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                gvMessages.DataSource = cmd.ExecuteReader();
                gvMessages.DataBind();
            }
        }

        protected void gvMessages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewMessage")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                LoadMessageDetails(id);
            }
        }

        private void LoadMessageDetails(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT Name, Email, Subject, Message FROM ContactMessages WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblName.Text = reader["Name"].ToString();
                    lblEmail.Text = reader["Email"].ToString();
                    lblSubject.Text = reader["Subject"].ToString();
                    lblFullMessage.Text = reader["Message"].ToString();
                }
            }

            // ✅ Trigger modal after postback
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup",
                "var modal = new bootstrap.Modal(document.getElementById('viewMessageModal')); modal.show();", true);
        }

        protected void gvMessages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvMessages.DataKeys[e.RowIndex].Value);

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "DELETE FROM ContactMessages WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            BindMessages();
        }
    }
}