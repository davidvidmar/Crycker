using System;
using System.IO;

namespace Cricker.Helper
{
    public static class Logger
    {
        private static string logfile = "cryker-log.txt";

        public static bool Enabled { get; set; }

        public static void Error(string message)
        {
            Log("ERROR", message);
        }

        public static void Error(string message, params object[] args)
        {
            Error(string.Format(message, args));
        }

        public static void Error(string message, Exception ex)
        {
            Error($"{message} - {ex.Message}");
        }

        public static void Warning(string message)
        {
            Log("WARN", message);
        }

        public static void Warning(string message, params object[] args)
        {
            Error(string.Format(message, args));
        }

        public static void Warning(string message, Exception ex)
        {
            Error($"{message} - {ex.Message}");
        }

        public static void Info(string message)
        {            
            Log("INFO", message);
        }

        public static void Info(string message, params object[] args)
        {
            Error(string.Format(message, args));
        }

        public static void Info(string message, Exception ex)
        {
            Error($"{message} - {ex.Message}");
        }

        public static void Log(string level, string message)
        {
            var logText = $"{DateTime.Now.ToString("yyyy-mm-hh HH:mm:ss")} [{level}] {message}";

            System.Diagnostics.Debug.WriteLine(logText);

            if (Enabled) 
                File.AppendAllText(logfile, logText + Environment.NewLine);
        }
    }
}