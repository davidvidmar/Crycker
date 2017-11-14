using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace Crycker.Settings
{
    public class UserSettings
    {
        private const string SettingsConfig = @"Crycker.config";

        public string Provider { get; set; }
        public string Coin { get; set; }
        public string Currency { get; set; }
        public int RefreshInterval { get; set; }

        [DefaultValue(true)]
        public bool Highlight { get; set; }
        [DefaultValue(true)]
        public bool DarkMode { get; set; }

        [DefaultValue("Segoe UI")]
        public string FontName { get; set; }
        [DefaultValue(false)]
        public bool Log { get; set; }
        [DefaultValue(true)]
        public bool CheckForUpdates { get; set; }

        public UserSettings()
        {
            Provider = "Bitstamp";
            Coin = "BTC";
            Currency = "EUR";
            RefreshInterval = 300;

            Highlight = true;
            DarkMode = true;

            FontName = "Segoe UI";
            Log = false;
        }        

        public static UserSettings Load()
        {
            var settings = new UserSettings();

            if (!File.Exists(SettingsConfig)) return settings;

            var stream = new FileStream(SettingsConfig, FileMode.Open, FileAccess.Read, FileShare.Read);

            var xmlSerializer = new XmlSerializer(typeof(UserSettings));
            settings = (UserSettings)xmlSerializer.Deserialize(stream);
            stream.Close();

            return settings;
        }

        public void Save()
        {
            var xmlSerializer = new XmlSerializer(typeof(UserSettings));
            var stream = new StreamWriter(SettingsConfig);

            xmlSerializer.Serialize(stream, this);
            stream.Close();
        }        
    }
}