using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {
    public partial class SpeciesInfo : ContentPage
    {

        private Species _species;

        public Species Species
        {
            get { return _species; }

            set
            {
                _species = value;
                SetSpecies(value);
            }
                
        }

        public SpeciesInfo() {
            InitializeComponent();
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
                    Text = attribute.Item1
                };
                title.FontAttributes = FontAttributes.Bold;
                Label info = new Label
                {
                    Text = attribute.Item2
                };
                s.Children.Add(title);
                s.Children.Add(info);
                AttributesLayout.Children.Add(s);
            }

            foreach (var paragraph in species.Content)
            {
                Label title = new Label
                {
                    Text = paragraph.Item1
                };
                title.FontAttributes = FontAttributes.Bold;
                Label info = new Label
                {
                    Text = paragraph.Item2
                };
                AttributesLayout.Children.Add(title);
                AttributesLayout.Children.Add(info);
            }

            foreach (var image in species.Images)
            {
                SpeciesImageView s = new SpeciesImageView(image);
                ImageLayout.Children.Add(s);
            }
        }

    }
}
