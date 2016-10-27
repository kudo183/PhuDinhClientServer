using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RKhoHangDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        string oTenKho;
        bool oTrangThai;

        int _Ma;
        string _TenKho;
        bool _TrangThai;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public string TenKho { get { return _TenKho; } set { _TenKho = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public bool TrangThai { get { return _TrangThai; } set { _TrangThai = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oTenKho = TenKho;
            oTrangThai = TrangThai;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oTenKho != TenKho)
            || (oTrangThai != TrangThai)
;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
