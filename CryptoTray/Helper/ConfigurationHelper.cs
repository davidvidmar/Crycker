using CryptoTray.Data;
using System;
using System.IO;
using System.Text.Json;

namespace CryptoTray.Helper
{
    public static class ConfigurationHelper
    {
        public static void SaveConfiguration(this ApiConfiguration settings)
        {
            string jsonPath = Path.Combine(AppContext.BaseDirectory, "api-entries.json");
            string jsonConverted = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonPath, jsonConverted);
        }
    }
}
