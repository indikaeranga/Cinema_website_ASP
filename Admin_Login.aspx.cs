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
using System.Security.Cryptography;

namespace Cinema
{
    public partial class Admin_Login1 : System.Web.UI.Page
    {
        ConString cn = new ConString();
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = Textusername.Text;
            string pass = Textpassword.Text;
            if (username != "" && pass != "")
            {
                string hashPassword = HashPassword(pass);
                try
                {
                    SqlConnection con = new SqlConnection(cn.connectionstring());
                    con.Open();
                    string sql = "select Name from Admin where user_name='" + username + "' and password='" + hashPassword + "' ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        con.Close();
                        Session["LoggedInUser"] = dt.Rows[0][0].ToString();
                        Response.Redirect("Admin_Home.aspx");
                    }
                    else
                    {
                        // Display an error message if login details are incorrect
                        string script = "alert('Incorrect login details. Please try again!');";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

                    }
                }
                catch (Exception ex)
                {

                    
                }
            }
            else {}
        }

    }
}