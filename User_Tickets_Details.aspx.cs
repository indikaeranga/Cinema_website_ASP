using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cinema
{
    public partial class User_Tickets_Details : System.Web.UI.Page
    {
        ConString cn = new ConString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (!string.IsNullOrEmpty(Request.QueryString["PN"]))
                {
                    string PhoneN;
                    if (!string.IsNullOrEmpty(Request.QueryString["PN"]))
                    {
                        // Fetch movie details from the database using the phonenumber parameter
                        PhoneN = Request.QueryString["PN"];
                        DataTable movieData = ShowBookingdetailsofclient(PhoneN);

                        if (movieData.Rows.Count > 0)
                        {
                            // Populate the UI elements with reservation data
                            DataRow row = movieData.Rows[0];
                            lblrid.Text = row["Reservation_Id"].ToString();
                            lblMoviename.Text = row["Movie_Name"].ToString();
                            lbltheater.Text = row["Theater_Name"].ToString();
                            lbldate.Text = row["Showing_Date"].ToString();
                            lbltime.Text = row["Show_Time"].ToString();
                            lbladultcount.Text = row["Adult_Seats"].ToString();
                            lblchildcount.Text = row["Child_Seats"].ToString();
                            lbltotalcount.Text = row["No_Of_Seats"].ToString();
                            lbltotprice.Text = row["Total_Price"].ToString();
                            lblphone.Text = row["phone"].ToString();
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
            // Get the label data
            string ticketData = $"Reservation ID: {lblrid.Text}\n"
                             + $"Movie Name: {lblMoviename.Text}\n"
                             + $"Theater: {lbltheater.Text}\n"
                             + $"Date: {lbldate.Text}\n"
                             + $"Time: {lbltime.Text}\n"
                             + $"Adult Count: {lbladultcount.Text}\n"
                             + $"Child Count: {lblchildcount.Text}\n"
                             + $"Total Count: {lbltotalcount.Text}\n"
                             + $"Total Price: {lbltotprice.Text}\n"
                             + $"Phone Number: {lblphone.Text}\n";

            // Create a text file with the label data
            string fileName = "TicketDetails.txt";
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", $"attachment;filename={fileName}");
            Response.Charset = "";
            Response.ContentType = "text/plain";
            Response.Output.Write(ticketData);
            Response.Flush();
            Response.End();
        }

        protected DataTable ShowBookingdetailsofclient(string Phonen)
        {
            // Replace with your database connection string
            SqlConnection con = new SqlConnection(cn.connectionstring());
            using (con)
            {
                DataTable ticketdetails = new DataTable();               
                string query = " select rsn.Reservation_Id,m.Movie_Name,t.Theater_Name,rsn.Adult_Seats,rsn.Child_Seats, rsn.No_Of_Seats,rsn.Total_Price,ms.Showing_Date,ms.Show_Time,rsn.phone  " +
                             " from Seat_Reservation_New rsn " +
                             " inner join Movie_Schedule ms on rsn.Schedule_ID=ms.Schedule_ID " +
                             " inner join Movie m on m.Movie_ID = ms.Movie_ID " +
                             " inner join Theater t on t.Theater_ID =ms.Theater_ID " +
                             " where rsn.phone = @PhoneNumber order by rsn.phone desc;";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@PhoneNumber", Phonen);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(ticketdetails);
                    }
                }
                return ticketdetails;
            }
        }

        protected void BthMail_Click(object sender, EventArgs e)
        {
           
        }
    }
}