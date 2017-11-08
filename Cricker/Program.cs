using System;
using System.Windows.Forms;

namespace Cricker
{
    static class Program
    {                
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new App());
        }
    }
}
