using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChuyenHang
    {
        public TChuyenHang()
        {
            TChuyenHangDonHang = new HashSet<TChuyenHangDonHang>();
        }

        public int Ma { get; set; }
        public TimeSpan? Gio { get; set; }
        public int MaNhanVienGiaoHang { get; set; }
        public DateTime Ngay { get; set; }
        public int TongDonHang { get; set; }
        public int TongSoLuongTheoDonHang { get; set; }
        public int TongSoLuongThucTe { get; set; }

        public virtual ICollection<TChuyenHangDonHang> TChuyenHangDonHang { get; set; }
        public virtual RNhanVien MaNhanVienGiaoHangNavigation { get; set; }
    }
}
