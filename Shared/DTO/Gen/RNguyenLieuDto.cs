using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RNguyenLieuDto : IDto, INotifyPropertyChanged
    {
        int oDuongKinh;
        int oGroupID;
        int oID;
        int oMaLoaiNguyenLieu;

        int _DuongKinh;
        int _GroupID;
        int _ID;
        int _MaLoaiNguyenLieu;

        [ProtoBuf.ProtoMember(1)]
        public int DuongKinh { get { return _DuongKinh; } set { _DuongKinh = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaLoaiNguyenLieu { get { return _MaLoaiNguyenLieu; } set { _MaLoaiNguyenLieu = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oDuongKinh = DuongKinh;
            oGroupID = GroupID;
            oID = ID;
            oMaLoaiNguyenLieu = MaLoaiNguyenLieu;
        }

        public bool HasChange()
        {
            return (oDuongKinh != DuongKinh)
            || (oGroupID != GroupID)
            || (oID != ID)
            || (oMaLoaiNguyenLieu != MaLoaiNguyenLieu)
;
        }

        object _MaLoaiNguyenLieuSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaLoaiNguyenLieuSources { get { return _MaLoaiNguyenLieuSources; } set { _MaLoaiNguyenLieuSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
