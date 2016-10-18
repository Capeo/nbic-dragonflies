using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {

    public partial class NavigationMaster : ContentPage {

        public ListView ListView { get { return NavigationList; } }

        public NavigationMaster() {
            InitializeComponent();


            // Add items to navigation list
            var navigationPageItems = new List<NavigationListItem>();

            navigationPageItems.Add(new NavigationListItem {
                Title = "Hjem",
                IconSource = "hamburger.png",
                TargetType = typeof(Home)
            });

            navigationPageItems.Add(new NavigationListItem
            {
                Title = "Arter",
<<<<<<< HEAD

                IconSource = "hamburger.png",
                TargetType = typeof(TaxonTree)

=======
                IconSource = "hamburger.png",
                TargetType = typeof(TaxonTree)
>>>>>>> 17da7f527cfc052708a2bfe28121920c5d047ab1
            });

            navigationPageItems.Add(new NavigationListItem
            {
                Title = "Observasjoner",
                IconSource = "hamburger.png",
                TargetType = typeof(Observation)
            });

            navigationPageItems.Add(new NavigationListItem
            {
                Title = "Galleri",
                IconSource = "hamburger.png",
                TargetType = typeof(Gallery)
            });

            navigationPageItems.Add(new NavigationListItem
            {
                Title = "Identifiser art",
                IconSource = "hamburger.png",
                TargetType = typeof(Identify)
            });

            NavigationList.ItemsSource = navigationPageItems;
        }


    }
}
