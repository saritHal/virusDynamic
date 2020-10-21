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
    
        //function removes all the clean viruses in Update
        private void UpdateCleanState()
        {
           this.ListViruses.RemoveAll(x => x.isClean() == true);
            this.VirusNum = this.ListViruses.Count();

        }
        //OVERLOADING
        //for each Virus send to function that check if this virus multiplies and returns boolean
        // if Yes add new Virus to the List Of Viruses
        private void UpdateIncreaseState()
        {

            for (int i = 0; i < this.VirusNum; i++)
            {
                if (this.ListViruses[i].isIncrease(this.VirusNum, this.CellsNum))
                    this.ListViruses.Add(new Virus(0.1, 0.03,0.005));
            }
            this.VirusNum = this.ListViruses.Count();
            
        }
        //^do the same active like the last just when the patient gets medicine
        private void UpdateIncreaseState(List<string> m1)
        {

            foreach (Virus item in this.ListViruses.ToList())
            {
                int found = 0;
                foreach (var medicine in m1)
                    if (item.Medicines[medicine] == true)
                        found ++;
                if (found==m1.Count() && item.isIncrease(this.VirusNum, this.CellsNum))
                {
                    Virus descendent = new Virus(0.1, 0.03, 0.005);
                    //descendent.IsResistanceM1 = true;

                    this.ListViruses.Add(descendent);
                }

            }
            this.VirusNum = this.ListViruses.Count();

        }
        //when the patient gets a medicine this function update the Motation 
        private void updateMotation(List<string> medicinesList)
        {
            foreach (var item in medicinesList)
            {
                this.ListViruses.ForEach(v => v.setMotation(item));
            }
            
           
        }

        //UpdatePatient() does the Update to Patient
        public void UpdatePatient()
        {
            this.lastVirus = this.VirusNum;
            this.UpdateCleanState();
            this.UpdateIncreaseState();
        }

        //UpdatePatient() does the Update to Patient and gets list of medicines the patient gets
        public void UpdatePatient(List<string> s1)
        {
            this.lastVirus = this.VirusNum;
            this.UpdateCleanState();
            this.updateMotation(s1);
            this.UpdateIncreaseState(s1);
        }

        //calc if there is Increase in the Number of the viruses , compare to last run
        public bool CalcIncreas()
        {
            if (this.LastPrecents > this.VirusNum)
                return false;
            return true;

        }
           
    }
}
