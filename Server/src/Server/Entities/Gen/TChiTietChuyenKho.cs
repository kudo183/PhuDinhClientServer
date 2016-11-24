using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChiTietChuyenKho : huypq.SwaMiddleware.SwaIEntity
    {
        public TChiTietChuyenKho()
        {
        }

        public int GroupID { get; set; }
        public int ID { get; set; }
        public int MaChuyenKho { get; set; }
        public int MaMatHang { get; set; }
        public int SoLuong { get; set; }


        public TChuyenKho MaChuyenKhoNavigation { get; set; }
        public TMatHang MaMatHangNavigation { get; set; }
    }
}
