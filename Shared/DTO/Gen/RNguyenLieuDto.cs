﻿using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class RNguyenLieuDto : IDto, INotifyPropertyChanged
    {
        int oDuongKinh;
        int oGroupID;
        int oMa;
        int oMaLoaiNguyenLieu;

        int _DuongKinh;
        int _GroupID;
        int _Ma;
        int _MaLoaiNguyenLieu;

        [ProtoBuf.ProtoMember(1)]
        public int DuongKinh { get { return _DuongKinh; } set { _DuongKinh = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaLoaiNguyenLieu { get { return _MaLoaiNguyenLieu; } set { _MaLoaiNguyenLieu = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oDuongKinh = DuongKinh;
            oGroupID = GroupID;
            oMa = Ma;
            oMaLoaiNguyenLieu = MaLoaiNguyenLieu;
        }

        public bool HasChange()
        {
            return (oDuongKinh != DuongKinh)
            || (oGroupID != GroupID)
            || (oMa != Ma)
            || (oMaLoaiNguyenLieu != MaLoaiNguyenLieu);
        }

        object _MaLoaiNguyenLieuSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaLoaiNguyenLieuSources { get { return _MaLoaiNguyenLieuSources; } set { _MaLoaiNguyenLieuSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}
