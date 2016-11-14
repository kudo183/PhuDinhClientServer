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
    /// Interaction logic for Xuat.xaml
    /// </summary>
    public partial class Xuat : UserControl
    {
        XuatViewModel vm;
        IReportService reportService = ServiceLocator.Instance.GetInstance<IReportService>();
        NameValueCollection parameters = new NameValueCollection();
        List<DTO.Report.XuatDto> xuats = new List<DTO.Report.XuatDto>();

        public Xuat()
        {
            InitializeComponent();

            vm = new XuatViewModel();
            vm.PropertyChanged += Vm_PropertyChanged;
            parameters.Add("dateFrom", DateToString(vm.DateFrom));
            parameters.Add("dateTo", DateToString(vm.DateTo));

            DataContext = vm;

            Report();
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(XuatViewModel.GroupByIndex))
            {
                CalculateItem();
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
            xuats = reportService.Report<DTO.Report.XuatDto>("xuat", parameters);

            CalculateItem();

            //vm.Msg = string.Format("Tổng số tiền {0:N0}", groupByLoaiChiPhi.Sum(p => p.SoTien));
        }

        private void CalculateItem()
        {
            switch (vm.GroupByIndex)
            {
                case 0://Loai Hang
                    GroupByLoaiHang();
                    break;
                case 1://Mat Hang
                    GroupByMatHang();
                    break;
                case 2://Khach Hang
                    GroupByKhachHang();
                    break;
                case 3://Khong groupby
                    GroupByKhoHang();
                    break;
            }
        }

        private void GroupByLoaiHang()
        {
            var dicLoaiHangs = new Dictionary<int, XuatViewModel.GroupByLoaiHang>();
            foreach (var xuat in xuats)
            {
                foreach (var ctXuat in xuat.ChiTietXuat)
                {
                    XuatViewModel.GroupByLoaiHang item = null;
                    if (dicLoaiHangs.TryGetValue(ctXuat.MaLoaiHang, out item) == false)
                    {
                        item = new XuatViewModel.GroupByLoaiHang()
                        {
                            TenLoaiHang = ctXuat.TenLoaiHang,
                            SoLuong = ctXuat.SoLuong,
                            SoKy = ctXuat.SoKg * ctXuat.SoLuong,
                            Details = new List<XuatViewModel.GroupByMatHang>(),
                            DictionaryDetails = new Dictionary<int, XuatViewModel.GroupByMatHang>()
                        };
                        dicLoaiHangs.Add(ctXuat.MaLoaiHang, item);
                    }
                    else
                    {
                        item.SoLuong = item.SoLuong + ctXuat.SoLuong;
                        item.SoKy = item.SoKy + (ctXuat.SoLuong * ctXuat.SoKg);
                    }

                    XuatViewModel.GroupByMatHang itemMH = null;
                    if (item.DictionaryDetails.TryGetValue(ctXuat.MaMatHang, out itemMH) == false)
                    {
                        itemMH = new XuatViewModel.GroupByMatHang()
                        {
                            TenMatHang = ctXuat.TenMatHang,
                            SoLuong = ctXuat.SoLuong,
                            SoKy = ctXuat.SoKg * ctXuat.SoLuong
                        };
                        item.DictionaryDetails.Add(ctXuat.MaMatHang, itemMH);
                    }
                    else
                    {
                        itemMH.SoLuong = itemMH.SoLuong + ctXuat.SoLuong;
                        itemMH.SoKy = itemMH.SoKy + (ctXuat.SoLuong * ctXuat.SoKg);
                    }
                }
            }
            var t = dicLoaiHangs.Select(p => p.Value).OrderByDescending(p => p.SoKy).ToList();
            foreach (var item in t)
            {
                item.SoKy = item.SoKy / 10;
                var t1 = item.DictionaryDetails.Select(p => p.Value).OrderByDescending(p => p.SoKy).ToList();
                foreach (var item1 in t1)
                {
                    item1.SoKy = item1.SoKy / 10;
                }
                item.Details = t1;
            }
            vm.Items = t;
            vm.Msg = string.Format("Tong so ky {0:N0}", t.Sum(p => p.SoKy));
        }

        private void GroupByMatHang()
        {
            var dicMatHangs = new Dictionary<int, XuatViewModel.GroupByMatHang>();
            foreach (var xuat in xuats)
            {
                foreach (var ctXuat in xuat.ChiTietXuat)
                {
                    XuatViewModel.GroupByMatHang item = null;
                    if (dicMatHangs.TryGetValue(ctXuat.MaMatHang, out item) == false)
                    {
                        item = new XuatViewModel.GroupByMatHang()
                        {
                            TenMatHang = ctXuat.TenMatHang,
                            SoLuong = ctXuat.SoLuong,
                            SoKy = ctXuat.SoKg * ctXuat.SoLuong,
                            Details = new List<XuatViewModel.GroupByKhachHang>(),
                            DictionaryDetails = new Dictionary<int, XuatViewModel.GroupByKhachHang>()
                        };
                        dicMatHangs.Add(ctXuat.MaMatHang, item);
                    }
                    else
                    {
                        item.SoLuong = item.SoLuong + ctXuat.SoLuong;
                        item.SoKy = item.SoKy + (ctXuat.SoLuong * ctXuat.SoKg);
                    }

                    XuatViewModel.GroupByKhachHang itemKH = null;
                    if (item.DictionaryDetails.TryGetValue(xuat.MaKhachHang, out itemKH) == false)
                    {
                        itemKH = new XuatViewModel.GroupByKhachHang()
                        {
                            TenKhachHang = xuat.TenKhachHang,
                            SoLuong = ctXuat.SoLuong,
                            SoKy = ctXuat.SoKg * ctXuat.SoLuong
                        };
                        item.DictionaryDetails.Add(xuat.MaKhachHang, itemKH);
                    }
                    else
                    {
                        itemKH.SoLuong = itemKH.SoLuong + ctXuat.SoLuong;
                        itemKH.SoKy = itemKH.SoKy + (ctXuat.SoLuong * ctXuat.SoKg);
                    }
                }
            }
            var t = dicMatHangs.Select(p => p.Value).OrderByDescending(p => p.SoKy).ToList();
            foreach (var item in t)
            {
                item.SoKy = item.SoKy / 10;
                var t1 = item.DictionaryDetails.Select(p => p.Value).OrderByDescending(p => p.SoKy).ToList();
                foreach (var item1 in t1)
                {
                    item1.SoKy = item1.SoKy / 10;
                }
                item.Details = t1;
            }
            vm.Items = t;
            vm.Msg = string.Format("Tong so ky {0:N0}", t.Sum(p => p.SoKy));
        }

        private void GroupByKhachHang()
        {
            var dicKhachHangs = new Dictionary<int, XuatViewModel.GroupByKhachHang>();
            foreach (var xuat in xuats)
            {
                XuatViewModel.GroupByKhachHang item = null;
                if (dicKhachHangs.TryGetValue(xuat.MaKhachHang, out item) == false)
                {
                    item = new XuatViewModel.GroupByKhachHang()
                    {
                        TenKhachHang = xuat.TenKhachHang,
                        Details = new List<XuatViewModel.GroupByLoaiHang>(),
                        DictionaryDetails = new Dictionary<int, XuatViewModel.GroupByLoaiHang>()
                    };
                    dicKhachHangs.Add(xuat.MaKhachHang, item);
                }
                foreach (var ctXuat in xuat.ChiTietXuat)
                {
                    item.SoLuong = item.SoLuong + ctXuat.SoLuong;
                    item.SoKy = item.SoKy + (ctXuat.SoLuong * ctXuat.SoKg);

                    XuatViewModel.GroupByLoaiHang itemLH = null;
                    if (item.DictionaryDetails.TryGetValue(ctXuat.MaLoaiHang, out itemLH) == false)
                    {
                        itemLH = new XuatViewModel.GroupByLoaiHang()
                        {
                            TenLoaiHang = ctXuat.TenLoaiHang,
                            SoLuong = ctXuat.SoLuong,
                            SoKy = ctXuat.SoKg * ctXuat.SoLuong,
                            Details = new List<XuatViewModel.GroupByMatHang>(),
                            DictionaryDetails = new Dictionary<int, XuatViewModel.GroupByMatHang>()
                        };
                        item.DictionaryDetails.Add(ctXuat.MaLoaiHang, itemLH);
                    }
                    else
                    {
                        itemLH.SoLuong = itemLH.SoLuong + ctXuat.SoLuong;
                        itemLH.SoKy = itemLH.SoKy + (ctXuat.SoLuong * ctXuat.SoKg);
                    }

                    XuatViewModel.GroupByMatHang itemMH = null;
                    if (itemLH.DictionaryDetails.TryGetValue(ctXuat.MaMatHang, out itemMH) == false)
                    {
                        itemMH = new XuatViewModel.GroupByMatHang()
                        {
                            TenMatHang = ctXuat.TenMatHang,
                            SoLuong = ctXuat.SoLuong,
                            SoKy = ctXuat.SoKg * ctXuat.SoLuong
                        };
                        itemLH.DictionaryDetails.Add(ctXuat.MaMatHang, itemMH);
                    }
                    else
                    {
                        itemMH.SoLuong = itemMH.SoLuong + ctXuat.SoLuong;
                        itemMH.SoKy = itemMH.SoKy + (ctXuat.SoLuong * ctXuat.SoKg);
                    }
                }
            }
            var t = dicKhachHangs.Select(p => p.Value).OrderByDescending(p => p.SoKy).ToList();
            foreach (var item in t)
            {
                item.SoKy = item.SoKy / 10;
                var t1 = item.DictionaryDetails.Select(p => p.Value).OrderByDescending(p => p.SoKy).ToList();
                foreach (var item1 in t1)
                {
                    item1.SoKy = item1.SoKy / 10;
                    var t2 = item1.DictionaryDetails.Select(p => p.Value).OrderByDescending(p => p.SoKy).ToList();
                    foreach (var item2 in t2)
                    {
                        item2.SoKy = item2.SoKy / 10;
                    }
                    item1.Details = t2;
                }
                item.Details = t1;
            }
            vm.Items = t;
            vm.Msg = string.Format("Tong so ky {0:N0}", t.Sum(p => p.SoKy));
        }

        private void GroupByKhoHang()
        {
            var dicKhoHangs = new Dictionary<int, XuatViewModel.GroupByKhoHang>();
            foreach (var xuat in xuats)
            {
                XuatViewModel.GroupByKhoHang item = null;
                if (dicKhoHangs.TryGetValue(xuat.MaKho, out item) == false)
                {
                    item = new XuatViewModel.GroupByKhoHang()
                    {
                        TenKhoHang = xuat.TenKho,
                        Details = new List<XuatViewModel.GroupByLoaiHang>(),
                        DictionaryDetails = new Dictionary<int, XuatViewModel.GroupByLoaiHang>()
                    };
                    dicKhoHangs.Add(xuat.MaKho, item);
                }
                foreach (var ctXuat in xuat.ChiTietXuat)
                {
                    item.SoLuong = item.SoLuong + ctXuat.SoLuong;
                    item.SoKy = item.SoKy + (ctXuat.SoLuong * ctXuat.SoKg);

                    XuatViewModel.GroupByLoaiHang itemLH = null;
                    if (item.DictionaryDetails.TryGetValue(ctXuat.MaLoaiHang, out itemLH) == false)
                    {
                        itemLH = new XuatViewModel.GroupByLoaiHang()
                        {
                            TenLoaiHang = ctXuat.TenLoaiHang,
                            SoLuong = ctXuat.SoLuong,
                            SoKy = ctXuat.SoKg * ctXuat.SoLuong,
                            Details = new List<XuatViewModel.GroupByMatHang>(),
                            DictionaryDetails = new Dictionary<int, XuatViewModel.GroupByMatHang>()
                        };
                        item.DictionaryDetails.Add(ctXuat.MaLoaiHang, itemLH);
                    }
                    else
                    {
                        itemLH.SoLuong = itemLH.SoLuong + ctXuat.SoLuong;
                        itemLH.SoKy = itemLH.SoKy + (ctXuat.SoLuong * ctXuat.SoKg);
                    }

                    XuatViewModel.GroupByMatHang itemMH = null;
                    if (itemLH.DictionaryDetails.TryGetValue(ctXuat.MaMatHang, out itemMH) == false)
                    {
                        itemMH = new XuatViewModel.GroupByMatHang()
                        {
                            TenMatHang = ctXuat.TenMatHang,
                            SoLuong = ctXuat.SoLuong,
                            SoKy = ctXuat.SoKg * ctXuat.SoLuong
                        };
                        itemLH.DictionaryDetails.Add(ctXuat.MaMatHang, itemMH);
                    }
                    else
                    {
                        itemMH.SoLuong = itemMH.SoLuong + ctXuat.SoLuong;
                        itemMH.SoKy = itemMH.SoKy + (ctXuat.SoLuong * ctXuat.SoKg);
                    }
                }
            }
            var t = dicKhoHangs.Select(p => p.Value).OrderByDescending(p => p.SoKy).ToList();
            foreach (var item in t)
            {
                item.SoKy = item.SoKy / 10;
                var t1 = item.DictionaryDetails.Select(p => p.Value).OrderByDescending(p => p.SoKy).ToList();
                foreach (var item1 in t1)
                {
                    item1.SoKy = item1.SoKy / 10;
                    var t2 = item1.DictionaryDetails.Select(p => p.Value).OrderByDescending(p => p.SoKy).ToList();
                    foreach (var item2 in t2)
                    {
                        item2.SoKy = item2.SoKy / 10;
                    }
                    item1.Details = t2;
                }
                item.Details = t1;
            }
            vm.Items = t;
            vm.Msg = string.Format("Tong so ky {0:N0}", t.Sum(p => p.SoKy));
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

        private void DataGridExt_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "SoKy" || e.PropertyName == "SoLuong")
            {
                DataGridTextColumn column = e.Column as DataGridTextColumn;
                Binding binding = column.Binding as Binding;
                binding.StringFormat = "N0";
            }
            else if (e.PropertyName == "Details" || e.PropertyName == "DictionaryDetails")
            {
                e.Cancel = true;
            }
        }
    }
}
