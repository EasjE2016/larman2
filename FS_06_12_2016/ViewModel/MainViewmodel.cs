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
using System.Data;
using Windows.UI.Xaml.Controls;

namespace FS_06_12_2016.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        #region Properties
        //------------------------------------------------------------------------------
        // Gør det muligt at vælge og aktivere hus fra listerne. F.eks opdatere og frameld.
        private TilmeldteHuse selectedHuse;

        public TilmeldteHuse SelectedHus
        {
            get { return selectedHuse; }
            set
            {
                IaltiListeMandag();
                IaltiListeTirsdag();
                IaltiListeOnsdag();
                IaltiListeTorsdag();
                selectedHuse = value;
                OnPropertyChanged(nameof(SelectedHus));
            }
        }

        //--------------------------------------------------------------------------------

        // Tæller hvor mange der deltager på den pågældende dag.
        private double ialtMandag = 0;

        public double IaltMandag
        {
            get { return ialtMandag; }
            private set
            {
                ialtMandag = value;
                OnPropertyChanged(nameof(IaltMandag));
            }
        }

        private double ialtTirsdag = 0;

        public double IaltTirsdag
        {
            get { return ialtTirsdag; }
            private set
            {
                ialtTirsdag = value;
                OnPropertyChanged(nameof(IaltTirsdag));
            }
        }

        private double ialtOnsdag = 0;

        public double IaltOnsdag
        {
            get { return ialtOnsdag; }
            private set
            {
                ialtOnsdag = value;
                OnPropertyChanged(nameof(IaltOnsdag));
            }
        }

        private double ialtTorsdag = 0;

        public double IaltTorsdag
        {
            get { return ialtTorsdag; }
            private set
            {
                ialtTorsdag = value;
                OnPropertyChanged(nameof(IaltTorsdag));
            }
        }

        public Dictionary<int, double> Ugenspris;

        private GridView gW;

        public GridView GW
        {
            get { return gW; }
            set
            {
                gW = value;
                OnPropertyChanged(nameof(GW));
            }
        }


        public Uge NyUge { get; set; }

        public Dag UgeDag { get; set; }

        private double kuvert;

        public double Kuvert
        {
            get { return kuvert; }
            set
            {
                kuvert = value;
                OnPropertyChanged(nameof(Kuvert));
            }
        }

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

        double result;

        public Model.TilmeldteHuse NewHus { get; set; }
        #endregion

        public RelayCommand IndtastUdgiftCommand { get; set; }
        public RelayCommand OpretUgeCommand { get; set; }
        public RelayCommand FjernEtHus { get; set; }

        public RelayCommand OpretEtHus { get; set; }

        public MainViewModel()
        {
            //TilmeldteHuse hus = new TilmeldteHuse();
            TilmeldteHuse hus1 = new TilmeldteHuse(18, 2, 3, 1, "Hjælper");
            TilmeldteHuse hus2 = new TilmeldteHuse(19, 2, 2, 0, "Oprydder");
            TilmeldteHuse hus3 = new TilmeldteHuse(20, 1, 1, 1, "Chefkok");
            TilmeldteHuse hus4 = new TilmeldteHuse(21, 4, 0, 0, "Ingen");

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
            GW = new GridView();
            Ugenspris = new Dictionary<int, double>();

            
        }

        public async void AddNewHus()
        {
            //TilmeldteHuse hus = new TilmeldteHuse();
            //hus = NewHus;

            if (NewHus.HusNr >= 1 && NewHus.AntalVoksen >= 1)
            {

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
            else
            {
                MessageDialog oprethus = new MessageDialog("Du skal huske husnummer og mindst en voksen");
                await oprethus.ShowAsync();
            }





        }

        public async void LavNyUge()
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

        public async void Beregn()
        {
            if (udgiftUge >= 1)
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

                        //hvis husnummeret ikke er på listen bliver det tilføjet
                        if (!Ugenspris.ContainsKey(hus.HusNr))
                        {
                            //Husnummeret og dagsprisen bliver lagt ind i dictionaryet
                            Ugenspris.Add(hus.HusNr, hus.DagsPris);
                        }
                        else
                        {
                            //hvis huset er lagt på listen skla den tage den nuværende value 
                            //og lægge dagens dagspris til og lægge den tilbage ved den key(husnummer)
                            this.result = 0;
                            this.result = Ugenspris[hus.HusNr] + hus.DagsPris;
                            Ugenspris[hus.HusNr] = result;
                        }
                    }
                }

                //Binder ugenspris dictionaryet til et gridview
                //så vi kan binde/vise det på siden.
                GW.DataContext = Ugenspris;
            }
            else
            {
                MessageDialog info = new MessageDialog("Indtast et positivt beløb!");
                await info.ShowAsync();
            }
           

        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
