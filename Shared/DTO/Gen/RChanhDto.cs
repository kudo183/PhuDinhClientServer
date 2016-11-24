using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RChanhDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        int oID;
        int oMaBaiXe;
        string oTenChanh;

        int _GroupID;
        int _ID;
        int _MaBaiXe;
        string _TenChanh;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaBaiXe { get { return _MaBaiXe; } set { _MaBaiXe = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public string TenChanh { get { return _TenChanh; } set { _TenChanh = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oID = ID;
            oMaBaiXe = MaBaiXe;
            oTenChanh = TenChanh;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
            || (oID != ID)
            || (oMaBaiXe != MaBaiXe)
            || (oTenChanh != TenChanh)
;
        }

        object _MaBaiXeSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaBaiXeSources { get { return _MaBaiXeSources; } set { _MaBaiXeSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
