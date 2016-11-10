using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Data;
using NbicDragonflies.Models;
using NbicDragonflies.Models.Taxon;

namespace NbicDragonflies.Controllers {

    /// <summary>
    /// Implementation of ITaxonTreeController interface
    /// </summary>
    public class TaxonTreeController : ITaxonTreeController
    {
        private int _rootScientificNameId;
        private string _rootRank;

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaxonTreeController()
        {
            _rootScientificNameId = 107;
            _rootRank = "order";
        }

        /// <summary>
        /// Retrieves the root taxon of the taxonomy displayed by the TaxonTree (Odonata, taxonId 107)
        /// </summary>
        /// <returns>Root taxon object</returns>
        public Taxon GetRootTaxon()
        {
            ApplicationDataManager adm = new ApplicationDataManager();
            Taxon root = adm.GetTaxon(_rootScientificNameId).Result;
            if (root != null)
            {
                root.taxonRank = _rootRank;
            }
            return root;
        }

        /// <summary>
        /// Retrieves a list of all child-taxons of a given taxon. Retrieves only taxons one rank lower in the taxon rank system. 
        /// </summary>
        /// <param name="parent">The 'parent' taxon used to retrieve sub-taxons</param>
        /// <returns>List of sub-taxons</returns>
        public List<Taxon> GetSubTaxons(Taxon parent)
        {
            List<Taxon> children = ApplicationDataManager.GetTaxonsFromHigherClassification(parent).Result;
            return children;
        }
    }
}
