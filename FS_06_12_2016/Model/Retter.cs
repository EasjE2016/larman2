using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS_06_12_2016.Model
{
    public class Retter
    {
        private int _menunummer;

        public int MenuNummer
        {
            get { return _menunummer; }
            set
            {
                _menunummer = value;
            }
        }

        private string _menunavn;

        public string MenuNavn
        {
            get { return _menunavn; }
            set
            {
                _menunavn = value;
            }
        }

        private double _prisprkuvert;

        public double PrisPrKuvert
        {
            get { return _prisprkuvert; }
            set
            {
                _prisprkuvert = value;

            }
        }

        private string _ingredienser;

        public string Ingredienser
        {
            get { return _ingredienser; }
            set { _ingredienser = value; }
        }




        public override string ToString()
        {
            return "Menu nr: " + MenuNummer + "\n " + MenuNavn + "\n" + "Pris pr kuvert: " + PrisPrKuvert + "\n" + " Ingredienser: " + Ingredienser + "\n ---------------------------------";
        }

    }
}
