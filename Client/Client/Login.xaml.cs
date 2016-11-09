using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        ViewModel.LoginViewModel vm;
        public Login()
        {
            InitializeComponent();
            vm = new ViewModel.LoginViewModel(this);
            vm.User = "huy";
            passbox.Password = "nobita";
            DataContext = vm;
        }

        private void passbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            vm.Pass = passbox.Password;
        }
    }
}
