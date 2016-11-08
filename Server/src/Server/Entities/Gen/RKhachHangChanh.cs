using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RKhachHangChanh : huypq.SwaMiddleware.SwaIEntity
    {
        public RKhachHangChanh()
        {
        }

        public bool LaMacDinh { get; set; }
        public int Ma { get; set; }
        public int MaChanh { get; set; }
        public int MaGroup { get; set; }
        public int MaKhachHang { get; set; }


        public RChanh MaChanhNavigation { get; set; }
        public RKhachHang MaKhachHangNavigation { get; set; }
    }
}
