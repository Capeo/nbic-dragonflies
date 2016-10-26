using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using NbicDragonflies.Utility;
using Xamarin.Forms;

namespace NbicDragonflies.Views {
    public partial class Navigation : MasterDetailPage {

        public Navigation() {
            InitializeComponent();

            NavigationMaster.ListView.ItemSelected += OnItemSelected;
        }

        // EventHandler for itemSelection in NavigationList.
        // Creates new Page and sets the page as current detail.
        void OnItemSelected(Object sender, SelectedItemChangedEventArgs e) {
            var item = e.SelectedItem as NavigationListItem;
            if (item != null)
            {
                NavigationPage page;
                if (item.TargetType == typeof(Identify))
                {
                    page = new NavigationPage(new Identify(new Placeholder()));
                }
                else
                {
                    page = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                }
                page.BarBackgroundColor = Utility.Constants.NbicBrown;
                Detail = page;
                NavigationMaster.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
