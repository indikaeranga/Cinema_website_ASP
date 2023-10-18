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
    public partial class Movie_Schedule : System.Web.UI.Page
    {
        ConString cn = new ConString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInUser"] == null)
            {
                Response.Redirect("Admin_Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    // Call a function to populate the DropDownList
                    PopulateMovieDropDown();
                    // Call a function to populate the DropDownList with times
                    PopulateTimeDropDown();
                    // Call a function to populate the DropDownList with theaters
                    PopulateTheaterDropDown();
                    BindGridView();
                }
            }
           
        }

        protected void bthAdd_Click(object sender, EventArgs e)
        {
            // Get values from the ASP.NET controls
            int movierid = Int32.Parse(DropDownList1_Moviename.SelectedValue);
            int theaterid = Int32.Parse(DropDownList1_theater.SelectedValue);           
            DateTime showdate = Calendar1.SelectedDate.Date;
            DateTime movietime = Convert.ToDateTime(DropDownList2_moviescheduletime.SelectedValue);
            float adult = float.Parse(Txtadultprice.Text);
            float child = float.Parse(Txtchildprice.Text);
            // Handle image upload


            // Get the selected date from the Calendar control

            int adminid = 1;
            // Create a connection to the database
            SqlConnection con = new SqlConnection(cn.connectionstring());
            using (con)
            {
                // SQL INSERT statement
                string insertQuery = "INSERT INTO Movie_Schedule (Showing_Date, Show_Time, Adult_Ticket_Price, Child_Ticket_Price, Movie_ID,Theater_ID) " +
                                     "VALUES (@Showing_Date, @Show_Time, @Adult_Ticket_Price, @Child_Ticket_Price, @Movie_ID, @Theater_ID)";

                SqlCommand command = new SqlCommand(insertQuery, con);
                command.Parameters.AddWithValue("@Showing_Date", showdate);
                command.Parameters.AddWithValue("@Show_Time", movietime);
                command.Parameters.AddWithValue("@Adult_Ticket_Price", adult);
                command.Parameters.AddWithValue("@Child_Ticket_Price", child);
                command.Parameters.AddWithValue("@Movie_ID", movierid);
                command.Parameters.AddWithValue("@Theater_ID", theaterid);

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    BindGridView();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the insertion process
                    Response.Write("Error: " + ex.Message);
                }
            }
        }
        private void PopulateMovieDropDown()
        {
          
            string query = "SELECT Movie_ID, Movie_Name FROM Movie";

            SqlConnection con = new SqlConnection(cn.connectionstring());
            using (con)
            {
                {
                    SqlCommand command = new SqlCommand(query, con);
                    con.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int movieID = Convert.ToInt32(reader["Movie_ID"]);
                            string movieName = reader["Movie_Name"].ToString();

                            // Add each movie to the DropDownList
                            ListItem item = new ListItem(movieName, movieID.ToString());
                            DropDownList1_Moviename.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void PopulateTimeDropDown()
        {
            // Define an array of time values
            string[] times = { "10:30 AM", "2:30 PM", "6:30 PM" };

            // Clear any existing items in the DropDownList
            DropDownList2_moviescheduletime.Items.Clear();

            // Add each time to the DropDownList
            foreach (string time in times)
            {
                DropDownList2_moviescheduletime.Items.Add(new ListItem(time));
            }
        }
        private void PopulateTheaterDropDown()
        {
            // Create a dictionary to map theater IDs to values
            Dictionary<int, string> theaters = new Dictionary<int, string>
        {
            { 1, "Silver" },
            { 2, "Gold" },
            { 3, "Platinum" }
        };

            // Clear any existing items in the DropDownList
            DropDownList1_theater.Items.Clear();

            // Add each theater to the DropDownList
            foreach (var theater in theaters)
            {
                DropDownList1_theater.Items.Add(new ListItem(theater.Value, theater.Key.ToString()));
            }
        }

        private void BindGridView()
        {
            //string connectionString = "YourConnectionString";
            string query = "SELECT Schedule_ID as 'ID',LEFT(CONVERT(VARCHAR(10), Showing_Date, 120), 10) as 'Show_Date',CONVERT(VARCHAR(8), Show_Time, 108) as 'Time',Adult_Ticket_Price as 'Adult Price',Child_Ticket_Price as 'Child Price',Movie_ID as 'Movie ID',Theater_ID as 'Theater ID' FROM Movie_Schedule";

            using (SqlConnection connection = new SqlConnection(cn.connectionstring()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }
}