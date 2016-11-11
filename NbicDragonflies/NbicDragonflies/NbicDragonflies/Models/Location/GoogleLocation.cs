using System.Collections.Generic;

namespace NbicDragonflies.Models.Location
{
    /// <summary>
    /// Address component of a LocationResult
    /// </summary>
    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }

    /// <summary>
    /// Result part of GoogleLocation
    /// </summary>
    public class LocationResult
    {
        public List<AddressComponent> address_components { get; set; }
        public string formatted_address { get; set; }
        public string place_id { get; set; }
        public List<string> types { get; set; }
    }

    /// <summary>
    /// Model class received from Google API
    /// </summary>
    public class GoogleLocation
    {
        public List<LocationResult> results { get; set; }
        public string status { get; set; }
    }

}
