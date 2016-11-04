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
using NbicDragonflies.Models.Taxon;
using NbicDragonflies.Resources;

namespace NbicDragonflies.Views {

	/// <summary>
	/// HomePage page.
	/// </summary>
    public partial class HomePage : ContentPage {

        //public ListView ListView { get { return RecentObservationsList; } }

        private IHomeController _controller;
        private TapGestureRecognizer _infoTap;

        public HomePage()
        {
            InitializeComponent();
            _controller = new HomeController();
            _infoTap = new TapGestureRecognizer();

			// Position image within InfoLayout
			InfoLayout.Children.Add(InfoImage,
				Constraint.RelativeToParent((parent) => parent.X),
				Constraint.RelativeToParent((parent) => parent.Y),
				Constraint.RelativeToParent((parent) => (parent.Width)),
				Constraint.RelativeToParent((parent) => parent.Height));
			InfoImage.WidthRequest = InfoLayout.Width;
			InfoImage.Aspect = Aspect.AspectFit;

			//Create and position white box behind notice text
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
            

            SetNotice(_controller.GetHomeNotice());
            FillRecentObservationsList(_controller.GetRecentObservations());  
                      
            SpeciesSearchBar.SearchButtonPressed += OnSearchButtonPressed;

            RecentObservationsList.ItemSelected += OnObservationSelected;
        }

        private async void OnSearchButtonPressed(object sender, EventArgs e) 
        {
            List<SearchResultItem> searchResultsResponse = await ApplicationDataManager.GetSearchResultAsync(SpeciesSearchBar.Text);

            await Navigation.PushAsync(new SearchResultPage(SpeciesSearchBar.Text, searchResultsResponse));
        }
        
        private void OnInfoPressed(object sender, EventArgs e)
        {
            if (_controller.GetHomeNotice().Taxon != null)
            {
                Navigation.PushAsync(new Pages.TaxonContentPage(_controller.GetHomeNotice().Taxon));
            }
        }

        private void FillRecentObservationsList(List<Observation> observations)
        {
            if (observations != null)
            {
                RecentObservationsList.ItemsSource = Utility.Utilities.GetObservationCellList(observations);
                RecentObservationsTitle.Text = RecentObservationsTitle.Text + " " + observations[0].County;
            }
            else
            {
                RecentObservationsList.ItemsSource = "";
                RecentObservationsTitle.Text = LanguageResource.GeoLocatorOff;
            }
        }

        private void SetNotice(HomeNotice notice)
        {
            InfoTitle.Text = notice.Title;
            InfoText.Text = notice.Text;
            InfoImage.Source = notice.Image;

            InfoLayout.GestureRecognizers.Clear();
            if (notice.Taxon != null)
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
