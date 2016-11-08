using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TNhapHang
    {
        public TNhapHang()
        {
            TChiTietNhapHang = new HashSet<TChiTietNhapHang>();
        }

        public int Ma { get; set; }
        public int MaNhanVien { get; set; }
        public int MaKhoHang { get; set; }
        public int MaNhaCungCap { get; set; }
        public DateTime Ngay { get; set; }
        public int MaGroup { get; set; }

        public virtual ICollection<TChiTietNhapHang> TChiTietNhapHang { get; set; }
        public virtual RKhoHang MaKhoHangNavigation { get; set; }
        public virtual RNhaCungCap MaNhaCungCapNavigation { get; set; }
        public virtual RNhanVien MaNhanVienNavigation { get; set; }
    }
}
