using System.ComponentModel;

namespace DTO
{
    public partial class SwaUserDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return Email;
            }
        }
    }
}
