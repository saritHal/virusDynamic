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

        //
        private void button1_Click(object sender, EventArgs e)
        {
            p.LastPrecents = p.VirusNum;
            for (int i = 0; i < this.numericUpDown1.Value; i++)
                p.UpdatePatient();
            
            this.label1.Text = "viruses: "+p.VirusNum + " \n"+"Cells: "+(p.CellsNum-p.VirusNum);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.label5.Text = " this.label5.Text";
            this.label5.Text = p.CalcIncreas() ? "the number of the viruses increase" : "the number of the viruses decrease";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Patient p1 = new Patient(100, 1000);
            for (int i = 0; i < 150; i++)
                p1.UpdatePatient();
            this.label6.Text = "After 150 runs without Medicine viruses: " + p1.VirusNum + " \n";
            //with medicine
            Patient p2 = new Patient(100, 1000);
            List<string> MedicineList = new List<string>();
            MedicineList.Add("m1");
            for (int i = 0; i < 150; i++)
                p2.UpdatePatient(MedicineList);
            this.label6.Text += "After 150 runs with Medicine viruses: " + p2.VirusNum + " \n";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Patient p3 = new Patient(100, 1000);
            List<string> MedicineList = new List<string>();
            MedicineList.Add("m1"); 
            int after = int.Parse(this.comboBox1.Text);
            for (int i = 0; i < after; i++)
                p3.UpdatePatient();
            this.label8.Text =  after + " runs without Medicines\n";
            for (int i = 0; i < 150; i++)
                p3.UpdatePatient(MedicineList);
            this.label8.Text += "150 runs with Medicine "+p3.VirusNum.ToString()+" Viruses";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Patient p4 = new Patient(100, 1000);
            List<string> MedicineList = new List<string>();
            var b=this.checkedListBox1.CheckedItems;
            foreach (var item in b)
                MedicineList.Add(item.ToString());
            for (int i = 0; i < 150; i++)
                p4.UpdatePatient(MedicineList);
            this.label9.Text = p4.VirusNum.ToString();


        }


    }
}
