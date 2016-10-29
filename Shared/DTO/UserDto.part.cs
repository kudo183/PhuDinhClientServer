using System.ComponentModel;

namespace DTO
{
    public partial class UserDto : IDto, INotifyPropertyChanged
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
