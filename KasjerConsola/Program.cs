using System;
using System.Collections.Generic;
using KasjerConsola.Klasy;

namespace KasjerConsola
{
    class Program
    {
        private static List<FaceValue> _cascet;
        private static List<FaceValue> _daySafe;
        private static List<FaceValue> _mainSafe;

        public static decimal WalletValue { get; private set; }

        static void Main()
        {
            CreateWallet();
            DataStorage.Load(_cascet, _daySafe, _mainSafe);
            int x = 1;
            #region Pętla

            while (x != 0)
            {
                x = Menu();

                switch(x)
                {
                    case 1:
                        {
                            WalletWrite(_cascet, "Kasetka");
                            break;
                        }
                    case 2:
                        {
                            WalletWrite(_daySafe, "Sejf dzienny");
                            break;
                        }
                    case 3:
                        {
                            WalletWrite(_mainSafe, "Sejf Główny");
                            break;
                        }
                    case 4:
                        {
                            WalletReadValue(_cascet, "Kasetka");
                            break;
                        }
                    case 5:
                        {
                            WalletReadValue(_daySafe, "Sejf Dzienny");
                            break;
                        }
                    case 6:
                        {
                            WalletReadValue(_mainSafe, "Sejf Główny");
                            break;
                        }
                    case 8:
                        {
                            DataStorage.Storage(_cascet, _daySafe, _mainSafe);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            #endregion
        }
        static void CreateWallet()
        {
            _cascet = new List<FaceValue>();
            _cascet.Add(new FaceValue("N50000", 500.00));
            _cascet.Add(new FaceValue("N20000", 200.00));
            _cascet.Add(new FaceValue("N10000", 100.00));
            _cascet.Add(new FaceValue("N5000 ", 50.00));
            _cascet.Add(new FaceValue("N2000 ", 20.00));
            _cascet.Add(new FaceValue("N1000 ", 10.00));
            _cascet.Add(new FaceValue("N500  ", 5.00));
            _cascet.Add(new FaceValue("N200  ", 2.00));
            _cascet.Add(new FaceValue("N100  ", 1.00));
            _cascet.Add(new FaceValue("N50   ", 0.50));
            _cascet.Add(new FaceValue("N20   ", 0.20));
            _cascet.Add(new FaceValue("N10   ", 0.10));
            _cascet.Add(new FaceValue("N5    ", 0.05));
            _cascet.Add(new FaceValue("N2    ", 0.02));
            _cascet.Add(new FaceValue("N1    ", 0.01));
            _daySafe = new List<FaceValue>();
            _daySafe.Add(new FaceValue("N50000", 500.00));
            _daySafe.Add(new FaceValue("N20000", 200.00));
            _daySafe.Add(new FaceValue("N10000", 100.00));
            _daySafe.Add(new FaceValue("N5000 ", 50.00));
            _daySafe.Add(new FaceValue("N2000 ", 20.00));
            _daySafe.Add(new FaceValue("N1000 ", 10.00));
            _daySafe.Add(new FaceValue("N500  ", 5.00));
            _daySafe.Add(new FaceValue("N200  ", 2.00));
            _daySafe.Add(new FaceValue("N100  ", 1.00));
            _daySafe.Add(new FaceValue("N50   ", 0.50));
            _daySafe.Add(new FaceValue("N20   ", 0.20));
            _daySafe.Add(new FaceValue("N10   ", 0.10));
            _daySafe.Add(new FaceValue("N5    ", 0.05));
            _daySafe.Add(new FaceValue("N2    ", 0.02));
            _daySafe.Add(new FaceValue("N1    ", 0.01));
            _mainSafe = new List<FaceValue>();
            _mainSafe.Add(new FaceValue("N50000", 500.00));
            _mainSafe.Add(new FaceValue("N20000", 200.00));
            _mainSafe.Add(new FaceValue("N10000", 100.00));
            _mainSafe.Add(new FaceValue("N5000 ", 50.00));
            _mainSafe.Add(new FaceValue("N2000 ", 20.00));
            _mainSafe.Add(new FaceValue("N1000 ", 10.00));
            _mainSafe.Add(new FaceValue("N500  ", 5.00));
            _mainSafe.Add(new FaceValue("N200  ", 2.00));
            _mainSafe.Add(new FaceValue("N100  ", 1.00));
            _mainSafe.Add(new FaceValue("N50   ", 0.50));
            _mainSafe.Add(new FaceValue("N20   ", 0.20));
            _mainSafe.Add(new FaceValue("N10   ", 0.10));
            _mainSafe.Add(new FaceValue("N5    ", 0.05));
            _mainSafe.Add(new FaceValue("N2    ", 0.02));
            _mainSafe.Add(new FaceValue("N1    ", 0.01));
        }

        static decimal Wallet(List<FaceValue> listFaceValues, string description)
        {
            decimal walletValue = 0;
            Console.WriteLine(description);
            foreach (FaceValue item in listFaceValues)
            {
                Console.WriteLine("  " + item.Opis + " * " + item.quantity + " = " + item.Value);
                walletValue += (decimal)item.Value;
            }
            Console.WriteLine();
            //Console.WriteLine($"Stan kasetki: {0}", walletValue);         //      ???    Wyświetla "0"  ???
            return walletValue;
        }

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
        private static int Menu()
        {
            Console.Clear();
            Console.WriteLine("Wybierz opcję z menu: \n");
            Console.WriteLine("(1): Pokaż 'Kasetka' ");
            Console.WriteLine("(2): Pokaż 'Sejf Dzienny' ");
            Console.WriteLine("(3): Pokaż 'Sejf główny' ");
            Console.WriteLine("(4): Wprowadź ilości 'Kasetka' ");
            Console.WriteLine("(5): Wprowadź ilości 'Sejf Dzienny' ");
            Console.WriteLine("(6): Wprowadź ilości 'Sejf główny' ");
            Console.WriteLine("(8): Zapisz ");
            Console.WriteLine("(0): Zakończ Program");
            Console.WriteLine();
            Console.Write("Opcja:  ");
            bool succes = int.TryParse(Console.ReadLine(), out int x);
            if(succes)
            {
            return x;
            }
            else
            {
                return 9;
            }
        }

        static void WalletWrite(List<FaceValue> listFaceValues, string description)
        {
            Console.Clear();
            WalletValue = Wallet(listFaceValues, description);
            Console.WriteLine("Stan Kasetki: " + string.Format("{0:0,0.00}", WalletValue) + " zł.");
            Console.ReadKey();
        }

        static void WalletReadValue(List<FaceValue> listFaceValues, string description)
        {
            Console.Clear();
            Console.WriteLine(description);
            FillTheWallet(listFaceValues);
            Console.Clear();
            WalletValue = Wallet(listFaceValues, description);
            Console.WriteLine("Stan Kasetki: " + string.Format("{0:0,0.00}", WalletValue) + " zł.");
            Console.ReadKey();
        }

         
    }
}
