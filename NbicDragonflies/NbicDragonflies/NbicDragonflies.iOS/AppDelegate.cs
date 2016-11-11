using System;
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

			//Set color in navigation bar (hamburger icon and language icon)
			UINavigationBar.Appearance.TintColor = UIColor.White;
			//Set page title color
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
			{
				TextColor = UIColor.White
			});

			//Set background image to enable change of background color
			UITabBar.Appearance.BackgroundImage = new UIImage();
			//Set default iOS background color  
			UITabBar.Appearance.BackgroundColor = UIColor.FromRGB(247, 247, 247);
			//Set Nbic orange color to tab bar icons
			UITabBar.Appearance.SelectedImageTintColor = UIColor.FromRGB(232, 108, 25);

            global::Xamarin.Forms.Forms.Init();
            global::Xamarin.FormsMaps.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
