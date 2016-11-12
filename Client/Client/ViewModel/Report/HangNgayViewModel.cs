using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.ViewModel.Report
{
    public class HangNgayViewModel : INotifyPropertyChanged
    {
        private string msg;

        public string Msg
        {
            get { return msg; }
            set
            {
                if (msg == value)
                    return;

                msg = value;
                OnPropertyChanged();
            }
        }

        private DateTime selectedDate = DateTime.Now;

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                if (selectedDate == value)
                    return;

                selectedDate = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<DTO.Report.DailyReportDto> items = new ObservableCollection<DTO.Report.DailyReportDto>();

        public ObservableCollection<DTO.Report.DailyReportDto> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
