using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RNguyenLieu : huypq.SwaMiddleware.SwaIEntity
    {
        public RNguyenLieu()
        {
            RMatHangNguyenLieuMaNguyenLieuNavigation = new HashSet<RMatHangNguyenLieu>();
            TNhapNguyenLieuMaNguyenLieuNavigation = new HashSet<TNhapNguyenLieu>();
        }

        public int DuongKinh { get; set; }
        public int GroupID { get; set; }
        public int Ma { get; set; }
        public int MaLoaiNguyenLieu { get; set; }

        public ICollection<RMatHangNguyenLieu> RMatHangNguyenLieuMaNguyenLieuNavigation { get; set; }
        public ICollection<TNhapNguyenLieu> TNhapNguyenLieuMaNguyenLieuNavigation { get; set; }

        public RLoaiNguyenLieu MaLoaiNguyenLieuNavigation { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}
