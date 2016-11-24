using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RNhaCungCapDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        int oID;
        string oTenNhaCungCap;

        int _GroupID;
        int _ID;
        string _TenNhaCungCap;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public string TenNhaCungCap { get { return _TenNhaCungCap; } set { _TenNhaCungCap = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oID = ID;
            oTenNhaCungCap = TenNhaCungCap;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
            || (oID != ID)
            || (oTenNhaCungCap != TenNhaCungCap)
;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
