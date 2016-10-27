﻿using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public partial class TChiPhiDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        string oGhiChu;
        int oMaLoaiChiPhi;
        int oMaNhanVienGiaoHang;
        System.DateTime oNgay;
        int oSoTien;

        int _Ma;
        string _GhiChu;
        int _MaLoaiChiPhi;
        int _MaNhanVienGiaoHang;
        System.DateTime _Ngay;
        int _SoTien;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public string GhiChu { get { return _GhiChu; } set { _GhiChu = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaLoaiChiPhi { get { return _MaLoaiChiPhi; } set { _MaLoaiChiPhi = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaNhanVienGiaoHang { get { return _MaNhanVienGiaoHang; } set { _MaNhanVienGiaoHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public int SoTien { get { return _SoTien; } set { _SoTien = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oGhiChu = GhiChu;
            oMaLoaiChiPhi = MaLoaiChiPhi;
            oMaNhanVienGiaoHang = MaNhanVienGiaoHang;
            oNgay = Ngay;
            oSoTien = SoTien;
        }

        public bool HasChange()
        {
            return (oMa != Ma)
            || (oGhiChu != GhiChu)
            || (oMaLoaiChiPhi != MaLoaiChiPhi)
            || (oMaNhanVienGiaoHang != MaNhanVienGiaoHang)
            || (oNgay != Ngay)
            || (oSoTien != SoTien)
;
        }

        object _MaLoaiChiPhiSources;
        object _MaNhanVienGiaoHangSources;

        [Newtonsoft.Json.JsonIgnore]
        public object MaLoaiChiPhiSources { get { return _MaLoaiChiPhiSources; } set { _MaLoaiChiPhiSources = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaNhanVienGiaoHangSources { get { return _MaNhanVienGiaoHangSources; } set { _MaNhanVienGiaoHangSources = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
