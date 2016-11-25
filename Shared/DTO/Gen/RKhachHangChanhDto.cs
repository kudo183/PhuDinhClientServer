using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RKhachHangChanhDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        bool oLaMacDinh;
        int oMa;
        int oMaChanh;
        int oMaKhachHang;

        int _GroupID;
        bool _LaMacDinh;
        int _Ma;
        int _MaChanh;
        int _MaKhachHang;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public bool LaMacDinh { get { return _LaMacDinh; } set { _LaMacDinh = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaChanh { get { return _MaChanh; } set { _MaChanh = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int MaKhachHang { get { return _MaKhachHang; } set { _MaKhachHang = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oLaMacDinh = LaMacDinh;
            oMa = Ma;
            oMaChanh = MaChanh;
            oMaKhachHang = MaKhachHang;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
            || (oLaMacDinh != LaMacDinh)
            || (oMa != Ma)
            || (oMaChanh != MaChanh)
            || (oMaKhachHang != MaKhachHang);
        }

        object _MaChanhSources;
        object _MaKhachHangSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaChanhSources { get { return _MaChanhSources; } set { _MaChanhSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaKhachHangSources { get { return _MaKhachHangSources; } set { _MaKhachHangSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}
