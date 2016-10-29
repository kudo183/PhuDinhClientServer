using System.ComponentModel;

namespace DTO
{
    public partial class TChuyenKhoDto : IDto, INotifyPropertyChanged
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
