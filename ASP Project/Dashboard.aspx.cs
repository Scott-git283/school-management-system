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
    public partial class Dashboard : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Uncomment if you want login restriction
                // if (Session["UserEmail"] == null)
                // {
                //     Response.Redirect("login.aspx");
                // }

                LoadProfile();
                LoadCourses();
                LoadResults();
                CalculateQuizProgress();
            }
        }

        void LoadProfile()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT FullName, Email, Photo FROM Users WHERE Email=@Email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", Session["UserEmail"]?.ToString() ?? "demo@example.com");
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblName.Text = dr["FullName"].ToString();
                    lblEmail.Text = dr["Email"].ToString();

                    string photoFileName = dr["Photo"].ToString();
                    if (!string.IsNullOrEmpty(photoFileName))
                        profilePic.ImageUrl = "~/uploads/" + photoFileName;                    // <-- uploads folder
                    else
                        profilePic.ImageUrl = "~/uploads/default-profile.png"; // fallback image
                }
            }
        }


        void LoadCourses()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT Title, Category FROM Courses";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvCourses.DataSource = dt;
                gvCourses.DataBind();
            }
        }

        void LoadResults()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT CourseID, Score, TotalQuestions, Percentage, Grade, AttemptDate FROM QuizResults WHERE UserEmail=@Email";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@Email", Session["UserEmail"]?.ToString() ?? "demo@example.com");
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvResults.DataSource = dt;
                gvResults.DataBind();
            }
        }

        void CalculateQuizProgress()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string queryTotal = "SELECT COUNT(*) FROM Courses";
                string queryTaken = "SELECT COUNT(*) FROM QuizResults WHERE UserEmail=@Email";
                SqlCommand cmdTotal = new SqlCommand(queryTotal, con);
                SqlCommand cmdTaken = new SqlCommand(queryTaken, con);
                cmdTaken.Parameters.AddWithValue("@Email", Session["UserEmail"]?.ToString() ?? "demo@example.com");

                con.Open();
                int total = Convert.ToInt32(cmdTotal.ExecuteScalar());
                int taken = Convert.ToInt32(cmdTaken.ExecuteScalar());
                con.Close();

                int progress = (total > 0) ? (int)((double)taken / total * 100) : 0;
                progressFill.Style["width"] = progress + "%";
                progressFill.InnerText = progress + "%";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("login.aspx");
        }
    }
}