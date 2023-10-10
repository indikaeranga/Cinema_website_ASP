using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Cinema
{
    public partial class User_Movie_Detail : System.Web.UI.Page
    {
        ConString cn = new ConString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if Movie_ID parameter is provided in the query string
                if (!string.IsNullOrEmpty(Request.QueryString["Movie_ID"]))
                {
                    int movieId;
                    if (int.TryParse(Request.QueryString["Movie_ID"], out movieId))
                    {
                        // Fetch movie details from the database using the Movie_ID parameter
                        DataTable movieData = GetMovieDetailsFromDatabase(movieId);

                        if (movieData.Rows.Count > 0)
                        {
                            // Populate the UI elements with movie data
                            DataRow row = movieData.Rows[0];
                            MovieTitle.Text = row["Movie_Name"].ToString();
                            MovieDescription.Text = row["Movie_Description"].ToString();
                            MovieImage.ImageUrl = row["Movie_Image_Location"].ToString();
                        }
                        else
                        {
                            // Handle the case where no data is found for the provided Movie_ID
                        }
                    }
                    else
                    {
                        // Handle the case where Movie_ID is not a valid integer
                    }
                }
                else
                {
                    // Handle the case where Movie_ID parameter is missing in the query string
                }
            }
        }
        protected DataTable GetMovieDetailsFromDatabase(int movieId)
        {
            // Replace with your database connection string
            SqlConnection con = new SqlConnection(cn.connectionstring());
            using (con)
            {
                DataTable movieData = new DataTable();
                string query = "SELECT * FROM Movie WHERE Movie_ID = @Movie_ID";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Movie_ID", movieId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(movieData);
                    }
                }
                return movieData;
            }
        }
    }
}