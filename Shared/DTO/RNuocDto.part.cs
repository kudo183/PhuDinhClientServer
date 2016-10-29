using System.ComponentModel;

namespace DTO
{
    public partial class RNuocDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return TenNuoc;
            }
        }
    }
}
