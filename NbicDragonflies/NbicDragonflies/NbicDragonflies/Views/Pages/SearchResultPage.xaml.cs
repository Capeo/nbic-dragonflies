using NbicDragonflies.Data;
using NbicDragonflies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models.Taxon;
using NbicDragonflies.Resources;

using Xamarin.Forms;
using NbicDragonflies.Views.ViewElements;
using NbicDragonflies.Controllers;

namespace NbicDragonflies.Views
{
    public partial class SearchResultPage : ContentPage
    {
        private GestureRecognizer _resultTap;
        private IHomeController _controller;

        public SearchResultPage(string SearchText, List<SearchResultItem> SearchResults)
        {
            InitializeComponent();

            _controller = new HomeController();
			Title = LanguageResource.SearchTitle;
			LabelHeader.Text = LanguageResource.SearchResultSuggestions;
            SpeciesSearchBar.SearchButtonPressed += OnSearchButtonPressed;
            if (SearchText!=null)
            {
                SpeciesSearchBar.Text = SearchText;
                
                if (SearchResults.Capacity==0)
                {
					LabelHeader.Text = LanguageResource.SearchResultCouldNotFind + " " + '"' + SearchText + '"';                    
                }
                else
                {
                    if (SearchResults.Capacity > 10)
                    {
                        SearchResults = SearchResults.GetRange(0, 10);
                    }
                    foreach(SearchResultItem searchItem in SearchResults)
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
            
            await Navigation.PushAsync(new Views.SearchResultPage(SpeciesSearchBar.Text, searchResultsResponse));
        }

        private void OnResultButtonPressed(object sender, EventArgs e) 
        {
            Pages.TaxonContentPage taxonContentPageView = new Pages.TaxonContentPage(((SearchResultButton)sender).Taxon);

            Navigation.PushAsync(taxonContentPageView);
        }
    }
}
