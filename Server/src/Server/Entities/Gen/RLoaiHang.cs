using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RLoaiHang : huypq.SwaMiddleware.SwaIEntity
    {
        public RLoaiHang()
        {
            TMatHangMaLoaiNavigation = new HashSet<TMatHang>();
        }

        public bool HangNhaLam { get; set; }
        public int Ma { get; set; }
        public int MaGroup { get; set; }
        public string TenLoai { get; set; }

        public ICollection<TMatHang> TMatHangMaLoaiNavigation { get; set; }

    }
}
