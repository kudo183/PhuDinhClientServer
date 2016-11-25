using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChuyenHangDonHang : huypq.SwaMiddleware.SwaIEntity
    {
        public TChuyenHangDonHang()
        {
            TChiTietChuyenHangDonHangMaChuyenHangDonHangNavigation = new HashSet<TChiTietChuyenHangDonHang>();
        }

        public int GroupID { get; set; }
        public int Ma { get; set; }
        public int MaChuyenHang { get; set; }
        public int MaDonHang { get; set; }
        public int TongSoLuongTheoDonHang { get; set; }
        public int TongSoLuongThucTe { get; set; }

        public ICollection<TChiTietChuyenHangDonHang> TChiTietChuyenHangDonHangMaChuyenHangDonHangNavigation { get; set; }

        public TChuyenHang MaChuyenHangNavigation { get; set; }
        public TDonHang MaDonHangNavigation { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}
