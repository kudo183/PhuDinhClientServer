using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RNhanVien
    {
        public RNhanVien()
        {
            TChiPhi = new HashSet<TChiPhi>();
            TChuyenHang = new HashSet<TChuyenHang>();
            TChuyenKho = new HashSet<TChuyenKho>();
            TNhapHang = new HashSet<TNhapHang>();
        }

        public int Ma { get; set; }
        public int MaPhuongTien { get; set; }
        public string TenNhanVien { get; set; }

        public virtual ICollection<TChiPhi> TChiPhi { get; set; }
        public virtual ICollection<TChuyenHang> TChuyenHang { get; set; }
        public virtual ICollection<TChuyenKho> TChuyenKho { get; set; }
        public virtual ICollection<TNhapHang> TNhapHang { get; set; }
        public virtual RPhuongTien MaPhuongTienNavigation { get; set; }
    }
}
