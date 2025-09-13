using TastyEats.Data;
using TastyEats.Views;
using System;
using System.Windows.Forms;

namespace TastyEats
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enable DPI awareness explicitly to fix scaling issues on high DPI displays
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Seed the database
            DatabaseSeeder.Seed();

            // Start the app
            Application.Run(new HomeForm());
        }
    }
}
