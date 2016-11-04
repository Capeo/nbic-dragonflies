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

		private List<ViewElements.ImageElementView> _gridElements = new List<ViewElements.ImageElementView>();
		private List<ImageElement> _imageList;
		private IGalleryController _controller;
        private int _indexCounter = 0;
	    private int _imagesCounter = 0;

		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		public GalleryPage()
		{
			InitializeComponent();

			_controller = new GalleryController();

			//Add pages to the Grid
			_gridElements.Add(P00);
			_gridElements.Add(P01);
			_gridElements.Add(P02);
			_gridElements.Add(P10);
			_gridElements.Add(P11);
			_gridElements.Add(P12);
			_gridElements.Add(P20);
			_gridElements.Add(P21);
			_gridElements.Add(P22);


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
			_imageList = galleryImages;
		    _imagesCounter = 0;

			for (int i = 0; i <= 8; i++)
			{
			    if (i < _imageList.Count)
			    {
			        _gridElements.ElementAt(i).Image = _imageList[i];
			        _gridElements.ElementAt(i).GalleryTap.Tapped += OnImageClick;
			        _imagesCounter++;
			    }
                else {
                    _gridElements.ElementAt(i).Image = new ImageElement();
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
			    if (i < _imageList.Count)
			    {
			        _gridElements.ElementAt(elementCounter).IsVisible = true;
			        _gridElements.ElementAt(elementCounter).Image = _imageList[i];
			        _imagesCounter++;
			    }
			    else
			    {
			        _gridElements.ElementAt(elementCounter).Image = new ImageElement();
			        _gridElements.ElementAt(elementCounter).IsVisible = false;
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
			    _gridElements.ElementAt(elementCounter).IsVisible = true;
				_gridElements.ElementAt(elementCounter).Image = _imageList[i];
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
				if (_indexCounter < _imageList.Count)
				{
					IncreaseGalleryImages();
				    if (_indexCounter >= _imageList.Count)
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
				    if (_indexCounter <= _imageList.Count)
				    {
				        NextPage.IsEnabled = true;
				    }
				}
			}
		}

	}
}
	