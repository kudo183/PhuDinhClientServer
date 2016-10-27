using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RChanhDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        int oMaBaiXe;
        string oTenChanh;

        int _Ma;
        int _MaBaiXe;
        string _TenChanh;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaBaiXe { get { return _MaBaiXe; } set { _MaBaiXe = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public string TenChanh { get { return _TenChanh; } set { _TenChanh = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oMaBaiXe = MaBaiXe;
            oTenChanh = TenChanh;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oMaBaiXe != MaBaiXe)
            || (oTenChanh != TenChanh)
;
        }

        object _MaBaiXeSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaBaiXeSources { get { return _MaBaiXeSources; } set { _MaBaiXeSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
