using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RLoaiHang
    {
        public RLoaiHang()
        {
            TMatHang = new HashSet<TMatHang>();
        }

        public int Ma { get; set; }
        public bool HangNhaLam { get; set; }
        public string TenLoai { get; set; }

        public virtual ICollection<TMatHang> TMatHang { get; set; }
    }
}
