using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasjerConsola.Klasy
{

    public class Firma
    {
        private decimal _systemValue;
        public Wallet Cascet { get; private set; }
        public Wallet DaySafe { get; private set; }
        public Wallet MainSafe { get; private set; }

        private DataStorage _dataStorage;

        public decimal DifferenceValue { get; private set; }
        public decimal CascetValue { get => Cascet.GetValue; }


        public decimal DaySafeValue { get => DaySafe.GetValue; }
        public decimal MainSafeValue { get => MainSafe.GetValue; }
        public decimal AllSafeValue { get => GetStateAllCasch; }

        Helper helper = new Helper();

        public decimal SystemValue
        {
            get => _systemValue;
            set => _systemValue = value;
        }

        public Firma(DataStorage dataStorage)
        {
            _dataStorage = dataStorage;
            Cascet = new Wallet("Kasetka");
            DaySafe = new Wallet("Sejf dzienny");
            MainSafe = new Wallet("Sejf Główny");

            _dataStorage.Load(this);
        }

        // TODO: Move to Wallet -   przeniosłem do firma
        private void FillSystemValue()
        {
            Console.Clear();
            Console.WriteLine("\nPodaj aktualny stan gotówki z systemu: ");
            string stringValue = Console.ReadLine();
            bool succes = decimal.TryParse(stringValue, out decimal value);
            if (succes) { SystemValue = value; }
        }


        public decimal GetStateAllCasch
        {
            get
            {
                return CascetValue + DaySafeValue + MainSafeValue;
            }
        }

        internal void SaveAndClose()
        {
            _dataStorage.Save(this, SystemValue);
        }

        internal void WriteCascete()
        {
            throw new NotImplementedException();
        }
    }
}
