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
                    string EmailPN;
                    if (!string.IsNullOrEmpty(Request.QueryString["PN"]))
                    {
                        // Fetch movie details from the database using the phonenumber parameter
                        EmailPN = Request.QueryString["PN"];
                        DataTable movieData = ShowBookingdetailsofclient(EmailPN);

                        if (movieData.Rows.Count > 0)
                        {
                            // Populate the UI elements with reservation data
                            DataRow row = movieData.Rows[0];
                            lblrid.Text = row["Reservation_Id"].ToString();
                            lblMoviename.Text = row["Movie_Name"].ToString();
                            lbltheater.Text = row["Theater_Name"].ToString();
                            lbldate.Text = row["Showing_Date"].ToString().Substring(0, Math.Min(10, row["Showing_Date"].ToString().Length)); ;
                            string originalText = row["Show_Time"].ToString();
                            string remainingText = originalText.Length > 10 ? originalText.Substring(10) : string.Empty;
                            lbltime.Text = remainingText;
                            lbladultcount.Text = row["Adult_Seats"].ToString();
                            lblchildcount.Text = row["Child_Seats"].ToString();
                            lbltotalcount.Text = row["No_Of_Seats"].ToString();
                            lbltotprice.Text = row["Total_Price"].ToString();
                            lblphone.Text = row["Email"].ToString();
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
                             + $"Email Address: {lblphone.Text}\n";

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

        protected DataTable ShowBookingdetailsofclient(string mail)
        {
            // Replace with your database connection string
            SqlConnection con = new SqlConnection(cn.connectionstring());
            using (con)
            {
                DataTable ticketdetails = new DataTable();               
                string query = " select top 1 rsn.Reservation_Id,m.Movie_Name,t.Theater_Name,rsn.Adult_Seats,rsn.Child_Seats, rsn.No_Of_Seats,rsn.Total_Price,ms.Showing_Date,ms.Show_Time,rsn.Email  " +
                             " from Seat_Reservation_New rsn " +
                             " inner join Movie_Schedule ms on rsn.Schedule_ID=ms.Schedule_ID " +
                             " inner join Movie m on m.Movie_ID = ms.Movie_ID " +
                             " inner join Theater t on t.Theater_ID =ms.Theater_ID " +
                             " where rsn.Email = @Email order by rsn.Reservation_Id desc;";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Email", mail);
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

        protected void btnmail_Click(object sender, EventArgs e)
        {
            // Your Gmail credentials
            string senderEmail = "worldwidefunwwf@gmail.com";
            string senderPassword = "khde ktef zphd uiyf";

            // Recipient email address
            string recipientEmail = lblphone.Text;

            // Create a new MailMessage
            MailMessage mail = new MailMessage(senderEmail, recipientEmail);

            // Set the subject and body of the email
            mail.Subject = "Movie Tickets Booking Confirmation";
            string emailBody = "Dear Customer, <br/><br/>" +
                   "Please find your details of movie ticket booking. <br/>" +
                   "<br/> <br/>" +
                   "Reservation ID: " + lblrid.Text + "<br/>" +
                   "Movie Name: " + lblMoviename.Text + "<br/>" +
                   "Theater Name: " + lbltheater.Text + "<br/>" +
                   "Showing Date: " + lbldate.Text.Substring(0, 10) + "<br/>" +
                   "Show Time: " + lbltime.Text + "<br/>" +
                   "Adult Seats: " + lbladultcount.Text + "<br/>" +
                   "Child Seats: " + lblchildcount.Text + "<br/>" +
                   "Total Seats: " + lbltotalcount.Text + "<br/>" +
                   "Total Price: " + lbltotprice.Text + "<br/>" +
                   "<br/> <br/>" +
                   "Thank you! <br/>";

     mail.IsBodyHtml = true;  // Set the email body as HTML
            mail.Body = emailBody;

           

            // Create a new SmtpClient
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

            // Set Gmail credentials for authentication
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

            // Enable SSL to secure the connection
            smtpClient.EnableSsl = true;

            // Set the SMTP port for Gmail
            smtpClient.Port = 587;

            try
            {
                // Send the email
                smtpClient.Send(mail);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SuccessScript", "alert('Email sent successfully!');", true);

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorScript", $"alert('Error sending email: {ex.Message}');", true);

            }
        }
    }
}