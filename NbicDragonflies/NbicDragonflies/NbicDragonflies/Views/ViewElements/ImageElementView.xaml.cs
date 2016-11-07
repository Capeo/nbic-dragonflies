using System.Collections.Generic;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views.ViewElements {

	/// <summary>
	/// Image view class containing image and associated information.
	/// </summary>
    public partial class ImageElementView : ContentView
    {

        private ImageElement _image;

        /// <summary>
        /// Label for the description element of the image.
        /// </summary>
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

        // TODO remove?
		///// <summary>
		///// Gets or sets the images.
		///// </summary>
		///// <value>The images.</value>
		//public List<ImageElementView> Images { get; set; }

		/// <summary>
		/// TapGestureRecognizer for tap in GalleryPage.
		/// </summary>
		public TapGestureRecognizer GalleryTap;

		/// <summary>
		/// Constructor. Initializes a new instance of the view from the given image.
		/// </summary>
		/// <param name="image">Image.</param>
		public ImageElementView(ImageElement image) {
            InitializeComponent();

			Image = image;

			GalleryTap = new TapGestureRecognizer();
			ImageFrame.GestureRecognizers.Add(GalleryTap);

            // Style the view
            ImageContent.Aspect = Aspect.AspectFit;
        }

        /// <summary>
        /// Constructor. Initializes a new, empty instance of the view.
        /// </summary>
        public ImageElementView()
		{
			InitializeComponent();

			GalleryTap = new TapGestureRecognizer();
			ImageFrame.GestureRecognizers.Add(GalleryTap);

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
        }
    }
}
