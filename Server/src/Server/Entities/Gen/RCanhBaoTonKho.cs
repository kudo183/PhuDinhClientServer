using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RCanhBaoTonKho
    {
        public int Ma { get; set; }
        public int MaMatHang { get; set; }
        public int MaKhoHang { get; set; }
        public int TonCaoNhat { get; set; }
        public int TonThapNhat { get; set; }
        public int MaGroup { get; set; }

        public virtual RKhoHang MaKhoHangNavigation { get; set; }
        public virtual TMatHang MaMatHangNavigation { get; set; }
    }
}
