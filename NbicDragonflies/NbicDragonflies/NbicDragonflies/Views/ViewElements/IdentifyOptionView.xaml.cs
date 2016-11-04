using NbicDragonflies.Models.IdentificationKey;
using Xamarin.Forms;

namespace NbicDragonflies.Views.ViewElements {

    /// <summary>
    /// View element for option in identification key.
    /// </summary>
    public partial class IdentifyOptionView : ContentView
    {

        /// <summary>
        /// TapGestureRecognizer used to handle selection of option
        /// </summary>
        public TapGestureRecognizer OptionTap { get; }

        /// <summary>
        /// The option associated with the view
        /// </summary>
        public IdentifyOption Option { get; private set; }

        /// <summary>
        /// Constructor. Initialize new view from given identification key option
        /// </summary>
        /// <param name="option">The option associated with the view</param>
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
                Frame.BackgroundColor = Utility.Constants.IdentifyGreen;
            }
            else if (option.Status == OptionStatus.Disabled)
            {
                Frame.BackgroundColor = Utility.Constants.IdentifyRed;
                Frame.IsEnabled = false;
            }
        }
    }
}
