using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class Viewform : Form
    {
        public Viewform()
        {
            InitializeComponent();
        }

        private void Viewform_Load(object sender, EventArgs e)
        {
            string q = "SELECT std_id, std_name,std_fname,std_gender,std_address,std_addmissiondate,ad.ad_name as 'Admin name'  from tbl_student st inner join tbl_admin ad on ad.ad_id=st.std_ad_fk_id ";
            View v = new View(q);

            dataGridView1.DataSource = v.show_record();
                

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string q1 = "SELECT std_id, std_name,std_fname,std_gender,std_address,std_addmissiondate,ad.ad_name as 'Admin name'  from tbl_student st inner join tbl_admin ad on ad.ad_id=st.std_ad_fk_id where std_name like '"+textBox1.Text+"%'";
            View v1 = new View(q1);
            dataGridView1.DataSource = v1.show_record();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string q2 = "SELECT std_id, std_name,std_fname,std_gender,std_address,std_addmissiondate,ad.ad_name as 'Admin name'  from tbl_student st inner join tbl_admin ad on ad.ad_id=st.std_ad_fk_id where std_id ="+textBox2.Text ;
            View v2 = new View(q2);
            dataGridView1.DataSource = v2.show_record();
            textBox2.Text = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string q3 = "SELECT std_id, std_name,std_fname,std_gender,std_address,std_addmissiondate,ad.ad_name as 'Admin name'  from tbl_student st inner join tbl_admin ad on ad.ad_id=st.std_ad_fk_id";
            View v3 = new View(q3);
            dataGridView1.DataSource = v3.show_record();
        }
    }
}
