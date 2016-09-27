using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Startup += App_Startup;
            Exit += App_Exit;
            //System.Threading.Thread.CurrentThread.CurrentUICulture =
            //new System.Globalization.CultureInfo("vi-vn");
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            Settings.Instance.LoadSettings();

        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            Settings.Instance.SaveSettings();
        }
    }
}
