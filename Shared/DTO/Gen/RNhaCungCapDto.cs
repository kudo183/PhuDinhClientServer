using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RNhaCungCapDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        string oTenNhaCungCap;

        int _Ma;
        string _TenNhaCungCap;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public string TenNhaCungCap { get { return _TenNhaCungCap; } set { _TenNhaCungCap = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oTenNhaCungCap = TenNhaCungCap;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
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
