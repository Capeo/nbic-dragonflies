using NbicDragonflies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Controllers
{
    public interface ISpeciesContentController
    {
        SpeciesContent GetContentFromTaxon(Taxon taxon);
    }
}
