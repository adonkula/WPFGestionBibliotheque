using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;

namespace Sommatif2GestionBibliotheque
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void ChangeLanguage(string cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureCode);

            // Recharge entièrement l'application
            var main = new MainWindow();
            Application.Current.MainWindow = main;
            main.Show();
        }
    }

}
