using System.ComponentModel;

namespace DTO
{
    public partial class TChiTietChuyenHangDonHangDto : IDto, INotifyPropertyChanged
    {
        [ProtoBuf.ProtoMember(10)]
        public TChuyenHangDonHangDto TChuyenHangDonHang { get; set; }
        [ProtoBuf.ProtoMember(11)]
        public TChiTietDonHangDto TChiTietDonHang { get; set; }

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
