using System.ComponentModel;

namespace DTO
{
    public partial class RNhaCungCapDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return TenNhaCungCap;
            }
        }
    }
}
