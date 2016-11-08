using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RNhanVien : huypq.SwaMiddleware.SwaIEntity
    {
        public RNhanVien()
        {
            TChiPhiMaNhanVienGiaoHangNavigation = new HashSet<TChiPhi>();
            TChuyenHangMaNhanVienGiaoHangNavigation = new HashSet<TChuyenHang>();
            TChuyenKhoMaNhanVienNavigation = new HashSet<TChuyenKho>();
            TNhapHangMaNhanVienNavigation = new HashSet<TNhapHang>();
        }

        public int Ma { get; set; }
        public int MaGroup { get; set; }
        public int MaPhuongTien { get; set; }
        public string TenNhanVien { get; set; }

        public ICollection<TChiPhi> TChiPhiMaNhanVienGiaoHangNavigation { get; set; }
        public ICollection<TChuyenHang> TChuyenHangMaNhanVienGiaoHangNavigation { get; set; }
        public ICollection<TChuyenKho> TChuyenKhoMaNhanVienNavigation { get; set; }
        public ICollection<TNhapHang> TNhapHangMaNhanVienNavigation { get; set; }

        public RPhuongTien MaPhuongTienNavigation { get; set; }
    }
}
