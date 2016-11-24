using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class TPhuThuKhachHangDto : IDto, INotifyPropertyChanged
    {
        string oGhiChu;
        int oGroupID;
        int oID;
        int oMaKhachHang;
        System.DateTime oNgay;
        int oSoTien;

        string _GhiChu;
        int _GroupID;
        int _ID;
        int _MaKhachHang;
        System.DateTime _Ngay;
        int _SoTien;

        [ProtoBuf.ProtoMember(1)]
        public string GhiChu { get { return _GhiChu; } set { _GhiChu = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaKhachHang { get { return _MaKhachHang; } set { _MaKhachHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public int SoTien { get { return _SoTien; } set { _SoTien = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGhiChu = GhiChu;
            oGroupID = GroupID;
            oID = ID;
            oMaKhachHang = MaKhachHang;
            oNgay = Ngay;
            oSoTien = SoTien;
        }

        public bool HasChange()
        {
            return (oGhiChu != GhiChu)
            || (oGroupID != GroupID)
            || (oID != ID)
            || (oMaKhachHang != MaKhachHang)
            || (oNgay != Ngay)
            || (oSoTien != SoTien)
;
        }

        object _MaKhachHangSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaKhachHangSources { get { return _MaKhachHangSources; } set { _MaKhachHangSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
