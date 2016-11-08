using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TMatHang
    {
        public TMatHang()
        {
            RCanhBaoTonKho = new HashSet<RCanhBaoTonKho>();
            RMatHangNguyenLieu = new HashSet<RMatHangNguyenLieu>();
            TChiTietChuyenKho = new HashSet<TChiTietChuyenKho>();
            TChiTietDonHang = new HashSet<TChiTietDonHang>();
            TChiTietNhapHang = new HashSet<TChiTietNhapHang>();
            TTonKho = new HashSet<TTonKho>();
        }

        public int Ma { get; set; }
        public int MaLoai { get; set; }
        public string TenMatHang { get; set; }
        public int SoKy { get; set; }
        public int SoMet { get; set; }
        public string TenMatHangDayDu { get; set; }
        public string TenMatHangIn { get; set; }
        public int MaGroup { get; set; }

        public virtual ICollection<RCanhBaoTonKho> RCanhBaoTonKho { get; set; }
        public virtual ICollection<RMatHangNguyenLieu> RMatHangNguyenLieu { get; set; }
        public virtual ICollection<TChiTietChuyenKho> TChiTietChuyenKho { get; set; }
        public virtual ICollection<TChiTietDonHang> TChiTietDonHang { get; set; }
        public virtual ICollection<TChiTietNhapHang> TChiTietNhapHang { get; set; }
        public virtual ICollection<TTonKho> TTonKho { get; set; }
        public virtual RLoaiHang MaLoaiNavigation { get; set; }
    }
}
