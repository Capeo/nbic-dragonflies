using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NbicDragonflies.Data;
using NbicDragonflies.Utility;
using NbicDragonflies.Views;
using Xamarin.Forms;

namespace NbicDragonflies {
    public class App : Application {

        public static ApplicationDataManager ApplicationManager { get; private set; }

        public App() {
            System.Diagnostics.Debug.WriteLine("2");
            ApplicationManager = new ApplicationDataManager(new RestService ());
            System.Diagnostics.Debug.WriteLine("3");
            ApplicationManager.GetTasksAsync();

            // The root page of your application
            MasterDetailPage content = new Navigation();

            MainPage = content;
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
