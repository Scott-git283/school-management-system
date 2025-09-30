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
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReportData();
            }
        }

        private void LoadReportData()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                // ✅ Count Students
                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Users", con);
                lblTotalStudents.Text = cmd1.ExecuteScalar().ToString();

                // ✅ Count Courses
                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM Courses", con);
                lblTotalCourses.Text = cmd2.ExecuteScalar().ToString();

                // ✅ Count Quizzes Taken
                SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM QuizResults", con);
                lblTotalQuizzes.Text = cmd3.ExecuteScalar().ToString();

                // ✅ Count Messages
                SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM ContactMessages", con);
                lblTotalMessages.Text = cmd4.ExecuteScalar().ToString();
            }
        }
    }
}