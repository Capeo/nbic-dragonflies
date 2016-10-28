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
		private int _indexCounter = 0;
	    private int _imagesCounter = 0;
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
		    PreviousPage.IsEnabled = false;

			SetGalleryImages(Placeholders.NewGalleryImages());

		}

		public void SetGalleryImages(List<SpeciesImage> galleryImages)
		{
			ImageList = galleryImages;
		    _imagesCounter = 0;

			for (int i = 0; i <= 8; i++)
			{
			    if (i < ImageList.Count)
			    {
			        Pages.ElementAt(i).Image = ImageList[i];
			        Pages.ElementAt(i).GalleryTap.Tapped += HandleImageClick;
			        _imagesCounter++;
			    }
                else {
                    Pages.ElementAt(i).Image = new SpeciesImage();
                }
            }
		    _indexCounter += _imagesCounter;
		}

		public void IncreaseGalleryImages()
		{
		    int elementCounter = 0;
		    _imagesCounter = 0;
			for (int i = _indexCounter; i <= _indexCounter + 8; i++)
			{
			    if (i < ImageList.Count)
			    {
			        Pages.ElementAt(elementCounter).Image = ImageList[i];
			        _imagesCounter++;
			    }
			    else
			    {
			        Pages.ElementAt(elementCounter).Image = new SpeciesImage();
			    }
                elementCounter++;
			}
		    _indexCounter += _imagesCounter;
		}

		public void DecreaseGalleryImages()
		{
		    int elementCounter = 8;
		    int j = _indexCounter - _imagesCounter - 1;
		    _indexCounter -= _imagesCounter;
		    _imagesCounter = 0;
			for (int i = j; i >= j - 8; i--)
			{
				Pages.ElementAt(elementCounter).Image = ImageList[i];
				elementCounter--;
			    _imagesCounter++;
			}
		}

		// Handle tap on image in Gallery
		public async void HandleImageClick(object sender, EventArgs e)
		{
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
				if (_indexCounter < ImageList.Count)
				{
					IncreaseGalleryImages();
				    if (_indexCounter >= ImageList.Count)
				    {
				        NextPage.IsEnabled = false;
				    }
				    PreviousPage.IsEnabled = true;
				}
			}
		}

		//Handle tap on "Previous page" button
		public async void HandlePreviousPageClick(object sender, EventArgs e)
		{

			if (sender.GetType() == typeof(Button))
			{
				if (_indexCounter > 0)
				{
					DecreaseGalleryImages();
				    if (_indexCounter <= 9)
				    {
				        PreviousPage.IsEnabled = false;
				    }
				    if (_indexCounter <= ImageList.Count)
				    {
				        NextPage.IsEnabled = true;
				    }
				}
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
	