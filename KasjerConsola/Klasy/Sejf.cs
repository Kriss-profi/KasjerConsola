using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasjerConsola.Klasy
{
   // bez polskich liter!
   // uzycie Properties - setter and getter zamiast Zmien/stan
    public class Sejf
    {
        //public decimal N50000;
        // to mozna zamienic na liste albo tablice
        Nominał N50000 = new Nominał((decimal)500.00);
        Nominał N20000 = new Nominał((decimal)200.00);
        Nominał N10000 = new Nominał((decimal)100.00);



        public decimal Wartość 
        {
            get
            {
                return N50000.wartość + N20000.wartość + N10000.wartość;  
            } 
        }

        public void ZmieńN50000(int ilośćNominałów)
        {
            N50000.ilość = ilośćNominałów;
        }
        public int StanN50000()
        {
            return N50000.ilość;
        }
        public string OpisN50000()
        {
            return N50000.Opis();
        }



        public void ZmieńN20000(int ilośćNominałów)
        {
            N20000.ilość = ilośćNominałów;
        }
        public int StanN20000()
        {
            return N20000.ilość;
        }
        public string OpisN20000()
        {
            return N20000.Opis();
        }



        public void ZmieńN10000(int ilośćNominałów)
        {
            N10000.ilość = ilośćNominałów;
        }
        public int StanN10000()
        {
            return N10000.ilość;
        }
        public string OpisN10000()
        {
            return N10000.Opis();
        }


        public void Wypisz(string tekst)
        {
            Console.WriteLine(tekst);
            Console.WriteLine($"Stan kasy: {Wartość}\n");
            Console.WriteLine($"{N50000.Opis()} * {N50000.ilość} = {N50000.wartość} ");
            Console.WriteLine($"{N20000.Opis()} * {N20000.ilość} = {N20000.wartość} ");
            Console.WriteLine($"{N10000.Opis()} * {N10000.ilość} = {N10000.wartość} ");
        }


    }
}
