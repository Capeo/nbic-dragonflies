using System;
using NbicDragonflies.Controllers;
using NbicDragonflies.Models;
using NbicDragonflies.Utility;
using Xamarin.Forms;

namespace NbicDragonflies.Views.Pages {

	/// <summary>
	/// NavigationPage class for the NavigationPage bar.
	/// </summary>
    public partial class NavigationPage : MasterDetailPage {

        private ToolbarItem LanguageButton { get; }
        private Type CurrentDetailType { get; set; }

		/// <summary>
		/// Constructor. Initializes a new instance of the class.
		/// </summary>
        public NavigationPage() {
            InitializeComponent();

            LanguageButton = new ToolbarItem("", "UnitedKingdom.png", ChangeLanguage);

            CurrentDetailType = typeof(HomePage);
            Detail = NewDetailPage(CurrentDetailType);

            NavigationMaster.ListView.ItemSelected += OnItemSelected;
        }

        /// <summary>
        /// EventHandler for itemSelection in NavigationList. Creates new Page and sets the page as current detail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private Xamarin.Forms.NavigationPage NewDetailPage(Type type)
        {
			Xamarin.Forms.NavigationPage page = null;
			if (type == typeof(Pages.GalleryPage)) {
				page = new Xamarin.Forms.NavigationPage(new Pages.GalleryPage());
			}
            else if (type == typeof(Pages.IdentifyPage)) {
                page = new Xamarin.Forms.NavigationPage(new Pages.IdentifyPage());
            }
            else if (type == typeof(HomePage)) {
                page = new Xamarin.Forms.NavigationPage(new HomePage());
            }
            else if (type == typeof(ObservationsPage)) {
                page = new Xamarin.Forms.NavigationPage(new ObservationsPage());
            }
            else if (type == typeof(TaxonTreePage)) {
                page = new Xamarin.Forms.NavigationPage(new TaxonTreePage());
            }
            if (page != null)
            {
                page.BarBackgroundColor = Utility.Constants.NbicOrange;
                page.ToolbarItems.Add(LanguageButton);   
            }
            return page;
        }

        // Change language of app and icon
        private void ChangeLanguage()
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
                NavigationMaster.ReDrawNavigationList();
                Detail = NewDetailPage(CurrentDetailType);
            });
        }
    }
}
