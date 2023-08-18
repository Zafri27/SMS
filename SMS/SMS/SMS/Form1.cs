using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class Form1 : Form
    {
        public static string fk_ad;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            string userdb;
            string passworddb;
            returnclass rc = new returnclass();
            userdb = rc.scalarReturn("select count(ad_id) from tbl_admin where ad_name = '" + user + "'");

            if (userdb.Equals("0"))
            {
                MessageBox.Show("Invalid user Name!!..");
            }
            else
            {
                passworddb = rc.scalarReturn("select ad_password from tbl_admin where ad_name = '" + user + "'");

                if (passworddb.Equals(password))
                {
                    fk_ad = rc.scalarReturn("select ad_id from tbl_admin where ad_name = '" + user + "'");
                    Form2 f2 = new Form2();
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Password!!..");
                }
            }
        }
    }
}