using System.ComponentModel;

namespace DTO
{
    public partial class TChiTietDonHangDto : IDto, INotifyPropertyChanged
    {
        [ProtoBuf.ProtoMember(10)]
        public TDonHangDto TDonHang { get; set; }
        [ProtoBuf.ProtoMember(11)]
        public TMatHangDto TMatHang { get; set; }
        [ProtoBuf.ProtoMember(12)]
        public int SoLuongConLai { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return string.Format("{0} {1}", TDonHang.TenHienThi, TMatHang.TenHienThi);
            }
        }
    }
}
