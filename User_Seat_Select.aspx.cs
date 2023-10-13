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

        protected int scheduleid(int scheduleid) { return scheduleid; }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            // Get values from the ASP.NET controls
            int adult_count, child_count;

            if (int.TryParse(Textadult.Text, out adult_count) == false)
            {
                adult_count = 0;
            }
            else
            {
                adult_count = Int32.Parse(Textadult.Text);
            }

            if (int.TryParse(Textchild.Text, out child_count) == false)
            {
                child_count = 0;
            }
            else
            {
                child_count = Int32.Parse(Textchild.Text);
            }
            
            float adult_price = float.Parse(lbladultprice.Text);
            float child_price = float.Parse(lblchildprice.Text);
            string phone = txtphonenumber.Text;
            int moviescheduleid;
            if (int.TryParse(Request.QueryString["Schedule_ID"], out moviescheduleid))
            {
                moviescheduleid = moviescheduleid;
            }
            else
            {
               
            }

            float totalprice = (adult_count * adult_price) + (child_count * child_price);
            int totseat = (adult_count+ child_count);
            // Create a connection to the database
            SqlConnection con = new SqlConnection(cn.connectionstring());
            using (con)
            {
                // SQL INSERT statement
                string insertQuery = "INSERT INTO Seat_Reservation_New (Schedule_ID, Adult_Seats, Child_Seats, No_Of_Seats, Total_Price, phone) " +
                                     "VALUES (@Schedule_ID, @Adult_Seats, @Child_Seats, @No_Of_Seats, @Total_Price, @phone)";

                SqlCommand command = new SqlCommand(insertQuery, con);
                command.Parameters.AddWithValue("@Schedule_ID", moviescheduleid);
                command.Parameters.AddWithValue("@Adult_Seats", adult_count);
                command.Parameters.AddWithValue("@Child_Seats", child_count);
                command.Parameters.AddWithValue("@No_Of_Seats", totseat);
                command.Parameters.AddWithValue("@Total_Price", totalprice);
                command.Parameters.AddWithValue("@Phone", phone);
                try
                {
                    con.Open();
                    command.ExecuteNonQuery();                  
                    con.Close();
                    Response.Redirect("User_Tickets_Details.aspx?PN='"+phone+"'");
                }
                catch (Exception ex)
                {
                    string script = "alert('Incorrect details. Please try again!');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

                }
            }
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