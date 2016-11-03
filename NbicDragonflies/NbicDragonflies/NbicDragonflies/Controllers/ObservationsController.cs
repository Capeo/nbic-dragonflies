using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Data;
using NbicDragonflies.Models;
using NbicDragonflies.Models.Location;

namespace NbicDragonflies.Controllers {

    public class ObservationsController : IObservationsController
    {

        public List<Observation> GetObservations()
        {
            Models.ObservationList recentObservationsList = ApplicationDataManager.GetObservationListAsync("list?taxons=107&pageSize=30").Result;
            if (recentObservationsList != null)
            {
                return recentObservationsList.Observations;
            }
            return null;
        }

        //FIXME Cache me please
        public static List<CountyDataSet> GetCountyDataSet()
        {
            List<CountyDataSet> areaDataSetResult = new List<CountyDataSet>();
            //FIXME change hard coded numbers to a variable that receives total count of regions listed in the dataset
            for (int i = 1; i < 24; i++)
            {
                areaDataSetResult.Add(ApplicationDataManager.GetAreaDataSetAsync(i).Result);
            }
            return areaDataSetResult;
        }

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
