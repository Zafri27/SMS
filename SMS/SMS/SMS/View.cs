using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace SMS
{
    class View
    {
        private string connstring = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
        string querry;

        public View(string q)
        {
            this.querry = q;
        }

        public DataTable show_record() 
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand(querry,conn);

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
                else
                {
                    MessageBox.Show("No recors were found");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("No recors were found");
            }
            finally 
            {
                conn.Close();
            }
            return dt;
        }
    }
}
