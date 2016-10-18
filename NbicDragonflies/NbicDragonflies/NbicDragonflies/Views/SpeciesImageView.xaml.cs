﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {

    public partial class SpeciesImageView : ContentView
    {

        private SpeciesImage _image;

        public SpeciesImage Image
        {
            get { return _image; }

            set
            {
                _image = value;
                SetImage(value);
            }
        }

		public List<SpeciesImageView> Images { get; set; }

		public TapGestureRecognizer GalleryTap;

		public SpeciesImageView(SpeciesImage image) {
            InitializeComponent();

			Image = image;

			GalleryTap = new TapGestureRecognizer();
			ImageFrame.GestureRecognizers.Add(GalleryTap);

			Images = new List<SpeciesImageView>();
            // Style the view
            ImageContent.Aspect = Aspect.AspectFit;
        }

		public SpeciesImageView()
		{
			InitializeComponent();

			GalleryTap = new TapGestureRecognizer();
			ImageFrame.GestureRecognizers.Add(GalleryTap);

			Images = new List<SpeciesImageView>();
			// Style the view
			ImageContent.Aspect = Aspect.AspectFit;
		}

        // Fill view with content from image
        private void SetImage(SpeciesImage image)
        {
            ImageContent.Source = image.ImageSource;
            Owner.Text = image.Owner;
            Date.Text = image.Date;
			License.Text = image.License;
        }
    }
}