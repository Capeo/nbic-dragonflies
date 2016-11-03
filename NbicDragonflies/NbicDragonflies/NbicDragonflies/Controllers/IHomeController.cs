using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;

namespace NbicDragonflies.Controllers {


    /// <summary>
    /// Ïnterface for Home Page controller. Binds data between Home Page view and model classes.
    /// </summary>
    public interface IHomeController {


        /// <summary>
        /// Retrieves the notice/"Dragonfly of the day" for the Home page.
        /// </summary>
        /// <returns>HomeNotice object.</returns>
        HomeNotice GetHomeNotice();


        /// <summary>
        /// Retrives list of recent observations within the users county. Should return max 5 objeccts.
        /// </summary>
        /// <returns>List of recent, nearby observarionts.</returns>
        List<Observation> GetRecentObservations();

    }
}
