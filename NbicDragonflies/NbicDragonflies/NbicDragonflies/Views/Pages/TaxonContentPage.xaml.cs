using System;
using NbicDragonflies.Controllers;
using NbicDragonflies.Models;
using NbicDragonflies.Models.Taxon;
using Xamarin.Forms;

namespace NbicDragonflies.Views.Pages {

	/// <summary>
	/// Taxon content/info page. 
	/// </summary>
    public partial class TaxonContentPage : ContentPage
    {

        private ITaxonContentController _controller;
        private TaxonContent _taxonContent;

		/// <summary>
		/// Gets or sets the content of the page.
		/// </summary>
		/// <value>The content.</value>
        public TaxonContent TaxonContent
        {
            get { return _taxonContent; }

            set
            {
                _taxonContent = value;
                SetContent(value);
            }   
        }

        /// <summary>
        /// Constructor. Initializes new TaxonContent page from taxon object.
        /// </summary>
        /// <param name="taxon">The taxon associated with this page instance.</param>
        public TaxonContentPage(Taxon taxon)
        {
            InitializeComponent();

            _controller = new TaxonContentController();

            TaxonContent = _controller.GetContentFromTaxon(taxon);
        }

        // Fills the TaxonContentPage view
        private void SetContent(TaxonContent content)
        {
            Title = content.Taxon.GetPreferredName();

            TopImage.Image = content.TopImage;

            foreach (var attribute in content.Attributes)
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

            foreach (var paragraph in content.Content)
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

            foreach (var image in content.Images)
            {
				ViewElements.ImageElementView s = new ViewElements.ImageElementView(image);
                ImageLayout.Children.Add(s);
                s.DescriptionLabel.IsVisible = true;
				s.GalleryTap.Tapped += OnImageClick;
            }
        }

		// Handle tap on image in GalleryPage
		private void OnImageClick(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(Frame))
			{
				ViewElements.ImageElementView parent = (ViewElements.ImageElementView)Utility.Utilities.GetWrapperView((Frame)sender, typeof(ViewElements.ImageElementView));
				Navigation.PushAsync(new Pages.ImageInfoPage(parent.Image));
			}
		}

    }
}
