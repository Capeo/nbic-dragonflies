namespace NbicDragonflies.Models.IdentificationKey 
{

    public enum OptionStatus
    {
        Selected,
        Disabled,
        Enabled
    }

    public class IdentifyOption
    {
        public string Image { get; set; }
        public string Text { get; set; }
        public OptionStatus Status { get; set; }

        public IdentifyOption(string text, string image)
        {
            Text = text;
            Image = image;
            Status = OptionStatus.Enabled;
        }
    }

}