﻿using System;
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

        public async Task<string> FetchTaxonsAsync (string urlSuffix)
        {
            var client = new HttpClient ();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = Constants.TaxonRestUrl + $"{urlSuffix}";

            try
            {
                // GET method
                var response = await client.GetAsync(address).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var taxonsJson = response.Content.ReadAsStringAsync().Result;
					//var rootobject = JsonConvert.DeserializeObject<Rootobject>(taxonsJson);
                    return taxonsJson;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return "";
        }

        //FIXME avoid repetition, use a design pattern
        public async Task<string> FetchObservationsAsync(string urlSuffix)
        {
            var client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = Constants.ObservationRestUrl + $"{urlSuffix}";

            try
            {
                // GET method
                var response = await client.GetAsync(address).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var observationsJson = response.Content.ReadAsStringAsync().Result;
                    return observationsJson;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return "";
        }

        public async Task<string> FetchSearchResultsAsync(string searchText)
        {
            var client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = Constants.SearchUrl + $"{searchText}";

            try
            {
                var response = await client.GetAsync(address).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(@"				ERROR {0}", e.Message);
            }
            return "";
        }
    }
}

        