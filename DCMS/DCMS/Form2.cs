using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace DCMS
{
    public partial class Form2 : Form
    {
        Form1 conn = new Form1();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addToolStripMenuItem.Checked == false)
            {
                addToolStripMenuItem.Checked = true;
                Form3 f3 = new Form3();
                f3.Show();
            }
            
        }

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (updateDeleteToolStripMenuItem.Checked == false)
            {
                updateDeleteToolStripMenuItem.Checked = true;
                Form4 f4 = new Form4();
                f4.Show();
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (addToolStripMenuItem1.Checked == false)
            {
                addToolStripMenuItem1.Checked = true;
                Form5 f5 = new Form5();
                f5.Show();
            }
        }

        private void updateDeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (updateDeleteToolStripMenuItem1.Checked == false)
            {
                updateDeleteToolStripMenuItem1.Checked = true;
                Form6 f6 = new Form6();
                f6.Show();
            }
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (addToolStripMenuItem2.Checked == false)
            {
                addToolStripMenuItem2.Checked = true;
                Form7 f7 = new Form7();
                f7.Show();
            }
        }

        private void updateDeleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if (updateDeleteToolStripMenuItem2.Checked == false)
            {
                updateDeleteToolStripMenuItem2.Checked = true;
                Form8 f8 = new Form8();
                f8.Show();
            }
        }

        private void addUpdateDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (addUpdateDeleteToolStripMenuItem.Checked == false)
            {
                addUpdateDeleteToolStripMenuItem.Checked = true;
                Form9 f9 = new Form9();
                f9.Show();
            }
        }

        private void addUpdateDeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (addUpdateDeleteToolStripMenuItem1.Checked == false)
            {
                addUpdateDeleteToolStripMenuItem1.Checked = true;
                Form10 f10 = new Form10();
                f10.Show();
            }
        }

        private void addUpdateDeleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {

            if (addUpdateDeleteToolStripMenuItem3.Checked == false)
            {
                addUpdateDeleteToolStripMenuItem3.Checked = true;
                Form13 f13 = new Form13();
                f13.Show();
            }
        }

        private void addUpdateDeleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if (addUpdateDeleteToolStripMenuItem2.Checked == false)
            {
                addUpdateDeleteToolStripMenuItem2.Checked = true;
                Form11 f11 = new Form11();
                f11.Show();
            }
        }

        private void updateDeleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {

            if (updateDeleteToolStripMenuItem3.Checked == false)
            {
                updateDeleteToolStripMenuItem3.Checked = true;
                Form12 f12 = new Form12();
                f12.Show();
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
