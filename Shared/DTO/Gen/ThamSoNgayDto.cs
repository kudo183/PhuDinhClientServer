﻿using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class ThamSoNgayDto : IDto, INotifyPropertyChanged
    {
        System.DateTime oGiaTri;
        int oGroupID;
        int oMa;
        string oTen;

        System.DateTime _GiaTri;
        int _GroupID;
        int _Ma;
        string _Ten;

        [ProtoBuf.ProtoMember(1)]
        public System.DateTime GiaTri { get { return _GiaTri; } set { _GiaTri = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public string Ten { get { return _Ten; } set { _Ten = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGiaTri = GiaTri;
            oGroupID = GroupID;
            oMa = Ma;
            oTen = Ten;
        }

        public bool HasChange()
        {
            return (oGiaTri != GiaTri)
            || (oGroupID != GroupID)
            || (oMa != Ma)
            || (oTen != Ten);
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
