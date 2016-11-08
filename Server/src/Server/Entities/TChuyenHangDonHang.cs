using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChuyenHangDonHang
    {
        public TChuyenHangDonHang()
        {
            TChiTietChuyenHangDonHang = new HashSet<TChiTietChuyenHangDonHang>();
        }

        public int Ma { get; set; }
        public int MaChuyenHang { get; set; }
        public int MaDonHang { get; set; }
        public int TongSoLuongTheoDonHang { get; set; }
        public int TongSoLuongThucTe { get; set; }
        public int MaGroup { get; set; }

        public virtual ICollection<TChiTietChuyenHangDonHang> TChiTietChuyenHangDonHang { get; set; }
        public virtual TChuyenHang MaChuyenHangNavigation { get; set; }
        public virtual TDonHang MaDonHangNavigation { get; set; }
    }
}
