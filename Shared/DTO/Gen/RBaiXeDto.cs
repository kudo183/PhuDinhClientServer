﻿using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RBaiXeDto : IDto, INotifyPropertyChanged
    {
        string oDiaDiemBaiXe;
        int oMa;

        string _DiaDiemBaiXe;
        int _Ma;

        [ProtoBuf.ProtoMember(1)]
        public string DiaDiemBaiXe { get { return _DiaDiemBaiXe; } set { _DiaDiemBaiXe = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oDiaDiemBaiXe = DiaDiemBaiXe;
            oMa = Ma;
        }

        public bool HasChange()
        {
            return (oDiaDiemBaiXe != DiaDiemBaiXe)
            || (oMa != Ma)
;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
