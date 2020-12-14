namespace Richasy.LocaleString.UWP
{
    public class LocaleConfig
    {
        public string TipFileName { get; private set; }
        public string ControlsFileName { get; private set; }
        public string OtherFileName { get; private set; }
        public string TipPrefix { get; private set; }
        public string ControlsPrefix { get; private set; }
        public string OtherPrefix { get; private set; }
        public LocaleConfig(string tipName,
                            string controlName,
                            string otherName,
                            string tipPrefix,
                            string controlPrefix,
                            string otherPrefix)
        {
            this.TipFileName = tipName;
            this.ControlsFileName = controlName;
            this.OtherFileName = otherName;
            this.TipPrefix = tipPrefix;
            this.ControlsPrefix = controlPrefix;
            this.OtherPrefix = otherPrefix;
        }
        internal LocaleConfig() { }

        public static LocaleConfig Default = new LocaleConfig("Resources.Tip", "Resources.Controls", "Resources.Other",
                                                              "Tip_", "Control_", "Other_");
    }
}
