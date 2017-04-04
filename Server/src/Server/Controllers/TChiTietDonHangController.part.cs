using huypq.SwaMiddleware;
using Server.Entities;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    public partial class TChiTietDonHangController : SwaEntityBaseController<PhuDinhServerContext, TChiTietDonHang, TChiTietDonHangDto>
    {
        partial void ConvertToDtoPartial(ref TChiTietDonHangDto dto, TChiTietDonHang entity)
        {
            dto.TDonHang = new TDonHangDto();
            dto.TDonHang.MaKhoHang = entity.MaDonHangNavigation.MaKhoHang;
            dto.TDonHang.MaKhachHang = entity.MaDonHangNavigation.MaKhachHang;
            dto.TDonHang.Ngay = entity.MaDonHangNavigation.Ngay;
            dto.SoLuongConLai = entity.SoLuong - entity.TChiTietChuyenHangDonHangMaChiTietDonHangNavigation.Sum(p => p.SoLuong);
        }

        protected override IQueryable<TChiTietDonHang> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.MaDonHangNavigation)
                .Include(p => p.TChiTietChuyenHangDonHangMaChiTietDonHangNavigation);
        }
        
        protected override void UpdateEntity(PhuDinhServerContext context, TChiTietDonHang entity)
        {
            var entry = context.TChiTietDonHang.Attach(entity);
            entry.Property(p => p.MaMatHang).IsModified = true;
            entry.Property(p => p.SoLuong).IsModified = true;
        }
    }
}
