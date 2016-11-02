using System.ComponentModel;

namespace DTO
{
    public partial class TChiTietDonHangDto : IDto, INotifyPropertyChanged
    {
        [ProtoBuf.ProtoMember(10)]
        public TDonHangDto TDonHang { get; set; }

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
