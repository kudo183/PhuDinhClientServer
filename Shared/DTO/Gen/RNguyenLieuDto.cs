using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RNguyenLieuDto : IDto, INotifyPropertyChanged
    {
        int oDuongKinh;
        int oMa;
        int oMaLoaiNguyenLieu;

        int _DuongKinh;
        int _Ma;
        int _MaLoaiNguyenLieu;

        [ProtoBuf.ProtoMember(1)]
        public int DuongKinh { get { return _DuongKinh; } set { _DuongKinh = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaLoaiNguyenLieu { get { return _MaLoaiNguyenLieu; } set { _MaLoaiNguyenLieu = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oDuongKinh = DuongKinh;
            oMa = Ma;
            oMaLoaiNguyenLieu = MaLoaiNguyenLieu;
        }

        public bool HasChange()
        {
            return (oDuongKinh != DuongKinh)
            || (oMa != Ma)
            || (oMaLoaiNguyenLieu != MaLoaiNguyenLieu)
;
        }

        object _MaLoaiNguyenLieuSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaLoaiNguyenLieuSources { get { return _MaLoaiNguyenLieuSources; } set { _MaLoaiNguyenLieuSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
