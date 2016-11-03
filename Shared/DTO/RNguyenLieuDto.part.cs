using System.ComponentModel;

namespace DTO
{
    public partial class RNguyenLieuDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public RLoaiNguyenLieuDto RLoaiNguyenLieu { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return string.Format("{0} {1}", RLoaiNguyenLieu.TenHienThi, DuongKinh);
            }
        }
    }
}
