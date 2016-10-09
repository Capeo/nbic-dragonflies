using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;

namespace NbicDragonflies.Data
{
    public interface IRestService
    {
        Task<string> FetchTaxonsAsync (string urlSuffix);
    }
}