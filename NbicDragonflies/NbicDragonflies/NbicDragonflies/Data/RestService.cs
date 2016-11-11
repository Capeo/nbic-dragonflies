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

    /// <summary>
    /// Implementation of IRestService interface
    /// </summary>
    public class RestService : IRestService
    {

        /// <summary>
        /// Fetches data from API using given url query
        /// </summary>
        /// <param name="url">URL query</param>
        /// <returns>Results, usually JSON object, in string form</returns>
        public async Task<string> FetchDataAsync(string url)
        {
            var client = new HttpClient ();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = url;

            try
            {
                // GET method
                string response = await client.GetStringAsync(address).ConfigureAwait(false);

                if (response!=null)
                {
                    var json = response;
                    return json;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.StackTrace);
            }

            return "";
        }

    }
}

        