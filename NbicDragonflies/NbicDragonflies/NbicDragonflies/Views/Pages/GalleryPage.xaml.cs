using System;
using System.Collections.Generic;
using System.Linq;
using NbicDragonflies.Controllers;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views.Pages
{
	/// <summary>
	/// GalleryPage page. 
	/// </summary>
	public partial class GalleryPage : ContentPage
	{
		/// <summary>
		/// The pages in the grid.
		/// </summary>
		private List<ViewElements.ImageElementView> GridElements = new List<ViewElements.ImageElementView>();
		/// <summary>
		/// List over Images to fill in all pages. 
		/// </summary>
		private List<ImageElement> ImageList;

		private IGalleryController _controller;
        private int _indexCounter = 0;
	    private int _imagesCounter = 0;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Views.GridElements.GalleryPage"/> class with IGalleryControllers as parameter.
		/// </summary>
		public GalleryPage()
		{
			InitializeComponent();

			_controller = new GalleryController();

			//All pages in the Grid
			GridElements.Add(p00);
			GridElements.Add(p01);
			GridElements.Add(p02);
			GridElements.Add(p10);
			GridElements.Add(p11);
			GridElements.Add(p12);
			GridElements.Add(p20);
			GridElements.Add(p21);
			GridElements.Add(p22);


			NextPage.Clicked += OnNextPageClick;
			PreviousPage.Clicked += OnPreviousPageClick;
		    PreviousPage.IsEnabled = false;

			NextPage.BorderColor = Utility.Constants.NbicBrown;
			PreviousPage.BorderColor = Utility.Constants.NbicBrown;
			NextPage.TextColor = Utility.Constants.NbicBrown;
			PreviousPage.TextColor = Utility.Constants.NbicBrown;


			SetGalleryImages(_controller.GetGalleryImages());

		}

		/// <summary>
		/// Sets the gallery images from the beginning.
		/// </summary>
		/// <param name="galleryImages">GalleryPage images.</param>
		private void SetGalleryImages(List<ImageElement> galleryImages)
		{
			ImageList = galleryImages;
		    _imagesCounter = 0;

			for (int i = 0; i <= 8; i++)
			{
			    if (i < ImageList.Count)
			    {
			        GridElements.ElementAt(i).Image = ImageList[i];
			        GridElements.ElementAt(i).GalleryTap.Tapped += OnImageClick;
			        _imagesCounter++;
			    }
                else {
                    GridElements.ElementAt(i).Image = new ImageElement();
                }
            }
		    _indexCounter += _imagesCounter;
		}

		/// <summary>
		/// Set pictures in GalleryPage when pressing "Next page" button
		/// </summary>
		private void IncreaseGalleryImages()
		{
		    int elementCounter = 0;
		    _imagesCounter = 0;
			for (int i = _indexCounter; i <= _indexCounter + 8; i++)
			{
			    if (i < ImageList.Count)
			    {
			        GridElements.ElementAt(elementCounter).IsVisible = true;
			        GridElements.ElementAt(elementCounter).Image = ImageList[i];
			        _imagesCounter++;
			    }
			    else
			    {
			        GridElements.ElementAt(elementCounter).Image = new ImageElement();
			        GridElements.ElementAt(elementCounter).IsVisible = false;
			    }
                elementCounter++;
			}
		    _indexCounter += _imagesCounter;
		}

		/// <summary>
		/// Set pictures in GalleryPage when pressing "Previous page" button
		/// </summary>
		private void DecreaseGalleryImages()
		{
		    int elementCounter = 8;
		    int j = _indexCounter - _imagesCounter - 1;
		    _indexCounter -= _imagesCounter;
		    _imagesCounter = 0;
			for (int i = j; i >= j - 8; i--)
			{
			    GridElements.ElementAt(elementCounter).IsVisible = true;
				GridElements.ElementAt(elementCounter).Image = ImageList[i];
				elementCounter--;
			    _imagesCounter++;
			}
		}

		/// <summary>
		/// Handle tap on image in GalleryPage
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void OnImageClick(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(Frame))
			{
				ViewElements.ImageElementView parent = (ViewElements.ImageElementView)Utility.Utilities.GetWrapperView((Frame)sender, typeof(ViewElements.ImageElementView));
				Navigation.PushAsync(new ImageInfoPage(parent.Image));
			}
		}

		/// <summary>
		/// Handles click on "Next page" button
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void OnNextPageClick(object sender, EventArgs e)
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

		/// <summary>
		/// Handles click on "Previous page" button
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void OnPreviousPageClick(object sender, EventArgs e)
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

	}
}
	