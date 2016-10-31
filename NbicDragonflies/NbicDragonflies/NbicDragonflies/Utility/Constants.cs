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
        public static readonly Color NbicBrown = Color.FromHex("4a4846");
        public static readonly Color NbicOrange = Color.FromHex("e86c19");
        public static readonly Color KeyGreen = Color.FromHex("c6f0a8");
        public static readonly Color KeyRed = Color.FromHex("f0a8a8");

        // Hierarchy of orders
        public static readonly List<string> TaxonRanks = new List<string> { "kingdom", "phylum", "subphylum", "class", "order", "suborder", "family", "genus", "species" };
    }
}
