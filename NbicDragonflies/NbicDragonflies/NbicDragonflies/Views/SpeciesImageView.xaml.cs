using System;
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

        public SpeciesImageView() {
            InitializeComponent();

            // Style the view
            ImageContent.Aspect = Aspect.AspectFit;
        }

        public SpeciesImageView(SpeciesImage image)
        {
            InitializeComponent();

            ImageContent.Aspect = Aspect.AspectFit;
            SetImage(image);
        }

        // Fill view with content from image
        private void SetImage(SpeciesImage image)
        {
            ImageContent.Source = image.ImageSource;
            Owner.Text = image.Owner;
            Caption.Text = image.Caption;
        }
    }
}
