using System.ComponentModel;

namespace DTO
{
    public partial class RChanhDto : IDto, INotifyPropertyChanged
    {
        [ProtoBuf.ProtoMember(10)]
        public RBaiXeDto RBaiXe { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return string.Format("{0} - {1}", TenChanh, RBaiXe.DiaDiemBaiXe);
            }
        }
    }
}
