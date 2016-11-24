using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RBaiXeDto : IDto, INotifyPropertyChanged
    {
        string oDiaDiemBaiXe;
        int oGroupID;
        int oID;

        string _DiaDiemBaiXe;
        int _GroupID;
        int _ID;

        [ProtoBuf.ProtoMember(1)]
        public string DiaDiemBaiXe { get { return _DiaDiemBaiXe; } set { _DiaDiemBaiXe = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oDiaDiemBaiXe = DiaDiemBaiXe;
            oGroupID = GroupID;
            oID = ID;
        }

        public bool HasChange()
        {
            return (oDiaDiemBaiXe != DiaDiemBaiXe)
            || (oGroupID != GroupID)
            || (oID != ID)
;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
