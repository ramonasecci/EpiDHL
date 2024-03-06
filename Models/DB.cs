using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EpiDHL.Models
{
    public class DB
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["EpiDHLDBConnection"].ToString();
        public static SqlConnection conn = new SqlConnection(connectionString);
    }
}