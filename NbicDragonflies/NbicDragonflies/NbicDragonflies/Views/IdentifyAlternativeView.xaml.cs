using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {
    public partial class IdentifyAlternativeView : ContentView
    {

        public TapGestureRecognizer AlternativeTap;

        public IdentifyAlternative Alternative { get; set; }

        public IdentifyAlternativeView() {
            InitializeComponent();

            AlternativeTap = new TapGestureRecognizer();
            Frame.GestureRecognizers.Add(AlternativeTap);
        }

        public IdentifyAlternativeView(IdentifyAlternative alternative)
        {
            InitializeComponent();

            AlternativeTap = new TapGestureRecognizer();
            Frame.GestureRecognizers.Add(AlternativeTap);

            Image.Source = alternative.Image;
            Text.Text = alternative.Text;
        }
    }
}
