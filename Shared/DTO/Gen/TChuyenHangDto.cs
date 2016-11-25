using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class TChuyenHangDto : IDto, INotifyPropertyChanged
    {
        System.TimeSpan? oGio;
        int oGroupID;
        int oMa;
        int oMaNhanVienGiaoHang;
        System.DateTime oNgay;
        int oTongDonHang;
        int oTongSoLuongTheoDonHang;
        int oTongSoLuongThucTe;

        System.TimeSpan? _Gio;
        int _GroupID;
        int _Ma;
        int _MaNhanVienGiaoHang;
        System.DateTime _Ngay;
        int _TongDonHang;
        int _TongSoLuongTheoDonHang;
        int _TongSoLuongThucTe;

        [ProtoBuf.ProtoMember(1)]
        public System.TimeSpan? Gio { get { return _Gio; } set { _Gio = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaNhanVienGiaoHang { get { return _MaNhanVienGiaoHang; } set { _MaNhanVienGiaoHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public int TongDonHang { get { return _TongDonHang; } set { _TongDonHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(7)]
        public int TongSoLuongTheoDonHang { get { return _TongSoLuongTheoDonHang; } set { _TongSoLuongTheoDonHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(8)]
        public int TongSoLuongThucTe { get { return _TongSoLuongThucTe; } set { _TongSoLuongThucTe = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGio = Gio;
            oGroupID = GroupID;
            oMa = Ma;
            oMaNhanVienGiaoHang = MaNhanVienGiaoHang;
            oNgay = Ngay;
            oTongDonHang = TongDonHang;
            oTongSoLuongTheoDonHang = TongSoLuongTheoDonHang;
            oTongSoLuongThucTe = TongSoLuongThucTe;
        }

        public bool HasChange()
        {
            return (oGio != Gio)
            || (oGroupID != GroupID)
            || (oMa != Ma)
            || (oMaNhanVienGiaoHang != MaNhanVienGiaoHang)
            || (oNgay != Ngay)
            || (oTongDonHang != TongDonHang)
            || (oTongSoLuongTheoDonHang != TongSoLuongTheoDonHang)
            || (oTongSoLuongThucTe != TongSoLuongThucTe);
        }

        object _MaNhanVienGiaoHangSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaNhanVienGiaoHangSources { get { return _MaNhanVienGiaoHangSources; } set { _MaNhanVienGiaoHangSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}
