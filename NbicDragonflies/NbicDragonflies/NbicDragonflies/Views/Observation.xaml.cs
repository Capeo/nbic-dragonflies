using NbicDragonflies.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;


/*
 var navigationPage = new NavigationPage (new SchedulePageCS ());
    navigationPage.Icon = "schedule.png";
    navigationPage.Title = "Schedule";

    Children.Add (new TodayPageCS ());
    Children.Add (navigationPage);
     */

namespace NbicDragonflies.Views
{
    public partial class Observation : TabbedPage
    {
        public Observation()
        {
            var observationListPage 
            InitializeComponent();
            ObservableCollection<ObservationListItem> observationsList = new ObservableCollection<ObservationListItem>();

            observationsList.Add(new ObservationListItem
            {
                Id = 1234,
                ObservedOn = "2012-04-10",
                PlaceGuess = "Trondheim, Sor-Trondelag",
                UserLogin = "thedragonslayer",
                SpeciesGuess = "DragonFly"
            });

            observationsList.Add(new ObservationListItem
            {
                Id = 1235,
                ObservedOn = "2016-04-10",
                PlaceGuess = "Bergen, Hordland",
                UserLogin = "theotherdragonslayer",
                SpeciesGuess = "DamselFly"
            });

            ObservationList.ItemsSource = observationsList;
        }
    }
}
