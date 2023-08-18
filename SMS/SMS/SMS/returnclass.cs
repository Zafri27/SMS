using System;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SMS
{
    class returnclass
    {
        private string connstring = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
        public string scalarReturn(string q)
        {
            
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(q, conn);
            string s = cmd.ExecuteScalar().ToString();
            return s;
        }
    }
}
