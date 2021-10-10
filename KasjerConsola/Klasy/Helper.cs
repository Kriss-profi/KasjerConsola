using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasjerConsola.Klasy
{
    public class Helper
    {

        public string FormatValue(decimal value)
        {
            string s = string.Format("{0,12:#,0.00}", value);
            return s;
        }
        public string DoubleFormat(decimal value)
        {
            string s = string.Format("{0,9:#,0.00}", value);
            return s;
        }
        public string IntFormat(int value)
        {
            string s = string.Format("{0,4:#,0}", value);
            return s;
        }
    }
}
