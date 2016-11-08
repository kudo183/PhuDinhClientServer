using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TPhuThuKhachHang : huypq.SwaMiddleware.SwaIEntity
    {
        public TPhuThuKhachHang()
        {
        }

        public string GhiChu { get; set; }
        public int Ma { get; set; }
        public int MaGroup { get; set; }
        public int MaKhachHang { get; set; }
        public System.DateTime Ngay { get; set; }
        public int SoTien { get; set; }


        public RKhachHang MaKhachHangNavigation { get; set; }
    }
}
