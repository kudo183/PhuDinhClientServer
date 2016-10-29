using System.ComponentModel;

namespace DTO
{
    public partial class TDonHangDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return "TenHienThi";
            }
        }
    }
}
