using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using NbicDragonflies.Views.ListItems;
using Xamarin.Forms;
using NbicDragonflies.Data;

namespace NbicDragonflies.Views {

	/// <summary>
	/// Home page.
	/// </summary>
    public partial class Home : ContentPage {

		/// <summary>
		/// Gets the list view of recent observations.
		/// </summary>
		/// <value>The list view.</value>
        public ListView ListView { get { return RecentObservationsList; } }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Views.Home"/> class.
		/// </summary>
        public Home()
        {
            InitializeComponent();
            SpeciesSearchBar.SearchButtonPressed += OnSearchButtonPressed;

            // Position title within InfoLayout
            InfoLayout.Children.Add(InfoTitle,
                Constraint.RelativeToParent((parent) => parent.X),
                Constraint.RelativeToParent((parent) => parent.Y),
                Constraint.RelativeToParent((parent) => parent.Width*0.5),
                Constraint.RelativeToParent((parent) => parent.Height*0.2));
            InfoTitle.FontAttributes = FontAttributes.Bold;

            // Position text within InfoLayout
            InfoLayout.Children.Add(InfoText,
                Constraint.RelativeToView(InfoTitle, (parent, sibling) => sibling.X),
                Constraint.RelativeToView(InfoTitle, (parent, sibling) => (sibling.Y + sibling.Height + 4)),
                Constraint.RelativeToParent((parent) => parent.Width * 0.5),
                Constraint.RelativeToParent((parent) => parent.Height * 0.8)
                );

            // Position image within InfoLayout
            InfoLayout.Children.Add(InfoImage,
                Constraint.RelativeToView(InfoText, (parent, sibling) => (sibling.X + sibling.Width + 2)),
                Constraint.RelativeToView(InfoText, (parent, sibling) => (sibling.Y)),
                Constraint.RelativeToParent((parent) => (parent.Width * 0.45)),
                Constraint.RelativeToParent((parent) => parent.Height * 0.7));
            InfoImage.Aspect = Aspect.AspectFit;

            RecentObservationsTitle.FontAttributes = FontAttributes.Bold;


            SetInfo("Brun øyenstikker", "En karakteristisk stor, nøttebrun øyenstikker med påfallende bruntonede vinger.", "BrownDragonfly.jpg");

            // Add items to RecentObservations list
            FillRecentObservationsList();            
        }

        private void SpeciesSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

		/// <summary>
		/// Handles click on search button.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        public async void OnSearchButtonPressed(object sender, EventArgs e) {
            List<SearchResultItem> searchResultsResponse = await ApplicationDataManager.GetSearchResultAsync(SpeciesSearchBar.Text);
            List<string> searchResults = new List<string>();
            if (searchResultsResponse.Capacity != 0) {
                searchResults = searchResultsResponse[0].ScientificName;
            }

            await Navigation.PushAsync(new Views.SearchResultList(SpeciesSearchBar.Text, searchResults));
        }

		/// <summary>
		/// Fills the recent observations list.
		/// </summary>
        public async void FillRecentObservationsList()
        {
            //FIXME: refine url to filter nearest observations
            Models.ObservationList recentObservationsList = await ApplicationDataManager.GetObservationListAsync("list");
            if (recentObservationsList != null && recentObservationsList.Observations != null) {
                var recentObservationsCells = new List<ObservationsCell>();
                foreach (Models.Observation observation in recentObservationsList.Observations)
                {
                    string name = observation.Name == null
                        ? observation.ScientificName
                        : observation.Name + ", " + observation.ScientificName;
                    ObservationsCell cell = new ObservationsCell
                    {
                        Species = name,
                        Location = observation.GetLocationText(),
                        Date = observation.CollctedDate,
                        User = observation.Collector,
                    };
                    recentObservationsCells.Add(cell);
                }
                RecentObservationsList.ItemsSource = recentObservationsCells;
            }
            
        }

		/// <summary>
		/// Sets the info of species.
		/// </summary>
		/// <param name="title">Title.</param>
		/// <param name="text">Text.</param>
		/// <param name="imageFilename">Image filename.</param>
        public void SetInfo(string title, string text, string imageFilename)
        {
            InfoTitle.Text = title;
            InfoText.Text = text;
            InfoImage.Source = imageFilename;
        }
    }
}
