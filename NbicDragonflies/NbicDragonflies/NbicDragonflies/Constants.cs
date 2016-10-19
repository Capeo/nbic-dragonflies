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
        public static string TaxonRestUrl = "http://data.beta.artsdatabanken.no/Api/Taxon/";
        public static string ObservationRestUrl = "http://pavlov.itea.ntnu.no/artskart/Api/Observations/";
    
        // Credentials that are hard coded into the REST service
        public static string Username = "Xamarin";
        public static string Password = "Pa$$w0rd";
    }
}
