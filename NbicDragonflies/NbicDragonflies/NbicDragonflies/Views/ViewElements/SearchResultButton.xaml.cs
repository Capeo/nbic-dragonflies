using NbicDragonflies.Models.Taxon;
using Xamarin.Forms;

namespace NbicDragonflies.Views.ViewElements
{
	/// <summary>
	/// Class to handle the search result button.
	/// </summary>
    public partial class SearchResultButton : ContentView
    {
		/// <summary>
		/// Add TapeGestureRecognizer to the search result button.
		/// </summary>
        public TapGestureRecognizer ButtonTap;

        public Taxon Taxon { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:NbicDragonflies.Views.ViewElements.SearchResultButton"/> class with a string as parameter.
        /// </summary>
        /// <param name="searchLabelText">Search label text.</param>
        public SearchResultButton(string searchLabelText, Taxon taxon)
        {
            InitializeComponent();
            Taxon = taxon;
            ButtonTap = new TapGestureRecognizer();
            SearchResultLabel.Text = searchLabelText;
            this.GestureRecognizers.Add(ButtonTap);
            //SearchResultLabel.GestureRecognizers.Add(ButtonTap);
        }
    }
}
