using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasjerConsola.Klasy
{

    // BEZ POLSKICH LITER! :D 
    public class Nominał
    {
        // po co kasior? czemu string?
        public string kasior;   // 500, 200, 100 ... 
        public string waluta;
        decimal nominał;
        public int ilość = 0;
        public decimal wartość
        {
            get
            {
                return nominał * ilość;
            }
        }

        public string Opis()
        {
            return $"{ kasior} {waluta}";
        }


        public Nominał(decimal nominałZKonstruktora)
        {
            kasior = nominałZKonstruktora.ToString();
            if (nominałZKonstruktora > 0)
            {
                waluta = "zł.";
            }
            else
            {
                waluta = "gr.";
            }
            nominał = nominałZKonstruktora;
        }
    }
}
