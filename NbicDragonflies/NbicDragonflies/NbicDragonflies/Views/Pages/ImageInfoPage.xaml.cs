using System;
using System.Collections.Generic;
using NbicDragonflies.Models;
using NbicDragonflies.Models.Taxon;
using NbicDragonflies.Resources;
using Xamarin.Forms;

namespace NbicDragonflies.Views.Pages
{
	/// <summary>
	/// Shows image with and details
	/// </summary>
	public partial class ImageInfoPage : ContentPage
	{
		/// <summary>
		/// TapGestureRecognizer for tap at TaxonName. 
		/// </summary>
		public TapGestureRecognizer TaxonTap;

		/// <summary>
		/// The taxons.
		/// </summary>
		public List<Taxon> Taxons;

		private string _photographer;
		private string _date;
		private string _license;
		private string _description;
		private string _moreInfo;


		/// <summary>
		/// Constructor. Initializes a new instance of the class. 
		/// </summary>
		/// <param name="image">Image.</param>
		public ImageInfoPage(ImageElement image)
		{
			InitializeComponent();

		    Title = image.TaxonName;
			_photographer = LanguageResource.GalleryImagePhotographerLabel;
			_date = LanguageResource.GalleryImageDateLabel;
			_license = LanguageResource.GalleryImageLicenseLabel;
			_description = LanguageResource.GalleryImageDescriptionLabel;
			_moreInfo = LanguageResource.GalleryImageMoreInfoLabel;


			BigImage.Source = image.ImageSource;
			TaxonName.Text = image.TaxonName;
			MoreInfo.Text = _moreInfo;
			PhotographerDescription.Text = _photographer;
			Photographer.Text = image.Owner;
			DateDescription.Text = _date;
			Date.Text =  image.Date;
			LicenseDescription.Text = _license;
			License.Text = image.License;
            TaxonInformationDescription.Text = _description;
			TaxonInformation.Text = image.Description;
			Taxons = image.Taxons;


			TaxonTap = new TapGestureRecognizer();

			TaxonName.GestureRecognizers.Add(TaxonTap);
			BigImage.GestureRecognizers.Add(TaxonTap);

		    TaxonTap.Tapped += OnTaxonClick;

		}

		/// <summary>
		/// Handles click on TaxonName
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void OnTaxonClick(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(Label))
			{
				ViewElements.ImageElementView parent = (ViewElements.ImageElementView)Utility.Utilities.GetWrapperView((Label)sender, typeof(ViewElements.ImageElementView));
				Navigation.PushAsync(new TaxonContentPage(Taxons[0]));
			}
			else if (sender.GetType() == typeof(Image))
			{
				ViewElements.ImageElementView parent = (ViewElements.ImageElementView)Utility.Utilities.GetWrapperView((Image)sender, typeof(ViewElements.ImageElementView)); ;
				Navigation.PushAsync(new TaxonContentPage(Taxons[0]));
			}
		}

	}
}
