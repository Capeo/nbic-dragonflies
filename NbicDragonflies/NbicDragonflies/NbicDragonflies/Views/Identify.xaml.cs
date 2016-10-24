using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {
    public partial class Identify : TabbedPage {

        public ListView ListView1 { get { return ResultsList; } }

        public Identify()
        {
            InitializeComponent();

            // Add alternatives

            IdentifyAlternative alt1 = new IdentifyAlternative("Vingene legges helt eller delvis bakover langs kroppen i hvile.", "hvilestilling1.png");

            IdentifyAlternative alt2 = new IdentifyAlternative("Vingene står vinkelrett ut fra kroppen i hvile.", "hvilestilling2.png");

            SetQuestion("Hvilestilling", new List<IdentifyAlternative> {alt1, alt2});


            // Add items for results

            var resultsItems = new List<ResultItem>();

            resultsItems.Add(new ResultItem
            {
                ImageSource = "dragonfly1.jpg",
                Text = "Dragonfly 1",
                Detail = "Something latin",
                TargetType = typeof(Home)
            });

            resultsItems.Add(new ResultItem
            {
                ImageSource = "dragonfly2.jpg",
                Text = "Dragonfly 2",
                Detail = "Something latin", 
                TargetType = typeof(Home)
            });

            resultsItems.Add(new ResultItem
            {
                ImageSource = "dragonfly2.jpg",
                Text = "Dragonfly 3",
                Detail = "Something latin",
                TargetType = typeof(Home)
            });

            resultsItems.Add(new ResultItem
            {
                ImageSource = "dragonfly1.jpg",
                Text = "Dragonfly 4",
                Detail = "Something latin",
                TargetType = typeof(Home)
            });

            resultsItems.Add(new ResultItem
            {
                ImageSource = "dragonfly1.jpg",
                Text = "Dragonfly 5",
                Detail = "Something latin",
                TargetType = typeof(Home)
            });

            resultsItems.Add(new ResultItem
            {
                ImageSource = "dragonfly2.jpg",
                Text = "Dragonfly 6",
                Detail = "Something latin",
                TargetType = typeof(Home)
            });

            resultsItems.Add(new ResultItem
            {
                ImageSource = "dragonfly1.jpg",
                Text = "Dragonfly 7",
                Detail = "Something latin",
                TargetType = typeof(Home)
            });

            ResultsList.ItemsSource = resultsItems;
        }

        private void SetQuestion(string title, List<IdentifyAlternative> alternatives)
        {
            AlternativeCategory.Text = title;
            StackLayout.Children.Clear();
            foreach (var alternative in alternatives)
            {
                IdentifyAlternativeView alternativeView = new IdentifyAlternativeView(alternative);
                StackLayout.Children.Add(alternativeView);
            }
        }

        private void HandleAlternativeTap(object sender, EventArgs e)
        {
            
        }
    }
}
