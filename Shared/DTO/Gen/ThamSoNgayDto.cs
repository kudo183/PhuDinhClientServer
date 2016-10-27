using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class ThamSoNgayDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        System.DateTime oGiaTri;
        string oTen;

        int _Ma;
        System.DateTime _GiaTri;
        string _Ten;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public System.DateTime GiaTri { get { return _GiaTri; } set { _GiaTri = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public string Ten { get { return _Ten; } set { _Ten = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oGiaTri = GiaTri;
            oTen = Ten;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oGiaTri != GiaTri)
            || (oTen != Ten)
;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
