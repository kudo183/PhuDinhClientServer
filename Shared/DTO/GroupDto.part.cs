using System.ComponentModel;

namespace DTO
{
    public partial class GroupDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return TenGroup;
            }
        }
    }
}
