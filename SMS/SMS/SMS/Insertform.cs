using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class Insertform : Form
    {
        public Insertform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            student s = new student();  
            s.sfk = Form1.fk_ad;               //gets admin name
            s.sdate = System.DateTime.Now.ToShortDateString();

            s.sname = textBox1.Text;
            s.sfname = textBox2.Text;
            if (radioButton1.Checked==true)
            {
                s.sgender = "Male";
            }
            else if (radioButton2.Checked==true)
            {
                s.sgender = "Female";
            }
            s.saddress = richTextBox1.Text;

            Insert i = new Insert();
           MessageBox.Show( i.insert_srecord(s));
            textBox1.Text = " ";
            textBox2.Text = " ";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            richTextBox1.Text = " ";
        }
    }
}
