using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasjerConsola.Klasy
{

    public class FaceValue   //  FaceValue - Nominał
    {
        public FaceValue(string nazwa, double nominalZKonstruktora)
        {
            Nazwa = nazwa;
            faceValue = System.Convert.ToDecimal(nominalZKonstruktora);
            string nominal = nominalZKonstruktora.ToString();
            if (nominalZKonstruktora >= 100)
            {
                Opis = $"{nominal}.00 zł.";
            }
            else if (100 > nominalZKonstruktora && nominalZKonstruktora >= 10)
            {
                Opis = $" {nominal}.00 zł.";
            }
            else if (10 > nominalZKonstruktora && nominalZKonstruktora >= 1)
            {
                Opis = $"  {nominal}.00 zł.";
            }
            else if (1 > nominalZKonstruktora && nominalZKonstruktora >= 0.10)
            {
                Opis = $"  {nominal}0 gr.";
            }
            else
            {
                Opis = $"  {nominal} gr.";
            }
        }

        public string Nazwa { get; set; }
        public string Opis { get; set; }
        private decimal faceValue;
        public int quantity = 0;

        public decimal Value
        {
            get
            {
                return faceValue * quantity;
            }
        }

        
    }
}
