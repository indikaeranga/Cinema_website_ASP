using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Cinema
{
    public partial class User_Home : System.Web.UI.Page
    {
        ConString cn = new ConString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMovieData(); // Call a method to bind data to the Repeater control
            }
        }


        private void BindMovieData()
        {
            // Create a connection to the database
            SqlConnection con = new SqlConnection(cn.connectionstring());
            using (con)
            {
                // SQL query to retrieve data from the database
                string query = "SELECT Movie_ID,Movie_Name, Movie_Image_Location FROM Movie";

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