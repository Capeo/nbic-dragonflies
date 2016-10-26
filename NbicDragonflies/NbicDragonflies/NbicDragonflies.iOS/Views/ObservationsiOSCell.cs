using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;

namespace NbicDragonflies.iOS.Views {
    class ObservationsiOSCell : UITableViewCell
    {
        UILabel topLabel, midFirstLabel, midSecondLabel, bottomLabel;
        UIImageView imageView;

        public ObservationsiOSCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;
            
            ContentView.BackgroundColor = UIColor.FromRGB(255, 255, 255);
            
            imageView = new UIImageView();
            
            topLabel = new UILabel()
            {
                Font = UIFont.FromName("Helvetica", 12f),
                TextColor = UIColor.FromRGB(0, 0, 0),
                BackgroundColor = UIColor.Clear
            };

            midFirstLabel = new UILabel()
            {
                Font = UIFont.FromName("Helvetica", 12f),
                TextColor = UIColor.FromRGB(38, 127, 0),
                BackgroundColor = UIColor.Clear
            };

            midSecondLabel = new UILabel()
            {
                Font = UIFont.FromName("Helvetica", 12f),
                TextColor = UIColor.FromRGB(38, 127, 0),
                BackgroundColor = UIColor.Clear
            };

            bottomLabel = new UILabel()
            {
                Font = UIFont.FromName("Helvetica", 12f),
                TextColor = UIColor.FromRGB(38, 127, 0),
                BackgroundColor = UIColor.Clear
            };

            

            ContentView.Add(topLabel);
            ContentView.Add(midFirstLabel);
            ContentView.Add(midSecondLabel);
            ContentView.Add(bottomLabel);
            ContentView.Add(imageView);
        }

        public void UpdateCell(string firstLine, string secondLine, string thirdLine, string fourthLine, UIImage image)
        {
            topLabel.Text = firstLine;
            midFirstLabel.Text = secondLine;
            midSecondLabel.Text = thirdLine;
            bottomLabel.Text = fourthLine;
            imageView.Image = image;
        }

        public override void LayoutSubviews () {
   			base.LayoutSubviews ();

   			topLabel.Frame = new CoreGraphics.CGRect (5, 4, ContentView.Bounds.Width - 63, 25);
   			midFirstLabel.Frame = new CoreGraphics.CGRect (100, 18, 100, 20);
   			imageView.Frame = new CoreGraphics.CGRect (ContentView.Bounds.Width - 63, 5, 33, 33);
 		}
    }
}
