using System.ComponentModel;

namespace Client
{
    public sealed class Settings : INotifyPropertyChanged
    {
        private static readonly Settings _instance = new Settings();

        public static Settings Instance
        {
            get { return _instance; }
        }

        public void LoadSettings()
        {
            _pageSize = Properties.Settings.Default.PageSize;
            _fontSize = Properties.Settings.Default.FontSize;
            UriRoot = Properties.Settings.Default.UriRoot;
            DefaultMaKhoHang = Properties.Settings.Default.DefaultMaKhoHang;
            DefaultMaKhachHang = Properties.Settings.Default.DefaultMaKhachHang;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.PageSize = _pageSize;
            Properties.Settings.Default.FontSize = _fontSize;
            Properties.Settings.Default.UriRoot = UriRoot;
            Properties.Settings.Default.DefaultMaKhoHang = DefaultMaKhoHang;
            Properties.Settings.Default.DefaultMaKhachHang = DefaultMaKhachHang;

            Properties.Settings.Default.Save();
        }
        
        public string UriRoot { get; set; }
        public int DefaultMaKhoHang { get; set; }
        public int DefaultMaKhachHang { get; set; }

        private int _pageSize = 20;
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if (_pageSize == value)
                    return;

                _pageSize = value;
                OnPropertyChanged("PageSize");
            }
        }

        private double _fontSize = 16;
        public double FontSize
        {
            get { return _fontSize; }
            set
            {
                if (_fontSize == value)
                    return;

                _fontSize = value;
                OnPropertyChanged("FontSize");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
