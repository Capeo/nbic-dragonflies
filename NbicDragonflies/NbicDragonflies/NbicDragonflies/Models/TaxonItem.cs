using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models
{
    public class TaxonItem
    {
        public int scientificNameId { get; set; }
        public int taxonId { get; set; }
        public string scientificName { get; set; }
        public string taxonRank { get; set; }

        public TaxonItem (int scientificNameId, int taxonId, string scientificName, string taxonRank)
        {
            this.scientificNameId = scientificNameId;
            this.taxonId = taxonId;
            this.scientificName = scientificName;
            this.taxonRank = taxonRank;
        }
    }
}
