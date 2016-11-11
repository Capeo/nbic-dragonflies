namespace NbicDragonflies.Models.Location {

    /// <summary>
    /// Model class for a user location. Contains latitude and longitude. 
    /// </summary>
    public class Location {

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        /// <summary>
        /// Constructor. Sets latitude and longitude
        /// </summary>
        /// <param name="Latitude"></param>
        /// <param name="Longitude"></param>
        public Location(double Latitude, double Longitude) {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
    }
}
