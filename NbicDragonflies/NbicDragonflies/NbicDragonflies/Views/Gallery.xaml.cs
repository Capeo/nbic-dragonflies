using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using NbicDragonflies.Utility;
using Xamarin.Forms;


namespace NbicDragonflies.Views
{
	public partial class Gallery : ContentPage
	{
		public List<SpeciesImageView> Pages = new List<SpeciesImageView>();
		public int IndexCounter = 0;
		public int ElementCounter = 0;
		public List<SpeciesImage> ImageList;


		public Gallery()
		{
			InitializeComponent();

			//All pages in the Grid
			Pages.Add(p00);
			Pages.Add(p01);
			Pages.Add(p02);
			Pages.Add(p10);
			Pages.Add(p11);
			Pages.Add(p12);
			Pages.Add(p20);
			Pages.Add(p21);
			Pages.Add(p22);


			NextPage.Clicked += HandleNextPageClick;
			PreviousPage.Clicked += HandlePreviousPageClick;

			SetGalleryImages(Placeholders.NewGalleryImages());

		}

		public void SetGalleryImages(List<SpeciesImage> GalleryImage)
		{
			ImageList = GalleryImage;

			for (int i = 0; i <= 8; i++)
			{
				IndexCounter++;
				Pages.ElementAt(i).Image = ImageList[i];
				Pages.ElementAt(i).GalleryTap.Tapped += HandleImageClick;
			}
		}

		public void IncreaseGalleryImages()
		{
			for (int i = IndexCounter; i <= IndexCounter + 8; i++)
			{
				Pages.ElementAt(ElementCounter).Image = ImageList[i];
				Pages.ElementAt(ElementCounter).GalleryTap.Tapped += HandleImageClick;
				ElementCounter++;
			}
			IndexCounter += 9;
			ElementCounter = 0;
			
		}

		public void DecreaseGalleryImages()
		{
			for (int i = IndexCounter; i >= IndexCounter - 8; i--)
			{
				Pages.ElementAt(ElementCounter).Image = ImageList[i];
				Pages.ElementAt(ElementCounter).GalleryTap.Tapped += HandleImageClick;
				ElementCounter++;
			}
			IndexCounter -= 9;
			ElementCounter = 0;
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
			
			if (sender.GetType() == typeof(Button))
			{
				System.Diagnostics.Debug.WriteLine("New Page");
				IncreaseGalleryImages();	
			}
		}

		//Handle tap on "Previous page" button
		public async void HandlePreviousPageClick(object sender, EventArgs e)
		{

			if (sender.GetType() == typeof(Button))
			{
				System.Diagnostics.Debug.WriteLine("Previous Page");
				DecreaseGalleryImages();
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
	