using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExRotem
{
    class Patient
    {
        public double LastPrecents = 0.1;
        public List<Virus> ListViruses { get; set; }
        public int VirusNum { get; set; }
        public int CellsNum { get; set; }

        private int lastVirus;
        //Constructor gets number of viruses and number of cells
        public Patient(int virusesNumber, int cellsNumber)
        {
            this.ListViruses = new List<Virus>(virusesNumber);
            for (int i = 0; i < virusesNumber; i++)
                ListViruses.Add(new Virus(0.1, 0.03,0.005));

            this.VirusNum = this.ListViruses.Count();
            this.CellsNum = cellsNumber;
            this.lastVirus = this.VirusNum;
        }
    
        private void UpdateCleanState()
        {
           this.ListViruses.RemoveAll(x => x.isClean() == true);
            this.VirusNum = this.ListViruses.Count();
        }
        private void UpdateIncreaseState()
        {

            for (int i = 0; i < this.VirusNum; i++)
            {
                if (this.ListViruses[i].isIncrease(this.VirusNum, this.CellsNum))
                    this.ListViruses.Add(new Virus(0.1, 0.03,0.005));
            }
            this.VirusNum = this.ListViruses.Count();
            
        }
        private void updateMotation(string m1)
        {
            this.ListViruses.ForEach(v => v.setMotation(m1));
        }

        private void UpdateIncreaseState(string m1)
        {
            foreach (Virus item in this.ListViruses.ToList())
            {
                if (item.IsResistanceM1 && item.isIncrease(this.VirusNum, this.CellsNum))
                {
                    Virus descendent = new Virus(0.1, 0.03, 0.005);
                    //descendent.IsResistanceM1 = true;

                   this.ListViruses.Add(descendent);
                }
            
            }
            
        }


        public void UpdatePatient()
        {
            this.lastVirus = this.VirusNum;
            this.UpdateCleanState();
            this.UpdateIncreaseState();
        }

        public void UpdatePatient(string s1)
        {
            this.lastVirus = this.VirusNum;
            this.UpdateCleanState();
            this.updateMotation(s1);
            this.UpdateIncreaseState(s1);

        }

        public bool CalcIncreas()
        {
            return (this.VirusNum > this.lastVirus);
        }
           
    }
}
