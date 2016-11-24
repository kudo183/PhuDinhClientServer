using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChuyenHang : huypq.SwaMiddleware.SwaIEntity
    {
        public TChuyenHang()
        {
            TChuyenHangDonHangMaChuyenHangNavigation = new HashSet<TChuyenHangDonHang>();
        }

        public System.TimeSpan? Gio { get; set; }
        public int GroupID { get; set; }
        public int ID { get; set; }
        public int MaNhanVienGiaoHang { get; set; }
        public System.DateTime Ngay { get; set; }
        public int TongDonHang { get; set; }
        public int TongSoLuongTheoDonHang { get; set; }
        public int TongSoLuongThucTe { get; set; }

        public ICollection<TChuyenHangDonHang> TChuyenHangDonHangMaChuyenHangNavigation { get; set; }

        public RNhanVien MaNhanVienGiaoHangNavigation { get; set; }
    }
}
