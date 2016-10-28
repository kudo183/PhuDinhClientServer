﻿using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class UserGroupDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        bool oLaChuGroup;
        int oMaGroup;
        int oMaUser;

        int _Ma;
        bool _LaChuGroup;
        int _MaGroup;
        int _MaUser;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public bool LaChuGroup { get { return _LaChuGroup; } set { _LaChuGroup = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaGroup { get { return _MaGroup; } set { _MaGroup = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaUser { get { return _MaUser; } set { _MaUser = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oLaChuGroup = LaChuGroup;
            oMaGroup = MaGroup;
            oMaUser = MaUser;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oLaChuGroup != LaChuGroup)
            || (oMaGroup != MaGroup)
            || (oMaUser != MaUser)
;
        }

        object _MaGroupSources;
        object _MaUserSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaGroupSources { get { return _MaGroupSources; } set { _MaGroupSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaUserSources { get { return _MaUserSources; } set { _MaUserSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}