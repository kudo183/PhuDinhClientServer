using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class TChiTietDonHangDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        int oID;
        int oMaDonHang;
        int oMaMatHang;
        int oSoLuong;
        bool oXong;

        int _GroupID;
        int _ID;
        int _MaDonHang;
        int _MaMatHang;
        int _SoLuong;
        bool _Xong;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaDonHang { get { return _MaDonHang; } set { _MaDonHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaMatHang { get { return _MaMatHang; } set { _MaMatHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int SoLuong { get { return _SoLuong; } set { _SoLuong = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public bool Xong { get { return _Xong; } set { _Xong = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oID = ID;
            oMaDonHang = MaDonHang;
            oMaMatHang = MaMatHang;
            oSoLuong = SoLuong;
            oXong = Xong;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
            || (oID != ID)
            || (oMaDonHang != MaDonHang)
            || (oMaMatHang != MaMatHang)
            || (oSoLuong != SoLuong)
            || (oXong != Xong)
;
        }

        object _MaDonHangSources;
        object _MaMatHangSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaDonHangSources { get { return _MaDonHangSources; } set { _MaDonHangSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaMatHangSources { get { return _MaMatHangSources; } set { _MaMatHangSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
