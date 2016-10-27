using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class TChuyenKhoDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        int oMaKhoHangNhap;
        int oMaKhoHangXuat;
        int oMaNhanVien;
        System.DateTime oNgay;

        int _Ma;
        int _MaKhoHangNhap;
        int _MaKhoHangXuat;
        int _MaNhanVien;
        System.DateTime _Ngay;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaKhoHangNhap { get { return _MaKhoHangNhap; } set { _MaKhoHangNhap = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaKhoHangXuat { get { return _MaKhoHangXuat; } set { _MaKhoHangXuat = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaNhanVien { get { return _MaNhanVien; } set { _MaNhanVien = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oMaKhoHangNhap = MaKhoHangNhap;
            oMaKhoHangXuat = MaKhoHangXuat;
            oMaNhanVien = MaNhanVien;
            oNgay = Ngay;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oMaKhoHangNhap != MaKhoHangNhap)
            || (oMaKhoHangXuat != MaKhoHangXuat)
            || (oMaNhanVien != MaNhanVien)
            || (oNgay != Ngay)
;
        }

        object _MaKhoHangNhapSources;
        object _MaKhoHangXuatSources;
        object _MaNhanVienSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaKhoHangNhapSources { get { return _MaKhoHangNhapSources; } set { _MaKhoHangNhapSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaKhoHangXuatSources { get { return _MaKhoHangXuatSources; } set { _MaKhoHangXuatSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaNhanVienSources { get { return _MaNhanVienSources; } set { _MaNhanVienSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
