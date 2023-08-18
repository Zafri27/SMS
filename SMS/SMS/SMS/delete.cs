using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace SMS
{
    class delete
    {
        private string connstring = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        public string delete_srecord(string id)
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("delete_student", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@std_id", SqlDbType.Int).Value = id;
               
                conn.Open();
                cmd.ExecuteNonQuery();

                msg = "Data succefully delted";

            }
            catch (Exception ex)
            {
                msg = "Data is not succefully Deleted" +ex.Message;


            }

            finally
            {
                conn.Close();
            }

            return msg;

        }
    }
}
