using System;
using System.Collections.Generic;
using System.Linq;
using NbicDragonflies.Controllers;
using NbicDragonflies.Models.Taxon;
using Xamarin.Forms;

namespace NbicDragonflies.Views.Pages {

    /// <summary>
    /// Taxon tree page
    /// </summary>
    public partial class TaxonTreePage : ContentPage
    {

        private const int _offset = 15;
        private ITaxonTreeController _controller;

        /// <summary>
        /// Constructor. Initializes new taxon tree page.
        /// </summary>
        public TaxonTreePage() {
            InitializeComponent();

            _controller = new TaxonTreeController();

            SetInitialTaxons(_controller.GetRootTaxon());
        }

        private void SetInitialTaxons(Taxon root)
        {
            if(root != null) 
            {
                ViewElements.TaxonButton rootButton = new ViewElements.TaxonButton(root, 0);
                rootButton.SwitchState();
                rootButton.NavigationTap.Tapped += OnNavigationClick;
                rootButton.InfoTap.Tapped += OnInfoClick;
                TaxonLayout.Children.Add(rootButton);

                List<Taxon> children = _controller.GetSubTaxons(root);

                foreach (var taxon in children)
                {
                    ViewElements.TaxonButton button = new ViewElements.TaxonButton(taxon, 1);
                    rootButton.Children.Add(button);
                    button.NavigationTap.Tapped += OnNavigationClick;
                    button.InfoTap.Tapped += OnInfoClick;
                    button.Padding = new Thickness(_offset*button.Level, 0, 0, 0);
                    TaxonLayout.Children.Add(button);
                }
            }
            
        }

        private void OnNavigationClick(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Frame))
            {
                ViewElements.TaxonButton parent = (ViewElements.TaxonButton)Utility.Utilities.GetWrapperView((Frame)sender, typeof(ViewElements.TaxonButton));

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
                            List<Taxon> children = _controller.GetSubTaxons(parentTaxon);

                            foreach (var taxon in children) {
                                ViewElements.TaxonButton button = new ViewElements.TaxonButton(taxon, parent.Level + 1);
                                parent.Children.Add(button);
                                button.Padding = new Thickness(_offset * button.Level, 0, 0, 0);
                                if (taxon.taxonRank != Utility.Constants.TaxonRanks.ElementAt(Utility.Constants.TaxonRanks.Count - 1))
                                {
                                    button.NavigationTap.Tapped += OnNavigationClick;
                                }
                                else 
                                {
                                    button.NavigationTap.Tapped += OnInfoClick;
                                }
                                button.InfoTap.Tapped += OnInfoClick;
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

        private void OnInfoClick(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Frame))
            {
                ViewElements.TaxonButton parent = (ViewElements.TaxonButton)Utility.Utilities.GetWrapperView((Frame)sender, typeof(ViewElements.TaxonButton));

                System.Diagnostics.Debug.WriteLine(parent.Taxon.taxonID + ", " + parent.Taxon.scientificNameID);

                Pages.TaxonContentPage taxonContentPageView = new Pages.TaxonContentPage(parent.Taxon);

                Navigation.PushAsync(taxonContentPageView);
            }
        }

        // Recursivly removes all descendants of a TaxonButton from the TaxonLayout stack layout
        private void RemoveAllDescendants(ViewElements.TaxonButton parent)
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
