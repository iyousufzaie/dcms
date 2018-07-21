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
    public partial class Form9 : Form
    {
        Form1 conn = new Form1();
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            this.panel1.Enabled = false;
            this.panel2.Enabled = false;


            this.textBox1.ReadOnly = true;

            conn.sqlConnection1.Open();
            
            SqlCommand cmd = new SqlCommand("Select Service_ID from tbl_Services", conn.sqlConnection1);

            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Service_ID"]).ToString();
            }
            conn.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.Enabled = true;
            this.panel2.Enabled = false;
            this.textBox1.ReadOnly = true;

            int c = 0;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(Service_ID) from tbl_Services", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            textBox1.Text = "S-0" + c.ToString();
            conn.sqlConnection1.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel2.Enabled = true;
            this.panel1.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_Services(Service_ID, Service_Name, Service_Amount)values(@Service_ID, @Service_Name, @Service_Amount);", conn.sqlConnection1);

            cmd.Parameters.AddWithValue("@Service_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Service_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Service_Amount", textBox3.Text);
            


            cmd.ExecuteNonQuery();
            MessageBox.Show("Your data has been inserted");
            conn.sqlConnection1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("delete from tbl_Services where Service_ID=@Service_ID", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@Service_ID", this.comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been deleted");
            conn.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_Services where Service_ID='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                comboBox1.Text = dr["Service_ID"].ToString();
                textBox4.Text = dr["Service_Name"].ToString();
                textBox5.Text = dr["Service_Amount"].ToString();
                


            }
            conn.sqlConnection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("update tbl_Services set Service_Name=@Service_Name, Service_Amount=@Service_Amount where Service_ID=@Service_ID ", conn.sqlConnection1);

            
            cmd.Parameters.AddWithValue("@Service_Name", textBox4.Text);
            cmd.Parameters.AddWithValue("@Service_Amount", textBox5.Text);
            cmd.Parameters.AddWithValue("@Service_ID", comboBox1.Text);

            
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been updated");
            conn.sqlConnection1.Close(); 
        }
    }
}
