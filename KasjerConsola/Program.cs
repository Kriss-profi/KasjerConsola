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
                x = Menu(firma);

                switch (x)
                {
                    case 1: { firma.WriteCascete(); break; }
                    case 2: { firma.WriteDaySafe(); break; }
                    case 3: { firma.WriteMainSafe(); break; }
                    case 4: { firma.ReadValueCascete(); break; }
                    case 5: { firma.ReadValueDaySafe(); break; }
                    case 6: { firma.ReadValueMainSafe(); break; }
                    case 7: { firma.ReadSystemValue(); break; }
                    case 8: { firma.SaveAndClose(); break; }
                    default: { break; }
                }
            }
            firma.SaveAndClose();
            #endregion
        }

        private static int Menu(Firma firma)
        {
            Console.Clear();
            firma.ShowDifferenceValue();
            Console.WriteLine("\n\nWybierz opcję z menu: \n");
            Console.WriteLine($"(1): Pokaż 'Kasetka'       :{firma.ShowCascetValue()} zł.");
            Console.WriteLine($"(2): Pokaż 'Sejf  Dzienny' :{firma.ShowDaySafeValue()} zł.");
            Console.WriteLine($"(3): Pokaż 'Sejf główny'   :{firma.ShowMainSafeValue()} zł.");
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
    }
}
