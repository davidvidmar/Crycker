using System;

namespace Cricker.Helper
{
    class Logger
    {
        public static void Error(string text)
        {
            if (!String.IsNullOrWhiteSpace(text))
                System.Diagnostics.Debug.WriteLine($"[ERROR] {DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss")} {text}");
        }

        public static void Error(Exception ex)
        {
            if (ex != null)
                System.Diagnostics.Debug.WriteLine($"[ERROR] {DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss")} {ex.Message}");            
        }

        public static void Info(string text)
        {
            if (!String.IsNullOrWhiteSpace(text))
                System.Diagnostics.Debug.WriteLine($"[INFO]  {DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss")} {text}");
        }
    }
}