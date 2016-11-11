namespace NbicDragonflies.Models.Location
{

    /// <summary>
    /// Model class representing a County. Fetched from API
    /// </summary>
    public class CountyDataSet
    {
        public string GoogleMercatorBbox { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        //TODO map area dataset with center location coordinates of county
        public Location Location { get; set; }
    }
}
