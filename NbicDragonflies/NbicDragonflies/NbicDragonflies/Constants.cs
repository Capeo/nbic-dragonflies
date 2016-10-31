using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies
{
    public static class Constants
    {
        // URL of REST service
        public static string TaxonRestUrl = "http://data.beta.artsdatabanken.no/Api/";
        public static string ObservationRestUrl = "http://pavlov.itea.ntnu.no/artskart/Api/Observations/";
        public static string SearchRestUrl = "http://data.beta.artsdatabanken.no/Api/search?q=";
        public static string PlaceholderSpeciesContentUrl = "http://data.beta.artsdatabanken.no/api/content/";
    }
}
