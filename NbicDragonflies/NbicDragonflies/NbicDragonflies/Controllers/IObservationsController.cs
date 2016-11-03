using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using NbicDragonflies.Models.Location;

namespace NbicDragonflies.Controllers {

    public interface IObservationsController
    {
        List<Observation> GetObservations();

        Dictionary<CountyDataSet, int> GetObservationsMapPins();
    }
}
