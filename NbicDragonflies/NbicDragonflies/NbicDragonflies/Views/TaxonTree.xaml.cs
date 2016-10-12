using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Data;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {
    public partial class TaxonTree : ContentPage
    {

        private ApplicationDataManager applicationDataManager;

        public TaxonTree() {
            InitializeComponent();

            applicationDataManager = new ApplicationDataManager(new RestService());

            CreateInitialTaxons();
        }

        public async void CreateInitialTaxons()
        {
            var children = await applicationDataManager.GetTaxonsAsync("Taxon/ScientificName?taxonRank=suborder&higherClassificationID=107");

            TaxonItem root = new TaxonItem(107, 107, "Odonata");

            Button rootButton = new Button
            {
                Text = root.scientificName,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            rootButton.Clicked += HandleClick;

            TaxonLayout.Children.Add(rootButton);

            foreach (var taxon in children)
            {
                Button button = new Button
                {
                    Text = taxon.scientificName,
                    Margin = new Thickness(20, 0, 0, 0),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                button.Clicked += HandleClick;
                TaxonLayout.Children.Add(button);
            }
        }

        public void HandleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Button");
            Button b = (Button) sender;
            if (b.Text == "Odonata")
            {
                System.Diagnostics.Debug.WriteLine("Button pressed");
            }
        }

    }
}
