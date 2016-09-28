using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {

    public partial class Navigation : ContentPage {

        public ListView ListView { get { return NavigationList; } }

        public Navigation() {
            InitializeComponent();

            var navigationPageItems = new List<NavigationListItem>();

            navigationPageItems.Add(new NavigationListItem {
                Title = "Home",
                IconSource = "dragonfly2.jpg",
                TargetType = typeof(Home)
            });

            navigationPageItems.Add(new NavigationListItem
            {
                Title = "Gallery",
                IconSource = "dragonfly1.jpg",
                TargetType = typeof(Gallery)
            });

            NavigationList.ItemsSource = navigationPageItems;
        }


    }
}
