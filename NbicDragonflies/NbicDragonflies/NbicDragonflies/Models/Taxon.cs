using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models
{
    public class Taxon {
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

		public Taxon()
		{
		}

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

        // Returns the vernacular name of the taxon for the current langauge. If not found, the first scientific name is returned.
        public string GetPreferredName()
        {
            string ret = "";
            if (vernacularNames != null && vernacularNames.Count > 0)
            {
                VernacularName vName = vernacularNames.Where(name => Utility.Language.CompareToCurrent(name.language)).ToList().FirstOrDefault();
                if (vName != null)
                {
                    ret = vName.vernacularName;
                }
            }
            if (ret == "" && scientificNames != null && scientificNames.Count > 0)
            {
                ScientificName sName = scientificNames.FirstOrDefault();
                if (sName != null)
                {
                    ret = sName.scientificName;
                }
            }
            return ret; 
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
