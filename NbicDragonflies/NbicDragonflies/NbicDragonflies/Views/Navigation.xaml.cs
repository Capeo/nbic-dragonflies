using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {
    public partial class Navigation : MasterDetailPage {

        private ToolbarItem LanguageButton { get; }

        public Navigation() {
            InitializeComponent();

            LanguageButton = new ToolbarItem("", "Norway.png", ChangeLanguage);
            StartPage.ToolbarItems.Add(LanguageButton);

            NavigationMaster.ListView.ItemSelected += OnItemSelected;
        }

        // EventHandler for itemSelection in NavigationList.
        // Creates new Page and sets the page as current detail.
        void OnItemSelected(Object sender, SelectedItemChangedEventArgs e) {
            var item = e.SelectedItem as NavigationListItem;
            if (item != null)
            {
                NavigationPage page = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                page.BarBackgroundColor = Utility.Constants.NbicBrown;
                page.ToolbarItems.Add(LanguageButton);
                Detail = page;
                NavigationMaster.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }

        void ChangeLanguage()
        {
            Utility.Language.Languages l = Utility.Language.SwitchLanguage();
            if (l == Utility.Language.Languages.En)
            {
                LanguageButton.Icon.File = "United-Kingdom.png";
            }
            else
            {
                LanguageButton.Icon.File = "Norway.png";
            }
        }
    }
}
