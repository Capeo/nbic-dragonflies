using System.Collections.Generic;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views.ViewElements {

	/// <summary>
	/// Content image view class.
	/// </summary>
    public partial class ImageElementView : ContentView
    {

        private ImageElement _image;

        public Label DescriptionLabel { get { return Description; } }

		/// <summary>
		/// Gets or sets the image with all its content.
		/// </summary>
		/// <value>The image.</value>
        public ImageElement Image
        {
            get { return _image; }

            set
            {
                _image = value;
                SetImage(value);
            }
        }

		/// <summary>
		/// Gets or sets the images.
		/// </summary>
		/// <value>The images.</value>
		public List<ImageElementView> Images { get; set; }

		/// <summary>
		/// TapGestureRecognizer for tap in GalleryPage.
		/// </summary>
		public TapGestureRecognizer GalleryTap;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Views.ViewElements.ImageElementView"/> class with a SpeciesImage as argument.
		/// </summary>
		/// <param name="image">Image.</param>
		public ImageElementView(ImageElement image) {
            InitializeComponent();

			Image = image;

			GalleryTap = new TapGestureRecognizer();
			ImageFrame.GestureRecognizers.Add(GalleryTap);

			Images = new List<ImageElementView>();
            // Style the view
            ImageContent.Aspect = Aspect.AspectFit;


        }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Views.ViewElements.ImageElementView"/> class.
		/// </summary>
		public ImageElementView()
		{
			InitializeComponent();

			GalleryTap = new TapGestureRecognizer();
			ImageFrame.GestureRecognizers.Add(GalleryTap);

			Images = new List<ImageElementView>();
			// Style the view
			ImageContent.Aspect = Aspect.AspectFit;
		}

		/// <summary>
		/// Fill view with content from image.
		/// </summary>
		/// <param name="image">Image.</param>
        private void SetImage(ImageElement image)
        {
            ImageContent.Source = image.ImageSource;
			TaxonName.Text = image.TaxonName;
            Description.Text = image.Description;
            Date.Text = image.Date;

			TaxonName.TextColor = Utility.Constants.NbicBrown;
			Date.TextColor = Utility.Constants.NbicBrown;
			//Photographer.TextColor = Utility.Constants.NbicBrown;
        }


    }
}
