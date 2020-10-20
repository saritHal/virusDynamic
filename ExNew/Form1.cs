using ExRotem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExNew
{
    public partial class Form1 : Form
    {
        Patient p = new Patient(100, 1000);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.numericUpDown1.Value; i++)
            {
                p.UpdatePatient();
               

            }
            this.label1.Text = p.VirusNum + " \n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.label5.Text = " this.label5.Text";
            this.label5.Text  = p.CalcIncreas() ? "the number of the viruses increase" : "the number of the viruses decrease";
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Patient p1 = new Patient(100, 1000);
            for (int i = 0; i < 150; i++)
            {
                p1.UpdatePatient();


            }
            this.label6.Text = p1.VirusNum + " \n";
            for (int i = 0; i < 10; i++)
            {
                p1.UpdatePatient("m1");


            }
            this.label6.Text += p1.VirusNum + " \n";
        }
    }
}
