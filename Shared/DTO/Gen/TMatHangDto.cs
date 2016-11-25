using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class TMatHangDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        int oMa;
        int oMaLoai;
        int oSoKy;
        int oSoMet;
        string oTenMatHang;
        string oTenMatHangDayDu;
        string oTenMatHangIn;

        int _GroupID;
        int _Ma;
        int _MaLoai;
        int _SoKy;
        int _SoMet;
        string _TenMatHang;
        string _TenMatHangDayDu;
        string _TenMatHangIn;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaLoai { get { return _MaLoai; } set { _MaLoai = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int SoKy { get { return _SoKy; } set { _SoKy = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int SoMet { get { return _SoMet; } set { _SoMet = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public string TenMatHang { get { return _TenMatHang; } set { _TenMatHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(7)]
        public string TenMatHangDayDu { get { return _TenMatHangDayDu; } set { _TenMatHangDayDu = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(8)]
        public string TenMatHangIn { get { return _TenMatHangIn; } set { _TenMatHangIn = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oMa = Ma;
            oMaLoai = MaLoai;
            oSoKy = SoKy;
            oSoMet = SoMet;
            oTenMatHang = TenMatHang;
            oTenMatHangDayDu = TenMatHangDayDu;
            oTenMatHangIn = TenMatHangIn;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
            || (oMa != Ma)
            || (oMaLoai != MaLoai)
            || (oSoKy != SoKy)
            || (oSoMet != SoMet)
            || (oTenMatHang != TenMatHang)
            || (oTenMatHangDayDu != TenMatHangDayDu)
            || (oTenMatHangIn != TenMatHangIn);
        }

        object _MaLoaiSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaLoaiSources { get { return _MaLoaiSources; } set { _MaLoaiSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}
