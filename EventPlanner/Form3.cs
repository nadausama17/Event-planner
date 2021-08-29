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
    public partial class Form3 : Form
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        string email = "";
        public Form3(string useremail)
        {
            InitializeComponent();
            email = useremail;
        }
         public Form3()
        {
            InitializeComponent();   

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Dispose();
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int maxID, newID;
            
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GetEventID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            try
            {
                maxID = Convert.ToInt32(cmd.Parameters["id"].Value.ToString());
                newID = maxID + 1;
            }
            catch
            {
                newID = 1;
            }
            
            DateTime today = DateTime.Today;
            int actual = 0;
         
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            if (dateTimePicker2.Value > today){
            cmd2.CommandText = "insert into EVENT values (:EVENT_ID, :NAMEE,:DESCRIPTION,:S_TIME,:E_TIME,:DATEE, :USER_EMAIL,:HALL_NO,:E_STATUS, :MAX_STUDENT,:ACTUAL_ATTEND)";
            try
            {
                cmd2.Parameters.Add("EVENT_ID", newID);
                cmd2.Parameters.Add("NAMEE", textBox2.Text);
                cmd2.Parameters.Add("DESCRIPTION", richTextBox1.Text);
                cmd2.Parameters.Add("S_TIME", Int32.Parse(comboBox4.SelectedItem.ToString()));
                cmd2.Parameters.Add("E_TIME", Int32.Parse(comboBox5.SelectedItem.ToString()));
                cmd2.Parameters.Add("DATEE", Convert.ToDateTime(dateTimePicker2.Value));
                cmd2.Parameters.Add("USER_EMAIL", Form1.username_check);
                cmd2.Parameters.Add("HALL_NO", null);
                cmd2.Parameters.Add("E_STATUS", 2);
                cmd2.Parameters.Add("MAX_STUDENT", Int32.Parse(textBox3.Text.ToString()));
                cmd2.Parameters.Add("ACTUAL_ATTEND", actual);

                cmd2.ExecuteNonQuery();
                MessageBox.Show("Event Send Successfully");
            }
                catch
            {
                MessageBox.Show("YOU SHOULD ENTER ALL DATA");
            }
            
            
            }
            else
                MessageBox.Show("Enter validate date");
      
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select USER_EMAIL,EVENT_ID  from EVENT  ";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() == Form1.username_check.ToString())
                {
                    comboBox1.Items.Add(Int32.Parse(dr[1].ToString()));
                }

            }

            dr.Close();
            

            
        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            conn.Dispose();
            Form6 f6 = new Form6(email);
            f6.Show();
            this.Hide();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you realy want to delete your account ?","Message",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                OracleCommand c2 = new OracleCommand();
                c2.Connection = conn;
                c2.CommandText = "Delete from Event where USER_EMAIL=:email";
                c2.Parameters.Add("email", email);
                int r2 = c2.ExecuteNonQuery();
                OracleCommand c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Delete from USERR where USER_EMAIL=:email";
                c.Parameters.Add("email",email);
                int r = c.ExecuteNonQuery();
                if (r!=-1)
                {
                    MessageBox.Show("Account Deleted");
                    conn.Dispose();
                    Form1 f = new Form1();
                    f.Show();
                    this.Hide();
                    
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string constr = "User Id=hr; Password=hr;Data source=orcl";
            string cmdstr = "";
            cmdstr = @"select NAMEE,E_STATUS from EVENT where EVENT_ID =:selected_id";

            OracleDataAdapter adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("selected_id", Int32.Parse(comboBox1.SelectedItem.ToString()));

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Dispose();
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
