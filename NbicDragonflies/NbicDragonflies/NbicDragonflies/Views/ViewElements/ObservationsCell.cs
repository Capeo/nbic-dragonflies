using Xamarin.Forms;

namespace NbicDragonflies.Views.ViewElements {

    /// <summary>
    /// Custom cell class used in ObservationsPage list
    /// </summary>
    public class ObservationsCell : ViewCell {

        /// <summary>
        /// Property for associated taxon
        /// </summary>
        public static readonly BindableProperty TaxonProperty = BindableProperty.Create("TaxonContent", typeof(string), typeof(ObservationsCell), "");

        public string Taxon
        {
            get { return (string) GetValue(TaxonProperty); }
            set { SetValue(TaxonProperty, value); }
        }

        /// <summary>
        /// Property for associated location
        /// </summary>
        public static readonly BindableProperty LocationProperty = BindableProperty.Create("Location", typeof(string), typeof(ObservationsCell), "");

        public string Location
        {
            get { return (string)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }

        /// <summary>
        /// Property for associated date
        /// </summary>
        public static readonly BindableProperty DateProperty = BindableProperty.Create("Date", typeof(string), typeof(ObservationsCell), "");

        public string Date
        {
            get { return (string)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        /// <summary>
        /// Property for associated user.
        /// </summary>
        public static readonly BindableProperty UserProperty = BindableProperty.Create("User", typeof(string), typeof(ObservationsCell), "");

        public string User
        {
            get { return (string) GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }

        /// <summary>
        /// Property for associated image filename
        /// </summary>
        public static readonly BindableProperty ImageFilenameProperty = BindableProperty.Create("ImageFilname", typeof(string), typeof(ObservationsCell), "");

        public string ImageFilename
        {
            get { return (string) GetValue(ImageFilenameProperty); }
            set { SetValue(ImageFilenameProperty, value); }
        }

    }
}
