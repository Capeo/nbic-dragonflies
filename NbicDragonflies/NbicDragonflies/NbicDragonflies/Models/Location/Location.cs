namespace NbicDragonflies.Models.Location {

    public class Location {

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location(double Latitude, double Longitude) {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
    }
}
