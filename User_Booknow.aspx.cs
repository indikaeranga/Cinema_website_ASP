using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cinema
{
    public partial class User_Booknow : System.Web.UI.Page
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
                        BindMovieScheduleData(movieId);
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
        protected DataTable GetMovieScheduleDetailsFromDatabase(int movieId)
        {
            // Replace with your database connection string
            SqlConnection con = new SqlConnection(cn.connectionstring());
            using (con)
            {
                DataTable movieData = new DataTable();
                string query = "SELECT * FROM Movie_Schedule WHERE Movie_ID = @Movie_ID";
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

        private void BindMovieScheduleData(int movieid)
        {
            // Create a connection to the database
            
            SqlConnection con = new SqlConnection(cn.connectionstring());
            using (con)
            {
                // SQL query to retrieve data from the database
                string query = "select ms.Showing_Date, ms.Show_Time , t.Theater_Name as 'Theater', ms.Schedule_ID from Movie_Schedule as ms INNER JOIN Theater as t on ms.Theater_ID = t.Theater_ID and ms.Movie_ID = '" + movieid+"'";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // Create a DataTable to hold the data
                        DataTable movieDataTable = new DataTable();

                        // Fill the DataTable with data from the database
                        adapter.Fill(movieDataTable);

                        // Bind the DataTable to the Repeater control
                        MovieRepeater.DataSource = movieDataTable;
                        MovieRepeater.DataBind();
                    }
                }
            }
        }
    }
}