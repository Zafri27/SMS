using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Insertform obj = new Insertform();
            obj.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Updateform vf = new Updateform();
            vf.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Deleteform dl = new Deleteform();
            dl.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Viewform vf = new Viewform();
            vf.Show();
        }
    }
}
