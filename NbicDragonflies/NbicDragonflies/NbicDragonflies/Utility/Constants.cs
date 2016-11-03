﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NbicDragonflies.Utility
{

    public class Constants
    {

        // Colors taken from NBIC webpage
        public static readonly Color NbicBrown = Color.FromHex("4a4846");
        public static readonly Color NbicOrange = Color.FromHex("e86c19");
        public static readonly Color KeyGreen = Color.FromHex("c6f0a8");
        public static readonly Color KeyRed = Color.FromHex("f0a8a8");

		//Page background
		public static readonly Color Background = Color.FromHex("e3e0da");

        // Hierarchy of orders
        public static readonly List<string> TaxonRanks = new List<string> { "kingdom", "phylum", "subphylum", "class", "order", "suborder", "family", "genus", "species" };

        // URL of REST service
        public static readonly string TaxonRestUrl = "http://data.beta.artsdatabanken.no/Api/";
        public static readonly string ObservationRestUrl = "http://pavlov.itea.ntnu.no/artskart/Api/ObservationsPage/";
        public static readonly string SearchRestUrl = "http://data.beta.artsdatabanken.no/Api/search?q=";
        public static readonly string PlaceholderSpeciesContentUrl = "http://data.beta.artsdatabanken.no/api/content/";
        public static readonly string AreaCountyDataRestUrl = "http://artskart2.artsdatabanken.no/Api/area/";
        public static readonly string AreaNameFromLatLong = "https://maps.googleapis.com/maps/api/geocode/json?sensor=false&latlng=";
    }
}
