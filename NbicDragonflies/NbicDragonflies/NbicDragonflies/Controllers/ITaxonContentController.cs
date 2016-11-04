using NbicDragonflies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models.Taxon;

namespace NbicDragonflies.Controllers
{

    /// <summary>
    /// Interface for Taxon TaxonContent Page controller. Binds data between TaxonContent Page view and model classes. 
    /// </summary>
    public interface ITaxonContentController
    {

        /// <summary>
        /// Retrieves TaxonInfo based on given taxon object. The method is intended to access the NBIC API using taxonId or scientificNameId from taxon, and return info. Currently unused.
        /// </summary>
        /// <param name="taxon">Taxon object. Should have taxonId and/or scientificNameId</param>
        /// <returns>Info for given taxon</returns>
        TaxonInfo GetInfoFromTaxon(Taxon taxon);

        /// <summary>
        /// Retrieves TaxonContent object based on given taxon. The method should return a complete TaxonContent object containing all desired content about the given taxon. Assume that all content can be access from taxonId and/or scientificNameId.
        /// </summary>
        /// <param name="taxon">Taxon object. Should have taxonId and/or scientificNameId</param>
        /// <returns>TaxonContent for given taxon</returns>
        TaxonContent GetContentFromTaxon(Taxon taxon);
    }
}
