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

        public TapGestureRecognizer AlternativeTap { get; }

        public IdentifyAlternative Alternative { get; private set; }

        public IdentifyAlternativeView(IdentifyAlternative alternative)
        {
            InitializeComponent();

            Alternative = alternative;

            AlternativeTap = new TapGestureRecognizer();
            Frame.GestureRecognizers.Add(AlternativeTap);

            Image.Source = alternative.Image;
            Text.Text = alternative.Text;

            if (alternative.Status == AlternativeStatus.Selected)
            {
                Frame.BackgroundColor = Utility.Constants.KeyGreen;
            }
            else if (alternative.Status == AlternativeStatus.Disabled)
            {
                Frame.BackgroundColor = Utility.Constants.KeyRed;
            }
        }
    }
}
