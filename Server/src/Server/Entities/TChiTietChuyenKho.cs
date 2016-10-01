using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChiTietChuyenKho
    {
        public int Ma { get; set; }
        public int MaChuyenKho { get; set; }
        public int MaMatHang { get; set; }
        public int SoLuong { get; set; }

        public virtual TChuyenKho MaChuyenKhoNavigation { get; set; }
        public virtual TMatHang MaMatHangNavigation { get; set; }
    }
}
