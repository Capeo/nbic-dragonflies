using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using NbicDragonflies.Views.ListItems;
using Xamarin.Forms;
using NbicDragonflies.Data;

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
            FillRecentObservationsList();            
        }

        public async void FillRecentObservationsList()
        {
            //FIXME: refine url to filter nearest observations
            ApplicationDataManager applicationDataManager = new ApplicationDataManager(new RestService());
            Models.ObservationList recentObservationsList = await applicationDataManager.GetObservationListAsync("list");
            var recentObservationsCells = new List<ObservationsCell>();
            foreach (Models.Observation observation in recentObservationsList.Observations)
            {
                ObservationsCell cell = new ObservationsCell
                {
                    Species = observation.Name,
                    LocationTime = observation.GetLocationText() + ", " + observation.CollctedDate,
                    User = observation.Collector,
                    ImageFilename = "hamburger.png" //TODO
                };
                recentObservationsCells.Add(cell);
            }
            RecentObservationsList.ItemsSource = recentObservationsCells;
        }


        public void SetInfo(string title, string text, string imageFilename)
        {
            InfoTitle.Text = title;
            InfoText.Text = text;
            InfoImage.Source = imageFilename;
        }
    }
}
