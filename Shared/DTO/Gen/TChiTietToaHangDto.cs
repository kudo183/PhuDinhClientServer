﻿using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class TChiTietToaHangDto : IDto, INotifyPropertyChanged
    {
        int oGiaTien;
        int oGroupID;
        int oID;
        int oMaChiTietDonHang;
        int oMaToaHang;

        int _GiaTien;
        int _GroupID;
        int _ID;
        int _MaChiTietDonHang;
        int _MaToaHang;

        [ProtoBuf.ProtoMember(1)]
        public int GiaTien { get { return _GiaTien; } set { _GiaTien = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int GroupID { get { return _GroupID; } set { _GroupID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaChiTietDonHang { get { return _MaChiTietDonHang; } set { _MaChiTietDonHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int MaToaHang { get { return _MaToaHang; } set { _MaToaHang = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oGiaTien = GiaTien;
            oGroupID = GroupID;
            oID = ID;
            oMaChiTietDonHang = MaChiTietDonHang;
            oMaToaHang = MaToaHang;
        }

        public bool HasChange()
        {
            return (oGiaTien != GiaTien)
            || (oGroupID != GroupID)
            || (oID != ID)
            || (oMaChiTietDonHang != MaChiTietDonHang)
            || (oMaToaHang != MaToaHang)
;
        }

        object _MaChiTietDonHangSources;
        object _MaToaHangSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaChiTietDonHangSources { get { return _MaChiTietDonHangSources; } set { _MaChiTietDonHangSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaToaHangSources { get { return _MaToaHangSources; } set { _MaToaHangSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
