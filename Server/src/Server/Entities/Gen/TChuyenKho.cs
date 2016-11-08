using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChuyenKho : huypq.SwaMiddleware.SwaIEntity
    {
        public TChuyenKho()
        {
            TChiTietChuyenKhoMaChuyenKhoNavigation = new HashSet<TChiTietChuyenKho>();
        }

        public int Ma { get; set; }
        public int MaGroup { get; set; }
        public int MaKhoHangNhap { get; set; }
        public int MaKhoHangXuat { get; set; }
        public int MaNhanVien { get; set; }
        public System.DateTime Ngay { get; set; }

        public ICollection<TChiTietChuyenKho> TChiTietChuyenKhoMaChuyenKhoNavigation { get; set; }

        public RKhoHang MaKhoHangNhapNavigation { get; set; }
        public RKhoHang MaKhoHangXuatNavigation { get; set; }
        public RNhanVien MaNhanVienNavigation { get; set; }
    }
}
