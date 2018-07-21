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
    public partial class Form12 : Form
    {
        Form1 conn = new Form1();

        public Form12()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_Bill", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("delete from tbl_Bill where Bill_ID=@Bill_ID", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@Bill_ID", this.comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been deleted");
            conn.sqlConnection1.Close();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select Bill_ID from tbl_Bill", conn.sqlConnection1);

            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Bill_ID"]).ToString();
            }
            conn.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_Bill where Bill_ID='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                comboBox1.Text = dr["Bill_ID"].ToString();
                textBox1.Text = dr["Doctor_Name"].ToString();
                dateTimePicker1.Text = dr["Bill_Date"].ToString();
                textBox2.Text = dr["Patient_Name"].ToString();
                
                textBox5.Text = dr["Bill_Total"].ToString();
                textBox3.Text = dr["Services"].ToString();
                
                
            }
            conn.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("update tbl_Bill set Doctor_Name=@Doctor_Name , Bill_Date=@Bill_Date, Patient_Name=@Patient_Name, Bill_Total=@Bill_Total, Services=@Services where Bill_ID=@Bill_ID", conn.sqlConnection1);

            cmd.Parameters.AddWithValue("@Doctor_Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Bill_Date", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Patient_Name", textBox2.Text);


            cmd.Parameters.AddWithValue("@Bill_Total", textBox3.Text);
            cmd.Parameters.AddWithValue("@Services", textBox5.Text);

            cmd.Parameters.AddWithValue("@Bill_ID", this.comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been updated");
            conn.sqlConnection1.Close(); 
        }
    }
}
