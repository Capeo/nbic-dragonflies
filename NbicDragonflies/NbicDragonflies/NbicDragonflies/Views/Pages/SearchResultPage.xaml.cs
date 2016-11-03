﻿using NbicDragonflies.Data;
using NbicDragonflies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models.Taxon;
using NbicDragonflies.Resources;

using Xamarin.Forms;

namespace NbicDragonflies.Views
{
    public partial class SearchResultPage : ContentPage
    {
        private GestureRecognizer _resultTap;

        public SearchResultPage(string searchText, List<String> searchResults)
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
                        _resultTap = new TapGestureRecognizer();
                        ViewElements.SearchResultButton searchResultButton = new ViewElements.SearchResultButton(searchItem);
                        SearchStackLayout.Children.Add(searchResultButton);
                        searchResultButton.ButtonTap.Tapped+= OnResultButtonPressed;
                    }
                }
            }
        }

        private async void OnSearchButtonPressed(object sender, EventArgs e)
        {
            List<SearchResultItem> searchResultsResponse = await ApplicationDataManager.GetSearchResultAsync(SpeciesSearchBar.Text);
            List<string> searchResults = searchResultsResponse[0].VernacularName;

            await Navigation.PushAsync(new Views.SearchResultPage(SpeciesSearchBar.Text, searchResults));
        }

        private void OnResultButtonPressed(object sender, EventArgs e) 
        {
            Pages.TaxonContentPage taxonContentPageView = new Pages.TaxonContentPage(new Taxon());
            taxonContentPageView.Title = ((Label)sender).Text;

            Navigation.PushAsync(taxonContentPageView);
        }
    }
}