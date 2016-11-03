using huypq.SwaMiddleware;
using Server.Entities;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    public partial class TChiTietNhapHangController : SwaEntityBaseController<PhuDinhServerContext, TChiTietNhapHang, TChiTietNhapHangDto>
    {
        partial void ConvertToDtoPartial(ref TChiTietNhapHangDto dto, TChiTietNhapHang entity)
        {
            dto.TNhapHang = new TNhapHangDto();
            dto.TNhapHang.MaKhoHang = entity.MaNhapHangNavigation.MaKhoHang;
            dto.TNhapHang.MaNhaCungCap = entity.MaNhapHangNavigation.MaNhaCungCap;
            dto.TNhapHang.Ngay = entity.MaNhapHangNavigation.Ngay;
        }

        protected override IQueryable<TChiTietNhapHang> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.MaNhapHangNavigation);
        }
    }
}
