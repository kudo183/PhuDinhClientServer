using System.ComponentModel;

namespace DTO
{
    public partial class RBaiXeDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return DiaDiemBaiXe;
            }
        }
    }
}
