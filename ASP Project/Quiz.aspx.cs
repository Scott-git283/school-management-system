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
    public partial class Quiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourses();
            }
        }

        private void LoadCourses()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT CourseID, Title FROM Courses", con);
                con.Open();
                ddlCourses.DataSource = cmd.ExecuteReader();
                ddlCourses.DataTextField = "Title";
                ddlCourses.DataValueField = "CourseID";
                ddlCourses.DataBind();
                con.Close();
            }

            ddlCourses.Items.Insert(0, new ListItem("-- Select Course --", "0"));
        }

        protected void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCourses.SelectedValue != "0")
            {
                int courseId = Convert.ToInt32(ddlCourses.SelectedValue);
                LoadQuiz(courseId);
            }
            else
            {
                rptQuestions.DataSource = null;
                rptQuestions.DataBind();
                lblTitle.Text = "No course selected.";
                lblResult.Text = "";
            }
        }

        private void LoadQuiz(int courseId)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                // Get 10 random questions
                SqlCommand cmd = new SqlCommand(
                    "SELECT TOP 10 * FROM QuizQuestions WHERE CourseID=@CourseID ORDER BY NEWID()", con);
                cmd.Parameters.AddWithValue("@CourseID", courseId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptQuestions.DataSource = dt;
                rptQuestions.DataBind();

                // Get course title
                SqlCommand cmdCourse = new SqlCommand("SELECT Title FROM Courses WHERE CourseID=@CourseID", con);
                cmdCourse.Parameters.AddWithValue("@CourseID", courseId);
                con.Open();
                lblTitle.Text = cmdCourse.ExecuteScalar()?.ToString() ?? "Unknown Course";
                con.Close();
            }

            lblResult.Text = ""; // clear old result
        }

        protected void rptQuestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RadioButtonList rblOptions = (RadioButtonList)e.Item.FindControl("rblOptions");
                HiddenField hfOptionA = (HiddenField)e.Item.FindControl("hfOptionA");
                HiddenField hfOptionB = (HiddenField)e.Item.FindControl("hfOptionB");
                HiddenField hfOptionC = (HiddenField)e.Item.FindControl("hfOptionC");
                HiddenField hfOptionD = (HiddenField)e.Item.FindControl("hfOptionD");

                if (rblOptions != null)
                {
                    rblOptions.Items.Clear();
                    rblOptions.Items.Add(new ListItem(hfOptionA.Value, "A"));
                    rblOptions.Items.Add(new ListItem(hfOptionB.Value, "B"));
                    rblOptions.Items.Add(new ListItem(hfOptionC.Value, "C"));
                    rblOptions.Items.Add(new ListItem(hfOptionD.Value, "D"));
                }
            }
        }

        protected void btnSubmitQuiz_Click(object sender, EventArgs e)
        {
            int score = 0;
            int total = rptQuestions.Items.Count;

            foreach (RepeaterItem item in rptQuestions.Items)
            {
                RadioButtonList rblOptions = (RadioButtonList)item.FindControl("rblOptions");
                HiddenField hfCorrectAnswer = (HiddenField)item.FindControl("hfCorrectAnswer");
                Label lblFeedback = (Label)item.FindControl("lblFeedback");

                if (rblOptions != null && hfCorrectAnswer != null)
                {
                    string correctAnswer = hfCorrectAnswer.Value;

                    if (rblOptions.SelectedValue == correctAnswer)
                    {
                        score++;
                        lblFeedback.Text = "✅ Correct!";
                        lblFeedback.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblFeedback.Text = "❌ Wrong. Correct Answer: " +
                            rblOptions.Items.FindByValue(correctAnswer)?.Text;
                        lblFeedback.ForeColor = System.Drawing.Color.Red;
                    }

                    // disable options after submit
                    rblOptions.Enabled = false;
                }
            }

            double percentage = (total > 0) ? (double)score / total * 100 : 0;
            string grade = (percentage >= 90) ? "🌟 Excellent"
                        : (percentage >= 75) ? "👍 Good"
                        : (percentage >= 50) ? "🙂 Fair"
                        : "❌ Fail";

            lblResult.Text = $"Your Score: {score}/{total} ({percentage:F2}%) - {grade}";

            // save result
            SaveQuizResult(score, total, percentage, grade);
        }

        private void SaveQuizResult(int score, int total, double percentage, string grade)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(@"
            INSERT INTO QuizResults (UserEmail, CourseID, Score, TotalQuestions, Percentage, Grade)
            VALUES (@UserEmail, @CourseID, @Score, @TotalQuestions, @Percentage, @Grade)", con);

                cmd.Parameters.AddWithValue("@UserEmail", Session["UserEmail"] ?? "guest@example.com");
                cmd.Parameters.AddWithValue("@CourseID", Convert.ToInt32(ddlCourses.SelectedValue));
                cmd.Parameters.AddWithValue("@Score", score);
                cmd.Parameters.AddWithValue("@TotalQuestions", total);
                cmd.Parameters.AddWithValue("@Percentage", percentage);
                cmd.Parameters.AddWithValue("@Grade", grade);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void btnRestart_Click(object sender, EventArgs e)
        {
            ddlCourses.SelectedIndex = 0; // reset dropdown
            rptQuestions.DataSource = null;
            rptQuestions.DataBind();
            lblTitle.Text = "";
            lblResult.Text = "";
        }
    }
}
