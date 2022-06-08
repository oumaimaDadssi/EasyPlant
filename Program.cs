using System;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace EasyPlants
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo culture;
            culture = CultureInfo.CreateSpecificCulture("fr-FR");
            System.Globalization.CultureInfo cultureFr =new System.Globalization.CultureInfo("fr-FR");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}