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
    public static class ApplicationDataManager
    {
        private static readonly IRestService restService = new RestService();

        public static async Task<ObservationList> GetObservationListAsync (string urlSuffix)
        {
            string observationsJson = await restService.FetchDataAsync(Constants.ObservationRestUrl + $"{urlSuffix}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ObservationList>(observationsJson);
        }

        public static async Task<CountyDataSet> GetAreaDataSetAsync (int areaId)
        {
            string areaDataSetJson = await restService.FetchDataAsync(Constants.AreaCountyDataRestUrl + $"{areaId}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountyDataSet>(areaDataSetJson);
        }

        public static async Task<List<SearchResultItem>> GetSearchResultAsync(string searchText)
        {
            string searchResult = await restService.FetchDataAsync(Constants.SearchRestUrl + $"{searchText}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<SearchResultItem>>(searchResult);
        }

        public static async Task<TaxonInfo> GetTaxonInfoFromTaxonAsync(Taxon taxon)
        {
            string taxonInfo = await restService.FetchDataAsync(Constants.PlaceholderSpeciesContentUrl + "135474").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<TaxonInfo>(taxonInfo);
        }

        // Get a Taxon based on its scientificNameID
        public static async Task<Taxon> GetTaxon(int scientificNameId)
        {
            String taxonJson = await restService.FetchDataAsync(Constants.TaxonRestUrl + $"Taxon/{scientificNameId}").ConfigureAwait(false);
            Taxon taxon = JsonConvert.DeserializeObject<Taxon>(taxonJson);
            if(taxon != null) 
            {
                taxon.scientificNameID = scientificNameId;
            }
            return taxon;
        }

        // Get a list of sub-taxons from its direct higher classifications
        public static async Task<List<Taxon>> GetTaxonsFromHigherClassification(Taxon higherClassification)
        {
            int currentRankIndex = Utility.Constants.TaxonRanks.IndexOf(higherClassification.taxonRank);
            if (currentRankIndex < Utility.Constants.TaxonRanks.Count)
            {
                String taxonsJson = await restService.FetchDataAsync(Constants.TaxonRestUrl + $"Taxon/ScientificName?taxonRank={Utility.Constants.TaxonRanks.ElementAt(currentRankIndex + 1)}&higherClassificationID={higherClassification.scientificNameID}").ConfigureAwait(false);
                List<Taxon> taxons = JsonConvert.DeserializeObject<List<Taxon>>(taxonsJson);
                foreach (var taxon in taxons)
                {
                    await GetVernacularNames(taxon).ConfigureAwait(false);
                }
                return taxons;
            }
            return null;
        }

        public static async Task<List<Result>> GetLocationData(double latitude, double longitude)
        {
            string locationData = await restService.FetchDataAsync(Constants.AreaNameFromLatLong + $"{latitude}" + "," + $"{longitude}").ConfigureAwait(false);
            GoogleLocation locationInfo = JsonConvert.DeserializeObject<GoogleLocation>(locationData);
            return locationInfo.results;
        }

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

        // Add vernacular names and accepted names to given Taxon
        private static async Task GetVernacularNames(Taxon taxon)
        {
            String vernacularJson = await restService.FetchDataAsync(Constants.TaxonRestUrl + $"Taxon/{taxon.taxonID}").ConfigureAwait(false);
            VernacularTaxon vt = JsonConvert.DeserializeObject<VernacularTaxon>(vernacularJson);
            if (vt != null)
            {
                taxon.scientificNames = vt.scientificNames;
                taxon.vernacularNames = vt.vernacularNames;
                taxon.PreferredVernacularName = vt.PreferredVernacularName;
                taxon.AcceptedName = vt.AcceptedName; 
            }
        }
    }
}
