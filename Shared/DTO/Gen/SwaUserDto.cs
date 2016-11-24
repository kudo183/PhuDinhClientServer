using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class SwaUserDto : IDto, INotifyPropertyChanged
    {
        System.DateTime oCreateDate;
        string oEmail;
        int oID;
        string oPasswordHash;

        System.DateTime _CreateDate;
        string _Email;
        int _ID;
        string _PasswordHash;

        [ProtoBuf.ProtoMember(1)]
        public System.DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public string Email { get { return _Email; } set { _Email = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public string PasswordHash { get { return _PasswordHash; } set { _PasswordHash = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oCreateDate = CreateDate;
            oEmail = Email;
            oID = ID;
            oPasswordHash = PasswordHash;
        }

        public bool HasChange()
        {
            return (oCreateDate != CreateDate)
            || (oEmail != Email)
            || (oID != ID)
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
