using Client.Abstraction;
using Client.ViewModel.Report;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            vm.DateRangePickerViewModel = new huypq.wpf.controls.DateRangePickerViewModel();

            vm.PropertyChanged += Vm_PropertyChanged;

            DataContext = vm;

            parameters.Add("dateFrom", DateToString(vm.DateRangePickerViewModel.DateFrom));
            parameters.Add("dateTo", DateToString(vm.DateRangePickerViewModel.DateTo));

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
            parameters["dateFrom"] = DateToString(vm.DateRangePickerViewModel.DateFrom);
            parameters["dateTo"] = DateToString(vm.DateRangePickerViewModel.DateTo);
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
    }
}
