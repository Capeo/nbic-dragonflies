using System;
using System.Collections.Generic;
using NbicDragonflies.Data;
using NbicDragonflies.Models;
using NbicDragonflies.Models.Taxon;
using NbicDragonflies.Resources;
using Xamarin.Forms;
using NbicDragonflies.Views.ViewElements;
using NbicDragonflies.Controllers;

namespace NbicDragonflies.Views.Pages
{
    /// <summary>
    /// Page for search results
    /// </summary>
    public partial class SearchResultPage : ContentPage
    {
        private GestureRecognizer _resultTap;
        private IHomeController _controller;

        /// <summary>
        /// Constructor. Initializes new search result page with search text and list of results.
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="searchResults"></param>
        public SearchResultPage(string searchText, List<SearchResultItem> searchResults)
        {
            InitializeComponent();

            _controller = new HomeController();
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
                    if (searchResults.Capacity > 10)
                    {
                        searchResults = searchResults.GetRange(0, 10);
                    }
                    foreach(SearchResultItem searchItem in searchResults)
                    {
                        if (searchItem.VernacularName.Capacity != 0)
                        {
                            string taxonDirectory = searchItem.Resource.Id;
                            int taxonId;
                            int.TryParse(taxonDirectory.Substring(taxonDirectory.IndexOf("/") + 1), out taxonId);
                            Taxon taxon = _controller.GetTaxonFromId(taxonId);
                            _resultTap = new TapGestureRecognizer();

                            string vernacularName = searchItem.VernacularName[0];
                            string searchResultButtonLabel = vernacularName.Substring(0, 1).ToUpper() + vernacularName.Substring(1) + ", " + searchItem.ScientificName[0];
                            ViewElements.SearchResultButton searchResultButton = new ViewElements.SearchResultButton(searchResultButtonLabel, taxon);
                            SearchStackLayout.Children.Add(searchResultButton);
                            searchResultButton.ButtonTap.Tapped += OnResultButtonPressed;
                        }
                    }
                }
            }
        }

        private async void OnSearchButtonPressed(object sender, EventArgs e)
        {
            List<SearchResultItem> searchResultsResponse = await ApplicationDataManager.GetSearchResultAsync(SpeciesSearchBar.Text);
            
            await Navigation.PushAsync(new SearchResultPage(SpeciesSearchBar.Text, searchResultsResponse));
        }

        private void OnResultButtonPressed(object sender, EventArgs e) 
        {
            Pages.TaxonContentPage taxonContentPageView = new Pages.TaxonContentPage(((SearchResultButton)sender).Taxon);

            Navigation.PushAsync(taxonContentPageView);
        }
    }
}
