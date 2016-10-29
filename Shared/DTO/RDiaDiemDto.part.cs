using System.ComponentModel;

namespace DTO
{
    public partial class RDiaDiemDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return Tinh;
            }
        }
    }
}
