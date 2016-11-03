namespace NbicDragonflies.Models.IdentificationKey
{

    public class IdentifySuggestion
    {
        public string ImageSource { get; private set; }
        public string Text { get; private set; }
        public string Detail { get; private set; }
        public Taxon.Taxon Taxon { get; }

        public IdentifySuggestion(Taxon.Taxon taxon, string image)
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