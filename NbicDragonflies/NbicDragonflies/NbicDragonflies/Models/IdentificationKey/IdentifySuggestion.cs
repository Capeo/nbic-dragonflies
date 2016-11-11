namespace NbicDragonflies.Models.IdentificationKey
{

    /// <summary>
    /// Model class representing a suggestion for the identification key
    /// </summary>
    public class IdentifySuggestion
    {

        /// <summary>
        /// Path to image for suggestion
        /// </summary>
        public string ImageSource { get; private set; }

        /// <summary>
        /// Main text of the suggestion, default preferred name of associated taxon
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Detail text of the suggestion, default scientific name of associated taxon
        /// </summary>
        public string Detail { get; private set; }

        /// <summary>
        /// Taxon associated with suggestion
        /// </summary>
        public Taxon.Taxon Taxon { get; }

        /// <summary>
        /// Constructor. Sets associated taxon and image
        /// </summary>
        /// <param name="taxon">Taxon object associated with suggestion</param>
        /// <param name="image">Path to image for suggestion</param>
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