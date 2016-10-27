using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RLoaiHangDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        bool oHangNhaLam;
        string oTenLoai;

        int _Ma;
        bool _HangNhaLam;
        string _TenLoai;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public bool HangNhaLam { get { return _HangNhaLam; } set { _HangNhaLam = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public string TenLoai { get { return _TenLoai; } set { _TenLoai = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oHangNhaLam = HangNhaLam;
            oTenLoai = TenLoai;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oHangNhaLam != HangNhaLam)
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
