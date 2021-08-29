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
    public partial class Form2 : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        string email="";
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string useremail)
        {
            InitializeComponent();
            email = useremail;

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Dispose();
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {



        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            textBox1.Text = Form1.username_check;

            int maxID, newID;
            OracleCommand cmd3 = new OracleCommand();
            cmd3.Connection = conn;
            cmd3.CommandText = "GetEventID";
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
            cmd3.ExecuteNonQuery();
            try
            {
                maxID = Convert.ToInt32(cmd3.Parameters["id"].Value.ToString());
                newID = maxID + 1;
            }
            catch
            {
                newID = 1;
            }
            textBox4.Text = newID.ToString();

            
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select ID_HALL,HALL_NAME,NO_CHAIRS,USER_EMAIL  from HALL";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(Int32.Parse(dr[0].ToString()));
                dataGridView1.Rows.Add(dr[1].ToString(), dr[3].ToString(), Int32.Parse(dr[2].ToString()), Int32.Parse(dr[0].ToString()));
            }

            dr.Close();
            



            string constr = "Data source=orcl;User Id=hr; Password=hr;";
            string cmdstr = "";
            cmdstr = "select NAMEE,DATEE,S_TIME,E_TIME,E_STATUS,EVENT_ID,USER_EMAIL,DESCRIPTION,MAX_STUDENT,HALL_NO,ACTUAL_ATTEND  from EVENT";
            adapter = new OracleDataAdapter(cmdstr, constr);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];

           


            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select EVENT_ID,E_STATUS  from EVENT";
            cmd2.CommandType = CommandType.Text;
            OracleDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                string state = "";
                if (Int32.Parse(dr2[1].ToString()) == 1)
                {
                    state = "Accepted";
                }
                else if (Int32.Parse(dr2[1].ToString()) == 2)
                {
                    state = "Pending";
                }
                else if (Int32.Parse(dr2[1].ToString()) == 3)
                {
                    state = "Rejected";
                }

                dataGridView3.Rows.Add(Int32.Parse(dr2[0].ToString()), state);
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Hall Name" || textBox2.Text == "" || textBox3.Text == "Chairs Number" || textBox3.Text == "" )
            {

                MessageBox.Show("You Should Enter Hall Name and Number of Chairs");
            }
            else
            {
                int maxID, newID;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "GetHallID";
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

                try
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Insert_Hall";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("HID", newID);
                    c.Parameters.Add("HName", textBox2.Text);
                    c.Parameters.Add("Aemail", email);
                    c.Parameters.Add("Nchairs", textBox3.Text);
                    c.ExecuteNonQuery();
                    MessageBox.Show("Hall Stored Successfully");
                }
                catch
                {
                    MessageBox.Show("Enter All Data");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try{
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "update_hall";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("HID", comboBox1.SelectedItem.ToString());
            c.Parameters.Add("HName", textBox2.Text);
            c.Parameters.Add("Aemail", textBox1.Text);
            c.Parameters.Add("Nchairs", textBox3.Text);
            c.ExecuteNonQuery();
            MessageBox.Show("Hall Updated Successfully");
            }
            catch
            {
                MessageBox.Show("You Should Choose an ID from Combobox");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Items.Clear();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "ViewHallID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try{
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "Delete_hall";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("HID", comboBox1.SelectedItem.ToString());
            c.ExecuteNonQuery();
            MessageBox.Show("Hall Deleted Successfully");
            }
            catch
            {
                MessageBox.Show("You Should Choose an ID from Combobox");
            }
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
           /* textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select HALL_NAME , NO_CHAIRS , USER_EMAIL from HALL where ID_HALL=:id";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("id",comboBox1.SelectedItem.ToString());
            OracleDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr[0].ToString();
                textBox3.Text = dr[1].ToString();
                textBox1.Text = dr[2].ToString();
            }
            dr.Close();
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Dispose();
            Form7 f = new Form7();
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Dispose();
            Form2 f = new Form2(email);
            f.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Dispose();
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
