﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace NbicDragonflies.iOS {
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //

		public override bool FinishedLaunching(UIApplication app, NSDictionary options) {

			UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
			{
				TextColor = UIColor.White
			});

			UITabBar.Appearance.BackgroundColor = UIColor.White;
			UITabBar.Appearance.SelectedImageTintColor = UIColor.FromRGB(232, 108, 25);
            global::Xamarin.Forms.Forms.Init();
            global::Xamarin.FormsMaps.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
