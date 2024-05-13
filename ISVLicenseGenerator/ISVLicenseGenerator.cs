using System;
using System.Windows.Forms;

namespace ISVLicenseGeneratorCore
{
    static class ISVLicenseGenerator
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ISVLicenseGeneratorForm());
        }
    }
}
