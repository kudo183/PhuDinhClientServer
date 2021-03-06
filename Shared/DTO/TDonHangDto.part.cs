﻿using System.ComponentModel;

namespace DTO
{
    public partial class TDonHangDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public RKhoHangDto RKhoHang { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public RKhachHangDto RKhachHang { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return string.Format("{0} {1} {2}",
                    Ngay.ToString("d"), RKhoHang.TenHienThi, RKhachHang.TenHienThi);
            }
        }
    }
}
