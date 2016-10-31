using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Data;
using NbicDragonflies.Models;

namespace NbicDragonflies.Controllers {

    public class PlaceholderHome : IHomeController
    {

        public HomeInfo GetHomeInfo()
        {
            return new HomeInfo("Dagens øyenstikker", "En karakteristisk stor, nøttebrun øyenstikker med påfallende bruntonede vinger.", "BrownDragonfly.jpg", ApplicationDataManager.GetTaxon(107).Result);
        }

        public List<Observation> GetRecentObservations()
        {
            ObservationList recentObservationsList =
                ApplicationDataManager.GetObservationListAsync("list").Result;
            if (recentObservationsList != null)
            {
                return recentObservationsList.Observations;
            }
            return null;
        }
    }
}
