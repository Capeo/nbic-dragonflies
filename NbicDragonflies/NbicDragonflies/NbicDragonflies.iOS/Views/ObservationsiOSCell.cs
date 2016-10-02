using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;

namespace NbicDragonflies.iOS.Views {
    class ObservationsiOSCell : UITableViewCell
    {
        UILabel topLabel, midLabel, bottomLabel;
        UIImageView imageView;

        public ObservationsiOSCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;
            
            ContentView.BackgroundColor = UIColor.FromRGB(255, 255, 224);
            
            imageView = new UIImageView();
            
            topLabel = new UILabel()
            {
                Font = UIFont.FromName("Cochin-BoldItalic", 22f),
                TextColor = UIColor.FromRGB(127, 51, 0),
                BackgroundColor = UIColor.Clear
            };

            midLabel = new UILabel()
            {
                Font = UIFont.FromName("AmericanTypewriter", 12f),
                TextColor = UIColor.FromRGB(38, 127, 0),
                TextAlignment = UITextAlignment.Center,
                BackgroundColor = UIColor.Clear
            };

            bottomLabel = new UILabel()
            {
                Font = UIFont.FromName("AmericanTypewriter", 12f),
                TextColor = UIColor.FromRGB(38, 127, 0),
                TextAlignment = UITextAlignment.Center,
                BackgroundColor = UIColor.Clear
            };

            ContentView.Add(topLabel);
            ContentView.Add(midLabel);
            ContentView.Add(bottomLabel);
            ContentView.Add(imageView);
        }

        public void UpdateCell(string firstLine, string secondLine, string thirdLine, UIImage image)
        {
            topLabel.Text = firstLine;
            midLabel.Text = secondLine;
            bottomLabel.Text = thirdLine;
            imageView.Image = image;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

        }
    }
}
