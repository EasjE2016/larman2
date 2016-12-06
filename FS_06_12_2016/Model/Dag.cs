using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS_06_12_2016.Model
{
    public class Dag : INotifyPropertyChanged
    {
        List<TilmeldteHuse> Alletilmeldtehuse = new List<TilmeldteHuse>();

        

        public Dag()
        {
            TilmeldteHuse hus1 = new TilmeldteHuse();
            TilmeldteHuse hus2 = new TilmeldteHuse();
            TilmeldteHuse hus3 = new TilmeldteHuse();

            Alletilmeldtehuse.Add(hus1);
            Alletilmeldtehuse.Add(hus2);
            Alletilmeldtehuse.Add(hus3);
        }


        /// <summary>
        /// Lægger alle husenes antal kuverter sammen og returner dem.
        /// </summary>
        /// <returns></returns>
        public double SumKuvertDag()
        {
            double sum = 0;

            foreach (var h in Alletilmeldtehuse)
            {
                sum += h.GetAntalKuverter();
            }
            return sum;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
