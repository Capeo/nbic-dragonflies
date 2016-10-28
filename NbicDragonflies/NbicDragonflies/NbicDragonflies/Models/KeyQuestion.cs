using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models {

    public class KeyQuestion {

        public string Title { get; set; }
        public List<IdentifyAlternative> Alternatives { get; set; }
        public IdentifyAlternative SelectedAlternative { get; set; } = null;

        public KeyQuestion(string title, List<IdentifyAlternative> alternatives)
        {
            Title = title;
            Alternatives = alternatives;
        }
    }
}
