using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RLoaiHangDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        bool oHangNhaLam;
        int oID;
        string oTenLoai;

        int _GroupID;
        bool _HangNhaLam;
        int _ID;
        string _TenLoai;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public bool HangNhaLam { get { return _HangNhaLam; } set { _HangNhaLam = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public string TenLoai { get { return _TenLoai; } set { _TenLoai = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oHangNhaLam = HangNhaLam;
            oID = ID;
            oTenLoai = TenLoai;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
            || (oHangNhaLam != HangNhaLam)
            || (oID != ID)
            || (oTenLoai != TenLoai)
;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
