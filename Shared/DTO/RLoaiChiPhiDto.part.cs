using System.ComponentModel;

namespace DTO
{
    public partial class RLoaiChiPhiDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return TenLoaiChiPhi;
            }
        }
    }
}
