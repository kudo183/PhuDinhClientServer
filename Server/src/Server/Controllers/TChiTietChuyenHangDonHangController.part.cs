using huypq.SwaMiddleware;
using Server.Entities;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    public partial class TChiTietChuyenHangDonHangController : SwaEntityBaseController<PhuDinhServerContext, TChiTietChuyenHangDonHang, TChiTietChuyenHangDonHangDto>
    {
        partial void ConvertToDtoPartial(ref TChiTietChuyenHangDonHangDto dto, TChiTietChuyenHangDonHang entity)
        {
            dto.TChuyenHangDonHang = new TChuyenHangDonHangDto();
            dto.TChuyenHangDonHang.TChuyenHang = new TChuyenHangDto();
            dto.TChuyenHangDonHang.TChuyenHang.MaNhanVienGiaoHang = entity.MaChuyenHangDonHangNavigation.MaChuyenHangNavigation.MaNhanVienGiaoHang;
            dto.TChuyenHangDonHang.TChuyenHang.Ngay = entity.MaChuyenHangDonHangNavigation.MaChuyenHangNavigation.Ngay;
            dto.TChuyenHangDonHang.TChuyenHang.Gio = entity.MaChuyenHangDonHangNavigation.MaChuyenHangNavigation.Gio;
            dto.TChuyenHangDonHang.TDonHang = new TDonHangDto();
            dto.TChuyenHangDonHang.TDonHang.MaKhachHang = entity.MaChuyenHangDonHangNavigation.MaDonHangNavigation.MaKhachHang;
            dto.TChuyenHangDonHang.TDonHang.MaKhoHang = entity.MaChuyenHangDonHangNavigation.MaDonHangNavigation.MaKhoHang;
            dto.TChuyenHangDonHang.TDonHang.Ngay = entity.MaChuyenHangDonHangNavigation.MaDonHangNavigation.Ngay;
            dto.TChiTietDonHang = new TChiTietDonHangDto();
            dto.TChiTietDonHang.ID = entity.MaChiTietDonHangNavigation.ID;
            dto.TChiTietDonHang.MaMatHang = entity.MaChiTietDonHangNavigation.MaMatHang;
            dto.TChiTietDonHang.Xong = entity.MaChiTietDonHangNavigation.Xong;
            dto.TChiTietDonHang.TDonHang = new TDonHangDto();
            dto.TChiTietDonHang.TDonHang.MaKhachHang = entity.MaChiTietDonHangNavigation.MaDonHangNavigation.MaKhachHang;
            dto.TChiTietDonHang.TDonHang.MaKhoHang = entity.MaChiTietDonHangNavigation.MaDonHangNavigation.MaKhoHang;
            dto.TChiTietDonHang.TDonHang.Ngay = entity.MaChiTietDonHangNavigation.MaDonHangNavigation.Ngay;
        }

        protected override IQueryable<TChiTietChuyenHangDonHang> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.MaChuyenHangDonHangNavigation.MaChuyenHangNavigation)
                .Include(p => p.MaChuyenHangDonHangNavigation.MaDonHangNavigation)
                .Include(p => p.MaChiTietDonHangNavigation.MaDonHangNavigation)
                .Include(p => p.MaChiTietDonHangNavigation.MaMatHangNavigation);
        }

        protected override void AfterSave()
        {
            //because sql trigger updated TongSoLuongThucTe of TChuyenHang
            TChuyenHangController.IncreaseVersionNumber();
            //because sql trigger updated TongSoLuongThucTe of TChuyenHangDonHang
            TChuyenHangDonHangController.IncreaseVersionNumber();
            //because sql trigger updated Xong of TChiTietDonHang
            TChiTietDonHangController.IncreaseVersionNumber();
            //because sql trigger updated Xong of TDonHang
            TDonHangController.IncreaseVersionNumber();
        }

        protected override void UpdateEntity(PhuDinhServerContext context, TChiTietChuyenHangDonHang entity)
        {
            var entry = context.TChiTietChuyenHangDonHang.Attach(entity);
            entry.Property(p => p.MaChiTietDonHang).IsModified = true;
            entry.Property(p => p.SoLuong).IsModified = true;
        }
    }
}
