using Client.Abstraction;
using Client.ViewModel.Report;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Client.View.Report
{
    /// <summary>
    /// Interaction logic for ChiPhi.xaml
    /// </summary>
    public partial class ChiPhi : UserControl
    {
        ChiPhiViewModel vm;
        IReportService reportService = ServiceLocator.Instance.GetInstance<IReportService>();
        NameValueCollection parameters = new NameValueCollection();
        List<DTO.Report.ChiPhiReportDto> chiPhis = new List<DTO.Report.ChiPhiReportDto>();

        public ChiPhi()
        {
            InitializeComponent();

            vm = new ChiPhiViewModel();
            vm.PropertyChanged += Vm_PropertyChanged;
            parameters.Add("dateFrom", DateToString(vm.DateFrom));
            parameters.Add("dateTo", DateToString(vm.DateTo));

            DataContext = vm;

            Report();
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ChiPhiViewModel.SelectedItem))
            {
                if (vm.SelectedItem != null)
                {
                    vm.DetailItems = chiPhis.Where(p => p.MaLoaiChiPhi == vm.SelectedItem.MaLoaiChiPhi).ToList();
                }
                else
                {
                    vm.DetailItems = new List<DTO.Report.ChiPhiReportDto>();
                }
            }
        }

        private void Button_OkClick(object sender, RoutedEventArgs e)
        {
            Report();
        }

        private void Report()
        {
            parameters["dateFrom"] = DateToString(vm.DateFrom);
            parameters["dateTo"] = DateToString(vm.DateTo);
            chiPhis = reportService.Report<DTO.Report.ChiPhiReportDto>("chiphi", parameters);

            var groupByLoaiChiPhi = new List<DTO.Report.ChiPhiReportDto>();
            foreach (var item in chiPhis.GroupBy(p => p.MaLoaiChiPhi))
            {
                var tenLoaiChiPhi = item.First().TenLoaiChiPhi;
                var soTien = item.Sum(p => p.SoTien);
                groupByLoaiChiPhi.Add(new DTO.Report.ChiPhiReportDto()
                {
                    MaLoaiChiPhi = item.Key,
                    TenLoaiChiPhi = tenLoaiChiPhi,
                    SoTien = soTien,
                });
            }

            vm.GroupByLoaiChiPhiItems = groupByLoaiChiPhi;

            vm.Msg = string.Format("Tổng số tiền {0:N0}", groupByLoaiChiPhi.Sum(p => p.SoTien));
        }

        private string DateToString(DateTime date)
        {
            return string.Format("{0:0000}{1:00}{2:00}", date.Year, date.Month, date.Day);
        }

        private void DatePicker_CalendarOpened(object sender, RoutedEventArgs e)
        {
            var datepicker = sender as DatePicker;
            if (datepicker != null)
            {
                var popup = datepicker.Template.FindName(
                    "PART_Popup", datepicker) as Popup;
                if (popup != null && popup.Child is Calendar)
                {
                    ((Calendar)popup.Child).DisplayMode = CalendarMode.Year;
                }
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var datepicker = sender as DatePicker;
            if (datepicker == null || datepicker.SelectedDate == null)
                return;

            var date = datepicker.SelectedDate.Value;

            vm.DateFrom = new DateTime(date.Year, date.Month, 1);

            var temp = vm.DateFrom.AddMonths(1).Subtract(new TimeSpan(1, 0, 0, 0));

            vm.DateTo = new DateTime(date.Year, date.Month, temp.Day);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox == null || comboBox.SelectedItem == null)
                return;

            var year = (int)comboBox.SelectedItem;
            vm.DateFrom = new DateTime(year, 1, 1);
            vm.DateTo = new DateTime(year, 12, 31);
        }
    }
}
