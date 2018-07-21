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
    public partial class Form6 : Form
    {
        Form1 conn = new Form1();
        public Form6()
        {
            InitializeComponent();
        }

       

        private void Form6_Load(object sender, EventArgs e)
        {

            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select Doctor_ID from tbl_Doctor", conn.sqlConnection1);

            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Doctor_ID"]).ToString();
            }
            conn.sqlConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_Doctor where Doctor_ID='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                comboBox1.Text = dr["Doctor_ID"].ToString();
                textBox1.Text = dr[" Doctor_Name"].ToString();
                textBox2.Text = dr[" Doctor_Age"].ToString();
                textBox7.Text = dr[" Doctor_Gender"].ToString();
                textBox3.Text = dr[" Doctor_Address"].ToString();
                textBox4.Text = dr[" Doctor_Contact"].ToString();
                textBox5.Text = dr[" Doctor_BloodGroup"].ToString();
                textBox6.Text = dr[" Doctor_Speciality"].ToString();
                dateTimePicker1.Text = dr[" Doctor_DOB"].ToString();
                

            }
            conn.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("update tbl_Doctor set  Doctor_Name=@Doctor_Name, Doctor_Age=@Doctor_Age, Doctor_Gender=@Doctor_Gender, Doctor_Address=@Doctor_Address, Doctor_Contact=@Doctor_Contact, Doctor_BloodGroup=@Doctor_BloodGroup , Doctor_Speciality=@Doctor_Speciality, Patient_DOB=@Patient_DOB where Doctor_ID=@Doctor_ID", conn.sqlConnection1);

            cmd.Parameters.AddWithValue("@Doctor_Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Doctor_Age", textBox2.Text);
            cmd.Parameters.AddWithValue("@Doctor_Gender", textBox7.Text);
            cmd.Parameters.AddWithValue("@Doctor_Address", textBox3.Text);
            cmd.Parameters.AddWithValue("@Doctor_Contact", textBox4.Text);
            cmd.Parameters.AddWithValue("@Doctor_BloodGroup", textBox5.Text);
            
            cmd.Parameters.AddWithValue("@Doctor_Speciality", textBox6.Text);
            cmd.Parameters.AddWithValue("@Doctor_DOB", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Doctor_ID", this.comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been updated");
            conn.sqlConnection1.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("delete from tbl_Doctor where Doctor_ID=@Doctor_ID", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@Doctor_ID", this.comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been deleted");
            conn.sqlConnection1.Close();
        }
    }
}
