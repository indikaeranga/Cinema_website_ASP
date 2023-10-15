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

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cn.connectionstring());
            string sql = "select distinct rsn.Reservation_Id, m.Movie_Name, t.Theater_Name, rsn.Adult_Seats, rsn.Child_Seats, "+
                         " rsn.No_Of_Seats, rsn.Total_Price, LEFT(CONVERT(VARCHAR(10), ms.Showing_Date, 120), 10) , "+
                         " CONVERT(VARCHAR(8), ms.Show_Time, 108) , rsn.phone " +
                         "    from Seat_Reservation_New rsn " +
                         "    inner join Movie_Schedule ms on rsn.Schedule_ID = ms.Schedule_ID " +
                         "    inner join Movie m on m.Movie_ID = ms.Movie_ID " +
                         "    inner join Theater t on t.Theater_ID = ms.Theater_ID order by rsn.Reservation_Id desc ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("CrystalReport_All_SReserv.rpt"));
            rpt.SetDataSource(ds.Tables["table"]);
            CrystalReportViewer1.ReportSource = rpt;
            rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "All seats");

        }
    }
}