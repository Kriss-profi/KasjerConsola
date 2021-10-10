using System;
using System.Collections.Generic;
using KasjerConsola.Klasy;

namespace KasjerConsola
{
    using System.Linq;

    
    class Program
    {
        static void Main()
        {
            int x = 1;
            var firma = new Firma(new DataStorage());
            Console.WriteLine(firma.SystemValue);
            #region Pętla
            while (x != 0)
            {
                x = Menu();

                switch (x)
                {
                    case 1: { firma.WriteCascete(); break; }
                    case 2: { firma.WriteDaySafe(); break; }
                    case 3: { firma.WriteMainSafe(); break; }

                    //case 1: { CascetValue = WalletWrite(_cascet, "Kasetka"); break; }
                    //case 2: { DaySafeValue = WalletWrite(_daySafe, "Sejf dzienny"); break; }
                    //case 3: { MainSafeValue = WalletWrite(_mainSafe, "Sejf Główny"); break; }
                    //case 4: { CascetValue = WalletReadValue(_cascet, "Kasetka"); break; }
                    //case 5: { DaySafeValue = WalletReadValue(_daySafe, "Sejf Dzienny"); break; }
                    //case 6: { MainSafeValue = WalletReadValue(_mainSafe, "Sejf Główny"); break; }
                    //case 7: { FillSystemValue(); break; }
                    case 8: { firma.SaveAndClose(); break; }
                    default: { break; }
                }
            }
            firma.SaveAndClose();
            #endregion
        }

        private static int Menu()
        {
            Console.Clear();
            ShowDifferenceValue();
            Console.WriteLine("\n\nWybierz opcję z menu: \n");
            Console.WriteLine($"(1): Pokaż 'Kasetka'       : zł.");
            Console.WriteLine($"(2): Pokaż 'Sejf  Dzienny' :FormatValue(DaySafeValue) zł.");
            Console.WriteLine($"(3): Pokaż 'Sejf główny'   :FormatValue(MainSafeValue) zł.");
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
    }
}
