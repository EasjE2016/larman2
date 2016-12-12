using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Popups;

namespace FS_06_12_2016.Model
{
    public class TilmeldteHuse : INotifyPropertyChanged
    {

        private string dialog;
        private int antalVoksen;

        public int AntalVoksen
        {
            get { return antalVoksen; }
            set
            {
                antalVoksen = value;
                OnPropertyChanged(nameof(AntalVoksen));
            }
        }

        private int antalUng;

        public int AntalUng
        {
            get { return antalUng; }
            set
            {
                antalUng = value;
                OnPropertyChanged(nameof(AntalUng));
            }
        }

        private int antalBarn;

        public int AntalBarn
        {
            get { return antalBarn; }
            set
            {
                antalBarn = value;
                OnPropertyChanged(nameof(AntalBarn));
            }
        }
        
        public double AntalKuverter;

        private double dagsPris;

        public double DagsPris
        {
            get { return dagsPris; }
            set
            {
                dagsPris = value;
                OnPropertyChanged(nameof(DagsPris));
            }
        }

        private string husNr;
        public string HusNr
        {
            get { return husNr; }
            set {
                {
                    if (value.All(char.IsNumber))
                        husNr = value;
                    else
                        SimpleMessageDialog();
                }

                OnPropertyChanged(nameof(HusNr)); 
                }
        }
        private async void SimpleMessageDialog()
        {
            var dialog = new MessageDialog("Prøv lige igen.");
            dialog.Title = "Husnumre må kun bestå af hele positive tal";
            await dialog.ShowAsync();
        }

        //private string _MyNemericStringr;

        //public string MyNemericString {
        //    get { return _MyNemericStringr; }
        //    set {
        //        if (value.All(char.IsDigit))
        //            _MyNemericStringr = value;
        //        else
        //            _MyNemericStringr = "0";
        //    }
        //}








        //private List<Person> personListe;

        public TilmeldteHuse(string husnr,int antalvoksne,int antalung,int antalbarn)
        {
            this.husNr = husnr;
            this.AntalVoksen = antalvoksne;
            this.AntalUng = antalung;
            this.AntalBarn = antalbarn;
            this.AntalKuverter = GetAntalKuverter();
        }

        public TilmeldteHuse()
        {
            
        }

        

        public double GetAntalKuverter()
        {
            double AntalKuverter;

            AntalKuverter = AntalVoksen + (AntalUng * 0.5) + (AntalBarn * 0.25);
           
            return AntalKuverter;

        }

        public override string ToString()
        {
            return $"Husnummer: {HusNr} \n " +
                   $"Antal Voksne: {AntalVoksen} \n Antal Unge: {AntalUng} Antal Børn: {AntalBarn}" +
                   
                   $" DagsPris: {DagsPris}";
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
