using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RPhuongTienDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        string oTenPhuongTien;

        int _Ma;
        string _TenPhuongTien;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public string TenPhuongTien { get { return _TenPhuongTien; } set { _TenPhuongTien = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oTenPhuongTien = TenPhuongTien;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oTenPhuongTien != TenPhuongTien)
;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
