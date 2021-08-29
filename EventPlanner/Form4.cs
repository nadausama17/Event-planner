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
    public partial class Form4 : Form
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        string email="";
        public Form4(string useremail)
        {
            InitializeComponent();
            email = useremail;
        }
         public Form4()
        {
            InitializeComponent();   

        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Dispose();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you realy want to delete your account ?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OracleCommand c2 = new OracleCommand();
                c2.Connection = conn;
                c2.CommandText = "Delete from ATTEND where USER_EMAIL=:email";
                c2.Parameters.Add("email", email);
                int r2 = c2.ExecuteNonQuery();
                OracleCommand c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Delete from USERR where USER_EMAIL=:email";
                c.Parameters.Add("email", email);
                int r = c.ExecuteNonQuery();
                
                if (r != -1 && r2!=-1)
                {
                    MessageBox.Show("Account Deleted");
                    conn.Dispose();
                    Form1 f = new Form1();
                    f.Show();
                    this.Hide();
                   
                }
            }
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

        private void Form4_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "AccEventsStud";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("name", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                object[] row = new object[] { dr[0], dr[1], dr[2],
           dr[3],dr[4],dr[5],dr[6] };
                dataGridView1.Rows.Add(row);
            }
            dr.Close();

            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select EVENT_ID,NAMEE from EVENT,ATTEND where ATTEND.EVENT_NO=EVENT.EVENT_ID and ATTEND.USER_EMAIL=:email";
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("email", email);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                
                dataGridView2.Rows.Add(dr2[0].ToString(), dr2[1].ToString());
            }

            dr2.Close();

            
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select F_NAME,L_NAME,PASSWORDS from USERR where USER_EMAIL=:email";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("email", Form1.username_check);
            OracleDataReader dr3 = c.ExecuteReader();
            if (dr3.Read())
            {
                textBox1.Text = dr3[0].ToString();
                textBox2.Text = dr3[1].ToString();
                textBox4.Text = dr3[2].ToString();
            }
            dr3.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool check;
            
            for (int i=0;i<dataGridView1.Rows.Count-1;i++)
            {
                try
                {
                     check = (bool)dataGridView1.Rows[i].Cells[7].Value;
                }
                catch
                {
                    check = false;
                }
                if (check==true)
                {
                    int attendno, maxstud;
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "geteveAttendance";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("eveID", dataGridView1.Rows[i].Cells[0].Value.ToString());
                    cmd.Parameters.Add("attendNO",OracleDbType.Int32,ParameterDirection.Output);
                    cmd.Parameters.Add("maxstud", OracleDbType.Int32, ParameterDirection.Output);
                    
            
                        cmd.ExecuteNonQuery();
                        attendno = Convert.ToInt32(cmd.Parameters["attendNO"].Value.ToString());
                        maxstud = Convert.ToInt32(cmd.Parameters["maxstud"].Value.ToString());
                        if (attendno==maxstud)
                        {
                            MessageBox.Show("You can't attend event " + dataGridView1.Rows[i].Cells[0].Value.ToString());
                            continue;
                        }
                        else
                        {
                            attendno++;
                        }
               
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into ATTEND values(:eventno,:email)";
                    c.Parameters.Add("eventno", dataGridView1.Rows[i].Cells[0].Value.ToString());
                    c.Parameters.Add("email", email);
                    try
                    {
                        int r2 = c.ExecuteNonQuery();

                        OracleCommand cmd2 = new OracleCommand();
                        cmd2.Connection = conn;
                        cmd2.CommandText = "update EVENT set ACTUAL_ATTEND=:attendNO where EVENT_ID=:id";
                        cmd2.Parameters.Add("attendNO", attendno);
                        cmd2.Parameters.Add("id", dataGridView1.Rows[i].Cells[0].Value.ToString());
                        int r = cmd2.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("You accept to attend event " + dataGridView1.Rows[i].Cells[0].Value.ToString() + " before");
                    }

                    
                }   
            }
            MessageBox.Show("Saved");

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Dispose();
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4(email);
            f.Show();
            this.Hide();
        }
    }
}
