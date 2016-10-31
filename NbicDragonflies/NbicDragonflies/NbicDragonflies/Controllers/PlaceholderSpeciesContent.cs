using NbicDragonflies.Data;
using NbicDragonflies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Controllers
{
    public class PlaceholderSpeciesContent : ISpeciesContentController
    {
        public SpeciesContent GetContentFromTaxon(Taxon taxon)
        {
            return ApplicationDataManager.GetSpeciesContentFromTaxonAsync(taxon).Result;
        }
    }
}
