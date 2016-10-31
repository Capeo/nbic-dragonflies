using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models
{

    public class PropertyUrl
    {
        public string Type { get; set; }
        public string LinkTekst { get; set; }
        public string Url { get; set; }
    }

    public class Observation
    {
        public string Id { get; set; }
        public string Collection { get; set; }
        public object Sex { get; set; }
        public object IdentifiedBy { get; set; }
        public string DatetimeIdentified { get; set; }
        public object Habitat { get; set; }
        public object DatasetId { get; set; }
        public object DatasetName { get; set; }
        public object ObsUrl { get; set; }
        public string DetailUrl { get; set; }
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public string Author { get; set; }
        public string kingdom { get; set; }
        public string phylum { get; set; }
        public string klass { get; set; }
        public string order { get; set; }
        public string family { get; set; }
        public string genus { get; set; }
        public object subgenus { get; set; }
        public object specificEpithet { get; set; }
        public object infraspecificEpithet { get; set; }
        public object Status { get; set; }
        public string BasisOfRecord { get; set; }
        public object TypeObj { get; set; }
        public object DeterminationDate { get; set; }
        public string Collector { get; set; }
        public string CollctedDate { get; set; }
        public string Count { get; set; }
        public string Notes { get; set; }
        public object Country { get; set; }
        public string County { get; set; }
        public string Municipality { get; set; }
        public string Locality { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Precision { get; set; }
        public object Info { get; set; }
        public List<PropertyUrl> PropertyUrls { get; set; }
        public string TaxonId { get; set; }

        public string GetLocationText()
        {
            this.Country = this.Country == null ? "Norge" : this.Country;
            return this.Locality + ", " + this.Municipality + ", " + this.County + ", " + this.Country;
        }
    }

    public class ObservationList
    {
        public List<Observation> Observations { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }



}
