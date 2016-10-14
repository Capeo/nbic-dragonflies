﻿using System;
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

        private int offset = 15;

        public TaxonTree() {
            InitializeComponent();

            applicationDataManager = new ApplicationDataManager(new RestService());

            CreateInitialTaxons();
        }

        public async void CreateInitialTaxons()
        {
            var children = await applicationDataManager.GetTaxonsAsync("Taxon/ScientificName?taxonRank=suborder&higherClassificationID=107");

            TaxonItem root = new TaxonItem(107, 107, "Odonata");

            TaxonButton rootButton = new TaxonButton(root, 0);
            rootButton.SwitchState();
            rootButton.NavigationTap.Tapped += HandleNavigationClick;
            TaxonLayout.Children.Add(rootButton);

            foreach (var taxon in children)
            {
                TaxonButton button = new TaxonButton(taxon, 1);
                rootButton.Subclasses.Add(button);
                button.NavigationTap.Tapped += HandleNavigationClick;
                button.Padding = new Thickness(offset*button.Level, 0, 0, 0);
                TaxonLayout.Children.Add(button);
            }
        }

        // Handle tap on navigation part of TaxonButton
        public async void HandleNavigationClick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Button");
            if (sender.GetType() == typeof(Frame))
            {
                TaxonButton parent = GetAncestor((Frame) sender);

                if (!parent.Open)
                {
                    parent.SwitchState();
                    int i = TaxonLayout.Children.IndexOf(parent) + 1;

                    var children = await applicationDataManager.GetTaxonsAsync("Taxon/ScientificName?taxonRank=suborder&higherClassificationID=107");

                    System.Diagnostics.Debug.WriteLine(children.Count);

                    foreach (var taxon in children) {
                        TaxonButton button = new TaxonButton(taxon, parent.Level + 1);
                        parent.Subclasses.Add(button);
                        button.NavigationTap.Tapped += HandleNavigationClick;
                        button.Padding = new Thickness(offset * button.Level, 0, 0, 0);
                        TaxonLayout.Children.Insert(i, button);
                        i++;
                    } 
                }
                else
                {
                    parent.SwitchState();
                    RemoveAllDescendants(parent);
                }
                
            }
        }

        // Returns the TaxonButton view to which an element belongs
        private TaxonButton GetAncestor(VisualElement e)
        {
            if (e != null)
            {
                var parent = e.Parent;
                while (parent != null)
                {
                    if (parent is TaxonButton)
                    {
                        return (TaxonButton) parent;
                    }
                    parent = parent.Parent;
                }
            }
            return null;
        }

        // Recursivly removes all descendants of a TaxonButton from the TaxonLayout stack layout
        private void RemoveAllDescendants(TaxonButton parent)
        {
            foreach (var button in parent.Subclasses)
            {
                RemoveAllDescendants(button);
                TaxonLayout.Children.Remove(button);
            }
            parent.Subclasses.Clear();
        }
    }
}
