using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RNhanVienDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        int oMaPhuongTien;
        string oTenNhanVien;

        int _Ma;
        int _MaPhuongTien;
        string _TenNhanVien;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaPhuongTien { get { return _MaPhuongTien; } set { _MaPhuongTien = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public string TenNhanVien { get { return _TenNhanVien; } set { _TenNhanVien = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oMaPhuongTien = MaPhuongTien;
            oTenNhanVien = TenNhanVien;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oMaPhuongTien != MaPhuongTien)
            || (oTenNhanVien != TenNhanVien)
;
        }

        object _MaPhuongTienSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaPhuongTienSources { get { return _MaPhuongTienSources; } set { _MaPhuongTienSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
