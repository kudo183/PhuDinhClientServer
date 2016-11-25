using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RKhachHangDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        bool oKhachRieng;
        int oMa;
        int oMaDiaDiem;
        string oTenKhachHang;

        int _GroupID;
        bool _KhachRieng;
        int _Ma;
        int _MaDiaDiem;
        string _TenKhachHang;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public bool KhachRieng { get { return _KhachRieng; } set { _KhachRieng = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaDiaDiem { get { return _MaDiaDiem; } set { _MaDiaDiem = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public string TenKhachHang { get { return _TenKhachHang; } set { _TenKhachHang = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oKhachRieng = KhachRieng;
            oMa = Ma;
            oMaDiaDiem = MaDiaDiem;
            oTenKhachHang = TenKhachHang;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
            || (oKhachRieng != KhachRieng)
            || (oMa != Ma)
            || (oMaDiaDiem != MaDiaDiem)
            || (oTenKhachHang != TenKhachHang);
        }

        object _MaDiaDiemSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaDiaDiemSources { get { return _MaDiaDiemSources; } set { _MaDiaDiemSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}
