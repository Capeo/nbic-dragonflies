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
    public partial class Home : ContentPage {

        public ListView ListView { get { return RecentObservationsList; } }

        public Home()
        {
            InitializeComponent();
            SpeciesSearchBar.SearchButtonPressed += OnSearchButtonPressed;

			// Position image within InfoLayout
			InfoLayout.Children.Add(InfoImage,
				Constraint.RelativeToParent((parent) => parent.X),
				Constraint.RelativeToParent((parent) => parent.Y),
				Constraint.RelativeToParent((parent) => (parent.Width)),
				Constraint.RelativeToParent((parent) => parent.Height));
			InfoImage.Aspect = Aspect.AspectFit;

            // Position title within InfoLayout
            InfoLayout.Children.Add(InfoTitle,
                Constraint.RelativeToView(InfoImage, (parent,sibling) => sibling.X),
                Constraint.RelativeToView(InfoImage, (parent, sibling) => parent.Y + InfoImage.Height*0.6),
                Constraint.RelativeToParent((parent) => parent.Width),
                Constraint.RelativeToParent((parent) => parent.Height));
			InfoTitle.FontSize = 30;
			InfoTitle.TextColor = Color.White;

            // Position text within InfoLayout
            InfoLayout.Children.Add(InfoText,
                Constraint.RelativeToView(InfoTitle, (parent, sibling) => sibling.X),
                Constraint.RelativeToView(InfoTitle, (parent, sibling) => (sibling.Y + 35)),
                Constraint.RelativeToParent((parent) => parent.Width),
                Constraint.RelativeToParent((parent) => parent.Height));
			InfoText.TextColor = Color.White;
            
            RecentObservationsTitle.FontAttributes = FontAttributes.Bold;


            SetInfo("Brun øyenstikker", "En karakteristisk stor, nøttebrun øyenstikker med påfallende bruntonede vinger.", "BrownDragonfly.jpg");

            // Add items to RecentObservations list
            FillRecentObservationsList();            
        }

        private void SpeciesSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public async void OnSearchButtonPressed(object sender, EventArgs e) {
            List<SearchResultItem> searchResultsResponse = await ApplicationDataManager.GetSearchResultAsync(SpeciesSearchBar.Text);
            List<string> searchResults = new List<string>();
            if (searchResultsResponse.Capacity != 0) {
                searchResults = searchResultsResponse[0].ScientificName;
            }

            await Navigation.PushAsync(new Views.SearchResultList(SpeciesSearchBar.Text, searchResults));
        }

        public async void FillRecentObservationsList()
        {
            //FIXME: refine url to filter nearest observations
            Models.ObservationList recentObservationsList = await ApplicationDataManager.GetObservationListAsync("list");
            if (recentObservationsList != null && recentObservationsList.Observations != null) {
                var recentObservationsCells = new List<ObservationsCell>();
                foreach (Models.Observation observation in recentObservationsList.Observations)
                {
					if (observation.Name != null)
					{
						observation.Name = observation.Name.Substring(0, 1).ToUpper() + observation.Name.Substring(1);
					}

                    ObservationsCell cell = new ObservationsCell
                    {
                        Species = observation.Name == null ? observation.ScientificName : observation.Name + " (" + observation.ScientificName + ")",
                        Location = observation.GetLocationText(),
                        Date = observation.CollctedDate,
                        User = observation.Collector,
                    };
                    recentObservationsCells.Add(cell);
                }
                RecentObservationsList.ItemsSource = recentObservationsCells;
            }
            
        }

        public void SetInfo(string title, string text, string imageFilename)
        {
            InfoTitle.Text = title;
            InfoText.Text = text;
            InfoImage.Source = imageFilename;
        }
    }
}
