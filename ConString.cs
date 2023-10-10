using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Cinema
{
    public class ConString
    {
        public string connectionstring()
        {
            string constr = @"Data Source=.\SQLEXPRESS;Initial Catalog=Cinema;Integrated Security=True";
            return constr;
        }
    }
}