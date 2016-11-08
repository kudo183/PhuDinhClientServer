using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RNguyenLieu
    {
        public RNguyenLieu()
        {
            RMatHangNguyenLieu = new HashSet<RMatHangNguyenLieu>();
            TNhapNguyenLieu = new HashSet<TNhapNguyenLieu>();
        }

        public int Ma { get; set; }
        public int MaLoaiNguyenLieu { get; set; }
        public int DuongKinh { get; set; }
        public int MaGroup { get; set; }

        public virtual ICollection<RMatHangNguyenLieu> RMatHangNguyenLieu { get; set; }
        public virtual ICollection<TNhapNguyenLieu> TNhapNguyenLieu { get; set; }
        public virtual RLoaiNguyenLieu MaLoaiNguyenLieuNavigation { get; set; }
    }
}
