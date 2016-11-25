using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RKhachHang : huypq.SwaMiddleware.SwaIEntity
    {
        public RKhachHang()
        {
            RKhachHangChanhMaKhachHangNavigation = new HashSet<RKhachHangChanh>();
            TCongNoKhachHangMaKhachHangNavigation = new HashSet<TCongNoKhachHang>();
            TDonHangMaKhachHangNavigation = new HashSet<TDonHang>();
            TGiamTruKhachHangMaKhachHangNavigation = new HashSet<TGiamTruKhachHang>();
            TNhanTienKhachHangMaKhachHangNavigation = new HashSet<TNhanTienKhachHang>();
            TPhuThuKhachHangMaKhachHangNavigation = new HashSet<TPhuThuKhachHang>();
            TToaHangMaKhachHangNavigation = new HashSet<TToaHang>();
        }

        public int GroupID { get; set; }
        public bool KhachRieng { get; set; }
        public int Ma { get; set; }
        public int MaDiaDiem { get; set; }
        public string TenKhachHang { get; set; }

        public ICollection<RKhachHangChanh> RKhachHangChanhMaKhachHangNavigation { get; set; }
        public ICollection<TCongNoKhachHang> TCongNoKhachHangMaKhachHangNavigation { get; set; }
        public ICollection<TDonHang> TDonHangMaKhachHangNavigation { get; set; }
        public ICollection<TGiamTruKhachHang> TGiamTruKhachHangMaKhachHangNavigation { get; set; }
        public ICollection<TNhanTienKhachHang> TNhanTienKhachHangMaKhachHangNavigation { get; set; }
        public ICollection<TPhuThuKhachHang> TPhuThuKhachHangMaKhachHangNavigation { get; set; }
        public ICollection<TToaHang> TToaHangMaKhachHangNavigation { get; set; }

        public RDiaDiem MaDiaDiemNavigation { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}
