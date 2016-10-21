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
            var navigationPageItems = new List<NavigationListItem>();

            navigationPageItems.Add(new NavigationListItem {
                Title = LanguageResource.HomeLabel,
                IconSource = "hamburger.png",
                TargetType = typeof(Home)
            });

            navigationPageItems.Add(new NavigationListItem
            {
                Title = LanguageResource.SpeciesLabel,
                IconSource = "hamburger.png",
                TargetType = typeof(TaxonTree)
            });

            navigationPageItems.Add(new NavigationListItem
            {
                Title = LanguageResource.ObservationsLabel,
                IconSource = "hamburger.png",
                TargetType = typeof(Observation)
            });

            navigationPageItems.Add(new NavigationListItem
            {
                Title = LanguageResource.GalleryLabel,
                IconSource = "hamburger.png",
                TargetType = typeof(Gallery)
            });

            navigationPageItems.Add(new NavigationListItem
            {
                Title = LanguageResource.IdentifyLabel,
                IconSource = "hamburger.png",
                TargetType = typeof(Identify)
            });

            NavigationList.ItemsSource = navigationPageItems;
        }


    }
}
