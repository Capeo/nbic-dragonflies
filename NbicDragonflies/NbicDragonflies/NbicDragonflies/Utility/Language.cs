using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Resources;
using Xamarin.Forms;

namespace NbicDragonflies.Utility
{

    /// <summary>
    /// Utility class for handling language
    /// </summary>
    public class Language
    {

        /// <summary>
        /// Enum for currently supported languages
        /// </summary>
        public enum Languages
        {
            /// <summary>
            /// English language
            /// </summary>
            En,

            /// <summary>
            /// Norwegian Bokmål language
            /// </summary>
            No
        }

        /// <summary>
        /// Field for the current language. Default norwegian
        /// </summary>
        public static Languages CurrentLanguage { get; private set; } = Languages.No;

        /// <summary>
        /// Switches the langauge
        /// </summary>
        /// <returns>The new language</returns>
        public static Languages SwitchLanguage()
        {
            CultureInfo cultureInfo;
            if (CurrentLanguage == Languages.En)
            {
                CurrentLanguage = Languages.No;
                System.Diagnostics.Debug.WriteLine(CurrentLanguage.ToString());
                cultureInfo = new CultureInfo(CurrentLanguage.ToString());
            }
            else
            {
                CurrentLanguage = Languages.En;
                System.Diagnostics.Debug.WriteLine(CurrentLanguage.ToString());
                cultureInfo = new CultureInfo(CurrentLanguage.ToString());
            }
            LanguageResource.Culture = cultureInfo;
            return CurrentLanguage;
        }

        /// <summary>
        /// Compares a given string representation of language with the current language
        /// </summary>
        /// <param name="language">String representation of a language</param>
        /// <returns>True if the current language matches the given parameter, else false</returns>
        public static bool CompareToCurrent(string language)
        {
            // TODO Add test for english. Add more tests if necessary

            if (language == "nb-NO" && CurrentLanguage == Languages.No)
            {
                return true;
            }
            return false;
        }

    }
}
