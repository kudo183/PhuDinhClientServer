using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class TChiTietChuyenKhoDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        int oMa;
        int oMaChuyenKho;
        int oMaMatHang;
        int oSoLuong;

        int _GroupID;
        int _Ma;
        int _MaChuyenKho;
        int _MaMatHang;
        int _SoLuong;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaChuyenKho { get { return _MaChuyenKho; } set { _MaChuyenKho = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaMatHang { get { return _MaMatHang; } set { _MaMatHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int SoLuong { get { return _SoLuong; } set { _SoLuong = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oMa = Ma;
            oMaChuyenKho = MaChuyenKho;
            oMaMatHang = MaMatHang;
            oSoLuong = SoLuong;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
            || (oMa != Ma)
            || (oMaChuyenKho != MaChuyenKho)
            || (oMaMatHang != MaMatHang)
            || (oSoLuong != SoLuong);
        }

        object _MaChuyenKhoSources;
        object _MaMatHangSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaChuyenKhoSources { get { return _MaChuyenKhoSources; } set { _MaChuyenKhoSources = value; OnPropertyChanged(); } }
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
