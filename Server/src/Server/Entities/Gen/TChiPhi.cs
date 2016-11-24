using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChiPhi : huypq.SwaMiddleware.SwaIEntity
    {
        public TChiPhi()
        {
        }

        public string GhiChu { get; set; }
        public int GroupID { get; set; }
        public int ID { get; set; }
        public int MaLoaiChiPhi { get; set; }
        public int MaNhanVienGiaoHang { get; set; }
        public System.DateTime Ngay { get; set; }
        public int SoTien { get; set; }


        public RLoaiChiPhi MaLoaiChiPhiNavigation { get; set; }
        public RNhanVien MaNhanVienGiaoHangNavigation { get; set; }
    }
}
