using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models
{
    public class Taxon {
        /// <summary>
        /// Gets or sets the Id of the taxon.
        /// </summary>
        /// <value>The identifier.</value>
		public string Id { get; set; }
        /// <summary>
        /// Gets or sets the scientific name Id for the taxon.
        /// </summary>
        /// <value>The scientific name identifier.</value>
		public int scientificNameID { get; set; }
        /// <summary>
        /// Gets or sets the taxon Id.
        /// </summary>
        /// <value>The taxon identifier.</value>
		public int taxonID { get; set; }
		/// <summary>
		/// Gets or sets the scientific name. 
		/// </summary>
		/// <value>The name of the scientific.</value>
        public string scientificName { get; set; }
        /// <summary>
        /// Gets or sets the scientific name authorship.
        /// </summary>
        /// <value>The scientific name authorship.</value>
		public object scientificNameAuthorship { get; set; }
        /// <summary>
        /// Gets or sets the taxon rank.
        /// </summary>
        /// <value>The taxon rank.</value>
		public string taxonRank { get; set; }
        /// <summary>
        /// Gets or sets the taxonomic status.
        /// </summary>
        /// <value>The taxonomic status.</value>
		public string taxonomicStatus { get; set; }
        /// <summary>
        /// Gets or sets the accepted name usage.
        /// </summary>
        /// <value>The accepted name usage.</value>
		public object acceptedNameUsage { get; set; }
        
		public object nameAccordingTo { get; set; }

		/// <summary>
		/// Gets or sets the scientific names.
		/// </summary>
		/// <value>The scientific names.</value>
        public List<ScientificName> scientificNames { get; set; }
        /// <summary>
        /// Gets or sets the vernacular names.
        /// </summary>
        /// <value>The vernacular names.</value>
		public List<VernacularName> vernacularNames { get; set; }
        /// <summary>
        /// Gets or sets the accepted name. 
        /// </summary>
        /// <value>The name of the accepted.</value>
		public AcceptedName AcceptedName { get; set; }
        /// <summary>
        /// Gets or sets the preferred vernacular name. 
        /// </summary>
        /// <value>The name of the preferred vernacular.</value>
		public PreferredVernacularName PreferredVernacularName { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Models.Taxon"/> class.
		/// </summary>
		/// <param name="vernacularName">Vernacular name.</param>
		public Taxon()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Models.Taxon"/> class with parameters.
		/// </summary>
		/// <param name="taxonId">Taxon identifier.</param>
		/// <param name="scientificNameId">Scientific name identifier.</param>
		/// <param name="scientificName">Scientific name.</param>
		/// <param name="taxonRank">Taxon rank.</param>
        public Taxon(int taxonId, int scientificNameId, string scientificName , string taxonRank)
        {
            taxonID = taxonId;
            scientificNameID = scientificNameId;
            this.scientificName = scientificName;
            this.taxonRank = taxonRank;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Models.Taxon"/> class with only taxonID as parameter.
		/// </summary>
		/// <param name="taxonId">Taxon identifier.</param>
		public Taxon(int taxonId)
		{
			this.taxonID = taxonId;
		}

		/// <summary>
		/// Returns the vernacular name of the taxon for the current language. If not found, the first scientific name is returned. 
		/// </summary>
		/// <returns>The preferred name.</returns>
        // Returns the vernacular name of the taxon for the current langauge. If not found, the first scientific name is returned.
        public string GetPreferredName()
        {
            string ret = "";
            if (vernacularNames != null && vernacularNames.Count > 0)
            {
                VernacularName vName = vernacularNames.Where(name => Utility.Language.CompareToCurrent(name.language)).ToList().FirstOrDefault();
                if (vName != null)
                {
                    ret = Utility.Utilities.CapitalizeFirstLetter(vName.vernacularName);
                }
            }
            if (ret == "" && scientificNames != null && scientificNames.Count > 0)
            {
                ScientificName sName = scientificNames.FirstOrDefault();
                if (sName != null)
                {
                    ret = Utility.Utilities.CapitalizeFirstLetter(sName.scientificName);
                }
            }
            return ret; 
        }

        public string GetScientificName()
        {
            string ret = "";
            if (scientificNames != null && scientificNames.Count > 0) {
                ScientificName sName = scientificNames.FirstOrDefault();
                if (sName != null) {
                    ret = Utility.Utilities.CapitalizeFirstLetter(sName.scientificName);
                }
            }
            return ret;
        }
    }


    public class ScientificName {
        /// <summary>
        /// Gets or sets the Id of the scientific name.
        /// </summary>
        /// <value>The identifier.</value>
		public string Id { get; set; }
        /// <summary>
        /// Gets or sets the scientific name Id for the scientific name.
        /// </summary>
        /// <value>The scientific name identifier.</value>
		public int scientificNameID { get; set; }
        /// <summary>
        /// Gets or sets the taxon Id.
        /// </summary>
        /// <value>The taxon identifier.</value>
		public int taxonID { get; set; }
        /// <summary>
        /// Gets or sets the scientific name.
        /// </summary>
        /// <value>The name of the scientific.</value>
		public string scientificName { get; set; }
        /// <summary>
        /// Gets or sets the scientific name authorship.
        /// </summary>
        /// <value>The scientific name authorship.</value>
		public object scientificNameAuthorship { get; set; }
        /// <summary>
        /// Gets or sets the taxon rank.
        /// </summary>
        /// <value>The taxon rank.</value>
		public string taxonRank { get; set; }
        /// <summary>
        /// Gets or sets the taxonomic status.
        /// </summary>
        /// <value>The taxonomic status.</value>
		public string taxonomicStatus { get; set; }
        /// <summary>
        /// Gets or sets the accepted name usage.
        /// </summary>
        /// <value>The accepted name usage.</value>
		public object acceptedNameUsage { get; set; }
        public string nameAccordingTo { get; set; }
    }

    public class VernacularName {
        /// <summary>
        /// Gets or sets the vernacular name Id for vernacular names.
        /// </summary>
        /// <value>The vernacular name identifier.</value>
		public int vernacularNameID { get; set; }
        /// <summary>
        /// Gets or sets the taxon Id for vernacular names.
        /// </summary>
        /// <value>The taxon identifier.</value>
		public int taxonID { get; set; }
        /// <summary>
        /// Gets or sets the vernacular name.
        /// </summary>
        /// <value>The name of the vernacular.</value>
		public string vernacularName { get; set; }
		/// <summary>
		/// Gets or sets the nomenclatural status.
		/// </summary>
		/// <value>The nomenclatural status.</value>
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
        public AcceptedName AcceptedName { get; set; }
        public PreferredVernacularName PreferredVernacularName { get; set; }
    }
}
