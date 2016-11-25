using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class TNhapHangDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        int oMa;
        int oMaKhoHang;
        int oMaNhaCungCap;
        int oMaNhanVien;
        System.DateTime oNgay;

        int _GroupID;
        int _Ma;
        int _MaKhoHang;
        int _MaNhaCungCap;
        int _MaNhanVien;
        System.DateTime _Ngay;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaKhoHang { get { return _MaKhoHang; } set { _MaKhoHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaNhaCungCap { get { return _MaNhaCungCap; } set { _MaNhaCungCap = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int MaNhanVien { get { return _MaNhanVien; } set { _MaNhanVien = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oMa = Ma;
            oMaKhoHang = MaKhoHang;
            oMaNhaCungCap = MaNhaCungCap;
            oMaNhanVien = MaNhanVien;
            oNgay = Ngay;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
            || (oMa != Ma)
            || (oMaKhoHang != MaKhoHang)
            || (oMaNhaCungCap != MaNhaCungCap)
            || (oMaNhanVien != MaNhanVien)
            || (oNgay != Ngay);
        }

        object _MaKhoHangSources;
        object _MaNhaCungCapSources;
        object _MaNhanVienSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaKhoHangSources { get { return _MaKhoHangSources; } set { _MaKhoHangSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaNhaCungCapSources { get { return _MaNhaCungCapSources; } set { _MaNhaCungCapSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaNhanVienSources { get { return _MaNhanVienSources; } set { _MaNhanVienSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}
