using NbicDragonflies.Data;
using NbicDragonflies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Resources;

using Xamarin.Forms;

namespace NbicDragonflies.Views
{
    public partial class SearchResultList : ContentPage
    {
        public GestureRecognizer ResultTap;

        public async void OnSearchButtonPressed(object sender, EventArgs e)
        {
            List<SearchResultItem> searchResultsResponse = await ApplicationDataManager.GetSearchResultAsync(SpeciesSearchBar.Text);
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


			Title = LanguageResource.SearchTitle;
			LabelHeader.Text = LanguageResource.SearchResultSuggestions;

            SpeciesSearchBar.SearchButtonPressed += OnSearchButtonPressed;
            if (searchText!=null)
            {
                SpeciesSearchBar.Text = searchText;
                
                if (searchResults.Capacity==0)
                {
					LabelHeader.Text = LanguageResource.SearchResultCouldNotFind + " " + '"' + searchText + '"';                    
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
