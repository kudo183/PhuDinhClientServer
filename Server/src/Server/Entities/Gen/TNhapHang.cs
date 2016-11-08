﻿using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TNhapHang : huypq.SwaMiddleware.SwaIEntity
    {
        public TNhapHang()
        {
            TChiTietNhapHangMaNhapHangNavigation = new HashSet<TChiTietNhapHang>();
        }

        public int Ma { get; set; }
        public int MaGroup { get; set; }
        public int MaKhoHang { get; set; }
        public int MaNhaCungCap { get; set; }
        public int MaNhanVien { get; set; }
        public System.DateTime Ngay { get; set; }

        public ICollection<TChiTietNhapHang> TChiTietNhapHangMaNhapHangNavigation { get; set; }

        public RKhoHang MaKhoHangNavigation { get; set; }
        public RNhaCungCap MaNhaCungCapNavigation { get; set; }
        public RNhanVien MaNhanVienNavigation { get; set; }
    }
}
