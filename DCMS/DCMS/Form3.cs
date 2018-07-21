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
    public partial class Form3 : Form
    {
        Form1 conn = new Form1();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_Patient(Patient_ID, Patient_Name,Patient_Age, Patient_Gender, Patient_Address, Patient_Contact, Patient_BloodGroup, Patient_DOB, Patient_HealthProblem)values(@Patient_ID, @Patient_Name, @Patient_Age, @Patient_Gender, @Patient_Address, @Patient_Contact, @Patient_BloodGroup, @Patient_DOB, @Patient_HealthProblem);", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@Patient_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Patient_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Patient_Age", textBox3.Text);
            cmd.Parameters.AddWithValue("@Patient_Gender", textBox8.Text);
            cmd.Parameters.AddWithValue("@Patient_Address", textBox4.Text);
            cmd.Parameters.AddWithValue("@Patient_Contact", textBox5.Text);
            cmd.Parameters.AddWithValue("@Patient_BloodGroup", textBox6.Text);
            cmd.Parameters.AddWithValue("@Patient_DOB", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Patient_HealthProblem", textBox7.Text);
            

            cmd.ExecuteNonQuery();
            MessageBox.Show("Your data has been inserted");
            conn.sqlConnection1.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = true;

            int c = 0;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(Patient_ID) from tbl_Patient", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            textBox1.Text = "P-0" + c.ToString();
            conn.sqlConnection1.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
    }

