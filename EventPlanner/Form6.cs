using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace EventPlanner
{
    public partial class Form6 : Form
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        string email="";
        public Form6(string useremail)
        {
            InitializeComponent();
            email = useremail;
        }
        public Form6()
        {
            InitializeComponent();   

        }
        
        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Dispose();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "update USERR set  PASSWORDS=:pass , F_NAME=:first_name, L_NAME=:last_name where  USER_EMAIL=:email";
            c.Parameters.Add("pass", textBox4.Text);
            c.Parameters.Add("first_name", textBox1.Text);
            c.Parameters.Add("last_name", textBox2.Text);
            c.Parameters.Add("email", email);
            
            int r = c.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("YOUR DATA IS UPDATED");
            }
        }
        
        private void Form6_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
             OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select F_NAME,L_NAME,PASSWORDS from USERR where USER_EMAIL=:email";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("email", Form1.username_check);
            OracleDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox4.Text = dr[2].ToString();
            }
            dr.Close();

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Dispose();
            Form3 f = new Form3(email);
            f.Show();
            this.Hide();
        }
    }
}
