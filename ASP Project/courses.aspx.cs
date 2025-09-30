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
    public partial class courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCourses();
            }
        }

        private void BindCourses()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT CourseID, Title, Category, Description, ImageUrl, Rating, ReviewsCount, Price FROM Courses";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptCourses.DataSource = dt;
                rptCourses.DataBind();
            }
        }

        
        protected string GetStars(object ratingObj)
        {
            if (ratingObj == DBNull.Value) return "<i class='far fa-star'></i><i class='far fa-star'></i><i class='far fa-star'></i><i class='far fa-star'></i><i class='far fa-star'></i>";

            decimal rating = Convert.ToDecimal(ratingObj);
            int fullStars = (int)Math.Floor(rating);
            bool halfStar = (rating - fullStars) >= 0.5m;

            string stars = "";
            for (int i = 0; i < fullStars; i++)
                stars += "<i class='fas fa-star'></i>";

            if (halfStar)
                stars += "<i class='fas fa-star-half'></i>";

            int emptyStars = 5 - fullStars - (halfStar ? 1 : 0);
            for (int i = 0; i < emptyStars; i++)
                stars += "<i class='far fa-star'></i>";

            return stars;
        }

        

        protected string GetImageUrl(object imageObj)
        {
            string imageUrl = imageObj?.ToString();
            if (string.IsNullOrEmpty(imageUrl))
                return "images/placeholder.png";
            return imageUrl;
        }

       
        protected void rptCourses_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Enroll")
            {
                string courseId = e.CommandArgument.ToString();
               
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}