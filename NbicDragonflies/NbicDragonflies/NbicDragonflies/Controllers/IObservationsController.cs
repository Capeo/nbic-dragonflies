using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using NbicDragonflies.Models.Location;

namespace NbicDragonflies.Controllers {

    /// <summary>
    /// Interface for Observation Page controller. Binds data between Observation Page view and model classes. 
    /// </summary>
    public interface IObservationsController
    {

        /// <summary>
        /// Retrieves a list of observations. Should be sorted by date.
        /// </summary>
        /// <returns>List of observations</returns>
        List<Observation> GetObservations();

        /// <summary>
        /// Retrieves a set of map pins for observations. 
        /// </summary>
        /// <returns>Dictionary. Each element consists of a county, and the number of observations made in that county recently.</returns>
        Dictionary<CountyDataSet, int> GetObservationsMapPins();
    }
}
