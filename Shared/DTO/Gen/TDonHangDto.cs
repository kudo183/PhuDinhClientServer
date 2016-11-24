using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class TDonHangDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        int oID;
        int? oMaChanh;
        int oMaKhachHang;
        int oMaKhoHang;
        System.DateTime oNgay;
        int oTongSoLuong;
        bool oXong;

        int _GroupID;
        int _ID;
        int? _MaChanh;
        int _MaKhachHang;
        int _MaKhoHang;
        System.DateTime _Ngay;
        int _TongSoLuong;
        bool _Xong;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int? MaChanh { get { return _MaChanh; } set { _MaChanh = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaKhachHang { get { return _MaKhachHang; } set { _MaKhachHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int MaKhoHang { get { return _MaKhoHang; } set { _MaKhoHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(7)]
        public int TongSoLuong { get { return _TongSoLuong; } set { _TongSoLuong = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(8)]
        public bool Xong { get { return _Xong; } set { _Xong = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oID = ID;
            oMaChanh = MaChanh;
            oMaKhachHang = MaKhachHang;
            oMaKhoHang = MaKhoHang;
            oNgay = Ngay;
            oTongSoLuong = TongSoLuong;
            oXong = Xong;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
            || (oID != ID)
            || (oMaChanh != MaChanh)
            || (oMaKhachHang != MaKhachHang)
            || (oMaKhoHang != MaKhoHang)
            || (oNgay != Ngay)
            || (oTongSoLuong != TongSoLuong)
            || (oXong != Xong)
;
        }

        object _MaChanhSources;
        object _MaKhachHangSources;
        object _MaKhoHangSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaChanhSources { get { return _MaChanhSources; } set { _MaChanhSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaKhachHangSources { get { return _MaKhachHangSources; } set { _MaKhachHangSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaKhoHangSources { get { return _MaKhoHangSources; } set { _MaKhoHangSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
