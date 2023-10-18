using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

namespace Cinema
{
    public partial class Admin_Seat_res_Report : System.Web.UI.Page
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
                    PopulateMovieDropDown();
                    Load_Future_Movie_buttons();
                }
            }
           
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {


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
        protected void BtnAllSeats_Click(object sender, EventArgs e) // report uses stored procedure to retrive data
        {
            SqlConnection con = new SqlConnection(cn.connectionstring());
            SqlCommand cmd = new SqlCommand("SelectAllSeat_Reservation", con);
            cmd.CommandType = CommandType.StoredProcedure;          
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("CrystalReport_All_SReserv.rpt"));
            rpt.SetDataSource(ds.Tables["table"]);
            CrystalReportViewer1.ReportSource = rpt;
            rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "All seats");
        }

        protected void Btnbymovie_Click(object sender, EventArgs e)
        {
            int movieid = Int32.Parse(DropDownList1_Moviename.SelectedValue);
            SqlConnection con = new SqlConnection(cn.connectionstring());
            SqlCommand cmd = new SqlCommand("Future_res_by_Movie_Name", con);
            cmd.CommandType = CommandType.StoredProcedure;
            // Add the parameter for Movie_ID
            cmd.Parameters.Add(new SqlParameter("@Movie", SqlDbType.Int));
            cmd.Parameters["@Movie"].Value = movieid;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("CrystalReport_by_Movie.rpt"));
            rpt.SetDataSource(ds.Tables["table"]);
            CrystalReportViewer1.ReportSource = rpt;
            rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "All seats");
        }
        private void BindMovieScheduleData(int movieid)
        {
            // Create a connection to the database

            SqlConnection con = new SqlConnection(cn.connectionstring());
            using (con)
            {
                // SQL query to retrieve data from the database
                string query = "select ms.Showing_Date, ms.Show_Time , t.Theater_Name as 'Theater', ms.Schedule_ID from Movie_Schedule as ms INNER JOIN Theater as t on ms.Theater_ID = t.Theater_ID and ms.Movie_ID = '" + movieid + "'";

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

        private void Load_Future_Movie_buttons() {

            SqlConnection con = new SqlConnection(cn.connectionstring());
            SqlCommand cmd = new SqlCommand("ALL_FUTURE_MOVIE_SCHEDULE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable movieDataTable = new DataTable();
            da.Fill(movieDataTable);
            MovieRepeater.DataSource = movieDataTable;
            MovieRepeater.DataBind();

        }

        protected void MovieRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {

                string idi  = e.CommandArgument.ToString();
                int scheduleId = Convert.ToInt32(idi);

                // Retrieve the Schedule_ID from the CommandArgument
                // int scheduleId = Convert.ToInt32(e.CommandArgument);
                SqlConnection con = new SqlConnection(cn.connectionstring());
                SqlCommand cmd = new SqlCommand("LIST_MOVIE_BY_SCHEDULE_LOOP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add the parameter for Movie_ID
                cmd.Parameters.Add(new SqlParameter("@Scheduleid", SqlDbType.Int));
                cmd.Parameters["@Scheduleid"].Value = scheduleId;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ReportDocument rpt = new ReportDocument();
                rpt.Load(Server.MapPath("CrystalReport_List_Movie_schedule_loop.rpt"));
                rpt.SetDataSource(ds.Tables["table"]);
                CrystalReportViewer1.ReportSource = rpt;
                rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "All seats");
            }
        }
    
            
        }
}