using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Form1 : Form
    {
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            this.datenbankZugriff();
        }

        public void datenbankZugriff()
        {
            try
            {
                this.dataSet1.Tables.Remove("tFrage");
                oleDbDataAdapter1.Fill(this.dataSet1);
            }
            catch (Exception)
            {
                oleDbDataAdapter1.Fill(this.dataSet1);
            }

            frageFüllen();
        }

        private void frageFüllen()
        {
            DataRow r = this.dataSet1.Tables["tFrage"].Rows[0];
            listBox1.Items.Add(r["Frage"].ToString());
            radio_Antwort1.Text = r["Antwort1"].ToString();
            radio_Antwort2.Text = r["Antwort2"].ToString();
            radio_Antwort3.Text = r["Antwort3"].ToString();
            radio_Antwort4.Text = r["Antwort4"].ToString();
            i++;
            zeit_ablauf();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void zeit_ablauf()
        {
            do
            {
                System.Threading.Thread.Sleep(10000);
                progressBar1.PerformStep();
            } while (progressBar1.Value != progressBar1.Minimum);
            if (progressBar1.Value == progressBar1.Minimum)
                test();

        }

        private void test()
        {
            if (!radio_Antwort1.Checked && !radio_Antwort2.Checked && !radio_Antwort3.Checked && !radio_Antwort4.Checked)
            {
                
            }
            if (radio_Antwort1.Checked)
            {
                int score = Convert.ToInt32(textBox1.Text);
                score += 1;
                textBox1.Text = score.ToString();
            }

            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DataRow r = this.dataSet1.Tables["tFrage"].Rows[i];
            listBox1.Items.Add(r["Frage"].ToString());
            radio_Antwort1.Text = r["Antwort1"].ToString();
            radio_Antwort2.Text = r["Antwort2"].ToString();
            radio_Antwort3.Text = r["Antwort3"].ToString();
            radio_Antwort4.Text = r["Antwort4"].ToString();
            i++;
            zeit_ablauf();
            button1.Enabled = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //bla
        }

    }
}
