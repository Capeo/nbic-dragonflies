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

        private int offset = 15;

        public TaxonTree() {
            InitializeComponent();

            CreateInitialTaxons(107, "order");
        }

        public async void CreateInitialTaxons(int rootScientificNameId, string taxonRank)
        {
            Taxon root = await ApplicationDataManager.GetTaxon(rootScientificNameId);

            if(root != null) 
            {
                root.taxonRank = taxonRank;

                List<Taxon> children = await ApplicationDataManager.GetTaxonsFromHigherClassification(root);

                TaxonButton rootButton = new TaxonButton(root, 0);
                rootButton.SwitchState();
                rootButton.NavigationTap.Tapped += HandleNavigationClick;
                rootButton.InfoTap.Tapped += HandleInfoClick;
                TaxonLayout.Children.Add(rootButton);

                foreach (var taxon in children)
                {
                    TaxonButton button = new TaxonButton(taxon, 1);
                    rootButton.Children.Add(button);
                    button.NavigationTap.Tapped += HandleNavigationClick;
                    button.InfoTap.Tapped += HandleInfoClick;
                    button.Padding = new Thickness(offset*button.Level, 0, 0, 0);
                    TaxonLayout.Children.Add(button);
                }
            }
            
        }

        // Handle tap on navigation part of TaxonButton
        public async void HandleNavigationClick(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Frame))
            {
                TaxonButton parent = (TaxonButton)Utility.Utilities.GetAncestor((Frame) sender, typeof(TaxonButton));

                if (!parent.Open)
                {
                    parent.SwitchState();
                    Taxon parentTaxon = parent.Taxon;
                    int i = TaxonLayout.Children.IndexOf(parent) + 1;
                    int currentOrderIndex = Utility.Constants.TaxonRanks.IndexOf(parentTaxon.taxonRank);

                    if(currentOrderIndex + 1 < Utility.Constants.TaxonRanks.Count)
                    {
                        if (parent.Children.Count > 0)
                        {
                            foreach (var taxonButton in parent.Children)
                            {
                                TaxonLayout.Children.Insert(i, taxonButton);
                                i++;
                            }
                        }
                        else
                        {
                            List<Taxon> children = await ApplicationDataManager.GetTaxonsFromHigherClassification(parentTaxon);
                            foreach (var taxon in children) {
                                TaxonButton button = new TaxonButton(taxon, parent.Level + 1);
                                parent.Children.Add(button);
                                button.Padding = new Thickness(offset * button.Level, 0, 0, 0);
                                if (taxon.taxonRank != Utility.Constants.TaxonRanks.ElementAt(Utility.Constants.TaxonRanks.Count - 1))
                                {
                                    button.NavigationTap.Tapped += HandleNavigationClick;
                                }
                                button.InfoTap.Tapped += HandleInfoClick;
                                TaxonLayout.Children.Insert(i, button);
                                i++;
                            } 
                        }
                    }
                }
                else
                {
                    parent.SwitchState();
                    RemoveAllDescendants(parent);
                }
            }
        }

        public void HandleInfoClick(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Frame))
            {
                TaxonButton parent = (TaxonButton)Utility.Utilities.GetAncestor((Frame)sender, typeof(TaxonButton));

                SpeciesInfo speciesInfoView = new SpeciesInfo(new Species());
                speciesInfoView.Title = parent.Name;

                Navigation.PushAsync(speciesInfoView);
            }
        }

        // Recursivly removes all descendants of a TaxonButton from the TaxonLayout stack layout
        private void RemoveAllDescendants(TaxonButton parent)
        {
            foreach (var button in parent.Children)
            {
                RemoveAllDescendants(button);
                TaxonLayout.Children.Remove(button);
            }
            parent.Children.Clear();
        }
    }
}
