using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Utility
{
    public class Utilities
    {
        public static string CapitalizeFirstLetter(string str)
        {
            if (str.Length >= 1)
            {
                return str.Substring(0, 1).ToUpper() + str.Substring(1);
            }
            return str;
        }
    }
}
