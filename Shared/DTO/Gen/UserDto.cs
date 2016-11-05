using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class UserDto : IDto, INotifyPropertyChanged
    {
        string oEmail;
        int oMa;
        System.DateTime oNgayTao;
        string oPasswordHash;

        string _Email;
        int _Ma;
        System.DateTime _NgayTao;
        string _PasswordHash;

        [ProtoBuf.ProtoMember(1)]
        public string Email { get { return _Email; } set { _Email = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public System.DateTime NgayTao { get { return _NgayTao; } set { _NgayTao = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public string PasswordHash { get { return _PasswordHash; } set { _PasswordHash = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oEmail = Email;
            oMa = Ma;
            oNgayTao = NgayTao;
            oPasswordHash = PasswordHash;
        }

        public bool HasChange()
        {
            return (oEmail != Email)
            || (oMa != Ma)
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
