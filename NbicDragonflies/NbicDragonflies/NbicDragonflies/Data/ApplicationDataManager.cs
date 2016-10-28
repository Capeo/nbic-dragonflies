﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Newtonsoft.Json;

namespace NbicDragonflies.Data
{
    public static class ApplicationDataManager
    {
        private static readonly IRestService restService = new RestService();

        public static async Task<ObservationList> GetObservationListAsync (string urlSuffix)
        {
            string observationsJson = await restService.FetchObservationsAsync(urlSuffix).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ObservationList>(observationsJson);
        }

        public static async Task<List<SearchResultItem>> GetSearchResultAsync(string searchText)
        {
            string searchResult = await restService.FetchSearchResultsAsync(searchText).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<SearchResultItem>>(searchResult);
        }

        // Get a Taxon based on its scientificNameID
        public static async Task<Taxon> GetTaxon(int scientificNameId)
        {
            String taxonJson = await restService.FetchTaxonsAsync($"Taxon/{scientificNameId}").ConfigureAwait(false);
            Taxon taxon = JsonConvert.DeserializeObject<Taxon>(taxonJson);
            if(taxon != null) 
            {
                taxon.scientificNameID = scientificNameId;
            }
            return taxon;
        }

        // Get a list of sub-taxons from its direct higher classifications
        public static async Task<List<Taxon>> GetTaxonsFromHigherClassification (Taxon higherClassification)
        {
            int currentRankIndex = Utility.Constants.TaxonRanks.IndexOf(higherClassification.taxonRank);
            if (currentRankIndex < Utility.Constants.TaxonRanks.Count)
            {
                String taxonsJson = await restService.FetchTaxonsAsync($"Taxon/ScientificName?taxonRank={Utility.Constants.TaxonRanks.ElementAt(currentRankIndex + 1)}&higherClassificationID={higherClassification.scientificNameID}").ConfigureAwait(false);
                List<Taxon> taxons = JsonConvert.DeserializeObject<List<Taxon>>(taxonsJson);
                foreach (var taxon in taxons)
                {
                    await GetVernacularNames(taxon).ConfigureAwait(false);
                }
                return taxons;
            }
            return null;
        }
            
        // Add vernacular names and accepted names to given Taxon
        private static async Task GetVernacularNames(Taxon taxon)
        {
            String vernacularJson = await restService.FetchTaxonsAsync($"Taxon/{taxon.taxonID}").ConfigureAwait(false);
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
