using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TNhapNguyenLieu
    {
        public int Ma { get; set; }
        public int MaNguyenLieu { get; set; }
        public int MaNhaCungCap { get; set; }
        public DateTime Ngay { get; set; }
        public int SoLuong { get; set; }

        public virtual RNguyenLieu MaNguyenLieuNavigation { get; set; }
        public virtual RNhaCungCap MaNhaCungCapNavigation { get; set; }
    }
}
