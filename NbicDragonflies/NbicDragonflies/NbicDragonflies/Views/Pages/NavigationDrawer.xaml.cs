using System.Collections.Generic;
using NbicDragonflies.Models;
using NbicDragonflies.Resources;
using Xamarin.Forms;

namespace NbicDragonflies.Views.Pages {
	
    public partial class NavigationDrawer : ContentPage {

		/// <summary>
		/// Gets the NavigationPage list view.
		/// </summary>
		/// <value>The list view.</value>
        public ListView ListView { get { return NavigationList; } }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Views.Pages.NavigationDrawer"/> class.
		/// </summary>
        public NavigationDrawer() {
            InitializeComponent();

            // Add items to navigation list
            ReDrawNavigationList();
        }

		/// <summary>
		/// Adds icons and labels to items in the NavigationPage list.
		/// </summary>
        public void ReDrawNavigationList()
        {
            var navigationPageItems = new List<NavigationListItem>();

            navigationPageItems.Add(new NavigationListItem(LanguageResource.HomeLabel, "home.png", typeof(HomePage)));

            navigationPageItems.Add(new NavigationListItem(LanguageResource.SpeciesLabel, "taxon.png", typeof(TaxonTreePage)));

            navigationPageItems.Add(new NavigationListItem(LanguageResource.ObservationsLabel, "observations.png", typeof(ObservationsPage)));

            navigationPageItems.Add(new NavigationListItem(LanguageResource.GalleryLabel, "gallery.png", typeof(GalleryPage)));

            navigationPageItems.Add(new NavigationListItem(LanguageResource.IdentifyLabel, "identify.png", typeof(IdentifyPage)));

            NavigationList.ItemsSource = navigationPageItems;
        }
    }
}
