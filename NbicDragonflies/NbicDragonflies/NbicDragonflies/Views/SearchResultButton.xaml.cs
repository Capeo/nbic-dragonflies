using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NbicDragonflies.Views
{
    public partial class SearchResultButton : ContentView
    {
        public TapGestureRecognizer ButtonTap;
        public SearchResultButton(string searchLabelText)
        {
            InitializeComponent();
            ButtonTap = new TapGestureRecognizer();
            SearchResultLabel.Text = searchLabelText;
            SearchResultLabel.GestureRecognizers.Add(ButtonTap);
        }
    }
}
