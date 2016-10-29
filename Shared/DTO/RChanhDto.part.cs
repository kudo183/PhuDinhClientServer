using System.ComponentModel;

namespace DTO
{
    public partial class RChanhDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return TenChanh;
            }
        }
    }
}
