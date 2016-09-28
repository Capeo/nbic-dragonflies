using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {
    public partial class Navigation : MasterDetailPage {

        public Navigation() {
            InitializeComponent();

<<<<<<< HEAD
            NavigationMaster.ListView.ItemSelected += OnItemSelected;
        }
=======
            var navigationPageItems = new List<NavigationListItem>();

            navigationPageItems.Add(new NavigationListItem {
                Title = "Home",
                IconSource = "dragonfly2.jpg",
                TargetType = typeof(Home)
            });
>>>>>>> 3b81f0fc35acd2f271a40ffa8c2efcb4c08fa3c7

        void OnItemSelected(Object sender, SelectedItemChangedEventArgs e) {
            var item = e.SelectedItem as NavigationListItem;
            if (item != null)
            {
<<<<<<< HEAD
                NavigationPage page = new NavigationPage((Page) Activator.CreateInstance(item.TargetType));
                page.BarBackgroundColor = Utility.Constants.NbicBrown;
                Detail = page;
                NavigationMaster.ListView.SelectedItem = null;
                IsPresented = false;
            }
=======
                Title = "Gallery",
                IconSource = "dragonfly1.jpg",
                TargetType = typeof(Gallery)
            });

            NavigationList.ItemsSource = navigationPageItems;
>>>>>>> 3b81f0fc35acd2f271a40ffa8c2efcb4c08fa3c7
        }
    }
}
