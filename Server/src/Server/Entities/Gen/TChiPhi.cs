using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChiPhi
    {
        public int Ma { get; set; }
        public int MaNhanVienGiaoHang { get; set; }
        public int MaLoaiChiPhi { get; set; }
        public int SoTien { get; set; }
        public DateTime Ngay { get; set; }
        public string GhiChu { get; set; }
        public int MaGroup { get; set; }

        public virtual RLoaiChiPhi MaLoaiChiPhiNavigation { get; set; }
        public virtual RNhanVien MaNhanVienGiaoHangNavigation { get; set; }
    }
}
