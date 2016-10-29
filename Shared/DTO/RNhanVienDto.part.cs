using System.ComponentModel;

namespace DTO
{
    public partial class RNhanVienDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return TenNhanVien;
            }
        }
    }
}
