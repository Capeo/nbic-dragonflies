using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Data;
using NbicDragonflies.Models;
using NbicDragonflies.Models.Location;

namespace NbicDragonflies.Controllers {

    /// <summary>
    /// Implementation of IObservationsController interface
    /// </summary>
    public class ObservationsController : IObservationsController
    {

        /// <summary>
        /// Retrieves list of observations for Observations page. Should be sorted by observation time.
        /// </summary>
        /// <returns>List of recent observations.</returns>
        public List<Observation> GetObservations()
        {
            Models.ObservationList recentObservationsList = ApplicationDataManager.GetObservationListAsync("list?taxons=107&pageSize=30").Result;
            if (recentObservationsList != null)
            {
                return recentObservationsList.Observations;
            }
            return null;
        }

        /// <summary>
        /// Retrieves a list of all counties in Norway used by NBIC API
        /// </summary>
        /// <returns>List of CountyDataSets</returns>
        public static List<CountyDataSet> GetCountyDataSet()
        {
            List<CountyDataSet> areaDataSetResult = new List<CountyDataSet>();
            //TODO change hard coded numbers to a variable that receives total count of regions listed in the dataset
            for (int i = 1; i < 24; i++)
            {
                areaDataSetResult.Add(ApplicationDataManager.GetAreaDataSetAsync(i).Result);
            }
            return areaDataSetResult;
        }

        /// <summary>
        /// Retrieves the number of recent observations for each county in Norway.
        /// </summary>
        /// <returns>Dictionary containing county and number of recent observations.</returns>
        public Dictionary<CountyDataSet, int> GetObservationsMapPins()
        {
            Dictionary<CountyDataSet, int>  observationsMap = new Dictionary<CountyDataSet, int>();
            foreach(CountyDataSet area in GetCountyDataSet())
            {
                //TODO Refine API to retrieve observations count based on date
                Models.ObservationList recentObservationsList = ApplicationDataManager.GetObservationListAsync("list?taxons=107&bounds=" + $"{area.GoogleMercatorBbox}").Result;
                observationsMap.Add(area, recentObservationsList.TotalCount);
            }
            return observationsMap;
        }
    }
}
