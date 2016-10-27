using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RNuocDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        string oTenNuoc;

        int _Ma;
        string _TenNuoc;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public string TenNuoc { get { return _TenNuoc; } set { _TenNuoc = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oTenNuoc = TenNuoc;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oTenNuoc != TenNuoc)
;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
