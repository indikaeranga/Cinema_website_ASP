using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Cinema
{
    public partial class Movie_Manage : System.Web.UI.Page
    {
        ConString cn = new ConString();
        string img_path = "";
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
                    BindGridView();
                }
            }
        }
        private int radiobtn_value()
        {
            int rbvalue =1;
            if (RadioButton1.Checked)
            { rbvalue = 1; }
            else if (RadioButton2.Checked)
            { rbvalue = 0; }
            return rbvalue;
        }
        protected void bthAdd_Click(object sender, EventArgs e)
        {
            // Get values from the ASP.NET controls
            string movieName = Textmoviename.Text;
            string description = TextDescription.Text;
            int isActive = radiobtn_value();

            // Handle image upload
            string imageFileName = UploadImage();

            // Get the selected date from the Calendar control
            DateTime uploadDate = Calendar1.SelectedDate;
            int adminid = 1;
            // Create a connection to the database
            SqlConnection con = new SqlConnection(cn.connectionstring());
            using (con)
            {
                // SQL INSERT statement
                string insertQuery = "INSERT INTO Movie (Movie_Name, Movie_Description, Is_Active, Movie_Image_Location, Add_Date,Admin_ID) " +
                                     "VALUES (@MovieName, @Description, @IsActive, @ImagePath, @UploadDate, @AdminID)";

                SqlCommand command = new SqlCommand(insertQuery, con);
                command.Parameters.AddWithValue("@MovieName", movieName);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@IsActive", isActive);

                // Add the @ImagePath parameter here
                command.Parameters.AddWithValue("@ImagePath", imageFileName);
                command.Parameters.AddWithValue("@UploadDate", uploadDate);
                command.Parameters.AddWithValue("@AdminID", adminid);
                // Add parameters for ImagePath and UploadDate as needed

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
        private string UploadImage()
        {
            
            if (FileUpload1.HasFile)
            {
                try
                {
                    // Get the file name and path
                    string fileName = Path.GetFileName(FileUpload1.FileName);
                    string filePath = Server.MapPath("~/images/") + fileName;
                    


                    // Save the file to the server
                    FileUpload1.SaveAs(filePath);

                    // Return the file path to store in the database
                    img_path = "~/images/" + fileName;
                    return img_path;
                }
                catch (Exception ex)
                {
                    Response.Write("Error uploading the image: " + ex.Message);
                }
            }
            return img_path;
        }

        private void BindGridView()
        {
            //string connectionString = "YourConnectionString";
            string query = "SELECT Movie_ID,Movie_Name as 'Movie Name', Is_Active as 'Active', Add_Date as 'Date' FROM Movie";

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