using System.ComponentModel;

namespace DTO
{
    public partial class TChuyenKhoDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public RKhoHangDto RKhoHangNhap { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public RKhoHangDto RKhoHangXuat { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return string.Format("{0} {1} {2}",
                    Ngay.ToString("d"), RKhoHangXuat.TenHienThi, RKhoHangNhap.TenHienThi);
            }
        }
    }
}
