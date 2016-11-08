using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RNhaCungCap
    {
        public RNhaCungCap()
        {
            TNhapHang = new HashSet<TNhapHang>();
            TNhapNguyenLieu = new HashSet<TNhapNguyenLieu>();
        }

        public int Ma { get; set; }
        public string TenNhaCungCap { get; set; }
        public int MaGroup { get; set; }

        public virtual ICollection<TNhapHang> TNhapHang { get; set; }
        public virtual ICollection<TNhapNguyenLieu> TNhapNguyenLieu { get; set; }
    }
}
