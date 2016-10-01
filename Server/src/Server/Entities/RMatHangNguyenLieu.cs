using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RMatHangNguyenLieu
    {
        public int Ma { get; set; }
        public int MaMatHang { get; set; }
        public int MaNguyenLieu { get; set; }

        public virtual TMatHang MaMatHangNavigation { get; set; }
        public virtual RNguyenLieu MaNguyenLieuNavigation { get; set; }
    }
}
