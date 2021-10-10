using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KasjerConsola.Klasy
{
    public class Wallet
    {
        public List<FaceValue> Values { get; set; }
        private readonly string _name;
        private readonly Helper helper = new();
        

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

        public void WalletWrite()        // Wypisanie nominałów portfels z podsumowaniem
        {
            Console.Clear();
            decimal walletValue = Calculate();
            Cash(walletValue);
            Console.ReadKey();
        }

        public void WalletWriteMore()        // Wypisanie nominałów portfels z podsumowaniem
        {
            decimal walletValue = Calculate();
            Cash(walletValue);
            Console.WriteLine();
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
            Console.WriteLine("********************************");
            Console.WriteLine($"          {_name}");
            Console.WriteLine("********************************");
            foreach (FaceValue item in Values)
            {
                Console.WriteLine("  " + item.Opis + " * " + helper.IntFormat(item.quantity) + " = " + helper.DoubleFormat(item.Value));
                walletValue += (decimal)item.Value;
            }
            Console.WriteLine();
            //Console.WriteLine($"Stan kasetki: {0}", walletValue);         //      ???    Wyświetla "0"  ???
            return walletValue;
        }


        // TODO: Move to Wallet - Done
        public decimal WalletReadValue()
        {
            Console.Clear();
            Console.WriteLine(value: $"\n{_name}\n");
            FillTheWallet();
            Console.Clear();
            decimal walletValue = Calculate();
            Cash(walletValue);
            Console.ReadKey();
            return walletValue;
        }

        private void Cash(decimal walletValue)
        {
            Console.WriteLine($"Stan Gotówki:   {helper.FormatValue(walletValue)} zł.");
            Console.WriteLine("--------------------------------");
        }


        /// <summary>
        /// Metoda wypełniająca portwel
        /// </summary>
        private void FillTheWallet()
        {
            foreach (FaceValue item in Values )
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
