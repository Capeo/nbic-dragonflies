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

        public async Task<string> FetchDataAsync (string restUrl)
        {
            var client = new HttpClient ();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = restUrl;

            try
            {
                // GET method
                string response = await client.GetStringAsync(address).ConfigureAwait(false);

                if (response!=null)
                {
                    var taxonsJson = response;
                    return taxonsJson;
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

        