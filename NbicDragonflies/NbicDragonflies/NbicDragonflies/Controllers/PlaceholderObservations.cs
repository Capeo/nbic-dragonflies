using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Data;
using NbicDragonflies.Models;

namespace NbicDragonflies.Controllers {

    public class PlaceholderObservations : IObservationsController
    {

        public List<Observation> GetObservations()
        {
            ObservationList recentObservationsList = ApplicationDataManager.GetObservationListAsync("list?taxons=107&pageSize=30").Result;
            if (recentObservationsList != null)
            {
                return recentObservationsList.Observations;
            }
            return null;
        }
    }
}
