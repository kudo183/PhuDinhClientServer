using System;
using System.ComponentModel;

namespace DTO
{
    public partial class TChuyenHangDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public RNhanVienDto RNhanVien { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return string.Format("{0} {1:hh\\:mm} {2}", Ngay.ToString("d"), Gio ?? new TimeSpan(0, 0, 0, 0), RNhanVien.TenHienThi);
            }
        }
    }
}
