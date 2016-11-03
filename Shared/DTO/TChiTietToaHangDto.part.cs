using System.ComponentModel;

namespace DTO
{
    public partial class TChiTietToaHangDto : IDto, INotifyPropertyChanged
    {
        [ProtoBuf.ProtoMember(10)]
        public TToaHangDto TToaHang { get; set; }
        [ProtoBuf.ProtoMember(11)]
        public TChiTietDonHangDto TChiTietDonHang { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return string.Format("{0} {1}", TToaHang.TenHienThi, TChiTietDonHang.TenHienThi);
            }
        }
    }
}
