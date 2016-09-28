using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {
    public partial class Identify : ContentPage {

        public ListView ListView { get { return ResultsList; } }

        public Identify()
        {
            InitializeComponent();

            var resultsItems = new List<ResultItem>();

            resultsItems.Add(new ResultItem
            {
                ImageSource = "dragonfly1.jpg",
                Text = "Dragonfly 1",
                TargetType = typeof(Home)
            });

            resultsItems.Add(new ResultItem
            {
                ImageSource = "dragonfly2.jpg",
                Text = "Dragonfly 2",
                TargetType = typeof(Home)
            });

            ResultsList.ItemsSource = resultsItems;
        }
    }
}
