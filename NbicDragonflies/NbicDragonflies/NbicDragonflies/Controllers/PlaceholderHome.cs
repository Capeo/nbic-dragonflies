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
            return new HomeInfo("Brun øyenstikker", "En karakteristisk stor, nøttebrun øyenstikker med påfallende bruntonede vinger.", "BrownDragonfly.jpg", ApplicationDataManager.GetTaxon(32564).Result);
        }

        public List<Observation> GetRecentObservations()
        {
            string countyName = GetCountyName();
            List<AreaDataSet> areaDataSet = PlaceholderObservations.GetAreaDataSet();
            string countyId = "";
            foreach (AreaDataSet area in areaDataSet)
            {
                if (countyName == area.Name)
                {
                    countyId = area.Id;
                    break;
                }
            }
            ObservationList recentObservationsList =
                ApplicationDataManager.GetObservationListAsync("list?taxons=107&pageSize=5&countys[]="+$"{countyId}").Result;
            if (recentObservationsList != null)
            {
                return recentObservationsList.Observations;
            }
            return null;
        }

        private string GetCountyName()
        {
            Location locationCoordinates = GetCurrentLocation();
            List<Result> locationInfotItem = ApplicationDataManager.GetLocationData(locationCoordinates.Latitude, locationCoordinates.Longitude).Result;
            if (locationInfotItem.Capacity != 0)
            {
                //FIXME there must be a better way to search for the County name in the JSON object using LINQ
                foreach (AddressComponent addressComponent in locationInfotItem[0].address_components)
                {
                    if (addressComponent.types[0] == "administrative_area_level_1")
                    {
                        return addressComponent.long_name;
                    }
                }
            }
            return null;

        }

        private Location GetCurrentLocation()
        {
            Location locationCoordinates = ApplicationDataManager.GetLocation().Result;
            if (locationCoordinates != null)
            {
                return locationCoordinates;
            }
            return null;
        }
    }
}
