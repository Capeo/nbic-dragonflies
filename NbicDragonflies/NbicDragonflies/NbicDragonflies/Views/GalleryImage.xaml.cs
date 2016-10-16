using System;
using System.Collections.Generic;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies
{
	public partial class GalleryImage : ContentPage
	{
		public GalleryImage(SpeciesImage image)
		{
			InitializeComponent();

			BigImage.Source = image.ImageSource;
			SpeciesName.Text = "Odonata";
			Photographer.Text = "Photographer: " + image.Owner;
			Date.Text = "Captured: " + image.Date;
			License.Text = "License: " + image.License;
			SpeciesInformation.Text = "A dragonfly is an insect belonging to the order Odonata, suborder Anisoptera (from Greek ἄνισος anisos uneven and πτερόν pteron, wing, because the hindwing is broader than the forewing). Adult dragonflies are characterized by large multifaceted eyes, two pairs of strong transparent wings, sometimes with coloured patches and an elongated body.";


			//use label + image instead of view. 
		}

		public GalleryImage()
		{
			InitializeComponent();
		}
	}
}
