using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace SMS
{
    class Update
    {
        private string connstring = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;


        public string update_srecord(student s)
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("update_student", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@std_id", SqlDbType.Int).Value = s.sid;
                cmd.Parameters.Add("@std_name", SqlDbType.NVarChar, 20).Value = s.sname;
                cmd.Parameters.Add("@std_fname", SqlDbType.NVarChar, 20).Value = s.sfname;
                cmd.Parameters.Add("@std_gender", SqlDbType.NVarChar, 6).Value = s.sgender;
                cmd.Parameters.Add("@std_address", SqlDbType.NVarChar, 100).Value = s.saddress;
                
                conn.Open();
                cmd.ExecuteNonQuery();  

                msg = "Data succefully updated";

            }
            catch (Exception)
            {
                msg = "Data is not succefully updated";


            }

            finally
            {
                conn.Close();
            }

            return msg;

        }
    }
}
