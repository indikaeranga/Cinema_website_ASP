using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cinema
{
    public partial class Admin_Registration : System.Web.UI.Page
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
                if (Session["LoggedInUser"].ToString() != "Super Admin")
                {
                    //MessageBox(this, "You are not permitted to register administrators.");
                    Response.Redirect("Admin_Home.aspx");
                }
                else
                { 
                if (!IsPostBack)
                {
                    BindGridView();
                }
                }
            }
        }

        private  void MessageBox(System.Web.UI.Page page, string strMsg)
        {
            //+ character added after strMsg "')"
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + strMsg + "')", true);

        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string hashPassword = HashPassword(TextPassword.Text);
            string name = TextName.Text;
            string username = TextUserName.Text;
            string email = TextEmail.Text;
            try
            {

                SqlConnection con = new SqlConnection(cn.connectionstring());
                con.Open();
                string sql = "insert into Admin (name,user_name,password,email) values  ('" + name + "','" + username + "','" + hashPassword + "','" + email + "' ) ";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGridView();
                //MessageBox.Show("Data Added success");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("invalid data insert. operation fail !");

            }
        }

        public DataTable GetDataFromDatabase()
        {

            string query = "SELECT Name,User_Name,Email FROM Admin";

            using (SqlConnection connection = new SqlConnection(cn.connectionstring()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        private void BindGridView()
        {
            //string connectionString = "YourConnectionString";
            string query = "SELECT Name,User_Name as 'User Name',Email FROM Admin";

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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = GridView1.SelectedRow;
            if (selectedRow != null)
            {
                // Retrieve the data from the selected row
                string name = selectedRow.Cells[1].Text; // Modify the cell index as per your data structure
                string username = selectedRow.Cells[2].Text; // Modify the cell index as per your data structure
                string email = selectedRow.Cells[3].Text;
                

                TextName.Text = name;
                TextUserName.Text = username;
                TextEmail.Text = email;
               
                // Do something with the selected data, e.g., display it or process it
                // You can also use these values for further actions
                // movieName and description variables now contain the selected data
            }
        }
    }

}