using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TCongNoKhachHang
    {
        public int Ma { get; set; }
        public int MaKhachHang { get; set; }
        public DateTime Ngay { get; set; }
        public int SoTien { get; set; }
        public int MaGroup { get; set; }

        public virtual RKhachHang MaKhachHangNavigation { get; set; }
    }
}
