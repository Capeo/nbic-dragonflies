using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using NbicDragonflies.Models.Taxon;

namespace NbicDragonflies.Controllers {

    public interface ITaxonTreeController
    {
        Taxon GetRootTaxon();

        List<Taxon> GetSubTaxons(Taxon parent);
    }
}
