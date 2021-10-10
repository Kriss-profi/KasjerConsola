using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KasjerConsola.Klasy
{
    public class Wallet
    {
        public List<FaceValue> Values { get; private set; }
        private string _name;
        Helper helper = new Helper();
        

        public Wallet(string name)
        {
            Values = InitilizeWallet();
            _name = name;
        }


        private List<FaceValue> InitilizeWallet()
        {
            var wallet = new List<FaceValue>
            {
                new FaceValue("N50000", 500.00),
                new FaceValue("N20000", 200.00),
                new FaceValue("N10000", 100.00),
                new FaceValue("N5000 ", 50.00),
                new FaceValue("N2000 ", 20.00),
                new FaceValue("N1000 ", 10.00),
                new FaceValue("N500  ", 5.00),
                new FaceValue("N200  ", 2.00),
                new FaceValue("N100  ", 1.00),
                new FaceValue("N50   ", 0.50),
                new FaceValue("N20   ", 0.20),
                new FaceValue("N10   ", 0.10),
                new FaceValue("N5    ", 0.05),
                new FaceValue("N2    ", 0.02),
                new FaceValue("N1    ", 0.01)
            };
            return wallet;
        }

        public decimal WalletWrite()        // Wypisanie nominałów portfels z podsumowaniem
        {
            Console.Clear();
            decimal walletValue = Calculate();
            Console.WriteLine("Stan Kasetki: " + helper.FormatValue(walletValue) + " zł.");
            Console.ReadKey();
            return walletValue;
        }


        public decimal GetValue
        {
            get
            {
                return Values.Sum(v => v.Value);
            }
        }


        private decimal Calculate()
        {
            decimal walletValue = 0;
            Console.WriteLine(_name);
            foreach (FaceValue item in Values)
            {
                Console.WriteLine("  " + item.Opis + " * " + helper.IntFormat(item.quantity) + " = " + helper.DoubleFormat(item.Value));
                walletValue += (decimal)item.Value;
            }
            Console.WriteLine();
            //Console.WriteLine($"Stan kasetki: {0}", walletValue);         //      ???    Wyświetla "0"  ???
            return walletValue;
        }


        // TODO: Move to Wallet - przeniosłem
        private decimal WalletReadValue(List<FaceValue> listFaceValues, string description)
        {
            Console.Clear();
            Console.WriteLine(value: $"\n{description}\n");
            FillTheWallet(listFaceValues);
            Console.Clear();
            decimal walletValue = Calculate();
            Console.WriteLine("Stan Kasetki: " + helper.FormatValue(walletValue) + " zł.");
            Console.ReadKey();
            return walletValue;
        }


        /// <summary>
        /// Metoda wypełniająca portwel
        /// </summary>
        /// <param name="listFaceValues">Portfel</param>
        static void FillTheWallet(List<FaceValue> listFaceValues)
        {
            foreach (FaceValue item in listFaceValues)
            {
                string iloscString;
                Console.Write($"{item.Opis} \t: ");
                iloscString = Console.ReadLine();
                bool succes = int.TryParse(iloscString, out int ilosc);
                if (succes)
                {
                    item.quantity = ilosc;
                }
            }
        }

    }
}
