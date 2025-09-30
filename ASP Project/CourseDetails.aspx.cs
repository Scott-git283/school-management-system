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
    public partial class CourseDetails : System.Web.UI.Page
    {
        protected int CourseID
        {
            get => ViewState["CourseID"] != null ? (int)ViewState["CourseID"] : 0;
            set => ViewState["CourseID"] = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && int.TryParse(Request.QueryString["id"], out int id))
            {
                CourseID = id;
                LoadCourse();
            }
        }

        private void LoadCourse()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Courses WHERE CourseID=@CourseID", con))
            {
                cmd.Parameters.AddWithValue("@CourseID", CourseID);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pnlCourse.Visible = true;
                        imgCourse.ImageUrl = string.IsNullOrEmpty(reader["ImageUrl"].ToString())
                            ? "~/assets/img/default-user.png"
                            : reader["ImageUrl"].ToString();
                        lblTitle.Text = reader["Title"].ToString();
                        lblCategory.Text = reader["Category"].ToString();
                        lblDescription.Text = reader["Description"].ToString();
                        lblPrice.Text = reader["Price"].ToString();
                        lblRating.Text = reader["Rating"].ToString();
                        lblReviews.Text = reader["ReviewsCount"].ToString();
                    }
                    else
                    {
                        lblError.Text = "Course not found.";
                        lblError.Visible = true;
                    }
                }
            }
        }

        protected void btnEnroll_Click(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null)
            {
                lblError.Text = "⚠️ Please login first to enroll.";
                lblError.Visible = true;
                return;
            }

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Enrollments (UserEmail, CourseID) VALUES (@UserEmail, @CourseID)", con))
            {
                cmd.Parameters.AddWithValue("@UserEmail", Session["UserEmail"].ToString());
                cmd.Parameters.AddWithValue("@CourseID", CourseID);

                con.Open();
                try { cmd.ExecuteNonQuery(); Response.Write("<script>alert('✅ Enrollment successful!');</script>"); }
                catch (SqlException ex)
                {
                    Response.Write(ex.Number == 2627
                        ? "<script>alert('⚠️ Already enrolled.');</script>"
                        : $"<script>alert('❌ Error: {ex.Message}');</script>");
                }
            }
        }
    }
}