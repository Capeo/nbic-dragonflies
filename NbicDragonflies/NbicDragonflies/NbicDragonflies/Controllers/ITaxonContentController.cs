using NbicDragonflies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models.Taxon;

namespace NbicDragonflies.Controllers
{
    public interface ITaxonContentController
    {
        TaxonInfo GetInfoFromTaxon(Taxon taxon);

        TaxonContent GetContentFromTaxon(Taxon taxon);
    }
}
