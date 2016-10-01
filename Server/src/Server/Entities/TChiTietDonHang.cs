using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChiTietDonHang
    {
        public TChiTietDonHang()
        {
            TChiTietChuyenHangDonHang = new HashSet<TChiTietChuyenHangDonHang>();
            TChiTietToaHang = new HashSet<TChiTietToaHang>();
        }

        public int Ma { get; set; }
        public int MaDonHang { get; set; }
        public int MaMatHang { get; set; }
        public int SoLuong { get; set; }
        public bool Xong { get; set; }

        public virtual ICollection<TChiTietChuyenHangDonHang> TChiTietChuyenHangDonHang { get; set; }
        public virtual ICollection<TChiTietToaHang> TChiTietToaHang { get; set; }
        public virtual TDonHang MaDonHangNavigation { get; set; }
        public virtual TMatHang MaMatHangNavigation { get; set; }
    }
}
