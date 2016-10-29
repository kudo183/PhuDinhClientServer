using System.ComponentModel;

namespace DTO
{
    public partial class RKhachHangDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return TenKhachHang;
            }
        }
    }
}
