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
        /// <param name="firma">Klasa firma posiada wszystkie portfele</param>
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

                // TODO - mozna tak..
                firma.WriteAllWallet();
                //firma.Cascet.WalletWrite();
                //firma.DaySafe.WalletWrite();
                //firma.MainSafe.WalletWrite();
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
        /// Metoda pobiera dane z pliku kasjer.dat
        /// </summary>
        /// <param name="firma">Klasa firma posiada wszystkie portfele</param>
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
                    }
                }
                foreach (FaceValue item in firma.DaySafe.Values)
                {
                    string iloscString = reader.ReadLine();
                    bool succes = int.TryParse(iloscString, out int ilosc);
                    if (succes)
                    {
                        item.quantity = ilosc;
                    }
                }
                foreach (FaceValue item in firma.MainSafe.Values)
                {
                    string iloscString = reader.ReadLine();
                    bool succes = int.TryParse(iloscString, out int ilosc);
                    if (succes)
                    {
                        item.quantity = ilosc;
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
