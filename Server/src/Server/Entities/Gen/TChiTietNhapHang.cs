using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChiTietNhapHang : huypq.SwaMiddleware.SwaIEntity
    {
        public TChiTietNhapHang()
        {
        }

        public int GroupID { get; set; }
        public int ID { get; set; }
        public int MaMatHang { get; set; }
        public int MaNhapHang { get; set; }
        public int SoLuong { get; set; }


        public TMatHang MaMatHangNavigation { get; set; }
        public TNhapHang MaNhapHangNavigation { get; set; }
    }
}
