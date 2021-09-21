using System;
using System.Collections.Generic;
using System.IO;

namespace KasjerConsola.Klasy
{
    public class DataStorage
    {
        // Dlaczego akurat static tego nie wiem, poprostu zaadoptowałem czyjąś klasę DataStorage do tego programu.
        public static void Storage(List<FaceValue> faceValues)
        {
            try
            {
                Console.Clear();

                FileStream stream = new FileStream("kasjer.dat", FileMode.Create);

                StreamWriter writer = new(stream);

                foreach (var item in faceValues)
                {
                    writer.WriteLine(item.quantity);
                }

                writer.Dispose();


                Console.WriteLine("Zapisano: ");
                foreach (var item in faceValues)
                {
                    Console.WriteLine(item.Nazwa + " " + item.quantity + " szt.");
                }
                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Błąd Zapisu: {exception.Message}");
                Console.ReadKey();
            }
        }

        public static void Load(List<FaceValue> faceValues)
        {
            try
            {            
                FileStream stream = new FileStream("kasjer.dat", FileMode.Open);

                StreamReader reader = new StreamReader(stream);

                foreach (FaceValue item in faceValues)
                {
                    string iloscString = reader.ReadLine();
                    bool succes = int.TryParse(iloscString, out int ilosc);
                    if (succes)
                    {
                        item.quantity = ilosc;
                    }
                }
                reader.Dispose();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Spodziewany błąd: {exception.Message}");
                Console.ReadKey();
            }
        }
    }
}
