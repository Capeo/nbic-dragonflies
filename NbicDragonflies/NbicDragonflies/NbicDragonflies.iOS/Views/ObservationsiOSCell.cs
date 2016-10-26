﻿using System;
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

			ContentView.BackgroundColor = UIColor.White;
            
            imageView = new UIImageView();

			topLabel = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 18f),
				TextColor = UIColor.Black,
                BackgroundColor = UIColor.Clear
            };

			midFirstLabel = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 12f),
				TextColor = UIColor.Black,
                BackgroundColor = UIColor.Clear
            };

            midSecondLabel = new UILabel()
            {
                Font = UIFont.FromName("Helvetica", 12f),
				TextColor = UIColor.Black,
                BackgroundColor = UIColor.Clear
            };

            bottomLabel = new UILabel()
            {
                Font = UIFont.FromName("Helvetica", 12f),
				TextColor = UIColor.Black,
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

   			topLabel.Frame = new CoreGraphics.CGRect (5, 4, ContentView.Bounds.Width, 20);
			midFirstLabel.Frame = new CoreGraphics.CGRect (5, 20, ContentView.Bounds.Width, 20);
			midSecondLabel.Frame = new CoreGraphics.CGRect(5, 36, ContentView.Bounds.Width, 40);
			bottomLabel.Frame = new CoreGraphics.CGRect(5, 52, ContentView.Bounds.Width, 40);
   			imageView.Frame = new CoreGraphics.CGRect (ContentView.Bounds.Width - 63, 5, ContentView.Bounds.Width, 33);
			Console.WriteLine("Bounds width: " + ContentView.Bounds.Width);
 		}
    }
}
