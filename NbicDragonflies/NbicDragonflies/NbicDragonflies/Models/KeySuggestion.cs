using System;
using System.Collections.ObjectModel;


namespace NbicDragonflies.Models
{

    public class KeySuggestion
    {
        public string ImageSource { get; private set; }
        public string Text { get; private set; }
        public string Detail { get; private set; }
        public Taxon Taxon { get; }

        public KeySuggestion(Taxon taxon, string image)
        {
            if (taxon != null)
            {
                Text = taxon.GetPreferredName();
                Detail = taxon.GetScientificName();
            }
            ImageSource = image;
            Taxon = taxon;
        }
    }

}