using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            var vm = new ViewModel.LoginViewModel(this);
            DataContext = vm;
        }
    }
}
