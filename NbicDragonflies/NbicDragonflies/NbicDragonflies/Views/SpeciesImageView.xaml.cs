using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {

	/// <summary>
	/// Species image view class.
	/// </summary>
    public partial class SpeciesImageView : ContentView
    {

        private SpeciesImage _image;

        public Label DescriptionLabel { get { return Description; } }

		/// <summary>
		/// Gets or sets the image with all its content.
		/// </summary>
		/// <value>The image.</value>
        public SpeciesImage Image
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
		public List<SpeciesImageView> Images { get; set; }

		/// <summary>
		/// TapGestureRecognizer for tap in Gallery.
		/// </summary>
		public TapGestureRecognizer GalleryTap;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Views.SpeciesImageView"/> class with a SpeciesImage as argument.
		/// </summary>
		/// <param name="image">Image.</param>
		public SpeciesImageView(SpeciesImage image) {
            InitializeComponent();

			Image = image;

			GalleryTap = new TapGestureRecognizer();
			ImageFrame.GestureRecognizers.Add(GalleryTap);

			Images = new List<SpeciesImageView>();
            // Style the view
            ImageContent.Aspect = Aspect.AspectFit;


        }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Views.SpeciesImageView"/> class.
		/// </summary>
		public SpeciesImageView()
		{
			InitializeComponent();

			GalleryTap = new TapGestureRecognizer();
			ImageFrame.GestureRecognizers.Add(GalleryTap);

			Images = new List<SpeciesImageView>();
			// Style the view
			ImageContent.Aspect = Aspect.AspectFit;
		}

		/// <summary>
		/// Fill view with content from image.
		/// </summary>
		/// <param name="image">Image.</param>
        private void SetImage(SpeciesImage image)
        {
            ImageContent.Source = image.ImageSource;
			SpeciesName.Text = image.SpeciesName;
            Description.Text = image.Description;
            Date.Text = image.Date;

			SpeciesName.TextColor = Utility.Constants.NbicBrown;
			Date.TextColor = Utility.Constants.NbicBrown;
			//Photographer.TextColor = Utility.Constants.NbicBrown;
        }


    }
}
