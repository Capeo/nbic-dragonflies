using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {
    public partial class NavigationDetail : MasterDetailPage {

        public NavigationDetail() {
            InitializeComponent();

            Navigation.ListView.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(Object sender, SelectedItemChangedEventArgs e) {
            var item = e.SelectedItem as NavigationListItem;
            if (item != null)
            {
                Detail = (Page)Activator.CreateInstance(item.TargetType);
                Navigation.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
