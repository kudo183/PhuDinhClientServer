using System.ComponentModel;

namespace DTO
{
    public partial class TChuyenHangDonHangDto : IDto, INotifyPropertyChanged
    {
        [ProtoBuf.ProtoMember(10)]
        public TChuyenHangDto TChuyenHang { get; set; }
        [ProtoBuf.ProtoMember(11)]
        public TDonHangDto TDonHang { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return string.Format("{0} {1}", TChuyenHang.TenHienThi, TDonHang.TenHienThi);
            }
        }
    }
}
