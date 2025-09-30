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
    public partial class QuizResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadResults();
            }
        }

        private void LoadResults()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(@"
                    SELECT r.Score, r.TotalQuestions, r.Percentage, r.Grade, r.AttemptDate, c.Title
                    FROM QuizResults r
                    INNER JOIN Courses c ON r.CourseID = c.CourseID
                    WHERE r.UserEmail = @UserEmail
                    ORDER BY r.AttemptDate DESC", con);

                // Get user email from Session (set during login)
                cmd.Parameters.AddWithValue("@UserEmail", Session["UserEmail"] ?? "guest@example.com");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvResults.DataSource = dt;
                gvResults.DataBind();
            }
        }
        protected void gvResults_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                string grade = e.Row.Cells[4].Text; // Grade column index (0-based: 4 = Grade)

                switch (grade)
                {
                    case "Excellent":
                        e.Row.Cells[4].CssClass = "excellent";
                        break;
                    case "Good":
                        e.Row.Cells[4].CssClass = "good";
                        break;
                    case "Fair":
                        e.Row.Cells[4].CssClass = "fair";
                        break;
                    case "Fail":
                        e.Row.Cells[4].CssClass = "fail";
                        break;
                }
            }
        }
        protected void gvResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Retake")
            {
                int courseId = Convert.ToInt32(e.CommandArgument);
                // Redirect to quiz page with selected course
                Response.Redirect($"Quiz.aspx?courseId={courseId}");
            }
        }


    }
}