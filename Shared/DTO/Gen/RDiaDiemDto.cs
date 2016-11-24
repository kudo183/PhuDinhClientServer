using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RDiaDiemDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        int oID;
        int oMaNuoc;
        string oTinh;

        int _GroupID;
        int _ID;
        int _MaNuoc;
        string _Tinh;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaNuoc { get { return _MaNuoc; } set { _MaNuoc = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public string Tinh { get { return _Tinh; } set { _Tinh = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oID = ID;
            oMaNuoc = MaNuoc;
            oTinh = Tinh;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
            || (oID != ID)
            || (oMaNuoc != MaNuoc)
            || (oTinh != Tinh)
;
        }

        object _MaNuocSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaNuocSources { get { return _MaNuocSources; } set { _MaNuocSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
