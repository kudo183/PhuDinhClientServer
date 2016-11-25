using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RLoaiHangDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        bool oHangNhaLam;
        int oMa;
        string oTenLoai;

        int _GroupID;
        bool _HangNhaLam;
        int _Ma;
        string _TenLoai;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public bool HangNhaLam { get { return _HangNhaLam; } set { _HangNhaLam = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public string TenLoai { get { return _TenLoai; } set { _TenLoai = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oHangNhaLam = HangNhaLam;
            oMa = Ma;
            oTenLoai = TenLoai;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
            || (oHangNhaLam != HangNhaLam)
            || (oMa != Ma)
            || (oTenLoai != TenLoai);
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}
