using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChiTietDonHang : huypq.SwaMiddleware.SwaIEntity
    {
        public TChiTietDonHang()
        {
            TChiTietChuyenHangDonHangMaChiTietDonHangNavigation = new HashSet<TChiTietChuyenHangDonHang>();
            TChiTietToaHangMaChiTietDonHangNavigation = new HashSet<TChiTietToaHang>();
        }

        public int Ma { get; set; }
        public int MaDonHang { get; set; }
        public int MaGroup { get; set; }
        public int MaMatHang { get; set; }
        public int SoLuong { get; set; }
        public bool Xong { get; set; }

        public ICollection<TChiTietChuyenHangDonHang> TChiTietChuyenHangDonHangMaChiTietDonHangNavigation { get; set; }
        public ICollection<TChiTietToaHang> TChiTietToaHangMaChiTietDonHangNavigation { get; set; }

        public TDonHang MaDonHangNavigation { get; set; }
        public TMatHang MaMatHangNavigation { get; set; }
    }
}
