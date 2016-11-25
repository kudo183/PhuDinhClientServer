using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TDonHang : huypq.SwaMiddleware.SwaIEntity
    {
        public TDonHang()
        {
            TChiTietDonHangMaDonHangNavigation = new HashSet<TChiTietDonHang>();
            TChuyenHangDonHangMaDonHangNavigation = new HashSet<TChuyenHangDonHang>();
        }

        public int GroupID { get; set; }
        public int Ma { get; set; }
        public int? MaChanh { get; set; }
        public int MaKhachHang { get; set; }
        public int MaKhoHang { get; set; }
        public System.DateTime Ngay { get; set; }
        public int TongSoLuong { get; set; }
        public bool Xong { get; set; }

        public ICollection<TChiTietDonHang> TChiTietDonHangMaDonHangNavigation { get; set; }
        public ICollection<TChuyenHangDonHang> TChuyenHangDonHangMaDonHangNavigation { get; set; }

        public RChanh MaChanhNavigation { get; set; }
        public RKhachHang MaKhachHangNavigation { get; set; }
        public RKhoHang MaKhoHangNavigation { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}
