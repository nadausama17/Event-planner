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
    public partial class Form1 : Form
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        public static string username_check = "";
        string email = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            

       }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            string useremail = textBox1.Text.ToString();
            string password = textBox2.Text.ToString();
            username_check = useremail;
        //    Int32.Parse(password);
            bool test = false;
            // needed to update by disconnected mood
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select USER_EMAIL , PASSWORDS ,TYPEE from userr";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            if (useremail == "" || password == "" || (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false))
            {
                MessageBox.Show("Please Enter Email,Password and Choose option");
            }
            else
            {
                while (dr.Read())
                {
                    if (useremail == dr[0].ToString() && password == dr[1].ToString() && radioButton1.Checked && Int32.Parse(dr[2].ToString()) == 1)
                    {
                        MessageBox.Show("Welcome To Admin of the System ^_^", "Welcome Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (textBox1.Text != "" && textBox2.Text != "" && radioButton1.Checked)
                        {
                            email = useremail;
                            
                            Form2 f2 = new Form2(email);
                            
                            f2.Show();
                            this.Hide();
                            test = true;
                        }
                    }
                    else if (useremail == dr[0].ToString() && password == dr[1].ToString() && radioButton2.Checked && Int32.Parse(dr[2].ToString()) == 2)
                    {
                        MessageBox.Show("Welcome To Organizer of the System ^_^", "Welcome Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (textBox1.Text != "" && textBox2.Text != "" && radioButton2.Checked)
                        {
                            email = useremail;
                            
                            Form3 f3 = new Form3(email);
                            f3.Show();
                            this.Hide();
                           
                            test = true;
                        }
                    }
                    else if (useremail == dr[0].ToString() && password == dr[1].ToString() && radioButton3.Checked && Int32.Parse(dr[2].ToString()) == 3)
                    {
                        MessageBox.Show("Welcome To Our Student in the System ^_^", "Welcome Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (textBox1.Text != "" && textBox2.Text != "" && radioButton3.Checked)
                        {
                            email = useremail;
                            
                            Form4 f4 = new Form4(email);
                            f4.Show();
                            this.Hide();
                            test = true;
                        }
                    }

                }

                dr.Close();
               
                if (test == false)
                {
                    MessageBox.Show("Please Enter All Correct Data", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();   
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Dispose();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Dispose();

            Form5 f5 = new Form5();
            
            f5.Show();
            this.Hide();
          
        }
        
    }
}
