using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FS_06_12_2016.Model;

namespace FS_06_12_2016.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public TilmeldteHuse hus1;

        public MainViewModel()
        {
            hus1 = new TilmeldteHuse();
            Dag dag1 = new Dag();
            dag1.SumKuvertDag();
            Uge uge1 = new Uge();
            uge1.SumKuvertUge();
            uge1.GetKuvertPrisUgen();
            //uge1.GetUdgiftPrUgePrHus();
            
        }

       

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
