using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RLoaiChiPhiDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        string oTenLoaiChiPhi;

        int _Ma;
        string _TenLoaiChiPhi;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public string TenLoaiChiPhi { get { return _TenLoaiChiPhi; } set { _TenLoaiChiPhi = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oTenLoaiChiPhi = TenLoaiChiPhi;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oTenLoaiChiPhi != TenLoaiChiPhi)
;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
