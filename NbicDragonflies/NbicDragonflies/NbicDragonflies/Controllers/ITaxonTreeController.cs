using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;

namespace NbicDragonflies.Controllers {

    public interface ITaxonTreeController
    {
        Taxon GetRootTaxon();

        List<Taxon> GetSubTaxons(Taxon parent);
    }
}
