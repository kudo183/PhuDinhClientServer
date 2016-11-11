﻿using Client.Abstraction;
using Client.ViewModel.Report;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Client.View.Report
{
    /// <summary>
    /// Interaction logic for HangNgay.xaml
    /// </summary>
    public partial class HangNgay : UserControl
    {
        HangNgayViewModel vm;
        IReportService reportService = ServiceLocator.Instance.GetInstance<IReportService>();
        NameValueCollection parameters = new NameValueCollection();

        public HangNgay()
        {
            InitializeComponent();

            vm = new HangNgayViewModel();
            vm.PropertyChanged += Vm_PropertyChanged;
            parameters.Add("date", DateToString(vm.SelectedDate));

            DataContext = vm;

            Report();
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(HangNgayViewModel.SelectedDate))
            {
                Report();
            }
        }

        private string DateToString(System.DateTime date)
        {
            return string.Format("{0}{1}{2:00}", date.Year, date.Month, date.Day);
        }

        private void Button_OkClick(object sender, RoutedEventArgs e)
        {
            Report();
        }

        private void Report()
        {
            parameters["date"] = DateToString(vm.SelectedDate);
            vm.Items = new ObservableCollection<DTO.Report.DailyReportDto>(
                reportService.Report<DTO.Report.DailyReportDto>("daily", parameters));

            vm.Msg = string.Format("{0:N0} kg  {1:N0} cuộn", vm.Items.Sum(p => p.SoKg * p.SoLuong) / 10, vm.Items.Sum(p => p.SoLuong));
        }

        private void Button_CopyClick(object sender, RoutedEventArgs e)
        {
            var builder = new StringBuilder();

            builder.AppendLine(string.Format("\t{0:dd/MM/yyyy}", vm.SelectedDate.Date));
            builder.AppendLine("");

            foreach (var row in vm.Items)
            {
                if (row.TenMatHang == null)
                {
                    builder.AppendLine("");
                    continue;
                }

                builder.Append("\t");
                builder.Append(row.TenKhachHang);
                builder.Append("\t");
                builder.Append(row.SoLuong);
                builder.Append("\t");
                builder.Append("\t");
                builder.Append(row.TenMatHang);

                builder.AppendLine("");
            }

            Clipboard.SetText(builder.ToString());
        }
    }
}
