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
        public ListView ListView2 { get { return AlternativesList; } }

        public Identify()
        {
            InitializeComponent();

            // Add alternatives

            var alternativesItems = new List<AlternativeItem>();

            alternativesItems.Add(new AlternativeItem
            {
                ImageSource = "hvilestilling1.png",
                Detail = "Vingene legges helt eller delvis bakover langs kroppen i hvile.",
                TargetType = typeof(Home)
            });

            alternativesItems.Add(new AlternativeItem
            {
                ImageSource = "hvilestilling2.png",
                Detail = "Vingene står vinkelrett ut fra kroppen i hvile.",
                TargetType = typeof(Home)
            });

            AlternativesList.ItemsSource = alternativesItems;



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
    }
}
