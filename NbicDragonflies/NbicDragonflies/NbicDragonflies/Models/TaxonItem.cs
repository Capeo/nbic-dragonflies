using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models
{
    public class TaxonItem
    {
        public int scientificNameId;
        public int taxonId;
        public string scientificName;

        public TaxonItem (int scientificNameId, int taxonId, string scientificName)
        {
            this.scientificNameId = scientificNameId;
            this.taxonId = taxonId;
            this.scientificName = scientificName;
        }
    }
}
