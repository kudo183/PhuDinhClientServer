using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class GroupDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        System.DateTime oNgayTao;
        string oTenGroup;

        int _Ma;
        System.DateTime _NgayTao;
        string _TenGroup;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public System.DateTime NgayTao { get { return _NgayTao; } set { _NgayTao = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public string TenGroup { get { return _TenGroup; } set { _TenGroup = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oNgayTao = NgayTao;
            oTenGroup = TenGroup;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oNgayTao != NgayTao)
            || (oTenGroup != TenGroup)
;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
