using System.ComponentModel;

namespace DTO
{
    public partial class RLoaiNguyenLieuDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return TenLoai;
            }
        }
    }
}
