using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace SMS
{
    public partial class Deleteform : Form
    {
        private string connstring = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
        public Deleteform()
        {
            InitializeComponent();
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            richTextBox1.Text = " ";

            string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
            string sql = "SELECT std_name, std_fname, std_gender, std_address FROM tbl_student WHERE std_id = " + textBox3.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        textBox1.Text = reader.GetString(0);
                        textBox2.Text = reader.GetString(1);
                        if (reader.GetString(2).Equals("Male"))
                        {
                            radioButton1.Checked = true;
                        }
                        else
                        {
                            radioButton2.Checked = true;
                        }
                        richTextBox1.Text = reader.GetString(3);
                    }
                    else
                    {
                        MessageBox.Show("No records were found");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Enter ID to search: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            delete d = new delete();
            string msg = d.delete_srecord(textBox3.Text);
            MessageBox.Show(msg);
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            richTextBox1.Text = " ";
        }
    }
}
