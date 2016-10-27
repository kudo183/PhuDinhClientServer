using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RLoaiNguyenLieuDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        string oTenLoai;

        int _Ma;
        string _TenLoai;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public string TenLoai { get { return _TenLoai; } set { _TenLoai = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oTenLoai = TenLoai;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oTenLoai != TenLoai)
;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
