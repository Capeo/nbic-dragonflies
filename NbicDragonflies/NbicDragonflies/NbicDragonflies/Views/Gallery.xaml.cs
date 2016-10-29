﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using NbicDragonflies.Utility;
using Xamarin.Forms;


namespace NbicDragonflies.Views
{
	/// <summary>
	/// Contentpage - Gallery
	/// </summary>
	public partial class Gallery : ContentPage
	{
		public List<SpeciesImageView> Pages = new List<SpeciesImageView>();
		private int _indexCounter = 0;
	    private int _imagesCounter = 0;
		public List<SpeciesImage> ImageList;
		private IGalleryControllers _controller;


		public Gallery(IGalleryControllers controller)
		{
			InitializeComponent();

			_controller = controller;

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

			SetGalleryImages(controller.GetGalleryImages());

		}

		/// <summary>
		/// Sets the gallery images from the beginning.
		/// </summary>
		/// <param name="galleryImages">Gallery images.</param>
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

		/// <summary>
		/// Set pictures in Gallery when pressing "Next page" button
		/// </summary>
		public void IncreaseGalleryImages()
		{
		    int elementCounter = 0;
		    _imagesCounter = 0;
			for (int i = _indexCounter; i <= _indexCounter + 8; i++)
			{
			    if (i < ImageList.Count)
			    {
			        Pages.ElementAt(elementCounter).IsVisible = true;
			        Pages.ElementAt(elementCounter).Image = ImageList[i];
			        _imagesCounter++;
			    }
			    else
			    {
			        Pages.ElementAt(elementCounter).Image = new SpeciesImage();
			        Pages.ElementAt(elementCounter).IsVisible = false;
			    }
                elementCounter++;
			}
		    _indexCounter += _imagesCounter;
		}

		/// <summary>
		/// Set pictures in Gallery when pressing "Previous page" button
		/// </summary>
		public void DecreaseGalleryImages()
		{
		    int elementCounter = 8;
		    int j = _indexCounter - _imagesCounter - 1;
		    _indexCounter -= _imagesCounter;
		    _imagesCounter = 0;
			for (int i = j; i >= j - 8; i--)
			{
			    Pages.ElementAt(elementCounter).IsVisible = true;
				Pages.ElementAt(elementCounter).Image = ImageList[i];
				elementCounter--;
			    _imagesCounter++;
			}
		}

		/// <summary>
		/// Handle tap on image in Gallery
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		public void HandleImageClick(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(Frame))
			{
				SpeciesImageView parent = (SpeciesImageView)Utility.Utilities.GetAncestor((Frame)sender, typeof(SpeciesImageView));
				Navigation.PushAsync(new GalleryImage(parent.Image));
			}
		}

		/// <summary>
		/// Handles click on "Next page" button
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		public void HandleNextPageClick(object sender, EventArgs e)
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
		public void HandlePreviousPageClick(object sender, EventArgs e)
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
	