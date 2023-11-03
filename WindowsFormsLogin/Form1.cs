using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace WindowsFormsLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\tassawer\documents\visual studio 2013\Projects\WindowsFormsLogin\WindowsFormsLogin\WindowFormLogin.mdf;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            // Step 01: Create Connection 
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // Step 02: Get Values from form attributes
            string userName = textBox1.Text;
            string pwd = textBox2.Text;

            // Step 03: Write query by SQL Parameters
            string query = "select * from users where Name = @uName and Password = @password";
            SqlParameter p1 = new SqlParameter("uName", userName);
            SqlParameter p2 = new SqlParameter("password", pwd);

            // Step 04: Execute Command
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            SqlDataReader reader = cmd.ExecuteReader();

            // Step 05: Checking the result
            if (reader.HasRows)
            {
                MessageBox.Show("Authenticated :)");
            }
            else
            {
                MessageBox.Show("Invalid UserName or Password");
            }
        }

    }
}
