using SimpleDataGrid;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Client.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set
            {
                if (_isLoggedIn != value)
                {
                    _isLoggedIn = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _user;
        public string User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged();
                    LoginCommand.RaiseCanExecuteChanged();
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
                    OnPropertyChanged();
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string selectedGroup;

        public string SelectedGroup
        {
            get { return selectedGroup; }
            set
            {
                selectedGroup = value;
                OnPropertyChanged();
                OkCommand.RaiseCanExecuteChanged();
            }
        }

        private string[] groupList;

        public string[] GroupList
        {
            get { return groupList; }
            set
            {
                groupList = value;
                OnPropertyChanged();

                if (groupList.Length > 0)
                {
                    SelectedGroup = groupList[0];
                    GroupListEnabled = true;
                }
                else
                {
                    GroupListEnabled = false;
                }
            }
        }

        private bool groupListEnabled;

        public bool GroupListEnabled
        {
            get { return groupListEnabled; }
            set
            {
                groupListEnabled = value;
                OnPropertyChanged();
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
                    OnPropertyChanged();
                }
            }
        }

        private Window _window;

        public LoginViewModel(Window window)
        {
            _window = window;

            LoginCommand = new SimpleCommand("LoginCommand",
                () => { LoginButtonClick(); },
                () =>
                {
                    return (string.IsNullOrEmpty(_user) == false
                    && string.IsNullOrEmpty(_pass) == false);
                }
            );

            OkCommand = new SimpleCommand("OkCommand",
                () => { OkButtonClick(); },
                () =>
                {
                    return (string.IsNullOrEmpty(SelectedGroup) == false);
                }
            );
        }

        void OkButtonClick()
        {
            try
            {
                Msg = "";
                ProtobufWebClient.Instance.AccessToken(SelectedGroup);

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
                        Msg = TextManager.LoginWindow_CannotConnect;
                        break;
                }
            }
        }

        void LoginButtonClick()
        {
            try
            {
                Msg = "";

                ProtobufWebClient.Instance.Login(User, Pass);
                
                GroupList = ProtobufWebClient.Instance.GetGroups(User);

                IsLoggedIn = true;
            }
            catch (WebException ex)
            {
                switch (ex.Status)
                {
                    case WebExceptionStatus.ConnectFailure:
                    case WebExceptionStatus.Timeout:
                        Msg = TextManager.LoginWindow_CannotConnect;
                        break;
                    case WebExceptionStatus.ProtocolError:
                        Msg = TextManager.LoginWindow_LoginFailed;
                        break;
                }
            }
        }

        public SimpleCommand OkCommand { get; private set; }

        public SimpleCommand LoginCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
