using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace EventPlanner
{
    public partial class Form7 : Form
    {
        string email="";
        CrystalReport1 cr;
        public Form7()
        {
            InitializeComponent();
        }
        

        private void Form7_Load(object sender, EventArgs e)
        {
            cr = new CrystalReport1();
            foreach(ParameterDiscreteValue v in cr.ParameterFields[0].DefaultValues)
            {
                comboBox1.Items.Add(v.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cr.SetParameterValue(0, comboBox1.Text);
            crystalReportViewer1.ReportSource = cr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form2 f = new Form2(Form1.username_check);
            f.Show();
            this.Hide();
        }
    }
}
