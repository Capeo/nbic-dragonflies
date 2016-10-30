using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models
{
    public class LocationCoordinates
    {
        public long Latitude { get; set; }
        public long Longitude { get; set; }
    }

    public class AreaDataSet
    {
        public string Bbox { get; set; }
        public string Dataset { get; set; }
        public string GoogleMercatorBbox { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public object ParentFid { get; set; }
        public LocationCoordinates Location { get; set; }
    }
}
