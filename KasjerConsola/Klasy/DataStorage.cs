using System;
using System.Collections.Generic;
using System.IO;

namespace KasjerConsola.Klasy
{
    public class DataStorage
    {
        // Dlaczego akurat static tego nie wiem, poprostu zaadoptowałem czyjąś klasę DataStorage do tego programu.
        public static void Storage(List<FaceValue> faceValues1, List<FaceValue> faceValues2, List<FaceValue> faceValues3)
        {
            try
            {
                Console.Clear();

                FileStream stream = new FileStream("kasjer.dat", FileMode.Create);

                StreamWriter writer = new(stream);

                foreach (var item in faceValues1)
                {
                    writer.WriteLine(item.quantity);
                }
                foreach (var item in faceValues2)
                {
                    writer.WriteLine(item.quantity);
                }
                foreach (var item in faceValues3)
                {
                    writer.WriteLine(item.quantity);
                }

                writer.Dispose();


                Console.WriteLine("Zapisano Wszystkie stany ");
                Console.WriteLine("KASETKA: ");
                foreach (var item in faceValues1)
                {
                    Console.WriteLine(item.Nazwa + " " + item.quantity + " szt.");
                }
                Console.ReadKey();
                Console.WriteLine("\nSejf DZIENNY: ");
                foreach (var item in faceValues2)
                {
                    Console.WriteLine(item.Nazwa + " " + item.quantity + " szt.");
                }
                Console.ReadKey();
                Console.WriteLine("\nSejf GŁÓWNY: ");
                foreach (var item in faceValues3)
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

        public static void Load(List<FaceValue> faceValues1, List<FaceValue> faceValues2, List<FaceValue> faceValues3)
        {
            try
            {            
                FileStream stream = new FileStream("kasjer.dat", FileMode.Open);

                StreamReader reader = new StreamReader(stream);

                foreach (FaceValue item in faceValues1)
                {
                    string iloscString = reader.ReadLine();
                    bool succes = int.TryParse(iloscString, out int ilosc);
                    if (succes)
                    {
                        item.quantity = ilosc;
                    }
                }
                foreach (FaceValue item in faceValues2)
                {
                    string iloscString = reader.ReadLine();
                    bool succes = int.TryParse(iloscString, out int ilosc);
                    if (succes)
                    {
                        item.quantity = ilosc;
                    }
                }
                foreach (FaceValue item in faceValues3)
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
