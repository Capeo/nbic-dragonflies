using NbicDragonflies.Data;
using NbicDragonflies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NbicDragonflies.Views
{
    public partial class SearchResultList : ContentPage
    {
        public GestureRecognizer ResultTap;
        public async void OnSearchButtonPressed(object sender, EventArgs e)
        {
            ApplicationDataManager applicationDataManager = new ApplicationDataManager(new RestService());
            List<SearchResultItem> searchResultsResponse = await applicationDataManager.GetSearchResultAsync(SpeciesSearchBar.Text);
            List<string> searchResults = searchResultsResponse[0].ScientificName;

            await Navigation.PushAsync(new Views.SearchResultList(SpeciesSearchBar.Text, searchResults));
        }
        public void OnResultButtonPressed(object sender, EventArgs e)
        {
                SpeciesInfo speciesInfoView = new SpeciesInfo(new Species());
                speciesInfoView.Title = ((Label)sender).Text;

                Navigation.PushAsync(speciesInfoView);
        }
        public SearchResultList(string searchText, List<String> searchResults)
        {
            InitializeComponent();
            SpeciesSearchBar.SearchButtonPressed += OnSearchButtonPressed;

            // Position Search Bar within layout 
            AbsoluteLayout.SetLayoutBounds(SpeciesSearchBar, new Rectangle(.5, 0, -1, -1));
            AbsoluteLayout.SetLayoutFlags(SpeciesSearchBar, AbsoluteLayoutFlags.PositionProportional);
            SearchLayout.Children.Add(SpeciesSearchBar);
            if (searchText!=null)
            {
                SpeciesSearchBar.Text = searchText;
                
                if (searchResults.Capacity==0)
                {
                    LabelHeader.Text = "Could not find " + searchText;                    
                }
                else
                {
                    foreach(string searchItem in searchResults)
                    {
                        ResultTap = new TapGestureRecognizer();
                        SearchResultButton searchResultButton = new SearchResultButton(searchItem);
                        SearchStackLayout.Children.Add(searchResultButton);
                        searchResultButton.ButtonTap.Tapped+= OnResultButtonPressed;
                    }
                }
            }
        }
    }
}
