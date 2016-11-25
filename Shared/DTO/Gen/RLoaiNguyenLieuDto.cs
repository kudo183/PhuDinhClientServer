using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RLoaiNguyenLieuDto : IDto, INotifyPropertyChanged
    {
        int oGroupID;
        int oMa;
        string oTenLoai;

        int _GroupID;
        int _Ma;
        string _TenLoai;

        [ProtoBuf.ProtoMember(1)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public string TenLoai { get { return _TenLoai; } set { _TenLoai = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGroupID = GroupID;
            oMa = Ma;
            oTenLoai = TenLoai;
        }

        public bool HasChange()
        {
            return (oGroupID != GroupID)
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
