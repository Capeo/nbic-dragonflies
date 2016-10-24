using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using NbicDragonflies.Resources;
using Xamarin.Forms;

namespace NbicDragonflies.Views {

    public partial class NavigationMaster : ContentPage {

        public ListView ListView { get { return NavigationList; } }

        public NavigationMaster() {
            InitializeComponent();

            // Add items to navigation list
            ReDrawNavigationList();
        }

        public void ReDrawNavigationList()
        {
            var navigationPageItems = new List<NavigationListItem>();

            navigationPageItems.Add(new NavigationListItem {
                Title = LanguageResource.HomeLabel,
                IconSource = "home.png",
                TargetType = typeof(Home)
            });

            navigationPageItems.Add(new NavigationListItem {
                Title = LanguageResource.SpeciesLabel,
                IconSource = "arter.png",
                TargetType = typeof(TaxonTree)
            });

            navigationPageItems.Add(new NavigationListItem {
                Title = LanguageResource.ObservationsLabel,
                IconSource = "observations.png",
                TargetType = typeof(Observations)
            });

            navigationPageItems.Add(new NavigationListItem {
                Title = LanguageResource.GalleryLabel,
                IconSource = "gallery.png",
                TargetType = typeof(Gallery)
            });

            navigationPageItems.Add(new NavigationListItem {
                Title = LanguageResource.IdentifyLabel,
                IconSource = "identify.png",
                TargetType = typeof(Identify)
            });

            NavigationList.ItemsSource = navigationPageItems;
        }
    }
}
