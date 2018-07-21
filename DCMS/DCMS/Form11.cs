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
    public partial class Form11 : Form
    {
        Form1 conn = new Form1();
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = true;

            int c = 0;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(Bill_ID) from tbl_Bill", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            textBox1.Text = "B-0" + c.ToString();
            conn.sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_Bill", conn.sqlConnection1);
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

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_Bill(Bill_ID,  Doctor_Name, Bill_Date,  Patient_Name, Bill_Total,Services)values(@Bill_ID, @Doctor_Name, @Bill_Date , @Patient_Name , @Bill_Total, @Services);", conn.sqlConnection1);

            cmd.Parameters.AddWithValue("@Bill_ID", textBox1.Text);
            
            cmd.Parameters.AddWithValue("@Doctor_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Bill_Date", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Patient_Name", textBox3.Text);
            

            cmd.Parameters.AddWithValue("@Bill_Total", textBox6.Text);
            cmd.Parameters.AddWithValue("@Services", textBox4.Text);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Your data has been inserted");
            conn.sqlConnection1.Close();

            conn.sqlConnection1.Open();

        }
    }
}
