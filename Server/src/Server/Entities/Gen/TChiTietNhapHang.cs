using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChiTietNhapHang : huypq.SwaMiddleware.SwaIEntity
    {
        public TChiTietNhapHang()
        {
        }

        public int Ma { get; set; }
        public int MaGroup { get; set; }
        public int MaMatHang { get; set; }
        public int MaNhapHang { get; set; }
        public int SoLuong { get; set; }


        public TMatHang MaMatHangNavigation { get; set; }
        public TNhapHang MaNhapHangNavigation { get; set; }
    }
}
