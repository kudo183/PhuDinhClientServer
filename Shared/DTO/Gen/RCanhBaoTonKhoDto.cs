using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RCanhBaoTonKhoDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        int oMa;
        int oMaKhoHang;
        int oMaMatHang;
        int oTonCaoNhat;
        int oTonThapNhat;

        int _GroupID;
        int _Ma;
        int _MaKhoHang;
        int _MaMatHang;
        int _TonCaoNhat;
        int _TonThapNhat;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaKhoHang { get { return _MaKhoHang; } set { _MaKhoHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaMatHang { get { return _MaMatHang; } set { _MaMatHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int TonCaoNhat { get { return _TonCaoNhat; } set { _TonCaoNhat = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public int TonThapNhat { get { return _TonThapNhat; } set { _TonThapNhat = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oMa = Ma;
            oMaKhoHang = MaKhoHang;
            oMaMatHang = MaMatHang;
            oTonCaoNhat = TonCaoNhat;
            oTonThapNhat = TonThapNhat;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
            || (oMa != Ma)
            || (oMaKhoHang != MaKhoHang)
            || (oMaMatHang != MaMatHang)
            || (oTonCaoNhat != TonCaoNhat)
            || (oTonThapNhat != TonThapNhat);
        }

        object _MaKhoHangSources;
        object _MaMatHangSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaKhoHangSources { get { return _MaKhoHangSources; } set { _MaKhoHangSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaMatHangSources { get { return _MaMatHangSources; } set { _MaMatHangSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}
