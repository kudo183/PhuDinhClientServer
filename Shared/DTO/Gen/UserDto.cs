using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class UserDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        string oEmail;
        System.DateTime oNgayTao;
        string oPasswordHash;

        int _Ma;
        string _Email;
        System.DateTime _NgayTao;
        string _PasswordHash;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public string Email { get { return _Email; } set { _Email = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public System.DateTime NgayTao { get { return _NgayTao; } set { _NgayTao = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public string PasswordHash { get { return _PasswordHash; } set { _PasswordHash = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oEmail = Email;
            oNgayTao = NgayTao;
            oPasswordHash = PasswordHash;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oEmail != Email)
            || (oNgayTao != NgayTao)
            || (oPasswordHash != PasswordHash)
;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
