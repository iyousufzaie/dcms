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
    public partial class Form4 : Form
    {
        Form1 conn = new Form1();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select Patient_ID from tbl_Patient", conn.sqlConnection1);

            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Patient_ID"]).ToString();
            }
            conn.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_Patient where Patient_ID='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                comboBox1.Text = dr["Patient_ID"].ToString();
                textBox1.Text = dr["Patient_Name"].ToString();
                textBox2.Text = dr["Patient_Age"].ToString();
                textBox7.Text = dr["Patient_Gender"].ToString();
                textBox3.Text = dr["Patient_Address"].ToString();
                textBox4.Text = dr["Patient_Contact"].ToString();
                textBox5.Text = dr["Patient_BloodGroup"].ToString();
                dateTimePicker1.Text = dr["Patient_DOB"].ToString();
                textBox6.Text = dr["Patient_HealthProblem"].ToString();

            }
            conn.sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("delete from tbl_Patient where Patient_ID=@Patient_ID", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@Patient_ID", this.comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been deleted");
            conn.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("update tbl_Patient set  Patient_Name=@Patient_Name, Patient_Age=@Patient_Age, Patient_Gender=@Patient_Gender, Patient_Address=@Patient_Address, Patient_Contact=@Patient_Contact, Patient_BloodGroup=@Patient_BloodGroup , Patient_DOB=@Patient_DOB, Patient_HealthProblem=@Patient_HealthProblem where Patient_ID=@Patient_ID", conn.sqlConnection1);

            cmd.Parameters.AddWithValue("@Patient_Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Patient_Age", textBox2.Text);
            cmd.Parameters.AddWithValue("@Patient_Gender", textBox7.Text);
            cmd.Parameters.AddWithValue("@Patient_Address", textBox3.Text);
            cmd.Parameters.AddWithValue("@Patient_Contact", textBox4.Text);
            cmd.Parameters.AddWithValue("@Patient_BloodGroup", textBox5.Text);
            cmd.Parameters.AddWithValue("@Patient_DOB", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Patient_HealthProblem", textBox6.Text);
            
            cmd.Parameters.AddWithValue("@Patient_ID", this.comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been updated");
            conn.sqlConnection1.Close(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();        }

    }
}
