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
        public ItemsChangeObservableCollection<Dag> ugedage = new ItemsChangeObservableCollection<Dag>();
        public ItemsChangeObservableCollection<TilmeldteHuse> Alletilmeldtehuse { get; set; }

        public Dag MandagListe { get; set; }
        public Dag TirsdagListe { get; set; }
        public Dag OnsdagListe { get; set; }
        public Dag TorsDagListe { get; set; }


        private double udgiftUge;

        public double UdgiftUge
        {
            get { return udgiftUge; }
            set
            {
                udgiftUge = value;
                OnPropertyChanged(nameof(UdgiftUge));
            }
        }

        public double result;
        public Dag dag;
        //public Uge(List<Dag> dageiugen)
        //{
        //    this.ugedage = dageiugen;
        //}

        public Uge()
        {
            MandagListe = new Dag();
            TirsdagListe = new Dag();
            OnsdagListe = new Dag();
            TorsDagListe = new Dag();

            ugedage = new ItemsChangeObservableCollection<Dag>();

            this.ugedage.Add(MandagListe);
            this.ugedage.Add(TirsdagListe);
            this.ugedage.Add(OnsdagListe);
            this.ugedage.Add(TorsDagListe);
        }

        /// <summary>
        /// Giver antallet af kuverter pr uge (18)
        /// </summary>
        /// <returns></returns>
        public double SumKuvertUge()
        {
            double sum = 0;

            foreach (var hus in ugedage)
            {
                sum += hus.SumKuvertDag();
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
