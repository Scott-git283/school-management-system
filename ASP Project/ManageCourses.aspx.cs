using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Project
{
    public partial class ManageCourses : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCoursesGrid();
            }
        }

        // Load all courses into GridView
        private void BindCoursesGrid()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT * FROM Courses";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridViewCourses.DataSource = dt;
                GridViewCourses.DataBind();
            }
        }

        // Add a new course
        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            string imageFileName = null;

            // Handle image upload
            if (fuImage.HasFile)
            {
                string folderPath = Server.MapPath("~/uploads/");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                imageFileName = Guid.NewGuid().ToString() + Path.GetExtension(fuImage.FileName);
                fuImage.SaveAs(Path.Combine(folderPath, imageFileName));
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"INSERT INTO Courses (Title, Category, Description, Price, ImageUrl, Rating, ReviewsCount)
                                 VALUES (@Title, @Category, @Description, @Price, @ImageUrl, @Rating, @ReviewsCount)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@Category", txtCategory.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@Price", string.IsNullOrEmpty(txtPrice.Text) ? 0 : Convert.ToDecimal(txtPrice.Text));
                cmd.Parameters.AddWithValue("@ImageUrl", (object)imageFileName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Rating", 0); // default
                cmd.Parameters.AddWithValue("@ReviewsCount", 0); // default

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            // Clear form
            txtTitle.Text = "";
            txtCategory.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";

            // Refresh Grid
            BindCoursesGrid();
        }

        // Handle edit/delete buttons
        protected void GridViewCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int courseId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "DeleteCourse")
            {
                DeleteCourse(courseId);
            }
            else if (e.CommandName == "EditCourse")
            {
                Response.Redirect("EditCourse.aspx?CourseID=" + courseId);
            }
        }

        private void DeleteCourse(int courseId)
        {
            string imagePath = null;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                // Get image filename
                string selectQuery = "SELECT ImageUrl FROM Courses WHERE CourseID=@CourseID";
                SqlCommand selectCmd = new SqlCommand(selectQuery, con);
                selectCmd.Parameters.AddWithValue("@CourseID", courseId);
                object result = selectCmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    imagePath = result.ToString();
                }

                // Delete course
                string deleteQuery = "DELETE FROM Courses WHERE CourseID=@CourseID";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, con);
                deleteCmd.Parameters.AddWithValue("@CourseID", courseId);
                deleteCmd.ExecuteNonQuery();

                con.Close();
            }

            // Delete image file from uploads
            if (!string.IsNullOrEmpty(imagePath))
            {
                string fullPath = Server.MapPath("~/uploads/" + imagePath);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }

            // Refresh grid
            BindCoursesGrid();
        }
    }
}
