﻿using Xamarin.Forms;

namespace NbicDragonflies.Views.ViewElements
{
	/// <summary>
	/// Class to handle the search result button.
	/// </summary>
    public partial class SearchResultButton : ContentView
    {
		/// <summary>
		/// Add TapeGestureRecognizer to the search result button.
		/// </summary>
        public TapGestureRecognizer ButtonTap;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Views.ViewElements.SearchResultButton"/> class with a string as parameter.
		/// </summary>
		/// <param name="searchLabelText">Search label text.</param>
		public SearchResultButton(string searchLabelText)
        {
            InitializeComponent();
            ButtonTap = new TapGestureRecognizer();
            SearchResultLabel.Text = searchLabelText;
            SearchResultLabel.GestureRecognizers.Add(ButtonTap);
        }
    }
}