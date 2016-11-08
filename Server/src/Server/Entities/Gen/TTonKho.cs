using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TTonKho
    {
        public int Ma { get; set; }
        public int MaKhoHang { get; set; }
        public int MaMatHang { get; set; }
        public DateTime Ngay { get; set; }
        public int SoLuong { get; set; }
        public int SoLuongCu { get; set; }
        public int MaGroup { get; set; }

        public virtual RKhoHang MaKhoHangNavigation { get; set; }
        public virtual TMatHang MaMatHangNavigation { get; set; }
    }
}
