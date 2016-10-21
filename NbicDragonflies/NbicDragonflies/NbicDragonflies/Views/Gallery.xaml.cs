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
		public TapGestureRecognizer NextPageTapped;

		public Gallery()
		{
			InitializeComponent();

			p00.Image = new SpeciesImage("dragonfly1.jpg", "Sara Phrida Kristina Norrhall", "12/3-14", "VERYLONGLICENSE");
			p01.Image = new SpeciesImage("dragonfly2.jpg", "Phrida Norrhall", "12/3-14", "LC4400");
			p02.Image = new SpeciesImage("dragonfly1.jpg", "Phrida Norrhall", "12/3-14", "LC4400");
			p10.Image = new SpeciesImage("dragonfly1.jpg", "Phrida Norrhall", "12/3-14", "LC4400");
			p11.Image = new SpeciesImage("dragonfly1.jpg", "Phrida Norrhall", "12/3-14", "LC4400");
			p12.Image = new SpeciesImage("dragonfly1.jpg", "Phrida Norrhall", "12/3-14", "LC4400");
			p20.Image = new SpeciesImage("dragonfly1.jpg", "Phrida Norrhall", "12/3-14", "LC4400");
			p21.Image = new SpeciesImage("dragonfly1.jpg", "Phrida Norrhall", "12/3-14", "LC4400");
			p22.Image = new SpeciesImage("dragonfly1.jpg", "Phrida Norrhall", "12/3-14", "LC4400");

			p00.GalleryTap.Tapped += HandleImageClick;
			p01.GalleryTap.Tapped += HandleImageClick;
			p02.GalleryTap.Tapped += HandleImageClick;
			p10.GalleryTap.Tapped += HandleImageClick;
			p11.GalleryTap.Tapped += HandleImageClick;
			p12.GalleryTap.Tapped += HandleImageClick;
			p20.GalleryTap.Tapped += HandleImageClick;
			p21.GalleryTap.Tapped += HandleImageClick;
			p22.GalleryTap.Tapped += HandleImageClick;

			NextPageTapped = new TapGestureRecognizer();
			nextPage.GestureRecognizers.Add(NextPageTapped);

			NextPageTapped.Tapped += HandleNextPageClick;




		}



		// Handle tap on image in Gallery
		public async void HandleImageClick(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Tapped");
			if (sender.GetType() == typeof(Frame))
			{
				SpeciesImageView parent = GetAncestor((Frame)sender);
				Navigation.PushAsync(new GalleryImage(parent.Image));


			}
		}

		//Handle tap on "Next page" button
		public async void HandleNextPageClick(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Tapped");
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
	