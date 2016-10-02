using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models
{
    class ObservationListItem
    {
        public long Id { get; set; }
        public String SpeciesGuess { get; set; }
        public String PlaceGuess { get; set; }
        public String ObservedOn { get; set; }
        public String UserLogin { get; set; }
    }
}
