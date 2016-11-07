using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NbicDragonflies.Utility
{

    /// <summary>
    /// Static class for constants used in the project
    /// </summary>
    public static class Constants
    {

        /// <summary>
        /// Brown color taken from NBIC home page.
        /// </summary>
        public static readonly Color NbicBrown = Color.FromHex("4a4846");

        /// <summary>
        /// Orange color taken from NBIC home page.
        /// </summary>
        public static readonly Color NbicOrange = Color.FromHex("e86c19");

        /// <summary>
        /// Green color used on identification key page for selected options.
        /// </summary>
        public static readonly Color IdentifyGreen = Color.FromHex("c6f0a8");

        /// <summary>
        /// Red color used on identification key page for disabled options.
        /// </summary>
        public static readonly Color IdentifyRed = Color.FromHex("f0a8a8");

		/// <summary>
        /// Background color.
        /// </summary>
		public static readonly Color Background = Color.FromHex("e3e0da");

        /// <summary>
        /// Hierarchy of taxon ranks
        /// </summary>
        public static readonly List<string> TaxonRanks = new List<string> { "kingdom", "phylum", "subphylum", "class", "order", "suborder", "family", "genus", "species" };

        /// <summary>
        /// URL for NBIC taxon API
        /// </summary>
        public static readonly string TaxonRestUrl = "http://data.beta.artsdatabanken.no/Api/";

        /// <summary>
        /// URL for NBIC observations API
        /// </summary>
        public static readonly string ObservationRestUrl = "http://pavlov.itea.ntnu.no/artskart/Api/Observations/";

        /// <summary>
        /// URL for NBIC search API
        /// </summary>
        public static readonly string SearchRestUrl = "http://data.beta.artsdatabanken.no/Api/search?q=";

        /// <summary>
        /// URL for NBIC taxon content/info API
        /// </summary>
        public static readonly string TaxonContenRestUrl = "http://data.beta.artsdatabanken.no/api/content/";

        /// <summary>
        /// URL for NBIC area API
        /// </summary>
        public static readonly string AreaCountyDataRestUrl = "http://artskart2.artsdatabanken.no/Api/area/";

        /// <summary>
        /// URL for Google location API
        /// </summary>
        public static readonly string AreaNameFromLatLong = "https://maps.googleapis.com/maps/api/geocode/json?sensor=false&latlng=";
    }
}
