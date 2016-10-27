using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class TTonKhoDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        int oMaKhoHang;
        int oMaMatHang;
        System.DateTime oNgay;
        int oSoLuong;
        int oSoLuongCu;

        int _Ma;
        int _MaKhoHang;
        int _MaMatHang;
        System.DateTime _Ngay;
        int _SoLuong;
        int _SoLuongCu;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaKhoHang { get { return _MaKhoHang; } set { _MaKhoHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaMatHang { get { return _MaMatHang; } set { _MaMatHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int SoLuong { get { return _SoLuong; } set { _SoLuong = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public int SoLuongCu { get { return _SoLuongCu; } set { _SoLuongCu = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oMaKhoHang = MaKhoHang;
            oMaMatHang = MaMatHang;
            oNgay = Ngay;
            oSoLuong = SoLuong;
            oSoLuongCu = SoLuongCu;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oMaKhoHang != MaKhoHang)
            || (oMaMatHang != MaMatHang)
            || (oNgay != Ngay)
            || (oSoLuong != SoLuong)
            || (oSoLuongCu != SoLuongCu)
;
        }

        object _MaKhoHangSources;
        object _MaMatHangSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaKhoHangSources { get { return _MaKhoHangSources; } set { _MaKhoHangSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaMatHangSources { get { return _MaMatHangSources; } set { _MaMatHangSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
