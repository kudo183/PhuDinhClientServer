using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class TChuyenHangDonHangDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        int oMaChuyenHang;
        int oMaDonHang;
        int oTongSoLuongTheoDonHang;
        int oTongSoLuongThucTe;

        int _Ma;
        int _MaChuyenHang;
        int _MaDonHang;
        int _TongSoLuongTheoDonHang;
        int _TongSoLuongThucTe;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaChuyenHang { get { return _MaChuyenHang; } set { _MaChuyenHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaDonHang { get { return _MaDonHang; } set { _MaDonHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int TongSoLuongTheoDonHang { get { return _TongSoLuongTheoDonHang; } set { _TongSoLuongTheoDonHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int TongSoLuongThucTe { get { return _TongSoLuongThucTe; } set { _TongSoLuongThucTe = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oMaChuyenHang = MaChuyenHang;
            oMaDonHang = MaDonHang;
            oTongSoLuongTheoDonHang = TongSoLuongTheoDonHang;
            oTongSoLuongThucTe = TongSoLuongThucTe;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oMaChuyenHang != MaChuyenHang)
            || (oMaDonHang != MaDonHang)
            || (oTongSoLuongTheoDonHang != TongSoLuongTheoDonHang)
            || (oTongSoLuongThucTe != TongSoLuongThucTe)
;
        }

        object _MaChuyenHangSources;
        object _MaDonHangSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaChuyenHangSources { get { return _MaChuyenHangSources; } set { _MaChuyenHangSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaDonHangSources { get { return _MaDonHangSources; } set { _MaDonHangSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
