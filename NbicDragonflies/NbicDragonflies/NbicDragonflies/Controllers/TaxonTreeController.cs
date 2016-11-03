using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Data;
using NbicDragonflies.Models;
using NbicDragonflies.Models.Taxon;

namespace NbicDragonflies.Controllers {

    public class TaxonTreeController : ITaxonTreeController
    {

        private int _rootScientificNameId;
        private string _rootRank;

        public TaxonTreeController()
        {
            _rootScientificNameId = 107;
            _rootRank = "order";
        }

        public Taxon GetRootTaxon()
        {
            Taxon root = ApplicationDataManager.GetTaxon(_rootScientificNameId).Result;
            if (root != null)
            {
                root.taxonRank = _rootRank;
            }
            return root;
        }

        public List<Taxon> GetSubTaxons(Taxon parent)
        {
            List<Taxon> children = ApplicationDataManager.GetTaxonsFromHigherClassification(parent).Result;
            return children;
        }
    }
}
