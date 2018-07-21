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
    public partial class Form7 : Form
    {
        Form1 conn = new Form1();
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = true;

            int c = 0;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(Appointment_ID) from tbl_Appointment", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            textBox1.Text = "AP-0" + c.ToString();
            conn.sqlConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_Patient", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_Appointment(Appointment_ID, Patient_ID, Patient_Name, Appointment_Date, Appointment_Time, Appointment_Service, Appointment_Doctor)values(@Appointment_ID, @Patient_ID, @Patient_Name, @Appointment_Date, @Appointment_Time, @Appointment_Service, @Appointment_Doctor);", conn.sqlConnection1);

            cmd.Parameters.AddWithValue("@Appointment_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Patient_ID", textBox2.Text);
            cmd.Parameters.AddWithValue("@Patient_Name", textBox3.Text);
            cmd.Parameters.AddWithValue("@Appointment_Date", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Appointment_Time", textBox4.Text);
            cmd.Parameters.AddWithValue("@Appointment_Service", textBox5.Text);
            cmd.Parameters.AddWithValue("@Appointment_Doctor", textBox6.Text);

          
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your data has been inserted");
            conn.sqlConnection1.Close();
        }
    }
}
