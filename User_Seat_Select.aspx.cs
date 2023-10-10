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
    public partial class User_Seat_Select : System.Web.UI.Page
    {
        ConString cn = new ConString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if Movie_ID parameter is provided in the query string
                if (!string.IsNullOrEmpty(Request.QueryString["Schedule_ID"]))
                {
                    int ScheduleID;
                    if (int.TryParse(Request.QueryString["Schedule_ID"], out ScheduleID))
                    {
                        // Fetch movie details from the database using the Movie_ID parameter
                        DataTable movieData = GetMovieticketpriceFromDatabase(ScheduleID);

                        if (movieData.Rows.Count > 0)
                        {
                            // Populate the UI elements with movie data
                            DataRow row = movieData.Rows[0];
                            lbladultprice.Text = row["Adult_Ticket_Price"].ToString();
                            lblchildprice.Text = row["Child_Ticket_Price"].ToString();
                          
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

        protected void BtnAdd_Click(object sender, EventArgs e)
        {

        }
        protected DataTable GetMovieticketpriceFromDatabase(int ScheduleID)
        {
            // Replace with your database connection string
            SqlConnection con = new SqlConnection(cn.connectionstring());
            using (con)
            {
                DataTable ticketprice = new DataTable();
                string query = "select Adult_Ticket_Price, Child_Ticket_Price from Movie_Schedule where Schedule_ID=@ScheduleID";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@ScheduleID", ScheduleID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(ticketprice);
                    }
                }
                return ticketprice;
            }
        }




    }
}