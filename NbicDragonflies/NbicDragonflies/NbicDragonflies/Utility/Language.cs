using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Resources;
using Xamarin.Forms;

namespace NbicDragonflies.Utility {
    class Language
    {

        public enum Languages
        {
            En,
            No
        }

        private static Languages _currentCulture = Languages.No;

        public static Languages CurrentCulture
        {
            get { return _currentCulture; }
            private set { _currentCulture = value; }
        }

        public static Languages SwitchLanguage()
        {
            CultureInfo ci;
            if (CurrentCulture == Languages.En)
            {
                CurrentCulture = Languages.No;
                System.Diagnostics.Debug.WriteLine(CurrentCulture.ToString());
                ci = new CultureInfo(CurrentCulture.ToString());
            }
            else
            {
                CurrentCulture = Languages.En;
                ci = new CultureInfo(CurrentCulture.ToString());
            }
            LanguageResource.Culture = ci;
            return CurrentCulture;
        }

    }
}
