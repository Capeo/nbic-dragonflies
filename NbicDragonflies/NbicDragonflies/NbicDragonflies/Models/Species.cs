using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models {
    public class Species {

        public SpeciesImage TopImage { get; set; }

        public List<Tuple<string, string>> Attributes { get; set; }

        public List<Tuple<string, string>> Content { get; set; }

        public List<SpeciesImage> Images { get; set; }
    }
}
