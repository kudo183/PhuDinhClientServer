using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChiTietChuyenHangDonHang : huypq.SwaMiddleware.SwaIEntity
    {
        public TChiTietChuyenHangDonHang()
        {
        }

        public int GroupID { get; set; }
        public int ID { get; set; }
        public int MaChiTietDonHang { get; set; }
        public int MaChuyenHangDonHang { get; set; }
        public int SoLuong { get; set; }
        public int SoLuongTheoDonHang { get; set; }


        public TChiTietDonHang MaChiTietDonHangNavigation { get; set; }
        public TChuyenHangDonHang MaChuyenHangDonHangNavigation { get; set; }
    }
}
