using System;
using System.Collections.ObjectModel;


namespace NbicDragonflies.Models
{

    public class KeySuggestion
    {
        public string ImageSource { get; set; }
        public string Text { get; set; }
        public string Detail { get; set; }
        public Type TargetType { get; set; }
    }

}