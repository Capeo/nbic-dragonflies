using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NbicDragonflies.Utility {
    class Constants
    {

        // Colors taken from NBIC webpage
        public static readonly Color NbicBrown = Color.FromHex("4f453e");
        public static readonly Color NbicOrange = Color.FromHex("e86c19");

        // Hierarchy of orders
        public static readonly List<string> order = new List<string> { "kingdom", "phylum", "subphylum", "class", "order", "suborder", "family", "genus", "species" };
    }
}
