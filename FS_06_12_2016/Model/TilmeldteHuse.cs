using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FS_06_12_2016.Model
{
    public class TilmeldteHuse : INotifyPropertyChanged
    {
        
        
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

        private int husNr;
        public int HusNr
        {
            get { return husNr; }
            set
            {
                husNr = value;
                OnPropertyChanged(nameof(HusNr));
            }
        }

        //private List<Person> personListe;

        public TilmeldteHuse(int husnr,int antalvoksne,int antalung,int antalbarn)
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
