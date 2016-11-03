using System.ComponentModel;

namespace DTO
{
    public partial class TChiTietNhapHangDto : IDto, INotifyPropertyChanged
    {
        [ProtoBuf.ProtoMember(10)]
        public TNhapHangDto TNhapHang { get; set; }
        [ProtoBuf.ProtoMember(11)]
        public TMatHangDto TMatHang { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return string.Format("{0} {1}", TNhapHang.TenHienThi, TMatHang.TenHienThi);
            }
        }
    }
}
