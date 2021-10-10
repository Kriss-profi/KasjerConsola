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
        public void Save(Firma firma, decimal value)
        {
            try
            {
                Console.Clear();

                FileStream stream = new("kasjer.dat", FileMode.Create);

                StreamWriter writer = new(stream);
                SaveWallet(writer, firma.Cascet.Values);
                SaveWallet(writer, firma.DaySafe.Values);
                SaveWallet(writer, firma.MainSafe.Values);
                writer.WriteLine(value);

                writer.Dispose();

                //Console.WriteLine("Zapisano Wszystkie stany ");
                //ReadWallet(firma.Cascet.Values, "KASETKA");
                //ReadWallet(firma.DaySafe.Values, "Sejf DZIENNY");
                //ReadWallet(firma.MainSafe.Values, "Sejf GŁÓWNY");
                
                // TODO - mozna tak..
                //firma.Cascet.ReadWallet();
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
        private static void SaveWallet(StreamWriter writer, List<FaceValue> faceValues)
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
        public void Load(Firma firma)
        {
            try
            {
                FileStream stream = new("kasjer.dat", FileMode.Open);

                StreamReader reader = new(stream);

                foreach (FaceValue item in firma.Cascet.Values)
                {
                    string iloscString = reader.ReadLine();
                    bool succes = int.TryParse(iloscString, out int ilosc);
                    if (succes)
                    {
                        item.quantity = ilosc;
                        firma.CascetValue += item.Value;
                    }
                }
                foreach (FaceValue item in firma.DaySafe.Values)
                {
                    string iloscString = reader.ReadLine();
                    bool succes = int.TryParse(iloscString, out int ilosc);
                    if (succes)
                    {
                        item.quantity = ilosc;
                        //firma.DaySafeValue += item.Value;
                    }
                }
                foreach (FaceValue item in firma.MainSafe.Values)
                {
                    string iloscString = reader.ReadLine();
                    bool succes = int.TryParse(iloscString, out int ilosc);
                    if (succes)
                    {
                        item.quantity = ilosc;
                        firma.MainSafeValue += item.Value;
                    }
                }
                string valueS = reader.ReadLine();
                bool succesSV = decimal.TryParse(valueS, out decimal valueD);
                if (succesSV) { firma.SystemValue = valueD; }
                
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
