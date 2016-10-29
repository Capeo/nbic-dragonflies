﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {
    public partial class SpeciesInfo : ContentPage
    {

        private Species _species;
		public TapGestureRecognizer ImageTapped;
		public SpeciesImage SpeciesImage;

        public Species Species
        {
            get { return _species; }

            set
            {
                _species = value;
                SetSpecies(value);
            }   
        }

        public SpeciesInfo() {
            InitializeComponent();
        }

        public SpeciesInfo(Species species) {
            InitializeComponent();

            if (species.Taxon != null)
            {
                Title = species.Taxon.GetPreferredName();
            }

            SetSpecies(species);

			ImageTapped = new TapGestureRecognizer();
        }

        // Fills the SpeciesInfo view
        private void SetSpecies(Species species)
        {
            TopImage.Image = species.TopImage;

            foreach (var attribute in species.Attributes)
            {
                StackLayout s = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal
                };
                Label title = new Label
                {
                    Text = attribute.Item1,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                title.FontAttributes = FontAttributes.Bold;
                Label info = new Label
                {
                    Text = attribute.Item2,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                s.Children.Add(title);
                s.Children.Add(info);
                AttributesLayout.Children.Add(s);
            }

            foreach (var paragraph in species.Content)
            {
                Label title = new Label
                {
                    Text = paragraph.Item1
                };
                title.FontAttributes = FontAttributes.Bold;
                Label info = new Label
                {
                    Text = paragraph.Item2
                };
                InfoLayout.Children.Add(title);
                InfoLayout.Children.Add(info);
            }

            foreach (var image in species.Images)
            {
				SpeciesImageView s = new SpeciesImageView(image);
                ImageLayout.Children.Add(s);
				ImageTapped = new TapGestureRecognizer();
				//s.GestureRecognizers.Add(ImageTapped);
				s.GalleryTap.Tapped += HandleImageClick;
            }
        }

		// Handle tap on image in Gallery
		private void HandleImageClick(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Tapped");
			if (sender.GetType() == typeof(Frame))
			{
				SpeciesImageView parent = GetAncestor((Frame)sender);
				Navigation.PushAsync(new GalleryImage(parent.Image));
			}
		}

		// Returns the SpeciesImage view to which an element belongs
		private SpeciesImageView GetAncestor(VisualElement e)
		{
			if (e != null)
			{
				var parent = e.Parent;
				while (parent != null)
				{
					if (parent is SpeciesImageView)
					{
						return (SpeciesImageView)parent;
					}
					parent = parent.Parent;
				}
			}
			return null;
		}

    }
}
