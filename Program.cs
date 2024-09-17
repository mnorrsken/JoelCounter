using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoelCounter
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            KeyboardHook.Start(); // Start the mouse hook
            Application.Run(new MainForm());
            KeyboardHook.Stop(); // Stop the mouse hook when the application closes
        }
    }

}
