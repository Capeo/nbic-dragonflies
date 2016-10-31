using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Controllers;
using NbicDragonflies.Models;
using NbicDragonflies.Utility;
using Xamarin.Forms;

namespace NbicDragonflies.Views {

	/// <summary>
	/// Navigation class for the Navigation bar.
	/// </summary>
    public partial class Navigation : MasterDetailPage {

        private ToolbarItem LanguageButton { get; }
        private Type CurrentDetailType { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Views.Navigation"/> class.
		/// </summary>
        public Navigation() {
            InitializeComponent();

            LanguageButton = new ToolbarItem("", "UnitedKingdom.png", ChangeLanguage);

            CurrentDetailType = typeof(Home);
            Detail = NewDetailPage(CurrentDetailType);

            NavigationMaster.ListView.ItemSelected += OnItemSelected;
        }

        // EventHandler for itemSelection in NavigationList.
        // Creates new Page and sets the page as current detail.
        private void OnItemSelected(Object sender, SelectedItemChangedEventArgs e) {
            var item = e.SelectedItem as NavigationListItem;
            if (item != null)
            {
                CurrentDetailType = item.TargetType;
                Detail = NewDetailPage(CurrentDetailType);
                NavigationMaster.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }

        private NavigationPage NewDetailPage(Type type)
        {
			NavigationPage page = null;
			if (type == typeof(Gallery)) {
				page = new NavigationPage(new Gallery(new PlaceholderGallery()));
			}
            else if (type == typeof(Identify)) {
                page = new NavigationPage(new Identify(new PlaceholderKey()));
            }
            else if (type == typeof(Home)) {
                page = new NavigationPage(new Home(new PlaceholderHome()));
            }
            else if (type == typeof(Observations)) {
                page = new NavigationPage(new Observations(new PlaceholderObservations()));
            }
            else if (type == typeof(TaxonTree)) {
                page = new NavigationPage(new TaxonTree(new TaxonTreeController()));
            }
            if (page != null)
            {
                page.BarBackgroundColor = Utility.Constants.NbicOrange;
                page.ToolbarItems.Add(LanguageButton);   
            }
            return page;
        }

        // Change language of app and icon
        void ChangeLanguage()
        {
            Utility.Language.Languages l = Utility.Language.SwitchLanguage();
            if (l == Utility.Language.Languages.En)
            {
                LanguageButton.Icon.File = "Norway.png";
            }
            else
            {
                LanguageButton.Icon.File = "UnitedKingdom.png";
            }
            Device.BeginInvokeOnMainThread(() =>
            {
                this.NavigationMaster.ReDrawNavigationList();
                Detail = NewDetailPage(CurrentDetailType);
            });
        }
    }
}
