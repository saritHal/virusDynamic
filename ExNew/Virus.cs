using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExRotem
{

    class Virus
    {
        public double ChanceIncrease { get; set; }
        public double ChanceClean { get; set; }
        public double Motation { get; set; }
        public Dictionary<string, bool> Medicines { get; set; }

        static Random r = new Random();

        //constructor for virus gets 3 arguments
        public Virus(double increase, double clean, double motation)
        {
            this.ChanceIncrease = increase;
            this.ChanceClean = clean;
            this.Motation = motation;
            this.Medicines = new Dictionary<string, bool>();
            for (int i = 1; i < 6; i++)
                this.Medicines.Add("m" + i, false);
        }
        //isClean() function return true if the virus died and false if it still alive
        public bool isClean()
        {
            int a = r.Next(1, 100);
            if (a <= 3)
                return true;
            return false;
        }
        //isIncrease()get number of viruses and cells, return true if the virus multiply itself
        public bool isIncrease(int numVirus, int numCells)
        {
            double pre = (double)numVirus / numCells;
            double prob = (1 - pre) * this.ChanceIncrease;
            int a = r.Next(1, numCells * 10);
            prob *= numCells * 10;
            if (a <= prob)
                return true;
            return false;

        }
        //UpMotation() calc for each virus if lost its resistance or develop resistance
        public void setMotation(string medicineNumber)
        {
            int a = r.Next(1, 1000);
            if (a <= 5)
                this.Medicines[medicineNumber] = !this.Medicines[medicineNumber];
        }
        
    }
}
