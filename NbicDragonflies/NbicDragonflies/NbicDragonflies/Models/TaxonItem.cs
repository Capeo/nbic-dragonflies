using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models
{
    public class TaxonItem
    {
        public int TaxonId { get; set; }
        public int ScientificNameID { get; set; }

        // Other characteristics

        public TaxonItem (int taxonId, int scientificNameId)
        {
            this.TaxonId = taxonId;
            this.ScientificNameID = scientificNameId;
        }
    }
}
