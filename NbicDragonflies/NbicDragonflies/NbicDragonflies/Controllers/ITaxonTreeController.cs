using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using NbicDragonflies.Models.Taxon;

namespace NbicDragonflies.Controllers {

    /// <summary>
    /// Interface for Taxon Tree Page controller. Binds data between TaxonTree Page view and model classes.
    /// </summary>
    public interface ITaxonTreeController
    {

        /// <summary>
        /// Retrieves the root taxon of the current taxonomy. For dragonflies/damselflies this is Odonata, taxonId 107.
        /// </summary>
        /// <returns>Root taxon</returns>
        Taxon GetRootTaxon();

        /// <summary>
        /// Retrieves a list of all child-taxons of a given taxon. Retrieves only taxons one rank lower in the taxon rank system. 
        /// </summary>
        /// <param name="parent">The 'parent' taxon of the retrieved taxons.</param>
        /// <returns>List of taxons beneath the given taxon.</returns>
        List<Taxon> GetSubTaxons(Taxon parent);
    }
}
