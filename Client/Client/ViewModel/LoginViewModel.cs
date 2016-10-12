using SimpleDataGrid;
using System.ComponentModel;
using System.Net;
using System.Windows;

namespace Client.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _user;
        public string User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged("User");
                    OkCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _pass;
        public string Pass
        {
            get { return _pass; }
            set
            {
                if (_pass != value)
                {
                    _pass = value;
                    OnPropertyChanged("Pass");
                    OkCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _msg;
        public string Msg
        {
            get { return _msg; }
            set
            {
                if (_msg != value)
                {
                    _msg = value;
                    OnPropertyChanged("Msg");
                    OkCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private Window _window;

        public LoginViewModel(Window window)
        {
            _window = window;
            _user = "huy";
            _pass = "nobita";

            OkCommand = new SimpleCommand("OkCommand",
                () => { OkButtonClick(); },
                () =>
                {
                    return (string.IsNullOrEmpty(_user) == false
                    && string.IsNullOrEmpty(_pass) == false);
                }
            );
        }

        void OkButtonClick()
        {
            try
            {
                Msg = "";

                ProtobufWebClient.Instance.Login(User, Pass);
                 
                var w = new MainWindow();
                w.Show();
                _window.Close();
            }
            catch (WebException ex)
            {
                switch (ex.Status)
                {
                    case WebExceptionStatus.ConnectFailure:
                    case WebExceptionStatus.Timeout:
                        Msg = Properties.Resources.LoginWindow_CannotConnect;
                        break;
                    case WebExceptionStatus.ProtocolError:
                        Msg = Properties.Resources.LoginWindow_LoginFailed;
                        break;
                }
            }
        }

        public SimpleCommand OkCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
