using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RNhaCungCap : huypq.SwaMiddleware.SwaIEntity
    {
        public RNhaCungCap()
        {
            TNhapHangMaNhaCungCapNavigation = new HashSet<TNhapHang>();
            TNhapNguyenLieuMaNhaCungCapNavigation = new HashSet<TNhapNguyenLieu>();
        }

        public int Ma { get; set; }
        public int MaGroup { get; set; }
        public string TenNhaCungCap { get; set; }

        public ICollection<TNhapHang> TNhapHangMaNhaCungCapNavigation { get; set; }
        public ICollection<TNhapNguyenLieu> TNhapNguyenLieuMaNhaCungCapNavigation { get; set; }

    }
}
