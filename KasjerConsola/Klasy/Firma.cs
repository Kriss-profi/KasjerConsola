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

        public decimal CascetValue { get => Cascet.GetValue; }
        public decimal DaySafeValue { get => DaySafe.GetValue; }
        public decimal MainSafeValue { get => MainSafe.GetValue; }
        public decimal AllSafeValue { get => GetStateAllCasch; }
        public decimal DifferenceValue
        {
            get
            {
                return AllSafeValue - _systemValue;
            }
        }

        readonly Helper helper = new();

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

        // TODO: Move to Wallet -   I have moved it to firma because SystemValue checks AllSafeValue
        internal void ReadSystemValue()
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

        #region WriteWallet
        internal void WriteCascete()
        {
            Cascet.WalletWrite();
        }
        internal void WriteDaySafe()
        {
            DaySafe.WalletWrite();
        }
        internal void WriteMainSafe()
        {
            MainSafe.WalletWrite();
        }

        internal void WriteAllWallet()
        {
            Cascet.WalletWriteMore();
            DaySafe.WalletWriteMore();
            MainSafe.WalletWriteMore();
            Console.ReadKey();
        }
        #endregion

        #region ReadWallet
        internal void ReadValueCascete()
        {
            Cascet.WalletReadValue();
        }
        internal void ReadValueDaySafe()
        {
            DaySafe.WalletReadValue();
        }
        internal void ReadValueMainSafe()
        {
            MainSafe.WalletReadValue();
        }
        #endregion

        #region DiferenceValue
        public bool CheckDifferenceValue()
        {
            
            if (DifferenceValue == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ShowCascetValue()
        {
            return helper.FormatValue(CascetValue);
        }

        public string ShowDaySafeValue()
        {
            return helper.FormatValue(DaySafeValue);
        }
        public string ShowMainSafeValue()
        {
            return helper.FormatValue(MainSafeValue);
        }
        public void ShowDifferenceValue()
        {
            Console.WriteLine($"Stan gotówki w systemie   : {helper.FormatValue(SystemValue)} zł.");
            Console.WriteLine($"Stan gotówki w Kasie      : {helper.FormatValue(AllSafeValue)} zł.");
            if (CheckDifferenceValue())
            {
                Console.WriteLine("Stan kasy zgadza się z stanem gotówki w systemie");
            }
            else
            {
                if (DifferenceValue > 0)
                {
                    Console.BackgroundColor = (ConsoleColor)1;
                    Console.WriteLine($" Nadmiar gotówki w Kasie  : {helper.FormatValue(DifferenceValue)} zł.");
                    Console.BackgroundColor = 0;
                }
                else
                {
                    Console.BackgroundColor = (ConsoleColor)4;
                    Console.WriteLine($" Niedobór gotówki w Kasie : {helper.FormatValue(DifferenceValue)} zł.");
                    Console.BackgroundColor = 0;
                }
            }
        }
        #endregion
    }
}
