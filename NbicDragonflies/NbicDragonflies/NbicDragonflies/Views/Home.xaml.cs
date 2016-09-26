using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {
    public partial class Home : ContentPage {

        public Home()
        {
            InitializeComponent();

            AbsoluteLayout.SetLayoutBounds(SearchBar, new Rectangle(.5, 0, -1, -1));
            AbsoluteLayout.SetLayoutFlags(SearchBar, AbsoluteLayoutFlags.PositionProportional);
            SearchLayout.Children.Add(SearchBar);

            InfoTitle.Text = "Lorem Ipsum";
            InfoTitle.FontAttributes = FontAttributes.Bold;
            InfoText.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque et interdum ipsum.";
            InfoImage.Source =
                "https://upload.wikimedia.org/wikipedia/commons/thumb/0/03/Sympetrum_flaveolum_-_side_%28aka%29.jpg/1920px-Sympetrum_flaveolum_-_side_%28aka%29.jpg";
            InfoImage.Aspect = Aspect.AspectFit;

            InfoLayout.Children.Add(InfoTitle,
                Constraint.RelativeToParent((parent) => parent.X),
                Constraint.RelativeToParent((parent) => parent.Y),
                Constraint.RelativeToParent((parent) => parent.Width*0.5),
                Constraint.RelativeToParent((parent) => parent.Height*0.2));

            InfoLayout.Children.Add(InfoText,
                Constraint.RelativeToView(InfoTitle, (parent, sibling) => sibling.X),
                Constraint.RelativeToView(InfoTitle, (parent, sibling) => (sibling.Y + sibling.Height + 4)),
                Constraint.RelativeToParent((parent) => parent.Width * 0.5),
                Constraint.RelativeToParent((parent) => parent.Height * 0.8)
                );

            InfoLayout.Children.Add(InfoImage,
                Constraint.RelativeToView(InfoText, (parent, sibling) => (sibling.X + sibling.Width + 2)),
                Constraint.RelativeToView(InfoText, (parent, sibling) => (sibling.Y)),
                Constraint.RelativeToParent((parent) => (parent.Width * 0.45)),
                Constraint.RelativeToParent((parent) => parent.Height * 0.7));

            RecentObservationsTitle.FontAttributes = FontAttributes.Bold;
        }
    }
}
