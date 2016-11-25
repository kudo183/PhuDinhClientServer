using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class TChiTietChuyenHangDonHangDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        int oMa;
        int oMaChiTietDonHang;
        int oMaChuyenHangDonHang;
        int oSoLuong;
        int oSoLuongTheoDonHang;

        int _GroupID;
        int _Ma;
        int _MaChiTietDonHang;
        int _MaChuyenHangDonHang;
        int _SoLuong;
        int _SoLuongTheoDonHang;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaChiTietDonHang { get { return _MaChiTietDonHang; } set { _MaChiTietDonHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaChuyenHangDonHang { get { return _MaChuyenHangDonHang; } set { _MaChuyenHangDonHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int SoLuong { get { return _SoLuong; } set { _SoLuong = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public int SoLuongTheoDonHang { get { return _SoLuongTheoDonHang; } set { _SoLuongTheoDonHang = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oMa = Ma;
            oMaChiTietDonHang = MaChiTietDonHang;
            oMaChuyenHangDonHang = MaChuyenHangDonHang;
            oSoLuong = SoLuong;
            oSoLuongTheoDonHang = SoLuongTheoDonHang;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
            || (oMa != Ma)
            || (oMaChiTietDonHang != MaChiTietDonHang)
            || (oMaChuyenHangDonHang != MaChuyenHangDonHang)
            || (oSoLuong != SoLuong)
            || (oSoLuongTheoDonHang != SoLuongTheoDonHang);
        }

        object _MaChiTietDonHangSources;
        object _MaChuyenHangDonHangSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaChiTietDonHangSources { get { return _MaChiTietDonHangSources; } set { _MaChiTietDonHangSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaChuyenHangDonHangSources { get { return _MaChuyenHangDonHangSources; } set { _MaChuyenHangDonHangSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}
