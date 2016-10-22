using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models
{
    public class Taxon {
        public object _ { get; set; }
        public string Id { get; set; }
        public int scientificNameID { get; set; }
        public int taxonID { get; set; }

        public string scientificName { get; set; }
        public object scientificNameAuthorship { get; set; }
        public string taxonRank { get; set; }
        public string taxonomicStatus { get; set; }
        public object acceptedNameUsage { get; set; }
        public object nameAccordingTo { get; set; }

        public List<ScientificName> scientificNames { get; set; }
        public List<VernacularName> vernacularNames { get; set; }
        public AcceptedName AcceptedName { get; set; }
        public PreferredVernacularName PreferredVernacularName { get; set; }

        public Taxon(int taxonId, int scientificNameId, string scientificName , string taxonRank )
        {
            taxonID = taxonId;
            scientificNameID = scientificNameId;
            this.scientificName = scientificName;
            this.taxonRank = taxonRank;
        }

		public Taxon(int taxonID)
		{
			taxonID = taxonID;
		}
    }

    public class ScientificName {
        public string Id { get; set; }
        public int scientificNameID { get; set; }
        public int taxonID { get; set; }
        public string scientificName { get; set; }
        public object scientificNameAuthorship { get; set; }
        public string taxonRank { get; set; }
        public string taxonomicStatus { get; set; }
        public object acceptedNameUsage { get; set; }
        public string nameAccordingTo { get; set; }
    }

    public class VernacularName {
        public int vernacularNameID { get; set; }
        public int taxonID { get; set; }
        public string vernacularName { get; set; }
        public string nomenclaturalStatus { get; set; }
        public string language { get; set; }
        public string nameAccordingTo { get; set; }
    }

    public class AcceptedName {
        public string Id { get; set; }
        public int scientificNameID { get; set; }
        public int taxonID { get; set; }
        public string scientificName { get; set; }
        public object scientificNameAuthorship { get; set; }
        public string taxonRank { get; set; }
        public string taxonomicStatus { get; set; }
        public object acceptedNameUsage { get; set; }
        //public List<HigherClassification2> higherClassification { get; set; }
        public string nameAccordingTo { get; set; }
        //public List<DynamicProperty2> dynamicProperties { get; set; }
    }

    public class PreferredVernacularName {
        public int vernacularNameID { get; set; }
        public int taxonID { get; set; }
        public string vernacularName { get; set; }
        public string nomenclaturalStatus { get; set; }
        public string language { get; set; }
        public string nameAccordingTo { get; set; }
    }

    public class VernacularTaxon {
        public object _ { get; set; }
        public string Id { get; set; }
        public int taxonID { get; set; }
        public List<ScientificName> scientificNames { get; set; }
        public List<VernacularName> vernacularNames { get; set; }
        //public List<object> dynamicProperties { get; set; }
        public AcceptedName AcceptedName { get; set; }
        public PreferredVernacularName PreferredVernacularName { get; set; }
    }
}
