using System.ComponentModel;

namespace DTO
{
    public partial class RKhoHangDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return TenKho;
            }
        }
    }
}
