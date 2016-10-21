using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Newtonsoft.Json;

namespace NbicDragonflies.Data
{
    public class ApplicationDataManager
    {
        private IRestService restService;

        public ApplicationDataManager (IRestService service)
        {
            restService = service;

        }

        public async Task<ObservationList> GetObservationListAsync (string urlSuffix)
        {
            string observationsJson = await restService.FetchObservationsAsync(urlSuffix);
            return JsonConvert.DeserializeObject<ObservationList>(observationsJson);
        }

        public async Task<List<SearchResultItem>> GetSearchResultAsync(string searchText)
        {
            string searchResult = await restService.FetchSearchResultsAsync(searchText);
            Debug.WriteLine(searchResult);
            return JsonConvert.DeserializeObject<List<SearchResultItem>>(searchResult);
        }
        // Get a Taxon based on its scientificNameID
        public async Task<Taxon> GetTaxon(int scientificNameId)
        {
            String taxonJson = await restService.FetchTaxonsAsync($"Taxon/{scientificNameId}");
            Taxon taxon = JsonConvert.DeserializeObject<Taxon>(taxonJson);
            taxon.scientificNameID = scientificNameId;
            return taxon;
        }

        // Get a list of sub-taxons from its direct higher classifications
        public async Task<List<Taxon>> GetTaxonsFromHigherClassification (Taxon higherClassification)
        {
            int currentRankIndex = Utility.Constants.TaxonRanks.IndexOf(higherClassification.taxonRank);
            if (currentRankIndex < Utility.Constants.TaxonRanks.Count)
            {
                String taxonsJson = await restService.FetchTaxonsAsync($"Taxon/ScientificName?taxonRank={Utility.Constants.TaxonRanks.ElementAt(currentRankIndex + 1)}&higherClassificationID={higherClassification.scientificNameID}");
                List<Taxon> taxons = JsonConvert.DeserializeObject<List<Taxon>>(taxonsJson);
                foreach (var taxon in taxons)
            {
                    await GetVernacularNames(taxon);
                }
                return taxons;
                }
            return null;
            }
            
        // Add vernacular names and accepted names to given Taxon
        private async Task GetVernacularNames(Taxon taxon)
            {
            String vernacularJson = await restService.FetchTaxonsAsync($"Taxon/{taxon.taxonID}");
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
