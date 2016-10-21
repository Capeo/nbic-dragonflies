using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models
{

    public class Resource
    {
        public string Id { get; set; }
        public object Title { get; set; }
        public string Type { get; set; }
    }

    public class SearchResultItem
    {
        public Resource Resource { get; set; }
        public string Heading { get; set; }
        public string Intro { get; set; }
        public List<object> References { get; set; }
        public List<string> SearchFragments { get; set; }
        public List<string> ScientificName { get; set; }
        public List<object> VernacularName { get; set; }
    }

}
