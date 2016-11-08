using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RKhoHang
    {
        public RKhoHang()
        {
            RCanhBaoTonKho = new HashSet<RCanhBaoTonKho>();
            TChuyenKhoMaKhoHangNhapNavigation = new HashSet<TChuyenKho>();
            TChuyenKhoMaKhoHangXuatNavigation = new HashSet<TChuyenKho>();
            TDonHang = new HashSet<TDonHang>();
            TNhapHang = new HashSet<TNhapHang>();
            TTonKho = new HashSet<TTonKho>();
        }

        public int Ma { get; set; }
        public string TenKho { get; set; }
        public bool TrangThai { get; set; }
        public int MaGroup { get; set; }

        public virtual ICollection<RCanhBaoTonKho> RCanhBaoTonKho { get; set; }
        public virtual ICollection<TChuyenKho> TChuyenKhoMaKhoHangNhapNavigation { get; set; }
        public virtual ICollection<TChuyenKho> TChuyenKhoMaKhoHangXuatNavigation { get; set; }
        public virtual ICollection<TDonHang> TDonHang { get; set; }
        public virtual ICollection<TNhapHang> TNhapHang { get; set; }
        public virtual ICollection<TTonKho> TTonKho { get; set; }
    }
}
