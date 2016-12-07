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
        private string husNr;
        public int AntalVoksen { get; set; }
        public int AntalUng { get; set; }
        public int AntalBarn { get; set; }
        public double AntalKuverter = 0;
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

        //private List<Person> personListe;

        public TilmeldteHuse()
        {
            this.AntalVoksen = 2;
            this.AntalUng = 2;
            this.AntalBarn = 0;
            this.HusNr = "14";
            GetAntalKuverter();
        }
        

        public string HusNr
        {
            get { return husNr; }
            set
            {
                husNr = value;
                OnPropertyChanged(nameof(HusNr));
            }
        }

        public double GetAntalKuverter()
        {
            double AntalKuverter;

            AntalKuverter = AntalVoksen + (AntalUng * 0.5) + (AntalBarn * 0.25);
           
            return AntalKuverter;

        }

        public override string ToString()
        {
            return $"Husnummer: {HusNr} Antal Voksne: {AntalVoksen} DagsPris: {DagsPris}";
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
