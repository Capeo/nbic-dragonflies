﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NbicDragonflies.Views.ListItems {

    // Custom cell class used in Observations list
    public class ObservationsCell : ViewCell {

        public static readonly BindableProperty SpeciesProperty = BindableProperty.Create("Species", typeof(string), typeof(ObservationsCell), "");

        public string Species
        {
            get { return (string) GetValue(SpeciesProperty); }
            set { SetValue(SpeciesProperty, value); }
        }

        public static readonly BindableProperty LocationTimeProperty = BindableProperty.Create("LocationTime", typeof(string), typeof(ObservationsCell), "");

        public string LocationTime
        {
            get { return (string) GetValue(LocationTimeProperty); }
            set { SetValue(LocationTimeProperty, value); }
        }

        public static readonly BindableProperty UserProperty = BindableProperty.Create("User", typeof(string), typeof(ObservationsCell), "");

        public string User
        {
            get { return (string) GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }

        public static readonly BindableProperty ImageFilenameProperty = BindableProperty.Create("ImageFilname", typeof(string), typeof(ObservationsCell), "");

        public string ImageFilename
        {
            get { return (string) GetValue(ImageFilenameProperty); }
            set { SetValue(ImageFilenameProperty, value); }
        }

    }
}