﻿using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TTonKho : huypq.SwaMiddleware.SwaIEntity
    {
        public TTonKho()
        {
        }

        public int Ma { get; set; }
        public int MaGroup { get; set; }
        public int MaKhoHang { get; set; }
        public int MaMatHang { get; set; }
        public System.DateTime Ngay { get; set; }
        public int SoLuong { get; set; }
        public int SoLuongCu { get; set; }


        public RKhoHang MaKhoHangNavigation { get; set; }
        public TMatHang MaMatHangNavigation { get; set; }
    }
}
