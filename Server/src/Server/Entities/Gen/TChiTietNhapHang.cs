using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChiTietNhapHang
    {
        public int Ma { get; set; }
        public int MaNhapHang { get; set; }
        public int MaMatHang { get; set; }
        public int SoLuong { get; set; }
        public int MaGroup { get; set; }

        public virtual TMatHang MaMatHangNavigation { get; set; }
        public virtual TNhapHang MaNhapHangNavigation { get; set; }
    }
}
