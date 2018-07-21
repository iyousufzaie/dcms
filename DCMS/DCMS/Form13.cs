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
    public partial class Form13 : Form
    {
        Form1 conn = new Form1();
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            this.panel1.Enabled = false;
            this.panel2.Enabled = false;


            this.textBox1.ReadOnly = true;

            int c = 0;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(Purchase_ID) from tbl_Purchases", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            textBox1.Text = "Pu-0" + c.ToString();
            conn.sqlConnection1.Close();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.Enabled = true;
            this.panel2.Enabled = false;

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select Purchase_ID from tbl_Purchases", conn.sqlConnection1);


            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Purchase_ID"]).ToString();
            }
            conn.sqlConnection1.Close();
            this.panel2.Enabled = true;
            this.panel1.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("delete from tbl_Purchases where Purchase_ID=@Purchase_ID", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@Purchase_ID", this.comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been deleted");
            conn.sqlConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_Purchases(Purchase_ID, Purchase_Date, Purchase_Supplier, Purchase_Product, Purchase_Quantity, Purchase_Rate, Purchase_Amount)values(@Purchase_ID, @Purchase_Date, @Purchase_Supplier, @Purchase_Product, @Purchase_Quantity, @Purchase_Rate, @Purchase_Amount) ;", conn.sqlConnection1);

            cmd.Parameters.AddWithValue("@Purchase_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Purchase_Date", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Purchase_Supplier", textBox2.Text);

            cmd.Parameters.AddWithValue("@Purchase_Product", textBox3.Text);


            cmd.Parameters.AddWithValue("@Purchase_Quantity", textBox4.Text);
            cmd.Parameters.AddWithValue("@Purchase_Rate", textBox5.Text);
            cmd.Parameters.AddWithValue("@Purchase_Amount", textBox6.Text);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Your data has been inserted");
            conn.sqlConnection1.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_Purchases where Purchase_ID='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                comboBox1.Text = dr["Purchase_ID"].ToString();
                dateTimePicker2.Text = dr["Purchase_Date"].ToString();
                textBox7.Text = dr["Purchase_Supplier"].ToString();
                
                textBox8.Text = dr["Purchase_Product"].ToString();

                textBox9.Text = dr["Purchase_Quantity"].ToString();
                textBox10.Text = dr["Purchase_Rate "].ToString();
                textBox11.Text = dr["Purchase_Amount"].ToString();


            }
            conn.sqlConnection1.Close();
        }
    }
}
