using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChiTietChuyenHangDonHang
    {
        public int Ma { get; set; }
        public int MaChuyenHangDonHang { get; set; }
        public int MaChiTietDonHang { get; set; }
        public int SoLuong { get; set; }
        public int SoLuongTheoDonHang { get; set; }
        public int MaGroup { get; set; }

        public virtual TChiTietDonHang MaChiTietDonHangNavigation { get; set; }
        public virtual TChuyenHangDonHang MaChuyenHangDonHangNavigation { get; set; }
    }
}
