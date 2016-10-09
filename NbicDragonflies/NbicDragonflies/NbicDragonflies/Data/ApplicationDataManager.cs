using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;

namespace NbicDragonflies.Data
{
    public class ApplicationDataManager
    {
        IRestService restService;

        public ApplicationDataManager (IRestService service)
        {
            restService = service;
        }

        // Call this method to get the list of data retrieved from RefreshDataAsync
        public Task<string> GetTaxonsAsync (string urlSuffix)
        {
            Task<string> taxons = restService.FetchTaxonsAsync (urlSuffix);

            return taxons;
        }
    }
}
