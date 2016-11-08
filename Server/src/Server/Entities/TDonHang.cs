using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TDonHang
    {
        public TDonHang()
        {
            TChiTietDonHang = new HashSet<TChiTietDonHang>();
            TChuyenHangDonHang = new HashSet<TChuyenHangDonHang>();
        }

        public int Ma { get; set; }
        public int MaKhachHang { get; set; }
        public int? MaChanh { get; set; }
        public DateTime Ngay { get; set; }
        public bool Xong { get; set; }
        public int MaKhoHang { get; set; }
        public int TongSoLuong { get; set; }
        public int MaGroup { get; set; }

        public virtual ICollection<TChiTietDonHang> TChiTietDonHang { get; set; }
        public virtual ICollection<TChuyenHangDonHang> TChuyenHangDonHang { get; set; }
        public virtual RChanh MaChanhNavigation { get; set; }
        public virtual RKhachHang MaKhachHangNavigation { get; set; }
        public virtual RKhoHang MaKhoHangNavigation { get; set; }
    }
}
