using System;
using System.Collections.Generic;
using NbicDragonflies.Models;
using NbicDragonflies.Views;
using Xamarin.Forms;

namespace NbicDragonflies
{
	public partial class GalleryImage : ContentPage
	{
		public TapGestureRecognizer SpeciesTapped;
		public List<Taxon> Taxons;

		public GalleryImage(SpeciesImage image)
		{
			InitializeComponent();

			BigImage.Source = image.ImageSource;
			SpeciesName.Text = "Name of species: " + image.SpeciesName;
			Photographer.Text = "Photographer: " + image.Owner;
			Date.Text = "Captured: " + image.Date;
			License.Text = "License: " + image.License;
			SpeciesInformation.Text = "Description: " + image.Description;
			Taxons = image.Taxons;


			SpeciesTapped = new TapGestureRecognizer();
			SpeciesName.GestureRecognizers.Add(SpeciesTapped);

			SpeciesTapped.Tapped += HandleSpeciesClick;







		}

		public GalleryImage()
		{
			InitializeComponent();
		}

		// Handle tap on image in Gallery
		public async void HandleSpeciesClick(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Tapped");
			if (sender.GetType() == typeof(Label))
			{
				SpeciesImageView parent = GetAncestor((Label)sender);
				Navigation.PushAsync(new SpeciesInfo(new Species(Taxons[0])));


			}
		}


		// Returns the SpeciesInfo view to which an element belongs
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
