using System.Windows;
using System.Windows.Controls;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            var button = (e.OriginalSource as Button);
            if (button == null)
            {
                return;
            }

            var viewType = System.Type.GetType("Client.View." + button.Tag);
            if (viewType == null)
            {
                viewType = System.Type.GetType("Client." + button.Tag);
            }
            if (viewType == null)
            {
                viewType = System.Type.GetType("Client.View.Report." + button.Tag);
            }

            var w = new Window()
            {
                Title = button.Content.ToString(),
                WindowState = WindowState.Maximized,
                Content = System.Activator.CreateInstance(viewType)
            };
            w.Show();
        }
    }
}
