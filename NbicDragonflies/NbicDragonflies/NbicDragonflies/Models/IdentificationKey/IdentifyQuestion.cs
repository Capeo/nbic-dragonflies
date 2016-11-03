using System.Collections.Generic;

namespace NbicDragonflies.Models.IdentificationKey
{

    public class IdentifyQuestion {

        public string Title { get; set; }
        public List<IdentifyOption> Options { get; set; }
        public IdentifyOption SelectedOption { get; set; } = null;

        public IdentifyQuestion(string title, List<IdentifyOption> options)
        {
            Title = title;
            Options = options;
        }
    }
}
