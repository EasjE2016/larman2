using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments;
using FS_06_12_2016.Model;

namespace FS_06_12_2016.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public TilmeldteHuse hus1;
        public Uge uge1;

        private double samletPris;

        public double SamletPris
        {
            get { return samletPris; }
            set { samletPris = value; }
        }

        private double kuvert;

        public double Kuvert
        {
            get { return kuvert; }
            set { kuvert = value; }
        }


        private List<TilmeldteHuse> alletilmeldtehuse = new List<TilmeldteHuse>();

        public List<TilmeldteHuse> Alletilmeldtehuse
        {
            get { return alletilmeldtehuse; }
            set
            {
                alletilmeldtehuse = value;
                OnPropertyChanged(nameof(Alletilmeldtehuse));
            }
        }


        public MainViewModel()
        {


            TilmeldteHuse hus1 = new TilmeldteHuse();
            TilmeldteHuse hus2 = new TilmeldteHuse();
            TilmeldteHuse hus3 = new TilmeldteHuse();

            Alletilmeldtehuse.Add(hus1);
            Alletilmeldtehuse.Add(hus2);
            Alletilmeldtehuse.Add(hus3);


            hus1 = new TilmeldteHuse();
            Dag dag1 = new Dag(Alletilmeldtehuse);
            Dag dag2 = new Dag(Alletilmeldtehuse);

            List<Dag> temp_uge = new List<Dag>();

            temp_uge.Add(dag1);
            temp_uge.Add(dag2);
            dag1.SumKuvertDag();

            this.uge1 = new Uge(temp_uge);
            this.SamletPris = uge1.SumKuvertUge();
            this.Kuvert = uge1.GetKuvertPrisUgen();
            GetUdgiftPrUgePrHus(Alletilmeldtehuse[0]);
        }

        public void GetUdgiftPrUgePrHus(TilmeldteHuse hus)
        {
            double antal = hus.GetAntalKuverter();
            double pris = antal * kuvert;
            hus.DagsPris = pris;
           
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
