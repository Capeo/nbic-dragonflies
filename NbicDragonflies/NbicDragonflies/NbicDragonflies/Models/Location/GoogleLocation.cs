using System.Collections.Generic;

namespace NbicDragonflies.Models.Location
{

    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }

    public class Result
    {
        public List<AddressComponent> address_components { get; set; }
        public string formatted_address { get; set; }
        public string place_id { get; set; }
        public List<string> types { get; set; }
    }

    public class GoogleLocation
    {
        public List<Result> results { get; set; }
        public string status { get; set; }
    }

}
