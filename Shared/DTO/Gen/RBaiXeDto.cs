using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RBaiXeDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        string oDiaDiemBaiXe;

        int _Ma;
        string _DiaDiemBaiXe;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public string DiaDiemBaiXe { get { return _DiaDiemBaiXe; } set { _DiaDiemBaiXe = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oDiaDiemBaiXe = DiaDiemBaiXe;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oDiaDiemBaiXe != DiaDiemBaiXe)
;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
