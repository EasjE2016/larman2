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
using Windows.UI.Popups;

namespace FS_06_12_2016.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        #region Properties
        //------------------------------------------------------------------------------
        // Gør det muligt at vælge og aktivere hus fra listerne. F.eks opdatere og frameld.
        private TilmeldteHuse selectedHuse;

        public TilmeldteHuse SelectedHus {
            get { return selectedHuse; }
            set {
                selectedHuse = value;
                OnPropertyChanged(nameof(SelectedHus));
            }
        }


        //--------------------------------------------------------------------------------

        // Tæller hvor mange der deltager på den pågældende dag.
        private double ialtMandag = 0;

        public double IaltMandag {
            get { return ialtMandag; }
            private set {
                ialtMandag = value;
                OnPropertyChanged(nameof(IaltMandag));
            }
        }

        private double ialtTirsdag = 0;

        public double IaltTirsdag {
            get { return ialtTirsdag; }
            private set {
                ialtTirsdag = value;
                OnPropertyChanged(nameof(IaltTirsdag));
            }
        }

        private double ialtOnsdag = 0;

        public double IaltOnsdag {
            get { return ialtOnsdag; }
            private set {
                ialtOnsdag = value;
                OnPropertyChanged(nameof(IaltOnsdag));
            }
        }

        private double ialtTorsdag = 0;

        public double IaltTorsdag {
            get { return ialtTorsdag; }
            private set {
                ialtTorsdag = value;
                OnPropertyChanged(nameof(IaltTorsdag));
            }
        }

        Dictionary<int, double> Ugenspris;

        public Uge NyUge { get; set; }

        public Dag UgeDag { get; set; }

        //private double samletPris;

        //public double SamletPris {
        //    get { return samletPris; }
        //    set { samletPris = dag value; }
        //}

        private double kuvert;

        public double Kuvert {
            get { return kuvert; }
            set {
                kuvert = value;
                OnPropertyChanged(nameof(Kuvert));
            }
        }

        private double udgiftUge;

        public double UdgiftUge {
            get { return udgiftUge; }
            set {
                udgiftUge = value;
                OnPropertyChanged(nameof(UdgiftUge));
            }
        }

        private ItemsChangeObservableCollection<TilmeldteHuse> alletilmeldtehuse;

        public ItemsChangeObservableCollection<TilmeldteHuse> Alletilmeldtehuse {
            get { return alletilmeldtehuse; }
            set {
                alletilmeldtehuse = value;
                OnPropertyChanged(nameof(Alletilmeldtehuse));
            }
        }
        public Model.TilmeldteHuse NewHus { get; set; }
        #endregion

        public RelayCommand IndtastUdgiftCommand { get; set; }
        public RelayCommand OpretUgeCommand { get; set; }
        public RelayCommand FjernEtHus { get; set; }

        public RelayCommand OpretEtHus { get; set; }

        public void AddNewHus()
        {
            //TilmeldteHuse hus = new TilmeldteHuse();
            //hus = NewHus;

            //kopiere et hus og lægger det ind
            TilmeldteHuse mandag_hus = new TilmeldteHuse(NewHus.HusNr, NewHus.AntalVoksen, NewHus.AntalUng, NewHus.AntalBarn, NewHus.MinRolle);
            NyUge.MandagListe.Alletilmeldtehuse.Add(mandag_hus);

            TilmeldteHuse tirsdag_hus = new TilmeldteHuse(NewHus.HusNr, NewHus.AntalVoksen, NewHus.AntalUng, NewHus.AntalBarn, NewHus.MinRolle);
            NyUge.TirsdagListe.Alletilmeldtehuse.Add(tirsdag_hus);

            TilmeldteHuse onsdag_hus = new TilmeldteHuse(NewHus.HusNr, NewHus.AntalVoksen, NewHus.AntalUng, NewHus.AntalBarn, NewHus.MinRolle);
            NyUge.OnsdagListe.Alletilmeldtehuse.Add(onsdag_hus);

            TilmeldteHuse torsdag_hus = new TilmeldteHuse(NewHus.HusNr, NewHus.AntalVoksen, NewHus.AntalUng, NewHus.AntalBarn, NewHus.MinRolle);
            NyUge.TorsDagListe.Alletilmeldtehuse.Add(torsdag_hus);

            this.alletilmeldtehuse.Add(NewHus);
        }

        public void LavNyUge()
        {
            foreach (var hus in alletilmeldtehuse)
            {
                //kopiere det hus den er nået til på listen
                TilmeldteHuse mandag_hus = new TilmeldteHuse(hus.HusNr, hus.AntalVoksen, hus.AntalUng, hus.AntalBarn, NewHus.MinRolle);
                NyUge.MandagListe.Alletilmeldtehuse.Add(mandag_hus);

                TilmeldteHuse tirsdag_hus = new TilmeldteHuse(hus.HusNr, hus.AntalVoksen, hus.AntalUng, hus.AntalBarn, NewHus.MinRolle);
                NyUge.TirsdagListe.Alletilmeldtehuse.Add(tirsdag_hus);

                TilmeldteHuse onsdag_hus = new TilmeldteHuse(hus.HusNr, hus.AntalVoksen, hus.AntalUng, hus.AntalBarn, NewHus.MinRolle);
                NyUge.OnsdagListe.Alletilmeldtehuse.Add(onsdag_hus);

                TilmeldteHuse torsdag_hus = new TilmeldteHuse(hus.HusNr, hus.AntalVoksen, hus.AntalUng, hus.AntalBarn, NewHus.MinRolle);
                NyUge.TorsDagListe.Alletilmeldtehuse.Add(torsdag_hus);
            }

            IaltiListeMandag();
            IaltiListeTirsdag();
            IaltiListeOnsdag();
            IaltiListeTorsdag();
        }
        public void IaltiListeMandag()
        {
            IaltMandag = NyUge.MandagListe.SumKuvertDag();
        }

        public void IaltiListeTirsdag()
        {
            IaltTirsdag = NyUge.TirsdagListe.SumKuvertDag();
        }

        public void IaltiListeOnsdag()
        {
            IaltOnsdag = NyUge.OnsdagListe.SumKuvertDag();
        }

        public void IaltiListeTorsdag()
        {
            IaltTorsdag = NyUge.TorsDagListe.SumKuvertDag();
        }
        //--------------------------------------
        //Fjern et hus fra listen en bestemt dag.
        public void FjernHusFraDag()
        {
            NyUge.MandagListe.Alletilmeldtehuse.Remove(SelectedHus);
            NyUge.TirsdagListe.Alletilmeldtehuse.Remove(SelectedHus);
            NyUge.OnsdagListe.Alletilmeldtehuse.Remove(SelectedHus);
            NyUge.TorsDagListe.Alletilmeldtehuse.Remove(SelectedHus);

            IaltiListeMandag();
            IaltiListeTirsdag();
            IaltiListeOnsdag();
            IaltiListeTorsdag();
        }
        //--------------------------------------

        public void GetUdgiftPrUgePrHus(TilmeldteHuse hus)
        {
            double antal = hus.AntalKuverter;
            double pris = antal * kuvert;
            hus.DagsPris = pris;
        }

        public void Beregn()
        {
            NyUge.UdgiftUge = this.udgiftUge;
            //henter ugens kuvert pris
            this.Kuvert = NyUge.GetKuvertPrisUgen();
           
            // todo: det skal være hver liste hver dag
            foreach (Dag dag in NyUge.ugedage)
            {
                foreach (TilmeldteHuse hus in dag.Alletilmeldtehuse)
                {
                    GetUdgiftPrUgePrHus(hus);
                    Ugenspris.Add(Convert.ToInt32(hus.HusNr), hus.DagsPris);
                }
            }
         }

        public MainViewModel()
        {
            //TilmeldteHuse hus = new TilmeldteHuse();
            TilmeldteHuse hus1 = new TilmeldteHuse("18", 2, 3, 1, "Hjælper");
            TilmeldteHuse hus2 = new TilmeldteHuse("19", 2, 2, 0, "Oprydder");
            TilmeldteHuse hus3 = new TilmeldteHuse("20", 1, 1, 1, "Chefkok");
            TilmeldteHuse hus4 = new TilmeldteHuse("21", 4, 0, 0, "Ingen");

            Alletilmeldtehuse = new ItemsChangeObservableCollection<TilmeldteHuse>();

            Alletilmeldtehuse.Add(hus1);
            Alletilmeldtehuse.Add(hus2);
            Alletilmeldtehuse.Add(hus3);
            Alletilmeldtehuse.Add(hus4);

            OpretUgeCommand = new RelayCommand(LavNyUge);
            FjernEtHus = new RelayCommand(FjernHusFraDag);
            IndtastUdgiftCommand = new RelayCommand(Beregn);
            OpretEtHus = new RelayCommand(AddNewHus);

            NewHus = new TilmeldteHuse();
            NyUge = new Uge();

            Ugenspris = new Dictionary<int, double>();
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
