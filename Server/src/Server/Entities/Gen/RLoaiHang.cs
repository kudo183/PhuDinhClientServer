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

        public int GroupID { get; set; }
        public bool HangNhaLam { get; set; }
        public int ID { get; set; }
        public string TenLoai { get; set; }

        public ICollection<TMatHang> TMatHangMaLoaiNavigation { get; set; }

    }
}
