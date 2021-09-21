using System;
using System.Collections.Generic;
using KasjerConsola.Klasy;

namespace KasjerConsola
{
    class Program
    {
        private static List<FaceValue> _faceValues;
        static void Main()
        {
            decimal WalletValue;
            CreateWallet();
            DataStorage.Load(_faceValues);
            int x = 1;
            while(x != 0)
            {
                x = Menu();

                switch(x)
                {
                    case 1:
                        {
                            Console.Clear();
                            WalletValue = Wallet();
                            Console.WriteLine("Stan Kasetki: " + string.Format("{0:0,0.00}", WalletValue) + " zł.");
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Kasetka");
                            FillTheWallet();
                            Console.Clear();
                            WalletValue = Wallet();
                            Console.WriteLine("Stan Kasetki: " + string.Format("{0:0,0.00}", WalletValue) + " zł.");
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Sejf dzienny \n");
                            Console.WriteLine("Jeszcze nie ma! \n");
                            Console.ReadKey();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Sejf dzienny \n");
                            Console.WriteLine("Jeszcze nie ma! \n");
                            Console.ReadKey();
                            break;
                        }
                    case 8:
                        {
                            DataStorage.Storage(_faceValues);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }

        }

        static void CreateWallet()
        {
            _faceValues = new List<FaceValue>();
            _faceValues.Add(new FaceValue("N50000", 500.00));
            _faceValues.Add(new FaceValue("N20000", 200.00));
            _faceValues.Add(new FaceValue("N10000", 100.00));
            _faceValues.Add(new FaceValue("N5000 ", 50.00));
            _faceValues.Add(new FaceValue("N2000 ", 20.00));
            _faceValues.Add(new FaceValue("N1000 ", 10.00));
            _faceValues.Add(new FaceValue("N500  ", 5.00));
            _faceValues.Add(new FaceValue("N200  ", 2.00));
            _faceValues.Add(new FaceValue("N100  ", 1.00));
            _faceValues.Add(new FaceValue("N50   ", 0.50));
            _faceValues.Add(new FaceValue("N20   ", 0.20));
            _faceValues.Add(new FaceValue("N10   ", 0.10));
            _faceValues.Add(new FaceValue("N5    ", 0.05));
            _faceValues.Add(new FaceValue("N2    ", 0.02));
            _faceValues.Add(new FaceValue("N1    ", 0.01));
        }

        static decimal Wallet()
        {
            decimal walletValue = 0;
            Console.WriteLine("K A S E T K A ");
            foreach (FaceValue item in _faceValues)
            {
                Console.WriteLine("  " + item.Opis + " * " + item.quantity + " = " + item.Value);
                walletValue += (decimal)item.Value;
            }
            Console.WriteLine();
            //Console.WriteLine($"Stan kasetki: {0}", walletValue);         //      ???    Wyświetla "0"  ???
            return walletValue;
        }

        static void FillTheWallet()
        {
            foreach (FaceValue item in _faceValues)
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
            Console.WriteLine("(2): Wprowadź ilości 'Kasetka' ");
            //Console.WriteLine("(4): Wprowadź ilości 'Sejf Dzienny' ");
            //Console.WriteLine("(6): Wprowadź ilości 'Sejf' ");
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
    }
}
