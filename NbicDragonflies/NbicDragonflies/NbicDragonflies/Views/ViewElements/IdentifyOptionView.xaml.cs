using NbicDragonflies.Models.IdentificationKey;
using Xamarin.Forms;

namespace NbicDragonflies.Views.ViewElements {

    public partial class IdentifyOptionView : ContentView
    {

        public TapGestureRecognizer OptionTap { get; }

        public IdentifyOption Option { get; private set; }

        public IdentifyOptionView(IdentifyOption option)
        {
            InitializeComponent();

            Option = option;

            OptionTap = new TapGestureRecognizer();
            Frame.GestureRecognizers.Add(OptionTap);

            Image.Source = option.Image;
            Text.Text = option.Text;

            if (option.Status == OptionStatus.Selected)
            {
                Frame.BackgroundColor = Utility.Constants.KeyGreen;
            }
            else if (option.Status == OptionStatus.Disabled)
            {
                Frame.BackgroundColor = Utility.Constants.KeyRed;
                Frame.IsEnabled = false;
            }
        }
    }
}
