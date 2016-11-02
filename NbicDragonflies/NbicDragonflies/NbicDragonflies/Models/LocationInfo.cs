using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models
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

    public class LocationInfo
    {
        public List<Result> results { get; set; }
        public string status { get; set; }
    }

}
