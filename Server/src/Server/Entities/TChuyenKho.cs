using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChuyenKho
    {
        public TChuyenKho()
        {
            TChiTietChuyenKho = new HashSet<TChiTietChuyenKho>();
        }

        public int Ma { get; set; }
        public int MaKhoHangNhap { get; set; }
        public int MaKhoHangXuat { get; set; }
        public int MaNhanVien { get; set; }
        public DateTime Ngay { get; set; }

        public virtual ICollection<TChiTietChuyenKho> TChiTietChuyenKho { get; set; }
        public virtual RKhoHang MaKhoHangNhapNavigation { get; set; }
        public virtual RKhoHang MaKhoHangXuatNavigation { get; set; }
        public virtual RNhanVien MaNhanVienNavigation { get; set; }
    }
}
