using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class SwaUserGroupDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        int oID;
        bool oIsGroupOwner;
        int oUserID;

        int _GroupID;
        int _ID;
        bool _IsGroupOwner;
        int _UserID;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public bool IsGroupOwner { get { return _IsGroupOwner; } set { _IsGroupOwner = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int UserID { get { return _UserID; } set { _UserID = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oID = ID;
            oIsGroupOwner = IsGroupOwner;
            oUserID = UserID;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
            || (oID != ID)
            || (oIsGroupOwner != IsGroupOwner)
            || (oUserID != UserID)
;
        }

        object _GroupIDSources;
        object _UserIDSources;

        [Newtonsoft.Json.JsonIgnore]
        public object GroupIDSources { get { return _GroupIDSources; } set { _GroupIDSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object UserIDSources { get { return _UserIDSources; } set { _UserIDSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
