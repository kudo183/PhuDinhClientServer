﻿using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TGiamTruKhachHang
    {
        public int Ma { get; set; }
        public string GhiChu { get; set; }
        public int MaKhachHang { get; set; }
        public DateTime Ngay { get; set; }
        public int SoTien { get; set; }

        public virtual RKhachHang MaKhachHangNavigation { get; set; }
    }
}