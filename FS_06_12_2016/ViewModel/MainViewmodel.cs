using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public Dag UgeDag { get; set; }
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

        private ItemsChangeObservableCollection<TilmeldteHuse> alletilmeldtehuse;

        public ItemsChangeObservableCollection<TilmeldteHuse> Alletilmeldtehuse
        {
            get { return alletilmeldtehuse; }
            set
            {
                alletilmeldtehuse = value;
                OnPropertyChanged(nameof(Alletilmeldtehuse));
            }
        }

        public RelayCommand IndtastUdgiftCommand { get; set; }

        public Model.TilmeldteHuse NewHus { get; set; }
        public MainViewModel()
        {
            Alletilmeldtehuse = new ItemsChangeObservableCollection<TilmeldteHuse>();

            IndtastUdgiftCommand = new RelayCommand(Beregn);
            TilmeldteHuse hus1 = new TilmeldteHuse(13,2,3,1);
            TilmeldteHuse hus2 = new TilmeldteHuse(21,1,1,1);
            TilmeldteHuse hus3 = new TilmeldteHuse(19,2,2,0);

            Alletilmeldtehuse.Add(hus1);
            Alletilmeldtehuse.Add(hus2);
            Alletilmeldtehuse.Add(hus3);

            //laver en ny dagliste af huse
            List<TilmeldteHuse> nylisteTilmeldteHuses = new List<TilmeldteHuse>();

            //tilføjer husene
            nylisteTilmeldteHuses.Add(hus1);
            nylisteTilmeldteHuses.Add(hus3);

            //opretter to nye dag og giver dem hver sin liste
            Dag mandag = new Dag(alletilmeldtehuse);
            //Dag tirsDag = new Dag(nylisteTilmeldteHuses);
            //Dag onsdag = new Dag();
            //Dag torsdag = new Dag();

            //hus1 = new TilmeldteHuse();
            //Dag dag1 = new Dag(Alletilmeldtehuse);
            //Dag dag2 = new Dag(Alletilmeldtehuse);

            List<Dag> temp_uge = new List<Dag>();

            temp_uge.Add(mandag);
            //temp_uge.Add(tirsDag);
            
            this.uge1 = new Uge(temp_uge);
            this.SamletPris = uge1.SumKuvertUge();
        }

        public void AddNewHus()
        {
            TilmeldteHuse Hus = new TilmeldteHuse()
            {
                HusNr = NewHus.HusNr,
                AntalVoksen = NewHus.AntalVoksen,
                AntalUng = NewHus.AntalUng,
                AntalBarn = NewHus.AntalBarn,
            };

            //skal lægge huset ind på ALLE dagene.
            //mandag.Add(Hus);
            
        }

        public void GetUdgiftPrUgePrHus(TilmeldteHuse hus)
        {
            double antal = hus.AntalKuverter;
            double pris = antal * kuvert;
            hus.DagsPris = pris;
           
        }

        public void Beregn()
        {

            uge1.UdgiftUge = this.udgiftUge;
            this.Kuvert = uge1.GetKuvertPrisUgen();
            foreach (var hus in Alletilmeldtehuse)
            {
                GetUdgiftPrUgePrHus(hus);
            }

            
            
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
