using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChiTietToaHang : huypq.SwaMiddleware.SwaIEntity
    {
        public TChiTietToaHang()
        {
        }

        public int GiaTien { get; set; }
        public int Ma { get; set; }
        public int MaChiTietDonHang { get; set; }
        public int MaGroup { get; set; }
        public int MaToaHang { get; set; }


        public TChiTietDonHang MaChiTietDonHangNavigation { get; set; }
        public TToaHang MaToaHangNavigation { get; set; }
    }
}
