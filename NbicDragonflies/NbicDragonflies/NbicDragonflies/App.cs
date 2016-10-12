using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NbicDragonflies.Data;
using NbicDragonflies.Utility;
using NbicDragonflies.Views;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies {
    public class App : Application {

        public static ApplicationDataManager ApplicationDataManager { get; private set; }

        public App() {
			RunApplicationDataManager();

            // The root page of your application
            MasterDetailPage content = new Navigation();
            MainPage = content;
        }

		public async void RunApplicationDataManager()
		{
			ApplicationDataManager = new ApplicationDataManager(new RestService());

            var taxons = await ApplicationDataManager.GetTaxonsAsync("Taxon/ScientificName?taxonRank=suborder&higherClassificationID=107");

            System.Diagnostics.Debug.WriteLine("Successfull REST call");
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
