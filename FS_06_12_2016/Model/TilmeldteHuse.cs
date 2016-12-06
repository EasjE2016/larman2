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
        private int husNr;
        public int AntalVoksen { get; set; }
        public int AntalUng { get; set; }
        public int AntalBarn { get; set; }
        public double AntalKuverter = 0;
        public double TotalDagPris = 366;

        //private List<Person> personListe;

        public TilmeldteHuse()
        {
            this.AntalVoksen = 2;
            this.AntalUng = 2;
            this.AntalBarn = 0;

            GetAntalKuverter();
        }
        

        public int HusNr
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

        //public void GetTotalDagPris()
        //{

        //}



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
