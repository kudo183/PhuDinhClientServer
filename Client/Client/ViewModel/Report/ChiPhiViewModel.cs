using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.ViewModel.Report
{
    public class ChiPhiViewModel : INotifyPropertyChanged
    {
        public ChiPhiViewModel()
        {
            var year = DateTime.Now.Year;
            Nams = new List<int>() { year, year - 1, year - 2, year - 3, year - 4, year - 5 };
        }

        public List<int> Nams { get; set; }

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

        private DateTime dateFrom = DateTime.Now;

        public DateTime DateFrom
        {
            get { return dateFrom; }
            set
            {
                if (dateFrom == value)
                    return;

                dateFrom = value;
                OnPropertyChanged();
            }
        }

        private DateTime dateTo = DateTime.Now;

        public DateTime DateTo
        {
            get { return dateTo; }
            set
            {
                if (dateTo == value)
                    return;

                dateTo = value;
                OnPropertyChanged();
            }
        }

        private DTO.Report.ChiPhiReportDto selectedItem;

        public DTO.Report.ChiPhiReportDto SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem == value)
                    return;

                selectedItem = value;
                OnPropertyChanged();
            }
        }


        private List<DTO.Report.ChiPhiReportDto> groupByLoaiChiPhiItems = new List<DTO.Report.ChiPhiReportDto>();

        public List<DTO.Report.ChiPhiReportDto> GroupByLoaiChiPhiItems
        {
            get { return groupByLoaiChiPhiItems; }
            set
            {
                groupByLoaiChiPhiItems = value;
                OnPropertyChanged();
            }
        }

        private List<DTO.Report.ChiPhiReportDto> detailItems = new List<DTO.Report.ChiPhiReportDto>();

        public List<DTO.Report.ChiPhiReportDto> DetailItems
        {
            get { return detailItems; }
            set
            {
                detailItems = value;
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
