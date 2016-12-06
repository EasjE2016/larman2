using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FS_06_12_2016.Model
{
    public class Person : INotifyPropertyChanged
    {
        private int alder;

        public int Alder
        {
            get { return alder; }
            set
            {
                alder = value;
                OnPropertyChanged(nameof(Alder));
            }
        }

        private string navn;

        public string Navn
        {
            get { return navn; }
            set
            {
                navn = value;
                OnPropertyChanged(nameof(Navn));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
