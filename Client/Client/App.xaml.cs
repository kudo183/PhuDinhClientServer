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
#if DEBUG
            ProtobufWebClient.Instance.Token = "CfDJ8P0zsQbbuUlBkhS-elYKeAcGLsOHUE2aXXYcY_ZYlRxDBvuqSenusoyRMKKXunn6953jTk4KeeiSkvgNJ5xRtaJ23J3fMSlP6rqvUo-aAwvBeSIjGyNbkNE1bv4RqMV9dm_Y3eec5SQZ-j-9ckRz-dI";
            StartupUri = new System.Uri("AllView.xaml", System.UriKind.Relative);
#endif
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            Settings.Instance.SaveSettings();
        }
    }
}
