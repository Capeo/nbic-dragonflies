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

        public Task<List<TaxonItem>> GetTasksAsync ()
        {
            return restService.RefreshDataAsync ();
        }
    }
}
