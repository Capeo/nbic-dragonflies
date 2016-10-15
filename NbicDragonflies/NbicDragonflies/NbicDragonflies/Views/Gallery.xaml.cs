using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;


namespace NbicDragonflies.Views
{
	public partial class Gallery : ContentPage
	{
		public Gallery()
		{
			InitializeComponent();

			p00.Image = new SpeciesImage("dragonfly1.jpg", "Phrida Norrhall", "23 Januari, 2012", "LC4400");
			p01.Image = new SpeciesImage("dragonfly2.jpg", "Phrida Norrhall", "23 Januari, 2012", "LC4400");
			p02.Image = new SpeciesImage("dragonfly1.jpg", "Phrida Norrhall", "23 Januari, 2012", "LC4400");
			p10.Image = new SpeciesImage("dragonfly1.jpg", "Phrida Norrhall", "23 Januari, 2012", "LC4400");
			p11.Image = new SpeciesImage("dragonfly1.jpg", "Phrida Norrhall", "23 Januari, 2012", "LC4400");
			p12.Image = new SpeciesImage("dragonfly1.jpg", "Phrida Norrhall", "23 Januari, 2012", "LC4400");
			p20.Image = new SpeciesImage("dragonfly1.jpg", "Phrida Norrhall", "23 Januari, 2012", "LC4400");
			p21.Image = new SpeciesImage("dragonfly1.jpg", "Phrida Norrhall", "23 Januari, 2012", "LC4400");
			p22.Image = new SpeciesImage("dragonfly1.jpg", "Phrida Norrhall", "23 Januari, 2012", "LC4400");

			p00.GalleryTap.Tapped += HandleNavigationClick;
			p01.GalleryTap.Tapped += HandleNavigationClick;
			p02.GalleryTap.Tapped += HandleNavigationClick;
			p10.GalleryTap.Tapped += HandleNavigationClick;
			p11.GalleryTap.Tapped += HandleNavigationClick;
			p12.GalleryTap.Tapped += HandleNavigationClick;
			p20.GalleryTap.Tapped += HandleNavigationClick;
			p21.GalleryTap.Tapped += HandleNavigationClick;
			p22.GalleryTap.Tapped += HandleNavigationClick;


		}



		// Handle tap on navigation part of TaxonButton
		public async void HandleNavigationClick(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Button");
			if (sender.GetType() == typeof(Frame))
			{
				SpeciesImageView parent = GetAncestor((Frame)sender);
				Navigation.PushAsync(new GalleryImage(parent.Image));


			}
		}

		// Returns the TaxonButton view to which an element belongs
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
	