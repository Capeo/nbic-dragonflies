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
                
            }

            foreach (var paragraph in species.Content)
            {
                
            }

            foreach (var image in species.Images)
            {
                
            }
        }

    }
}
