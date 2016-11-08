using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TMatHang : huypq.SwaMiddleware.SwaIEntity
    {
        public TMatHang()
        {
            RCanhBaoTonKhoMaMatHangNavigation = new HashSet<RCanhBaoTonKho>();
            RMatHangNguyenLieuMaMatHangNavigation = new HashSet<RMatHangNguyenLieu>();
            TChiTietChuyenKhoMaMatHangNavigation = new HashSet<TChiTietChuyenKho>();
            TChiTietDonHangMaMatHangNavigation = new HashSet<TChiTietDonHang>();
            TChiTietNhapHangMaMatHangNavigation = new HashSet<TChiTietNhapHang>();
            TTonKhoMaMatHangNavigation = new HashSet<TTonKho>();
        }

        public int Ma { get; set; }
        public int MaGroup { get; set; }
        public int MaLoai { get; set; }
        public int SoKy { get; set; }
        public int SoMet { get; set; }
        public string TenMatHang { get; set; }
        public string TenMatHangDayDu { get; set; }
        public string TenMatHangIn { get; set; }

        public ICollection<RCanhBaoTonKho> RCanhBaoTonKhoMaMatHangNavigation { get; set; }
        public ICollection<RMatHangNguyenLieu> RMatHangNguyenLieuMaMatHangNavigation { get; set; }
        public ICollection<TChiTietChuyenKho> TChiTietChuyenKhoMaMatHangNavigation { get; set; }
        public ICollection<TChiTietDonHang> TChiTietDonHangMaMatHangNavigation { get; set; }
        public ICollection<TChiTietNhapHang> TChiTietNhapHangMaMatHangNavigation { get; set; }
        public ICollection<TTonKho> TTonKhoMaMatHangNavigation { get; set; }

        public RLoaiHang MaLoaiNavigation { get; set; }
    }
}
