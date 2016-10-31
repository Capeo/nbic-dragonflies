using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;
using NbicDragonflies.Controllers;

namespace NbicDragonflies.Views {

	/// <summary>
	/// Species info page. 
	/// </summary>
    public partial class SpeciesInfo : ContentPage
    {
        private ISpeciesContentController _controller;

        private Species _species;
		/// <summary>
		/// TapGestureRecognizer for tap at image. 
		/// </summary>
		public TapGestureRecognizer ImageTapped;
		/// <summary>
		/// The species image with all content.
		/// </summary>
		public SpeciesImage SpeciesImage;

		/// <summary>
		/// Gets or sets the species.
		/// </summary>
		/// <value>The species.</value>
        public Species Species
        {
            get { return _species; }

            set
            {
                _species = value;
                SetSpecies(value);
            }   
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Views.SpeciesInfo"/> class.
		/// </summary>
        public SpeciesInfo() {
            InitializeComponent();
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Views.SpeciesInfo"/> class with Species as parameter.
		/// </summary>
		/// <param name="species">Species.</param>
        public SpeciesInfo(Species species) {
            InitializeComponent();

            if (species.Taxon != null)
            {
                Title = species.Taxon.GetPreferredName();
            }
            SetSpecies(species);

			ImageTapped = new TapGestureRecognizer();
        }

        //TODO create SetSpeciesContent for view
        public SpeciesInfo(Taxon taxon)
        {
            InitializeComponent();
            SpeciesContent speciesContent = _controller.GetContentFromTaxon(taxon);
        }

        // Fills the SpeciesInfo view
        private void SetSpecies(Species species)
        {
            TopImage.Image = species.TopImage;

            foreach (var attribute in species.Attributes)
            {
                StackLayout s = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal
                };
                Label title = new Label
                {
                    Text = attribute.Item1,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 14
                };
                Label info = new Label
                {
                    Text = attribute.Item2,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    FontSize = 14
                };
                s.Children.Add(title);
                s.Children.Add(info);
                AttributesLayout.Children.Add(s);
            }

            foreach (var paragraph in species.Content)
            {
                Label title = new Label
                {
                    Text = paragraph.Item1,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 16
                };
                Label info = new Label
                {
                    Text = paragraph.Item2
                };
                InfoLayout.Children.Add(title);
                InfoLayout.Children.Add(info);
            }

            foreach (var image in species.Images)
            {
				SpeciesImageView s = new SpeciesImageView(image);
                ImageLayout.Children.Add(s);
                s.DescriptionLabel.IsVisible = true;
				s.GalleryTap.Tapped += HandleImageClick;
            }
        }

		// Handle tap on image in Gallery
		private void HandleImageClick(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Tapped");
			if (sender.GetType() == typeof(Frame))
			{
				SpeciesImageView parent = GetAncestor((Frame)sender);
				Navigation.PushAsync(new GalleryImage(parent.Image));
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
