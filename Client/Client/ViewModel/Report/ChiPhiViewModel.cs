using huypq.wpf.controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.ViewModel.Report
{
    public class ChiPhiViewModel : INotifyPropertyChanged
    {
        public DateRangePickerViewModel DateRangePickerViewModel { get; set; }
    
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
