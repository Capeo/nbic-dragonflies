using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;

namespace NbicDragonflies.Data
{

    /// <summary>
    /// Interface used to fetch data from REST APIs
    /// </summary>
    public interface IRestService
    {

        /// <summary>
        /// Fetch data from REST API accessed by given url
        /// </summary>
        /// <param name="url">URL query</param>
        /// <returns>Results, usually JSON object, in string form</returns>
        Task<string> FetchDataAsync (string url);
    }
}