using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RKhachHang
    {
        public RKhachHang()
        {
            RKhachHangChanh = new HashSet<RKhachHangChanh>();
            TCongNoKhachHang = new HashSet<TCongNoKhachHang>();
            TDonHang = new HashSet<TDonHang>();
            TGiamTruKhachHang = new HashSet<TGiamTruKhachHang>();
            TNhanTienKhachHang = new HashSet<TNhanTienKhachHang>();
            TPhuThuKhachHang = new HashSet<TPhuThuKhachHang>();
            TToaHang = new HashSet<TToaHang>();
        }

        public int Ma { get; set; }
        public int MaDiaDiem { get; set; }
        public string TenKhachHang { get; set; }
        public bool KhachRieng { get; set; }
        public int MaGroup { get; set; }

        public virtual ICollection<RKhachHangChanh> RKhachHangChanh { get; set; }
        public virtual ICollection<TCongNoKhachHang> TCongNoKhachHang { get; set; }
        public virtual ICollection<TDonHang> TDonHang { get; set; }
        public virtual ICollection<TGiamTruKhachHang> TGiamTruKhachHang { get; set; }
        public virtual ICollection<TNhanTienKhachHang> TNhanTienKhachHang { get; set; }
        public virtual ICollection<TPhuThuKhachHang> TPhuThuKhachHang { get; set; }
        public virtual ICollection<TToaHang> TToaHang { get; set; }
        public virtual RDiaDiem MaDiaDiemNavigation { get; set; }
    }
}
