using System;
using System.Collections.Generic;
using NbicDragonflies.Models;
using NbicDragonflies.Views;
using Xamarin.Forms;
using NbicDragonflies.Resources;

namespace NbicDragonflies
{
	/// <summary>
	/// Class shows content for each Image in Gallery.
	/// </summary>
	public partial class GalleryImage : ContentPage
	{
		public TapGestureRecognizer SpeciesTapped;
		public List<Taxon> Taxons;

		public GalleryImage(SpeciesImage image)
		{
			InitializeComponent();

		    Title = image.SpeciesName;


			BigImage.Source = image.ImageSource;
			SpeciesName.Text = LanguageResource.GalleryImageSpeciesLabel + ": " + image.SpeciesName;
			Photographer.Text = LanguageResource.GalleryImagePhotographerLabel + ": " + image.Owner;
			Date.Text = LanguageResource.GalleryImageDateLabel + ": " + image.Date;
			License.Text = LanguageResource.GalleryImageLicenseLabel + ": " + image.License;
			SpeciesInformation.Text = LanguageResource.GalleryImageDescriptionLabel + ": " + image.Description;
			Taxons = image.Taxons;


			SpeciesTapped = new TapGestureRecognizer();
			SpeciesName.GestureRecognizers.Add(SpeciesTapped);

		    SpeciesTapped.Tapped += HandleSpeciesClick;

		}

		public GalleryImage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Handles click on SpeciesName
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		public async void HandleSpeciesClick(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Tapped");
			if (sender.GetType() == typeof(Label))
			{
				SpeciesImageView parent = GetAncestor((Label)sender);
				Navigation.PushAsync(new SpeciesInfo(new Species(Taxons[0])));


			}
		}

		/// <summary>
		/// Returns the SpeciesImageView to which an element belongs
		/// </summary>
		/// <returns>The ancestor.</returns>
		/// <param name="e">E.</param>
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
