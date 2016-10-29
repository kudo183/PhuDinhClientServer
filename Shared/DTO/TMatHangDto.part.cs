using System.ComponentModel;

namespace DTO
{
    public partial class TMatHangDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return TenMatHang;
            }
        }
    }
}
