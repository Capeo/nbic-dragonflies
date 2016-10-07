using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using NbicDragonflies.Models;
using NbicDragonflies.Views;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace NbicDragonflies.Data
{
    public class RestService : IRestService
    {
        HttpClient client;

        public List<TaxonItem> Items { get; set; }

        public RestService ()
        {
            client = new HttpClient ();
            client.MaxResponseContentBufferSize = 256000;
        }
        

        public async Task<List<TaxonItem>> RefreshDataAsync ()
        {
            Items = new List<TaxonItem> ();

            // Initalize URI
            var uri = new Uri (string.Format(Constants.TaxonRestUrl, string.Empty));

            try
            {
                // GET method
                var response = await client.GetAsync (uri);

                if (response.IsSuccessStatusCode)
                {
                    // TODO: Is this the right way to do it? (How to create Items of TaxonItem objects based on json?)
                    var content = await response.Content.ReadAsStringAsync ();
                    Items = JsonConvert.DeserializeObject <List<TaxonItem>> (content);   
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            /*
            // Get TaxonID and ScientificName from json
            int taxonId = Items["taxonID"];
            JsonValue scientificNames = json["scientificNames"];
            int scientificNameID = scientificNames["scientificNameID"];

            TaxonItem taxon = new TaxonItem(taxonId, scientificNameID);

            Items.Add(taxon);
            */

            return Items;
        }

    }
}

        