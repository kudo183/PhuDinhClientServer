using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class SwaGroupDto : IDto, INotifyPropertyChanged
    {
        System.DateTime oCreateDate;
        string oGroupName;
        int oID;

        System.DateTime _CreateDate;
        string _GroupName;
        int _ID;

        [ProtoBuf.ProtoMember(1)]
        public System.DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public string GroupName { get { return _GroupName; } set { _GroupName = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oCreateDate = CreateDate;
            oGroupName = GroupName;
            oID = ID;
        }

        public bool HasChange()
        {
            return (oCreateDate != CreateDate)
            || (oGroupName != GroupName)
            || (oID != ID);
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
