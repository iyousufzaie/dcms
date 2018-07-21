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
    public partial class Form8 : Form
    {
        Form1 conn = new Form1();
        public Form8()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_Patient", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.sqlConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("delete from tbl_Appointment where Appointment_ID=@Appointment_ID", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@Appointment_ID", this.comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been deleted");
            conn.sqlConnection1.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select Appointment_ID from tbl_Appointment", conn.sqlConnection1);

            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Appointment_ID"]).ToString();
            }
            conn.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_Appointment where Appointment_ID='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                comboBox1.Text = dr["Appointment_ID"].ToString();
                textBox1.Text = dr[" Patient_ID"].ToString();
                textBox2.Text = dr["Patient_Name"].ToString();
                dateTimePicker1.Text = dr["Appointment_Date"].ToString();
                textBox3.Text = dr[" Appointment_Time"].ToString();
                textBox4.Text = dr[" Apopointment_Service"].ToString();
                textBox5.Text = dr["Appointment_Doctor"].ToString();


            }
            conn.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("update tbl_Appointment set  Patient_ID=@Patient_ID, Patient_Name=@Patient_Name, Appointment_Date=@Appointment_Date,Appointment_Time=@Appointment_Time, Appointment_Service=@Appointment_Service, Appointment_Doctor=@Appointment_Doctor where Appointment_ID=@Appointment_ID", conn.sqlConnection1);


           
            cmd.Parameters.AddWithValue("@Patient_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Patient_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Appointment_Date", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Appointment_Time", textBox3.Text);
            cmd.Parameters.AddWithValue("@Appointment_Service", textBox4.Text);
            cmd.Parameters.AddWithValue("@Appointment_Doctor", textBox5.Text);
            cmd.Parameters.AddWithValue("@Appointment_ID", comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been updated");
            conn.sqlConnection1.Close(); 

        }
    }
}
