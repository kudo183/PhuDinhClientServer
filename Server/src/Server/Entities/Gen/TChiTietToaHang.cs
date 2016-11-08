using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChiTietToaHang
    {
        public int Ma { get; set; }
        public int MaToaHang { get; set; }
        public int MaChiTietDonHang { get; set; }
        public int GiaTien { get; set; }
        public int MaGroup { get; set; }

        public virtual TChiTietDonHang MaChiTietDonHangNavigation { get; set; }
        public virtual TToaHang MaToaHangNavigation { get; set; }
    }
}
