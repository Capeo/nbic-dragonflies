using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using NbicDragonflies.Views.ListItems;
using Xamarin.Forms;

namespace NbicDragonflies.Views {
    public partial class Home : ContentPage {

        public ListView ListView { get { return RecentObservationsList; } } 

        public Home()
        {
            InitializeComponent();

            // Position Search Bar within layout 
            AbsoluteLayout.SetLayoutBounds(SearchBar, new Rectangle(.5, 0, -1, -1));
            AbsoluteLayout.SetLayoutFlags(SearchBar, AbsoluteLayoutFlags.PositionProportional);
            SearchLayout.Children.Add(SearchBar);

            // Position title within InfoLayout
            InfoLayout.Children.Add(InfoTitle,
                Constraint.RelativeToParent((parent) => parent.X),
                Constraint.RelativeToParent((parent) => parent.Y),
                Constraint.RelativeToParent((parent) => parent.Width*0.5),
                Constraint.RelativeToParent((parent) => parent.Height*0.2));
            InfoTitle.FontAttributes = FontAttributes.Bold;

            // Position text within InfoLayout
            InfoLayout.Children.Add(InfoText,
                Constraint.RelativeToView(InfoTitle, (parent, sibling) => sibling.X),
                Constraint.RelativeToView(InfoTitle, (parent, sibling) => (sibling.Y + sibling.Height + 4)),
                Constraint.RelativeToParent((parent) => parent.Width * 0.5),
                Constraint.RelativeToParent((parent) => parent.Height * 0.8)
                );

            // Position image within InfoLayout
            InfoLayout.Children.Add(InfoImage,
                Constraint.RelativeToView(InfoText, (parent, sibling) => (sibling.X + sibling.Width + 2)),
                Constraint.RelativeToView(InfoText, (parent, sibling) => (sibling.Y)),
                Constraint.RelativeToParent((parent) => (parent.Width * 0.45)),
                Constraint.RelativeToParent((parent) => parent.Height * 0.7));
            InfoImage.Aspect = Aspect.AspectFit;

            RecentObservationsTitle.FontAttributes = FontAttributes.Bold;


            SetInfo("Lorem Ipsum", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque et interdum ipsum.", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/03/Sympetrum_flaveolum_-_side_%28aka%29.jpg/1920px-Sympetrum_flaveolum_-_side_%28aka%29.jpg");


            // Add items to RecentObservations list
            var recentObservations = new List<ObservationsCell>();

            recentObservations.Add(new ObservationsCell
            {
                Species = "Brun øyenstikker",
                LocationTime = "Trondehim, 30.09.16",
                User = "Odd Cappelen",
                ImageFilename = "dragonfly2.jpg"
            });

            recentObservations.Add(new ObservationsCell
            {
                Species = "Blå øyenstikker",
                LocationTime = "Trondheim, 29.09.16",
                User = "Odd Cappelen",
                ImageFilename = "dragonfly1.jpg"
            });

            recentObservations.Add(new ObservationsCell
            {
                Species = "Gul øyenstikker",
                LocationTime = "Trondheim, 28.09.16",
                User = "Odd Cappelen",
                ImageFilename = ""
            });

            RecentObservationsList.ItemsSource = recentObservations;
        }

        public void FillRecentObservationsList(List<ObservationItem> observations)
        {
            var recentObservations = new List<ObservationsCell>();
            foreach (var observation in observations)
            {
                ObservationsCell cell = new ObservationsCell
                {
                    Species = observation.Species,
                    LocationTime = observation.Location + ", " + observation.Date,
                    User = observation.User,
                    ImageFilename = observation.ImageFilename
                };
                recentObservations.Add(cell);
            }
            RecentObservationsList.ItemsSource = recentObservations;
        }


        public void SetInfo(string title, string text, string imageFilename)
        {
            InfoTitle.Text = title;
            InfoText.Text = text;
            InfoImage.Source = imageFilename;
        }
    }
}
