using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RCanhBaoTonKho : huypq.SwaMiddleware.SwaIEntity
    {
        public RCanhBaoTonKho()
        {
        }

        public int GroupID { get; set; }
        public int ID { get; set; }
        public int MaKhoHang { get; set; }
        public int MaMatHang { get; set; }
        public int TonCaoNhat { get; set; }
        public int TonThapNhat { get; set; }


        public RKhoHang MaKhoHangNavigation { get; set; }
        public TMatHang MaMatHangNavigation { get; set; }
    }
}
