using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RMatHangNguyenLieuDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        int oMaMatHang;
        int oMaNguyenLieu;

        int _Ma;
        int _MaMatHang;
        int _MaNguyenLieu;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaMatHang { get { return _MaMatHang; } set { _MaMatHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaNguyenLieu { get { return _MaNguyenLieu; } set { _MaNguyenLieu = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oMaMatHang = MaMatHang;
            oMaNguyenLieu = MaNguyenLieu;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oMaMatHang != MaMatHang)
            || (oMaNguyenLieu != MaNguyenLieu)
;
        }

        object _MaMatHangSources;
        object _MaNguyenLieuSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaMatHangSources { get { return _MaMatHangSources; } set { _MaMatHangSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaNguyenLieuSources { get { return _MaNguyenLieuSources; } set { _MaNguyenLieuSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
