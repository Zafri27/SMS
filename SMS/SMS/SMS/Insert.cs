using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace SMS
{
    class Insert
    {
        private string connstring = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        public string insert_srecord(student s) 
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("insert_students", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@std_name", SqlDbType.NVarChar, 20).Value = s.sname;
                cmd.Parameters.Add("@std_fname", SqlDbType.NVarChar, 20).Value = s.sfname;
                cmd.Parameters.Add("@std_gender", SqlDbType.NVarChar, 6).Value = s.sgender;
                cmd.Parameters.Add("@std_address", SqlDbType.NVarChar, 100).Value = s.saddress;
                cmd.Parameters.Add("@std_addmissiondate", SqlDbType.NVarChar, 20).Value = s.sdate;
                cmd.Parameters.Add("@std_ad_fk_id", SqlDbType.Int).Value = s.sfk;

                conn.Open();
                cmd.ExecuteNonQuery();

                msg = "Data successfully inserted";

            }
            catch (Exception)
            {
                msg = "Data is not successfully inserted";


            }

            finally
            {
                conn.Close();
            }

            return msg;

        }

    }
}
