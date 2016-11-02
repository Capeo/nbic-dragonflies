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

        public string CountyName { get; set; }

        public Home(IHomeController controller)
        {
            InitializeComponent();
            _controller = controller;
            _infoTap = new TapGestureRecognizer();

			// Position image within InfoLayout
			InfoLayout.Children.Add(InfoImage,
				Constraint.RelativeToParent((parent) => parent.X),
				Constraint.RelativeToParent((parent) => parent.Y),
				Constraint.RelativeToParent((parent) => (parent.Width)),
				Constraint.RelativeToParent((parent) => parent.Height));
			InfoImage.WidthRequest = InfoLayout.Width;
			InfoImage.Aspect = Aspect.AspectFit;

			//Create and position white box behind info text
			InfoLayout.Children.Add(WhiteBox,
                Constraint.RelativeToView(InfoImage, (parent, sibling) => sibling.X),
                Constraint.RelativeToView(InfoImage, (parent, sibling) => sibling.Y + sibling.Height * 0.72),
                Constraint.RelativeToView(InfoImage, (parent, sibling) => sibling.Width),
                Constraint.RelativeToView(InfoImage, (parent, sibling) => sibling.Height - sibling.Height * 0.72));
			WhiteBox.BackgroundColor = Color.White;
			WhiteBox.Opacity = 0.65;


            // Position title within InfoLayout
            InfoLayout.Children.Add(InfoTitle,
                Constraint.RelativeToView(WhiteBox, (parent,sibling) => sibling.X + 10),
                Constraint.RelativeToView(WhiteBox, (parent, sibling) => sibling.Y + 5),
                Constraint.RelativeToView(WhiteBox, (parent, sibling) => sibling.Width - 20),
                Constraint.RelativeToView(WhiteBox, (parent, sibling) => sibling.Height - 40));
			InfoTitle.FontSize = 25;
			InfoTitle.TextColor = Color.Black;

            // Position text within InfoLayout
            InfoLayout.Children.Add(InfoText,
                Constraint.RelativeToView(InfoTitle, (parent, sibling) => sibling.X),
                Constraint.RelativeToView(InfoTitle, (parent, sibling) => (sibling.Y + sibling.Height)),
                Constraint.RelativeToView(WhiteBox, (parent, sibling) => sibling.Width - 20),
                Constraint.RelativeToView(WhiteBox, (parent, sibling) => sibling.Height - 30));
			InfoText.FontSize = 12;
			InfoText.TextColor = Color.Black;
            

            SetInfo(_controller.GetHomeInfo());
            FillRecentObservationsList(_controller.GetRecentObservations());  
                      
            SpeciesSearchBar.SearchButtonPressed += OnSearchButtonPressed;

            RecentObservationsList.ItemSelected += OnObservationSelected;
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
                RecentObservationsTitle.Text = RecentObservationsTitle.Text + " " + observations[0].County;
            }
            
        }

        private void SetInfo(HomeInfo info)
        {
            InfoTitle.Text = info.Title;
            InfoText.Text = info.Text;
            InfoImage.Source = info.Image;

            InfoLayout.GestureRecognizers.Clear();
            if (info.Taxon != null)
            {
                InfoLayout.GestureRecognizers.Add(_infoTap);
                _infoTap.Tapped += OnInfoPressed;
            }
        }

	    private void OnObservationSelected(Object sender, SelectedItemChangedEventArgs e)
	    {
	        RecentObservationsList.SelectedItem = null;
	    }
    }
}
