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

		//Page background
		public static readonly Color Background = Color.FromHex("e0e0e0");

        // Hierarchy of orders
        public static readonly List<string> TaxonRanks = new List<string> { "kingdom", "phylum", "subphylum", "class", "order", "suborder", "family", "genus", "species" };
    }
}
