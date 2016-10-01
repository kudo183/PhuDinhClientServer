using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RKhachHangChanh
    {
        public int Ma { get; set; }
        public bool LaMacDinh { get; set; }
        public int MaChanh { get; set; }
        public int MaKhachHang { get; set; }

        public virtual RChanh MaChanhNavigation { get; set; }
        public virtual RKhachHang MaKhachHangNavigation { get; set; }
    }
}
