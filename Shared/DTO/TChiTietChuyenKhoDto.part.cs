using System.ComponentModel;

namespace DTO
{
    public partial class TChiTietChuyenKhoDto : IDto, INotifyPropertyChanged
    {
        [ProtoBuf.ProtoMember(10)]
        public TChuyenKhoDto TChuyenKho { get; set; }
        [ProtoBuf.ProtoMember(11)]
        public TMatHangDto TMatHang { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return string.Format("{0} {1}", TChuyenKho.TenHienThi, TMatHang.TenHienThi);
            }
        }
    }
}
