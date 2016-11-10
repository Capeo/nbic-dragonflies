using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using NbicDragonflies.Models.Location;
using NbicDragonflies.Models.Taxon;
using Newtonsoft.Json;
using NbicDragonflies.Utility;
using Plugin.Geolocator;

namespace NbicDragonflies.Data
{

    /// <summary>
    /// Static class used to retrieve data from the API
    /// </summary>
    public class ApplicationDataManager
    {
        private static readonly IRestService RestService = new RestService();

        ApplicationDataManager()
        {
        }
        /// <summary>
        /// Fetches list of observations from API using query in given url
        /// </summary>
        /// <param name="urlSuffix">URL containing the query used to fetch data.</param>
        /// <returns>List of observations</returns>
        public static async Task<ObservationList> GetObservationListAsync(string urlSuffix)
        {
            string observationsJson = await RestService.FetchDataAsync(Constants.ObservationRestUrl + $"{urlSuffix}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ObservationList>(observationsJson);
        }

        /// <summary>
        /// Fetches a CountyDataSeta from API based on areaId
        /// </summary>
        /// <param name="areaId">AreaId of desired county</param>
        /// <returns>CountyDataSet</returns>
        public static async Task<CountyDataSet> GetAreaDataSetAsync (int areaId)
        {
            string areaDataSetJson = await RestService.FetchDataAsync(Constants.AreaCountyDataRestUrl + $"{areaId}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountyDataSet>(areaDataSetJson);
        }

        /// <summary>
        /// Fetches a list of suggested search results based on a search query
        /// </summary>
        /// <param name="searchText">The search text submitted by the user</param>
        /// <returns>List of search results</returns>
        public static async Task<List<SearchResultItem>> GetSearchResultAsync(string searchText)
        {
            string searchResult = await RestService.FetchDataAsync(Constants.SearchRestUrl + $"{searchText}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<SearchResultItem>>(searchResult);
        }

        /// <summary>
        /// Fetches info about a taxon from a given taxon object.
        /// </summary>
        /// <param name="taxon">Taxon to find info about</param>
        /// <returns></returns>
        public static async Task<TaxonInfo> GetTaxonInfoFromTaxonAsync(Taxon taxon)
        {
            // TODO Need contentId to fetch TaxonInfo, not able to map from taxonId to contentId. Currently only returns static data from contentID 135474.

            string taxonInfo = await RestService.FetchDataAsync(Constants.TaxonContenRestUrl + "135474").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<TaxonInfo>(taxonInfo);
        }

        /// <summary>
        /// Fetches data about a taxon from its scientificNameId
        /// </summary>
        /// <param name="scientificNameId">The scientificNameId of the desired taxon</param>
        /// <returns>Taxon</returns>
        public static async Task<Taxon> GetTaxon(int scientificNameId)
        {
            String taxonJson = await RestService.FetchDataAsync(Constants.TaxonRestUrl + $"Taxon/{scientificNameId}").ConfigureAwait(false);
            Taxon taxon = JsonConvert.DeserializeObject<Taxon>(taxonJson);
            if (taxon != null)
            {
                taxon.scientificNameID = scientificNameId;
            }
            return taxon;
        }

        /// <summary>
        /// Get a list of sub-taxons from its direct 'parent' taxon
        /// </summary>
        /// <param name="higherClassification">The 'parent' taxon used to retrieve sub-taxons</param>
        /// <returns>List of sub-taxons</returns>
        public static async Task<List<Taxon>> GetTaxonsFromHigherClassification(Taxon higherClassification)
        {
            int currentRankIndex = Utility.Constants.TaxonRanks.IndexOf(higherClassification.taxonRank);
            if (currentRankIndex < Utility.Constants.TaxonRanks.Count)
            {
                String taxonsJson = await RestService.FetchDataAsync(Constants.TaxonRestUrl + $"Taxon/ScientificName?taxonRank={Utility.Constants.TaxonRanks.ElementAt(currentRankIndex + 1)}&higherClassificationID={higherClassification.scientificNameID}").ConfigureAwait(false);
                List<Taxon> taxons = JsonConvert.DeserializeObject<List<Taxon>>(taxonsJson);
                foreach (var taxon in taxons)
                {
                    await GetVernacularNames(taxon).ConfigureAwait(false);
                }
                return taxons;
            }
            return null;
        }

        /// <summary>
        /// Retrieves location data from Google maps API based on latitude and longitude
        /// </summary>
        /// <param name="latitude">Users current latitude</param>
        /// <param name="longitude">Users current longitude</param>
        /// <returns>GoogleLocation results</returns>
        public static async Task<List<LocationResult>> GetLocationData(double latitude, double longitude)
        {
            string locationData = await RestService.FetchDataAsync(Constants.AreaNameFromLatLong + $"{latitude}" + "," + $"{longitude}").ConfigureAwait(false);
            GoogleLocation locationInfo = JsonConvert.DeserializeObject<GoogleLocation>(locationData);
            return locationInfo.results;
        }

        /// <summary>
        /// Fetches the users current location
        /// </summary>
        /// <returns>Location</returns>
        public static async Task<Location> GetLocation()
        {
            try
            {
                var locator = CrossGeolocator.Current;

                if (locator.IsGeolocationEnabled)
                {
                    //TODO no longer works, work on alternative
                    //var position = await locator.GetPositionAsync(10000);
                    return new Location(63.410304, 10.435006);
                }
                System.Diagnostics.Debug.WriteLine("Geolocation is disabled!");
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
                return null;
            }
        }

        /// <summary>
        /// Add vernacular names and accepted names to given Taxon
        /// </summary>
        /// <param name="taxon"></param>
        /// <returns></returns>
        private static async Task GetVernacularNames(Taxon taxon)
        {
            String vernacularJson = await RestService.FetchDataAsync(Constants.TaxonRestUrl + $"Taxon/{taxon.taxonID}").ConfigureAwait(false);
            VernacularTaxon vt = JsonConvert.DeserializeObject<VernacularTaxon>(vernacularJson);
            if (vt != null)
            {
                taxon.scientificNames = vt.scientificNames;
                taxon.vernacularNames = vt.vernacularNames;
                taxon.PreferredVernacularName = vt.PreferredVernacularName;
                taxon.AcceptedName = vt.AcceptedName; 
            }
        }

        public static void Method()
        {
            throw new System.NotImplementedException();
        }
    }
}
