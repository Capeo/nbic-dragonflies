﻿namespace NbicDragonflies.Models.Location
{
    public class CountyDataSet
    {
        public string GoogleMercatorBbox { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        //TODO map area dataset with central location coordinates of county
        public Location Location { get; set; }
    }
}