using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class TChiTietNhapHangDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        int oMaMatHang;
        int oMaNhapHang;
        int oSoLuong;

        int _Ma;
        int _MaMatHang;
        int _MaNhapHang;
        int _SoLuong;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaMatHang { get { return _MaMatHang; } set { _MaMatHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaNhapHang { get { return _MaNhapHang; } set { _MaNhapHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int SoLuong { get { return _SoLuong; } set { _SoLuong = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oMaMatHang = MaMatHang;
            oMaNhapHang = MaNhapHang;
            oSoLuong = SoLuong;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oMaMatHang != MaMatHang)
            || (oMaNhapHang != MaNhapHang)
            || (oSoLuong != SoLuong)
;
        }

        object _MaMatHangSources;
        object _MaNhapHangSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaMatHangSources { get { return _MaMatHangSources; } set { _MaMatHangSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaNhapHangSources { get { return _MaNhapHangSources; } set { _MaNhapHangSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
