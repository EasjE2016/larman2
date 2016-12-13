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

        //private string dialog;
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
                        MessageDialog();
                }

                OnPropertyChanged(nameof(HusNr)); 
                }
        }

        /// <summary>
        /// Denne metode aktiverer en besked til brugeren, hvis den indtastede værdi 
        /// ikke stemmer overens med hvad der er tilladt at indtaste.
        /// </summary>
        private async void MessageDialog()
        {
            var dialog = new MessageDialog("Prøv lige igen.");
            dialog.Title = "Husnumre må kun bestå af hele positive tal";
            await dialog.ShowAsync();
        }

        
        public double GetAntalKuverter()
        {
            double AntalKuverter;
            AntalKuverter = AntalVoksen + (AntalUng * 0.5) + (AntalBarn * 0.25);
            return AntalKuverter;
        }

        //private List<Person> personListe;

        public double AntalKuverter;
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

        public override string ToString()
        {
            return $"Husnummer: {HusNr} \n" +
                   $"Antal Voksne: {AntalVoksen}, unge: {AntalUng} og børn: {AntalBarn}\n" +
                   $"Dagspris: {DagsPris}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
