namespace NbicDragonflies.Models.IdentificationKey 
{

    /// <summary>
    /// Enum containing the different possible states of an option
    /// </summary>
    public enum OptionStatus
    {
        /// <summary>
        /// Option is the selected alternative
        /// </summary>
        Selected,

        /// <summary>
        /// Option is disabled from selection
        /// </summary>
        Disabled,

        /// <summary>
        /// Option is enabled, but not selected
        /// </summary>
        Enabled
    }

    /// <summary>
    /// Model class representing an option for a question in the identification key
    /// </summary>
    public class IdentifyOption
    {
        /// <summary>
        /// Path to image associated with the option
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Text associated with the option
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Status of the option
        /// </summary>
        public OptionStatus Status { get; set; }

        /// <summary>
        /// Constructor. Sets text and image from parameters, and sets status to Enabled
        /// </summary>
        /// <param name="text">Text of option</param>
        /// <param name="image">Path to option image</param>
        public IdentifyOption(string text, string image)
        {
            Text = text;
            Image = image;
            Status = OptionStatus.Enabled;
        }
    }

}