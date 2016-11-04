using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using NbicDragonflies.Data;
using NbicDragonflies.Utility;
using NbicDragonflies.Views;
using NbicDragonflies.Models;
using NbicDragonflies.Resources;
using Xamarin.Forms;
using NavigationPage = NbicDragonflies.Views.Pages.NavigationPage;

namespace NbicDragonflies {

    /// <summary>
    ///  Main class of the Application
    /// </summary>
    public class App : Application {

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.App"/> class.
		/// </summary>
        public App() {
            // The root page of your application
            MasterDetailPage content = new NavigationPage();
            MainPage = content;
        }

		/// <summary>
		/// On start.
		/// </summary>
        protected override void OnStart() {
            // Handle when your app starts
        }

		/// <summary>
		/// On sleep.
		/// </summary>
        protected override void OnSleep() {
            // Handle when your app sleeps
        }

		/// <summary>
		/// On resume.
		/// </summary>
        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
