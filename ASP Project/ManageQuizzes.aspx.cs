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
    public partial class ManageQuizzes : System.Web.UI.Page
    {
        string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getcon();
                BindCourses();
                BindQuestions();
            }
        }

        void getcon()
        {
            con = new SqlConnection(s);
            con.Open();
        }

        void BindCourses()
        {
            getcon();
            cmd = new SqlCommand("SELECT CourseID, Title FROM Courses", con);
            dr = cmd.ExecuteReader();
            ddlCourses.DataSource = dr;
            ddlCourses.DataTextField = "Title";
            ddlCourses.DataValueField = "CourseID";
            ddlCourses.DataBind();
            con.Close();
        }

        void BindQuestions()
        {
            getcon();
            string q = @"SELECT q.QuestionID, q.QuestionText, q.OptionA, q.OptionB, q.OptionC, q.OptionD, 
                        q.CorrectOption, c.Title AS CourseTitle 
                 FROM QuizQuestions q 
                 INNER JOIN Courses c ON q.CourseID = c.CourseID";

            da = new SqlDataAdapter(q, con);
            ds = new DataSet();
            da.Fill(ds);
            gvQuestions.DataSource = ds;
            gvQuestions.DataBind();
            con.Close();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            getcon();
            cmd = new SqlCommand(@"INSERT INTO QuizQuestions 
        (CourseID, QuestionText, OptionA, OptionB, OptionC, OptionD, CorrectOption) 
        VALUES (@CourseID, @QuestionText, @OptionA, @OptionB, @OptionC, @OptionD, @CorrectOption)", con);

            cmd.Parameters.AddWithValue("@CourseID", ddlCourses.SelectedValue);
            cmd.Parameters.AddWithValue("@QuestionText", txtQuestion.Text);
            cmd.Parameters.AddWithValue("@OptionA", txtOptionA.Text);
            cmd.Parameters.AddWithValue("@OptionB", txtOptionB.Text);
            cmd.Parameters.AddWithValue("@OptionC", txtOptionC.Text);
            cmd.Parameters.AddWithValue("@OptionD", txtOptionD.Text);
            cmd.Parameters.AddWithValue("@CorrectOption", ddlCorrect.SelectedValue);

            cmd.ExecuteNonQuery();
            con.Close();

            clear();
            BindQuestions();
        }

        protected void gvQuestions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditRow")
            {
                getcon();
                cmd = new SqlCommand("SELECT * FROM QuizQuestions WHERE QuestionID=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    hfQuestionID.Value = dr["QuestionID"].ToString();
                    ddlCourses.SelectedValue = dr["CourseID"].ToString();
                    txtQuestion.Text = dr["QuestionText"].ToString();
                    txtOptionA.Text = dr["OptionA"].ToString();
                    txtOptionB.Text = dr["OptionB"].ToString();
                    txtOptionC.Text = dr["OptionC"].ToString();
                    txtOptionD.Text = dr["OptionD"].ToString();
                    ddlCorrect.SelectedValue = dr["CorrectOption"].ToString();

                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                }
                con.Close();
            }
            else if (e.CommandName == "DeleteRow")
            {
                getcon();
                cmd = new SqlCommand("DELETE FROM QuizQuestions WHERE QuestionID=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();

                BindQuestions();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            getcon();
            cmd = new SqlCommand(@"UPDATE QuizQuestions SET 
        CourseID=@CourseID, QuestionText=@QuestionText, OptionA=@OptionA, OptionB=@OptionB, 
        OptionC=@OptionC, OptionD=@OptionD, CorrectOption=@CorrectOption 
        WHERE QuestionID=@id", con);

            cmd.Parameters.AddWithValue("@CourseID", ddlCourses.SelectedValue);
            cmd.Parameters.AddWithValue("@QuestionText", txtQuestion.Text);
            cmd.Parameters.AddWithValue("@OptionA", txtOptionA.Text);
            cmd.Parameters.AddWithValue("@OptionB", txtOptionB.Text);
            cmd.Parameters.AddWithValue("@OptionC", txtOptionC.Text);
            cmd.Parameters.AddWithValue("@OptionD", txtOptionD.Text);
            cmd.Parameters.AddWithValue("@CorrectOption", ddlCorrect.SelectedValue);
            cmd.Parameters.AddWithValue("@id", hfQuestionID.Value);

            cmd.ExecuteNonQuery();
            con.Close();

            clear();
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            BindQuestions();
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        void clear()
        {
            txtQuestion.Text = "";
            txtOptionA.Text = "";
            txtOptionB.Text = "";
            txtOptionC.Text = "";
            txtOptionD.Text = "";
            ddlCorrect.SelectedIndex = 0;
            hfQuestionID.Value = "";
        }

    }
}