using Client.Abstraction;
using Client.ViewModel.Report;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace Client.View.Report
{
    /// <summary>
    /// Interaction logic for KhachHang.xaml
    /// </summary>
    public partial class KhachHang : UserControl
    {
        KhachHangViewModel vm;
        IReportService reportService = ServiceLocator.Instance.GetInstance<IReportService>();
        NameValueCollection parameters = new NameValueCollection();
        List<DTO.Report.KhachHangDto> khachHangs = new List<DTO.Report.KhachHangDto>();

        public KhachHang()
        {
            InitializeComponent();

            vm = new KhachHangViewModel();
            vm.DateRangePickerViewModel = new huypq.wpf.controls.DateRangePickerViewModel();
            vm.KhachHangs = ReferenceDataManager<DTO.RKhachHangDto>.Instance.GetList(true);
            DataContext = vm;
        }

        private void Button_OkClick(object sender, RoutedEventArgs e)
        {
            Report();
        }

        private void Report()
        {
            parameters["dateFrom"] = DateToString(vm.DateRangePickerViewModel.DateFrom);
            parameters["dateTo"] = DateToString(vm.DateRangePickerViewModel.DateTo);
            parameters["maKhachHang"] = vm.KhachHangs[vm.KhachHangIndex].ID.ToString();
            khachHangs = reportService.Report<DTO.Report.KhachHangDto>("khachhang", parameters);

            var result = new List<KhachHangViewModel.RowData>();
            var dictionaryGroupByMaMatHang = new Dictionary<int, KhachHangViewModel.RowData>();

            foreach (var kh in khachHangs)
            {
                var isFirst = true;
                foreach (var ct in kh.ChiTiet)
                {
                    if (isFirst == true)
                    {
                        result.Add(new KhachHangViewModel.RowData()
                        {
                            Ngay = kh.Ngay.ToShortDateString(),
                            TenKho = kh.TenKho,
                            TenMatHang = ct.TenMatHang,
                            SoLuong = ct.SoLuong
                        });
                        isFirst = false;
                    }
                    else
                    {
                        result.Add(new KhachHangViewModel.RowData()
                        {
                            Ngay = "",
                            TenKho = "",
                            TenMatHang = ct.TenMatHang,
                            SoLuong = ct.SoLuong
                        });
                    }

                    KhachHangViewModel.RowData r;
                    if (dictionaryGroupByMaMatHang.TryGetValue(ct.MaMatHang, out r) == false)
                    {
                        r = new KhachHangViewModel.RowData()
                        {
                            Ngay = "",
                            TenKho = "",
                            TenMatHang = ct.TenMatHang,
                            SoLuong = 0
                        };
                        dictionaryGroupByMaMatHang.Add(ct.MaMatHang, r);
                    }
                    r.SoLuong = r.SoLuong + ct.SoLuong;
                }
                result.Add(new KhachHangViewModel.RowData());
            }

            foreach (var item in dictionaryGroupByMaMatHang)
            {
                result.Add(item.Value);
            }
            vm.Items = result;
            vm.Msg = string.Format("");
        }

        private string DateToString(DateTime date)
        {
            return string.Format("{0:0000}{1:00}{2:00}", date.Year, date.Month, date.Day);
        }
    }
}
