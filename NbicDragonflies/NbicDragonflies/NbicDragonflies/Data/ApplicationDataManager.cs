using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using NbicDragonflies.Helpers;

namespace NbicDragonflies.Data
{
    public class ApplicationDataManager
    {
        IRestService restService;

        public ApplicationDataManager (IRestService service)
        {
            restService = service;

        }

        // Call this method to get the list of data retrieved from RefreshDataAsync
        public async Task<string> GetTaxonsJsonAsync (string urlSuffix)
        {
            var taxonsJson = await restService.FetchTaxonsAsync (urlSuffix);
            System.Diagnostics.Debug.WriteLine(taxonsJson);

            return taxonsJson;
        }

        // Create Taxons from Json and return them
        public async Task<List<TaxonItem>> GetTaxonsAsync (string urlSuffix)
        {
            String taxonsJson = await this.GetTaxonsJsonAsync (urlSuffix);

            TaxonHelper taxonHelper = new TaxonHelper ();

            List<TaxonItem> taxons = new List<TaxonItem>();

            Boolean moreElements = false;
            String currentJson = taxonsJson;

            int prevElementIndex;
            int elementIndex = taxonsJson.IndexOf("_");
            if (elementIndex != -1)
            {
                moreElements = true;
                elementIndex += 1;
            }

            while (moreElements)
            {
                currentJson = currentJson.Substring(elementIndex);

                TaxonItem taxon = taxonHelper.createTaxon(currentJson);
                taxons.Add(taxon);

                prevElementIndex = elementIndex;
                elementIndex = currentJson.IndexOf("_");
                if (elementIndex == -1)
                {
                    moreElements = false;
                }
                else
                {
                    elementIndex += 1;
                }
            }
            
            // Remove this loop if don't want to print the discovered taxons
            foreach (TaxonItem taxon in taxons)
            {
                System.Diagnostics.Debug.WriteLine("ScientificNameID: " + taxon.scientificNameId + " TaxonID: " + taxon.taxonId + " ScientificName: " + taxon.scientificName);
            }

            return taxons;
        }
    }
}
