using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS_06_12_2016.Model
{
    public class Uge : INotifyPropertyChanged
    {
        public List<Dag> ugedage = new List<Dag>();
        public List<TilmeldteHuse> Alletilmeldtehuse { get; set; }

        public Dag MandagListe { get; set; }
        public Dag Tirsdag { get; set; }
        public Dag Onsdag { get; set; }
        public Dag TorsDag { get; set; }


        private double udgiftUge;

        public double UdgiftUge
        {
            get { return udgiftUge; }
            set
            {
                udgiftUge = value;
                OnPropertyChanged(nameof(udgiftUge));
            }
        }

        public double result;
        public Dag dag;
        public Uge(List<Dag> dageiugen)
        {
            this.ugedage = dageiugen;
        }

        public Uge()
        {
            MandagListe = new Dag();
            Tirsdag = new Dag();
            Onsdag = new Dag();
            TorsDag = new Dag();

        }

        /// <summary>
        /// Giver antallet af kuverter pr uge (18)
        /// </summary>
        /// <returns></returns>
        public double SumKuvertUge()
        {
            double sum = 0;

            foreach (var h in ugedage)
            {
                sum += h.SumKuvertDag();
            }
            return sum;
        }
        /// <summary>
        /// Giver den gennemsnitlige kuvertpris per uge (100 kr)
        /// </summary>
        /// <returns></returns>
        public double GetKuvertPrisUgen()
        {
            return UdgiftUge / SumKuvertUge();
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
