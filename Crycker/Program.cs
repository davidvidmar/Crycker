using Crycker.Helper;
using System;
using System.Windows.Forms;

namespace Crycker
{
    static class Program
    {                
        [STAThread]
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                if (arg.ToLower() == "/log")
                    Logger.Enabled = true;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new App());
        }
    }
}