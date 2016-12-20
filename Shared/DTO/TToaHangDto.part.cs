using System.ComponentModel;

namespace DTO
{
    public partial class TToaHangDto : IDto, INotifyPropertyChanged
    {
        [ProtoBuf.ProtoMember(10)]
        public int ThanhTien { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public RKhachHangDto RKhachHang { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return string.Format("{0} {1}",
                    Ngay.ToString("d"), RKhachHang.TenHienThi);
            }
        }
    }
}
