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

        public static decimal DifferenceValue { get; private set; }
        public static decimal CascetValue { get; set; }
        public static decimal DaySafeValue { get; set; }
        public static decimal MainSafeValue { get; set; }
        public static decimal SafeValue { get; set; }
        public static decimal SystemValue { get; set; }

        static void Main()
        {
            int x = 1;
            CreateWallet();
            DataStorage.Load(_cascet, _daySafe, _mainSafe);
            Console.WriteLine(Program.SystemValue);
            #region Pętla
            while (x != 0)
            {

                ChangeSafeValue();
                x = Menu();

                switch(x)
                {
                    case 1: { CascetValue = WalletWrite(_cascet, "Kasetka"); break; }
                    case 2: { DaySafeValue = WalletWrite(_daySafe, "Sejf dzienny"); break; }
                    case 3: { MainSafeValue = WalletWrite(_mainSafe, "Sejf Główny"); break; }
                    case 4: { CascetValue = WalletReadValue(_cascet, "Kasetka"); break; }
                    case 5: { DaySafeValue =  WalletReadValue(_daySafe, "Sejf Dzienny"); break; }
                    case 6: { MainSafeValue =  WalletReadValue(_mainSafe, "Sejf Główny"); break; }
                    case 7: { FillSystemValue(); break; }
                    case 8: { DataStorage.Storage(_cascet, _daySafe, _mainSafe, SystemValue); break; }
                    default: { break; }
                }
            }
            DataStorage.Storage(_cascet, _daySafe, _mainSafe, SystemValue);
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

            _daySafe = new List<FaceValue>
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

            _mainSafe = new List<FaceValue>
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
        }

        private static int Menu()
        {
            Console.Clear();
            ShowDifferenceValue();
            Console.WriteLine("\n\nWybierz opcję z menu: \n");
            Console.WriteLine($"(1): Pokaż    'Kasetka'    :{FormatValue(CascetValue)} zł.");
            Console.WriteLine($"(2): Pokaż 'Sejf  Dzienny' :{FormatValue(DaySafeValue)} zł.");
            Console.WriteLine($"(3): Pokaż  'Sejf główny'  :{FormatValue(MainSafeValue)} zł.");
            Console.WriteLine("(4): Wprowadź ilości 'Kasetka' ");
            Console.WriteLine("(5): Wprowadź ilości 'Sejf Dzienny' ");
            Console.WriteLine("(6): Wprowadź ilości 'Sejf główny' ");
            Console.WriteLine("(7): Wprowadź stan gotówki z systemu ");
            Console.WriteLine("(8): Zapisz ");
            Console.WriteLine("(0): Zakończ Program");
            Console.WriteLine();
            Console.Write("Opcja:  ");
            bool succes = int.TryParse(Console.ReadLine(), out int x);
            if (succes)
            {
                return x;
            }
            else
            {
                return 9;
            }
        }

        static decimal Wallet(List<FaceValue> listFaceValues, string description)
        {
            decimal walletValue = 0;
            Console.WriteLine(description);
            foreach (FaceValue item in listFaceValues)
            {
                Console.WriteLine("  " + item.Opis + " * " + IntFormat(item.quantity) + " = " + DoubleFormat(item.Value));
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

        private static decimal WalletWrite(List<FaceValue> listFaceValues, string description)
        {
            Console.Clear();
            decimal walletValue = Wallet(listFaceValues, description);
            Console.WriteLine("Stan Kasetki: " + FormatValue(walletValue) + " zł.");
            Console.ReadKey();
            return walletValue;
        }

        private static decimal WalletReadValue(List<FaceValue> listFaceValues, string description)
        {
            Console.Clear();
            Console.WriteLine(value: $"\n{description}\n");
            FillTheWallet(listFaceValues);
            Console.Clear();
            decimal walletValue = Wallet(listFaceValues, description);
            Console.WriteLine("Stan Kasetki: " + FormatValue(walletValue) + " zł.");
            Console.ReadKey();
            return walletValue;
        }

        private static void FillSystemValue()
        {
            Console.Clear();
            Console.WriteLine("\nPodaj aktualny stan gotówki z systemu: ");
            string stringValue = Console.ReadLine();
            bool succes = decimal.TryParse(stringValue, out decimal value);
            if (succes) { SystemValue = value; }
        }
        private static void ChangeSafeValue()
        {
            SafeValue = CascetValue + DaySafeValue + MainSafeValue;
        }
        public static bool CheckDifferenceValue()
        {
            DifferenceValue = SafeValue - SystemValue;
            if (DifferenceValue == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ShowDifferenceValue()
        {
            Console.WriteLine($"Stan gotówki w systemie   : {FormatValue(SystemValue)} zł.");
            Console.WriteLine($"Stan gotówki w Kasie      : {FormatValue(SafeValue)} zł.");
            if (CheckDifferenceValue())
            {
                Console.WriteLine("Stan kasy zgadza się z stanem gotówki w systemie");
            }
            else
            {
                if (DifferenceValue > 0)
                {
                    Console.BackgroundColor = (ConsoleColor)1;
                    Console.WriteLine($" Nadmiar gotówki w Kasie  : {FormatValue(DifferenceValue)} zł.");
                    Console.BackgroundColor = 0;
                }
                else
                {
                    Console.BackgroundColor = (ConsoleColor)4;
                    Console.WriteLine($" Niedobór gotówki w Kasie : {FormatValue(DifferenceValue)} zł.");
                    Console.BackgroundColor = 0;
                }
            }
        }

        public static string FormatValue(decimal value)
        {
            string s = string.Format("{0,12:#,0.00}", value);
            return s;
        }
        public static string DoubleFormat(decimal value)
        {
            string s = string.Format("{0,9:#,0.00}", value);
            return s;
        }
        public static string IntFormat(int value)
        {
            string s = string.Format("{0,4:#,0}", value);
            return s;
        }
    }
}
