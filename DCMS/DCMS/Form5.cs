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
    public partial class Form5 : Form
    {
        Form1 conn = new Form1();
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = true;

            int c = 0;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(Doctor_ID) from tbl_Doctor", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            textBox1.Text = "Dr-0" + c.ToString();
            conn.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_ Doctor(Doctor_ID, Doctor_Name, Doctor_Age, Doctor_Gender, Doctor_Address, Doctor_Contact, Doctor_BloodGroup, Doctor_Speciality, Doctor_DOB)values(@Doctor_ID, @Doctor_Name, @Doctor_Age, @Doctor_Gender, @Doctor_Address, @Doctor_Contact, @Doctor_BloodGroup, @Doctor_Speciality, @Doctor_DOB);", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@Doctor_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Doctor_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Doctor_Age", textBox3.Text);
            cmd.Parameters.AddWithValue("@Doctor_Gender", textBox8.Text);
            cmd.Parameters.AddWithValue("@Doctor_Address", textBox4.Text);
            cmd.Parameters.AddWithValue("@Doctor_Contact", textBox5.Text);
            cmd.Parameters.AddWithValue("@Doctor_BloodGroup", textBox6.Text);
            
            cmd.Parameters.AddWithValue("@Doctor_Speciality", textBox7.Text);
            cmd.Parameters.AddWithValue("@Doctor_DOB", dateTimePicker1.Text);



            cmd.ExecuteNonQuery();
            MessageBox.Show("Your data has been inserted");
            conn.sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
