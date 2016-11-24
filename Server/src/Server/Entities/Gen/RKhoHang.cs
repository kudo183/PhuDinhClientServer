using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RKhoHang : huypq.SwaMiddleware.SwaIEntity
    {
        public RKhoHang()
        {
            RCanhBaoTonKhoMaKhoHangNavigation = new HashSet<RCanhBaoTonKho>();
            TChuyenKhoMaKhoHangNhapNavigation = new HashSet<TChuyenKho>();
            TChuyenKhoMaKhoHangXuatNavigation = new HashSet<TChuyenKho>();
            TDonHangMaKhoHangNavigation = new HashSet<TDonHang>();
            TNhapHangMaKhoHangNavigation = new HashSet<TNhapHang>();
            TTonKhoMaKhoHangNavigation = new HashSet<TTonKho>();
        }

        public int GroupID { get; set; }
        public int ID { get; set; }
        public string TenKho { get; set; }
        public bool TrangThai { get; set; }

        public ICollection<RCanhBaoTonKho> RCanhBaoTonKhoMaKhoHangNavigation { get; set; }
        public ICollection<TChuyenKho> TChuyenKhoMaKhoHangNhapNavigation { get; set; }
        public ICollection<TChuyenKho> TChuyenKhoMaKhoHangXuatNavigation { get; set; }
        public ICollection<TDonHang> TDonHangMaKhoHangNavigation { get; set; }
        public ICollection<TNhapHang> TNhapHangMaKhoHangNavigation { get; set; }
        public ICollection<TTonKho> TTonKhoMaKhoHangNavigation { get; set; }

    }
}
