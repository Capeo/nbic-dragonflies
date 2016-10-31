using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Controllers;
using NbicDragonflies.Models;
using NbicDragonflies.Views.ListItems;
using Xamarin.Forms;
using NbicDragonflies.Data;

namespace NbicDragonflies.Views {

	/// <summary>
	/// Home page.
	/// </summary>
    public partial class Home : ContentPage {

        //public ListView ListView { get { return RecentObservationsList; } }

        private IHomeController _controller;
        private TapGestureRecognizer _infoTap;

        public Home(IHomeController controller)
        {
            InitializeComponent();
            _controller = controller;
            _infoTap = new TapGestureRecognizer();

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

            SetInfo(_controller.GetHomeInfo());
            FillRecentObservationsList(_controller.GetRecentObservations());
            
            SpeciesSearchBar.SearchButtonPressed += OnSearchButtonPressed;
        }

        private async void OnSearchButtonPressed(object sender, EventArgs e) 
        {
            List<SearchResultItem> searchResultsResponse = await ApplicationDataManager.GetSearchResultAsync(SpeciesSearchBar.Text);
            List<string> searchResults = new List<string>();
            if (searchResultsResponse.Capacity != 0) {
                searchResults = searchResultsResponse[0].ScientificName;
            }

            await Navigation.PushAsync(new SearchResultList(SpeciesSearchBar.Text, searchResults));
        }

        private void OnInfoPressed(object sender, EventArgs e)
        {
            if (_controller.GetHomeInfo().Taxon != null)
            {
                Navigation.PushAsync(new SpeciesInfo(new Species(_controller.GetHomeInfo().Taxon)));
            }
        }

        private void FillRecentObservationsList(List<Observation> observations)
        {
            if (observations != null) {
                var recentObservationsCells = new List<ObservationsCell>();
                foreach (Observation observation in observations)
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

        private void SetInfo(HomeInfo info)
        {
            InfoText.Text = info.Text;
            InfoImage.Source = info.Image;
            InfoFrame.GestureRecognizers.Clear();
            if (info.Taxon != null)
            {
                InfoFrame.GestureRecognizers.Add(_infoTap);
                _infoTap.Tapped += OnInfoPressed;
            }
        }
    }
}
