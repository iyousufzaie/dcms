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
    public partial class Form10 : Form
    {
        Form1 conn = new Form1();
        public Form10()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            this.panel1.Enabled = false;
            this.panel2.Enabled = false;

            this.textBox1.ReadOnly = true;

            int c = 0;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(Product_ID) from tbl_Product", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            textBox1.Text = "Pr-0" + c.ToString();
            conn.sqlConnection1.Close();


           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.Enabled = true;
            this.panel2.Enabled = false;

            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select Product_ID from tbl_Product", conn.sqlConnection1);

            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Product_ID"]).ToString();
            }
            conn.sqlConnection1.Close();
        }
    

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_Product(Product_ID, Product_Name, Product_Amount)values(@Product_ID, @Product_Name, @Product_Amount);", conn.sqlConnection1);

            cmd.Parameters.AddWithValue("@Product_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Product_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Product_Amount", textBox3.Text);
            


            cmd.ExecuteNonQuery();
            MessageBox.Show("Your data has been inserted");
            conn.sqlConnection1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("delete from tbl_Product where Product_ID=@Product_ID", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@Product_ID", this.comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been deleted");
            conn.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_Product where Product_ID='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                comboBox1.Text = dr["Product_ID"].ToString();
                textBox4.Text = dr["Product_ID"].ToString();
                textBox5.Text = dr["Product_Amount"].ToString();
                


            }
            conn.sqlConnection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("update tbl_Product set Product_Name=@Product_Name, Product_Amount=@Product_Amount where Product_ID=@Product_ID ", conn.sqlConnection1);


            cmd.Parameters.AddWithValue("@Product_Name", textBox4.Text);
            cmd.Parameters.AddWithValue("@Product_Amount", textBox5.Text);
            cmd.Parameters.AddWithValue("@Product_ID", comboBox1.Text);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been updated");
            conn.sqlConnection1.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.panel2.Enabled = true;
            this.panel1.Enabled = false;
        }
    }
}
