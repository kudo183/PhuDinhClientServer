using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class TNhapNguyenLieuDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        int oID;
        int oMaNguyenLieu;
        int oMaNhaCungCap;
        System.DateTime oNgay;
        int oSoLuong;

        int _GroupID;
        int _ID;
        int _MaNguyenLieu;
        int _MaNhaCungCap;
        System.DateTime _Ngay;
        int _SoLuong;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaNguyenLieu { get { return _MaNguyenLieu; } set { _MaNguyenLieu = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaNhaCungCap { get { return _MaNhaCungCap; } set { _MaNhaCungCap = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public int SoLuong { get { return _SoLuong; } set { _SoLuong = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oID = ID;
            oMaNguyenLieu = MaNguyenLieu;
            oMaNhaCungCap = MaNhaCungCap;
            oNgay = Ngay;
            oSoLuong = SoLuong;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
            || (oID != ID)
            || (oMaNguyenLieu != MaNguyenLieu)
            || (oMaNhaCungCap != MaNhaCungCap)
            || (oNgay != Ngay)
            || (oSoLuong != SoLuong)
;
        }

        object _MaNguyenLieuSources;
        object _MaNhaCungCapSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaNguyenLieuSources { get { return _MaNguyenLieuSources; } set { _MaNguyenLieuSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaNhaCungCapSources { get { return _MaNhaCungCapSources; } set { _MaNhaCungCapSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
