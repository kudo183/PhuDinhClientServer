using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RLoaiNguyenLieu
    {
        public RLoaiNguyenLieu()
        {
            RNguyenLieu = new HashSet<RNguyenLieu>();
        }

        public int Ma { get; set; }
        public string TenLoai { get; set; }
        public int MaGroup { get; set; }

        public virtual ICollection<RNguyenLieu> RNguyenLieu { get; set; }
    }
}
