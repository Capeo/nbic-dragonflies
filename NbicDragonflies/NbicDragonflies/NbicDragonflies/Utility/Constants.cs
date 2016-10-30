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

        // URL of REST service
        public static string TaxonRestUrl = "http://data.beta.artsdatabanken.no/Api/";
        public static string ObservationRestUrl = "http://pavlov.itea.ntnu.no/artskart/Api/Observations/";
        public static string SearchRestUrl = "http://data.beta.artsdatabanken.no/Api/search?q=";
        public static string PlaceholderSpeciesContentUrl = "http://data.beta.artsdatabanken.no/api/content/";
        public static string AreaCountyDataRestUrl = "http://artskart2.artsdatabanken.no/Api/area/";
    }
}
