using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Location(double Latitude, double Longitude)
        {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
    }

    public class AreaDataSet
    {
        public string Bbox { get; set; }
        public string Dataset { get; set; }
        public string GoogleMercatorBbox { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public object ParentFid { get; set; }
        public Location Location { get; set; }
    }
}
