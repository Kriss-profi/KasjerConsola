using System;
using System.Collections.Generic;
using System.IO;

namespace KasjerConsola.Klasy
{
    public class DataStorage
    {
        // Dlaczego akurat static tego nie wiem, poprostu zaadoptowałem czyjąś klasę DataStorage do tego programu.
        /// <summary>
        /// Zapis wszystkich portweli do pliku ze sprawdzeniem czy kasjer.dat istnieje
        /// </summary>
        /// <param name="faceValues1">Portwel 1</param>
        /// <param name="faceValues2">Portwel 2</param>
        /// <param name="faceValues3">Portwel 3</param>
        /// <param name="value">Stan gotówki w systemie</param>
        public static void Storage(List<FaceValue> faceValues1, List<FaceValue> faceValues2, List<FaceValue> faceValues3, decimal value)
        {
            try
            {
                Console.Clear();

                FileStream stream = new("kasjer.dat", FileMode.Create);

                StreamWriter writer = new(stream);
                SaweWallet(writer, faceValues1);
                SaweWallet(writer, faceValues2);
                SaweWallet(writer, faceValues3);
                writer.WriteLine(value);

                writer.Dispose();

                Console.WriteLine("Zapisano Wszystkie stany ");
                ReadWallet(faceValues1, "KASETKA");
                ReadWallet(faceValues2, "Sejf DZIENNY");
                ReadWallet(faceValues3, "Sejf GŁÓWNY");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Błąd Zapisu: {exception.Message}");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Metoda zapisująca Wallet do pliku
        /// </summary>
        /// <param name="writer">Obiekt typu StreamWriter na potrzeby zapisu w obiekcie typu FileStream</param>
        /// <param name="faceValues">Portwel, który ma zostać zapisany</param>
        private static void SaweWallet(StreamWriter writer, List<FaceValue> faceValues)
        {
            foreach (var item in faceValues)
            {
                writer.WriteLine(item.quantity);
            }
        }
        /// <summary>
        /// Wypisywanie portwela na ekranie 
        /// </summary>
        /// <param name="faceValues">Portwel, który ma zostać wyświetlony</param>
        /// <param name="v">Opis portwela</param>
        private static void ReadWallet(List<FaceValue> faceValues, string v)
        {
            Console.WriteLine($"\n {v} : ");
            foreach (var item in faceValues)
            {
                Console.WriteLine(item.Nazwa + " " + item.quantity + " szt.");
            }
        }

        /// <summary>
        /// Metoda pobiera dane z pliku kasjer.dat
        /// </summary>
        /// <param name="faceValues1">Kasetka</param>
        /// <param name="faceValues2">Sejf dzienny</param>
        /// <param name="faceValues3">Sejf główny</param>
        public static void Load(List<FaceValue> faceValues1, List<FaceValue> faceValues2, List<FaceValue> faceValues3)
        {
            try
            {
                FileStream stream = new("kasjer.dat", FileMode.Open);

                StreamReader reader = new(stream);

                foreach (FaceValue item in faceValues1)
                {
                    string iloscString = reader.ReadLine();
                    bool succes = int.TryParse(iloscString, out int ilosc);
                    if (succes)
                    {
                        item.quantity = ilosc;
                        Program.CascetValue += item.Value;
                    }
                }
                foreach (FaceValue item in faceValues2)
                {
                    string iloscString = reader.ReadLine();
                    bool succes = int.TryParse(iloscString, out int ilosc);
                    if (succes)
                    {
                        item.quantity = ilosc;
                        Program.DaySafeValue += item.Value;
                    }
                }
                foreach (FaceValue item in faceValues3)
                {
                    string iloscString = reader.ReadLine();
                    bool succes = int.TryParse(iloscString, out int ilosc);
                    if (succes)
                    {
                        item.quantity = ilosc;
                        Program.MainSafeValue += item.Value;
                    }
                }
                string valueS = reader.ReadLine();
                bool succesSV = decimal.TryParse(valueS, out decimal valueD);
                if (succesSV) { Program.SystemValue = valueD; }
                
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
