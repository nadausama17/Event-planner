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
    public partial class Form5 : Form
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        public Form5()
        {
            InitializeComponent();
        }
         
        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Dispose();
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into USERR values (:USER_EMAIL,:F_NAME,:L_NAME,:TYPEE,:PASSWORDS)";
            cmd.Parameters.Add("USER_EMAIL", textBox3.Text);
            cmd.Parameters.Add("F_NAME", textBox1.Text);
            cmd.Parameters.Add("L_NAME", textBox2.Text);
            if (radioButton1.Checked)
            {
                cmd.Parameters.Add("TYPEE", 2);
            }
            if (radioButton2.Checked)
            {
                cmd.Parameters.Add("TYPEE", 3);
            }
            cmd.Parameters.Add("PASSWORDS", textBox4.Text);
            
            int r = cmd.ExecuteNonQuery();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && (radioButton1.Checked || radioButton2.Checked))
            {
                // Check The email is unique 
                MessageBox.Show("Done ^__* ", "Successfull Registeration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Dispose();
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
               
            }

            else
            {
                MessageBox.Show("Plese Enter All Data", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Dispose();
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
